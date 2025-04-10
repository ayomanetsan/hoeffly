import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicWishlistsRoutingModule } from './public-wishlists-routing.module';
import { PublicWishlistsComponent } from './public-wishlists.component';
import {SidebarModule} from "../../../shared/ui/sidebar/sidebar.module";
import {WishlistCardModule} from "../../ui/wishlist-card/wishlist-card.module";


@NgModule({
  declarations: [
    PublicWishlistsComponent
  ],
  imports: [
    CommonModule,
    PublicWishlistsRoutingModule,
    SidebarModule,
    WishlistCardModule
  ]
})
export class PublicWishlistsModule { }
