import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WishlistsLibraryRoutingModule } from './wishlists-library-routing.module';
import { WishlistsLibraryComponent } from './wishlists-library.component';
import { SidebarModule } from '../../../shared/ui/sidebar/sidebar.module';
import { WishlistCardModule } from '../../ui/wishlist-card/wishlist-card.module';
import { WishlistModalModule } from '../../ui/wishlist-modal/wishlist-modal.module';


@NgModule({
  declarations: [
    WishlistsLibraryComponent
  ],
  imports: [
    CommonModule,
    WishlistsLibraryRoutingModule,
    SidebarModule,
    WishlistCardModule,
    WishlistModalModule
  ]
})
export class WishlistsLibraryModule { }
