import { NgModule } from '@angular/core';
import { WishlistCreateComponent } from './wishlist-create.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    WishlistCreateComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
  ]
})
export class WishlistCreateModule { }
