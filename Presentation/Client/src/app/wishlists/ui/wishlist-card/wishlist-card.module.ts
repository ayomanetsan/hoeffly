import { NgModule } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { WishlistCardComponent } from './wishlist-card.component';
import { RouterLink } from '@angular/router';



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
        RouterLink
    ]
})
export class WishlistCardModule { }
