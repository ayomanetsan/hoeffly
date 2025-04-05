import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Skeleton } from 'primeng/skeleton';
import { WishlistSkeletonComponent } from './wishlist-skeleton.component';

@NgModule({
  declarations: [WishlistSkeletonComponent],
  imports: [CommonModule, Skeleton],
  exports: [WishlistSkeletonComponent],
})
export class WishlistSkeletonModule {}
