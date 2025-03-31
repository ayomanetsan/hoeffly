import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Currency, GiftResponse, ReserveAction, SharedGiftStatus } from '../../models/gift';
import { AccessType } from '../../../wishlists/models/accessRights';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ReservationModalComponent } from '../reservation-modal/reservation-modal.component';

@Component({
    selector: 'app-gift-card',
    templateUrl: './gift-card.component.html',
    styleUrl: './gift-card.component.sass',
    standalone: false
})
export class GiftCardComponent implements OnInit {

  @Input({ required: true }) gift!: GiftResponse;
  @Input({ required: true }) accessType!: AccessType;
  @Input({ required: true }) currentUserEmail!: string;
  @Input({ required: true }) dialogRef!: MatDialog;
  @Output() deleteGift = new EventEmitter<string>();
  @Output() updateGift = new EventEmitter<GiftResponse>();
  @Output() reserveGift = new EventEmitter<{ giftId: string, reserveAction: ReserveAction }>();
  @Output() joinReservation = new EventEmitter<{ giftId: string, userEmail: string }>();

  reservedByCurrentUser!: boolean;
  reservationRequestPending!: boolean;
  reservationRequestAccepted!: boolean;

  ngOnInit(): void {
    this.reservedByCurrentUser = this.gift.sharedGifts.some(sharedGift => sharedGift.userEmail === this.currentUserEmail && sharedGift.status === SharedGiftStatus.Primary);
    this.reservationRequestPending = this.gift.sharedGifts.some(sharedGift => sharedGift.userEmail === this.currentUserEmail && sharedGift.status === SharedGiftStatus.Pending);
    this.reservationRequestAccepted = this.gift.sharedGifts.some(sharedGift => sharedGift.userEmail === this.currentUserEmail && sharedGift.status === SharedGiftStatus.Accepted);
  }

  getCurrencyString(currency: Currency): string {
    return Currency[currency];
  }

  onDelete(): void {
    this.deleteGift.emit(this.gift.id);
  }

  onUpdate(): void {
    this.updateGift.emit(this.gift);
  }

  onReserve(action: ReserveAction): void {
    switch (action) {
      case ReserveAction.Reserve:
        this.reservedByCurrentUser = true;
        this.gift.isReserved = true;
        this.gift.sharedGifts.push({ userEmail: this.currentUserEmail, status: SharedGiftStatus.Primary });
        break;
      case ReserveAction.CancelReservation:
        this.gift.sharedGifts = this.gift.sharedGifts.filter(sharedGift => sharedGift.userEmail !== this.currentUserEmail);
        this.reservedByCurrentUser = false;
        this.reservationRequestAccepted = false;
        this.gift.isReserved = this.gift.sharedGifts.length > 0;
        break;
      case ReserveAction.RequestSharedReservation:
        this.reservationRequestPending = true;
        break;
    }

    this.reserveGift.emit({ giftId: this.gift.id, reserveAction: action });
  }

  openReservationModal(): void {
    const dialogRef = this.dialogRef.open(ReservationModalComponent, {
      data: { giftName: this.gift.name, reservations: this.gift.sharedGifts, currentUserEmail: this.currentUserEmail },
    });

    // TODO: unsubscribe from the subscription once the modal closes
    dialogRef.componentInstance.acceptReservationSent.subscribe((requesterEmail: string) => {
      this.joinReservation.emit({ giftId: this.gift.id, userEmail: requesterEmail });
    });

    dialogRef.componentInstance.cancelReservationSent.subscribe(() => {
      this.onReserve(ReserveAction.CancelReservation);
    });
  }

  protected readonly AccessType = AccessType;
  protected readonly ReserveAction = ReserveAction;
}
