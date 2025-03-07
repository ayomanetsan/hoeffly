import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { FriendResponse, InvitationStatus } from '../ui/friends';

@Injectable({
  providedIn: 'root'
})
export class FriendsHubService {

  private hubConnection!: HubConnection;
  private friendRequestReceived = new Subject<FriendResponse>();
  private friendRequestStatusReceived = new Subject<{ friendshipId: string, status: InvitationStatus }>();
  private friendRequestDeleteReceived = new Subject<string>();

  friendRequestReceived$ = this.friendRequestReceived.asObservable();
  friendRequestStatusReceived$ = this.friendRequestStatusReceived.asObservable();
  friendRequestDeleteReceived$ = this.friendRequestDeleteReceived.asObservable();

  constructor(private afAuth: AngularFireAuth) { }

  startConnection(): void {
    this.afAuth.idToken.subscribe(token => {
      this.hubConnection = new HubConnectionBuilder()
        .withUrl(`https://localhost:8080/friendsHub`, {
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

  private addMessageListener = () => {
    this.hubConnection.on('ReceiveFriendRequest', (friendshipId: string, senderName: string, senderEmail: string) => {
      const friend: FriendResponse = {
        id: friendshipId,
        name: senderName,
        status: InvitationStatus.Pending,
        email: senderEmail,
        isSender: false
      };

      this.friendRequestReceived.next(friend);
    });

    this.hubConnection.on('ReceiveFriendRequestStatus', (friendshipId: string, status: InvitationStatus) => {
      this.friendRequestStatusReceived.next({ friendshipId, status });
    });

    this.hubConnection.on('ReceiveFriendRequestDelete', (friendshipId: string) => {
      this.friendRequestDeleteReceived.next(friendshipId);
    });
  }

  sendFriendRequest(receiverEmail: string, friendshipId: string, senderName: string): void {
    this.hubConnection.invoke('SendFriendRequest', receiverEmail, friendshipId, senderName).then();
  }

  manageFriendRequest(receiverEmail: string, friendshipId: string, status: InvitationStatus): void {
    this.hubConnection.invoke('ManageFriendRequest', receiverEmail, friendshipId, status).then();
  }

  deleteFriendRequest(receiverEmail: string, friendshipId: string): void {
    this.hubConnection.invoke('DeleteFriendRequest', receiverEmail, friendshipId).then();
  }
}
