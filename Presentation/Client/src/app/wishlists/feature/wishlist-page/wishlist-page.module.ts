import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { Button } from 'primeng/button';
import { Tag } from 'primeng/tag';
import { GiftCardModule } from '../../../gifts/ui/gift-card/gift-card.module';
import { GiftModalModule } from '../../../gifts/ui/gift-modal/gift-modal.module';
import { ReservationModalModule } from '../../../gifts/ui/reservation-modal/reservation-modal.module';
import { DropdownModule } from '../../../shared/ui/dropdown/dropdown.module';
import { SidebarModule } from '../../../shared/ui/sidebar/sidebar.module';
import { WishlistCardModule } from '../../ui/wishlist-card/wishlist-card.module';
import { WishlistPageRoutingModule } from './wishlist-page-routing.module';
import { WishlistPageComponent } from './wishlist-page.component';

@NgModule({
  declarations: [WishlistPageComponent],
  imports: [
    CommonModule,
    WishlistPageRoutingModule,
    SidebarModule,
    WishlistCardModule,
    GiftCardModule,
    GiftModalModule,
    DropdownModule,
    ReservationModalModule,
    Button,
    Tag,
  ],
})
export class WishlistPageModule {}
