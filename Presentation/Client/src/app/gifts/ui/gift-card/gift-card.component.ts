import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Currency, GiftResponse, ReserveAction, SharedGiftStatus } from '../../models/gift';
import { AccessType } from '../../../wishlists/models/accessRights';

@Component({
  selector: 'app-gift-card',
  templateUrl: './gift-card.component.html',
  styleUrl: './gift-card.component.sass'
})
export class GiftCardComponent implements OnInit {

  @Input({ required: true }) gift!: GiftResponse;
  @Input({ required: true }) accessType!: AccessType;
  @Input({ required: true }) currentUserEmail!: string;
  @Output() deleteGift = new EventEmitter<string>();
  @Output() updateGift = new EventEmitter<GiftResponse>();
  @Output() reserveGift = new EventEmitter<{ giftId: string, reserveAction: ReserveAction }>();

  reservedByCurrentUser!: boolean;
  reservationRequestPending!: boolean;

  ngOnInit(): void {
    this.reservedByCurrentUser = this.gift.sharedGifts.some(sharedGift => sharedGift.userEmail === this.currentUserEmail && sharedGift.status === SharedGiftStatus.Primary);
    this.reservationRequestPending = this.gift.sharedGifts.some(sharedGift => sharedGift.userEmail === this.currentUserEmail && sharedGift.status === SharedGiftStatus.Pending);
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
        break;
      case ReserveAction.CancelReservation:
        this.gift.sharedGifts = this.gift.sharedGifts.filter(sharedGift => sharedGift.userEmail !== this.currentUserEmail);
        this.reservedByCurrentUser = false;
        this.gift.isReserved = this.gift.sharedGifts.length > 1;
        break;
      case ReserveAction.RequestSharedReservation:
        this.reservationRequestPending = true;
        break;
    }

    this.reserveGift.emit({ giftId: this.gift.id, reserveAction: action });
  }

  protected readonly AccessType = AccessType;
  protected readonly ReserveAction = ReserveAction;
}
