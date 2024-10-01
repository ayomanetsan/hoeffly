import { NgModule } from '@angular/core';
import { WishlistModalComponent } from './wishlist-modal.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    WishlistModalComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
  ]
})
export class WishlistModalModule { }
