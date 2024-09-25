import { Component, Input } from '@angular/core';
import { WishlistBriefResponse } from '../../models/wishlist';

@Component({
  selector: 'app-wishlist-card',
  templateUrl: './wishlist-card.component.html',
  styleUrl: './wishlist-card.component.sass'
})
export class WishlistCardComponent {

  @Input({ required: true }) wishlist!: WishlistBriefResponse;

}
