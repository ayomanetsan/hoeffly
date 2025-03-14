import { NgModule } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { WishlistCardComponent } from './wishlist-card.component';
import { RouterLink } from '@angular/router';
import { WishlistAccessModule } from '../wishlist-access/wishlist-access.module';



@NgModule({
  declarations: [
    WishlistCardComponent
  ],
  exports: [
    WishlistCardComponent
  ],
    imports: [
      CommonModule,
      NgOptimizedImage,
      RouterLink,
      WishlistAccessModule
    ]
})
export class WishlistCardModule { }
