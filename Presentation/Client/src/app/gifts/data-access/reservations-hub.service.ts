import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReservationsHubService {
  private hubConnection!: HubConnection;
  private giftReservationReceived = new Subject<{ giftId: string, reservedByEmail: string }>();
  private giftReservationCancelReceived = new Subject<{ giftId: string, reservedByEmail: string }>();
  private giftReservationAcceptanceReceived = new Subject<{ giftId: string, reservedByEmail: string }>();

  giftReservationReceived$ = this.giftReservationReceived.asObservable();
  giftReservationCancelReceived$ = this.giftReservationCancelReceived.asObservable();
  giftReservationAcceptanceReceived$ = this.giftReservationAcceptanceReceived.asObservable();

  constructor(private afAuth: AngularFireAuth) { }

  // TODO: create a shared hub service for all SignalR connections
  startConnection(): void {
    this.afAuth.idToken.subscribe(token => {
      this.hubConnection = new HubConnectionBuilder()
        .withUrl(`https://localhost:8080/reservationsHub`, {
          accessTokenFactory: () => { return token ?? '' }
        })
        .build();

      this.hubConnection
        .start()
        .then(() => this.addMessageListener())
        .catch(err => console.log('Error establishing SignalR connection: ' + err));
    });
  }

  stopConnection(): void {
    if (this.hubConnection) {
      this.hubConnection.stop().catch(err => console.log('Error stopping SignalR connection: ' + err));
    }
  }

  reserveGift(giftId: string) {
    this.hubConnection.invoke('ReserveGift', giftId).then().catch(err => console.error(err));
  }

  cancelReservation(giftId: string) {
    this.hubConnection.invoke('CancelReservation', giftId).then().catch(err => console.error(err));
  }

  acceptReservationRequest(giftId: string, reservedByEmail: string) {
    this.hubConnection.invoke('AcceptReservationRequest', giftId, reservedByEmail).then().catch(err => console.error(err));
  }

  private addMessageListener() {
    this.hubConnection.on('ReceiveGiftReservation', (giftId: string, reservedByEmail: string) => {
      this.giftReservationReceived.next({ giftId, reservedByEmail });
    });

    this.hubConnection.on('ReceiveGiftReservationCancel', (giftId: string, reservedByEmail: string) => {
      this.giftReservationCancelReceived.next({ giftId, reservedByEmail });
    });

    this.hubConnection.on('ReceiveGiftReservationAcceptance', (giftId: string, reservedByEmail: string) => {
      this.giftReservationAcceptanceReceived.next({ giftId, reservedByEmail });
    });
  }
}
