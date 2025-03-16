import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WishlistPageRoutingModule } from './wishlist-page-routing.module';
import { WishlistPageComponent } from './wishlist-page.component';
import { SidebarModule } from '../../../shared/ui/sidebar/sidebar.module';
import { WishlistCardModule } from '../../ui/wishlist-card/wishlist-card.module';
import { GiftCardModule } from '../../../gifts/ui/gift-card/gift-card.module';
import { GiftModalModule } from '../../../gifts/ui/gift-modal/gift-modal.module';
import {DropdownModule} from "../../../shared/ui/dropdown/dropdown.module";


@NgModule({
  declarations: [
    WishlistPageComponent
  ],
  imports: [
    CommonModule,
    WishlistPageRoutingModule,
    SidebarModule,
    WishlistCardModule,
    GiftCardModule,
    GiftModalModule,
    DropdownModule,
  ]
})
export class WishlistPageModule { }
