import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Currency, GiftResponse } from '../../models/gift';

@Component({
  selector: 'app-gift-card',
  templateUrl: './gift-card.component.html',
  styleUrl: './gift-card.component.sass'
})
export class GiftCardComponent {

  @Input({ required: true }) gift!: GiftResponse;
  @Output() deleteGift = new EventEmitter<string>(); 
  @Output() updateGift = new EventEmitter<GiftResponse>(); 

  getCurrencyString(currency: Currency): string {
    return Currency[currency];
  }

  onDelete(): void {
    this.deleteGift.emit(this.gift.id); 
  }

  onUpdate(): void {
    this.updateGift.emit(this.gift); 
  }
}