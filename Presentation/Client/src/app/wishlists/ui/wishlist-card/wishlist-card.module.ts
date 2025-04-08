import { CommonModule, NgOptimizedImage } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Button } from 'primeng/button';
import { Card } from 'primeng/card';
import { Chip } from 'primeng/chip';
import { Menu } from 'primeng/menu';
import { Tag } from 'primeng/tag';
import { ShareModalModule } from '../share-modal/share-modal.module';
import { WishlistCardComponent } from './wishlist-card.component';

@NgModule({
  declarations: [WishlistCardComponent],
  exports: [WishlistCardComponent],
  imports: [
    CommonModule,
    NgOptimizedImage,
    RouterLink,
    ShareModalModule,
    Card,
    Button,
    Tag,
    Chip,
    Menu,
  ],
})
export class WishlistCardModule {}
