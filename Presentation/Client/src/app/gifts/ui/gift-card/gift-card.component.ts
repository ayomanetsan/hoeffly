import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Currency, GiftResponse } from '../../models/gift';
import { AccessType } from '../../../wishlists/models/accessRights';

@Component({
  selector: 'app-gift-card',
  templateUrl: './gift-card.component.html',
  styleUrl: './gift-card.component.sass'
})
export class GiftCardComponent {

  @Input({ required: true }) gift!: GiftResponse;
  @Input({ required: true }) accessType!: AccessType;
  @Output() deleteGift = new EventEmitter<string>();
  @Output() updateGift = new EventEmitter<GiftResponse>();
  @Output() reserveGift = new EventEmitter<{ giftId: string, toBeReserved: boolean }>();

  getCurrencyString(currency: Currency): string {
    return Currency[currency];
  }

  onDelete(): void {
    this.deleteGift.emit(this.gift.id);
  }

  onUpdate(): void {
    this.updateGift.emit(this.gift);
  }

  onReserve(): void {
    this.reserveGift.emit({ giftId: this.gift.id, toBeReserved: !this.gift.isReserved });
    this.gift.isReserved = !this.gift.isReserved;
  }

  protected readonly AccessType = AccessType;
}
