import { Component, EventEmitter, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SharedGiftResponse, SharedGiftStatus } from '../../models/gift';

@Component({
    selector: 'app-reservation-modal',
    templateUrl: './reservation-modal.component.html',
    styleUrl: './reservation-modal.component.sass',
    standalone: false
})
export class ReservationModalComponent implements OnInit {
  acceptReservationSent = new EventEmitter<string>();
  cancelReservationSent = new EventEmitter();
  reservationOwner!: boolean;
  reservedByCurrentUser!: boolean;
  reservationRequestPending!: boolean;

  constructor(private dialogRef: MatDialogRef<ReservationModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { giftName: string, reservations: SharedGiftResponse[], currentUserEmail: string }
  ) { }

  ngOnInit(): void {
    this.reservationOwner = this.data.reservations.some(sharedGift => sharedGift.userEmail === this.data.currentUserEmail && sharedGift.status === SharedGiftStatus.Primary);
    this.reservedByCurrentUser = this.data.reservations.some(sharedGift => sharedGift.userEmail === this.data.currentUserEmail && sharedGift.status === SharedGiftStatus.Accepted);
    this.reservationRequestPending = this.data.reservations.some(sharedGift => sharedGift.userEmail === this.data.currentUserEmail && sharedGift.status === SharedGiftStatus.Pending);
  }

  close() {
    this.dialogRef.close();
  }

  onAcceptReservation(reservation: SharedGiftResponse) {
    reservation.status = SharedGiftStatus.Accepted;
    this.acceptReservationSent.emit(reservation.userEmail);
  }

  onCancelReservation(userEmail: string) {
    this.cancelReservationSent.emit();
    if (!this.reservationOwner || userEmail === this.data.currentUserEmail) {
      this.close();
    }
  }

  protected readonly SharedGiftStatus = SharedGiftStatus;
}
