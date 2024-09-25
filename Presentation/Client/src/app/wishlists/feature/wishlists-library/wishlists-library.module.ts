import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WishlistsLibraryRoutingModule } from './wishlists-library-routing.module';
import { WishlistsLibraryComponent } from './wishlists-library.component';
import { SidebarModule } from '../../../shared/ui/sidebar/sidebar.module';
import { WishlistCardModule } from '../../ui/wishlist-card/wishlist-card.module';
import { WishlistCreateModule } from '../../ui/wishlist-create/wishlist-create.module';


@NgModule({
  declarations: [
    WishlistsLibraryComponent
  ],
  imports: [
    CommonModule,
    WishlistsLibraryRoutingModule,
    SidebarModule,
    WishlistCardModule,
    WishlistCreateModule
  ]
})
export class WishlistsLibraryModule { }
