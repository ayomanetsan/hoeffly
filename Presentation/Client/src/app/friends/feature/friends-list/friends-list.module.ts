import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FriendsListRoutingModule } from './friends-list-routing.module';
import { FriendsListComponent } from './friends-list.component';
import { SidebarModule } from '../../../shared/ui/sidebar/sidebar.module';
import { WishlistCardModule } from '../../../wishlists/ui/wishlist-card/wishlist-card.module';
import { UserCardModule } from '../../ui/user-card/user-card.module';
import { FriendCardModule } from '../../ui/friend-card/friend-card.module';


@NgModule({
  declarations: [
    FriendsListComponent
  ],
  imports: [
    CommonModule,
    FriendsListRoutingModule,
    SidebarModule,
    WishlistCardModule,
    UserCardModule,
    FriendCardModule
  ]
})
export class FriendsListModule { }
