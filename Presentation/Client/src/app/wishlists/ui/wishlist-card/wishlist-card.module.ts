import { NgModule } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { WishlistCardComponent } from './wishlist-card.component';



@NgModule({
  declarations: [
    WishlistCardComponent
  ],
  exports: [
    WishlistCardComponent
  ],
  imports: [
    CommonModule,
    NgOptimizedImage
  ]
})
export class WishlistCardModule { }
