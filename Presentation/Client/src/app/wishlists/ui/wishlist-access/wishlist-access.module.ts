import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WishlistAccessComponent } from './wishlist-access.component';
import { DropdownModule } from '../../../shared/ui/dropdown/dropdown.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    WishlistAccessComponent
  ],
    imports: [
        CommonModule,
        DropdownModule,
        ReactiveFormsModule,
        FormsModule
    ]
})
export class WishlistAccessModule { }
