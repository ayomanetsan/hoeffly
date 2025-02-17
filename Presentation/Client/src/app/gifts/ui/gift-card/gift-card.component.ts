import { Component, Input } from '@angular/core';
import { Currency, GiftResponse } from '../../models/gift';

@Component({
  selector: 'app-gift-card',
  templateUrl: './gift-card.component.html',
  styleUrl: './gift-card.component.sass'
})
export class GiftCardComponent {

  @Input({ required: true }) gift!: GiftResponse;

  getCurrencyString(currency: Currency): string {
    return Currency[currency];
  }

}
