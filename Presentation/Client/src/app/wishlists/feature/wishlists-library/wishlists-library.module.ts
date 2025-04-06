import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { Button } from 'primeng/button';
import { SelectButton } from 'primeng/selectbutton';
import { Skeleton } from 'primeng/skeleton';
import { SidebarModule } from '../../../shared/ui/sidebar/sidebar.module';
import { CreateDialogModule } from '../../ui/create-dialog/create-dialog.module';
import { WishlistCardModule } from '../../ui/wishlist-card/wishlist-card.module';
import { WishlistSkeletonModule } from '../../ui/wishlist-skeleton/wishlist-skeleton.module';
import { WishlistsLibraryRoutingModule } from './wishlists-library-routing.module';
import { WishlistsLibraryComponent } from './wishlists-library.component';

@NgModule({
  declarations: [WishlistsLibraryComponent],
  imports: [
    CommonModule,
    WishlistsLibraryRoutingModule,
    SidebarModule,
    WishlistCardModule,
    Button,
    SelectButton,
    FormsModule,
    Skeleton,
    WishlistSkeletonModule,
    CreateDialogModule,
  ],
})
export class WishlistsLibraryModule {}
