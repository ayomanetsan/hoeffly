import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WishlistsService } from '../../data-access/wishlists.service';
import { GiftResponse } from '../../../gifts/models/gift';
import { MatDialog } from '@angular/material/dialog';
import { GiftModalComponent } from '../../../gifts/ui/gift-modal/gift-modal.component';
import { GiftService } from '../../../gifts/data-access/gift.service';

@Component({
  selector: 'app-wishlist-page',
  templateUrl: './wishlist-page.component.html',
  styleUrl: './wishlist-page.component.sass'
})
export class WishlistPageComponent implements OnInit {

  private wishlistId!: string;
  gifts: GiftResponse[] = [];

  constructor(
      private route: ActivatedRoute,
      private wishlistsService: WishlistsService,
      private giftService: GiftService,
      private dialogRef: MatDialog
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.wishlistId = params['id'];
      this.loadGifts();
    });
  }

  loadGifts(): void {
    this.wishlistsService.getById(this.wishlistId).subscribe(res => {
      this.gifts = res.gifts.collection;
    });
  }

  openCreateModal(): void {
    const dialogRef = this.dialogRef.open(GiftModalComponent, {
      data: {
        wishlistId: this.wishlistId
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadGifts(); // Reload gifts if the modal was closed with a result
      }
    });
  }

  onDelete(giftId: string): void {
    this.giftService.delete(giftId).subscribe(() => {
      this.loadGifts(); // Reload gifts after deletion
    });
  }

  onUpdate(gift: GiftResponse): void {
    const dialogRef = this.dialogRef.open(GiftModalComponent, {
      data: {
        gift, // Pass the gift object to the modal for editing
        wishlistId: this.wishlistId
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadGifts(); // Reload gifts if the modal was closed with a result
      }
    });
  }
}