import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MenuItem } from 'primeng/api';
import { WishlistsService } from '../../data-access/wishlists.service';
import { WishlistBriefResponse } from '../../models/wishlist';
import { WishlistAccessComponent } from '../wishlist-access/wishlist-access.component';
import { WishlistModalComponent } from '../wishlist-modal/wishlist-modal.component';

@Component({
  selector: 'app-wishlist-card',
  templateUrl: './wishlist-card.component.html',
  standalone: false,
})
export class WishlistCardComponent {
  @Input({ required: true }) wishlist!: WishlistBriefResponse;
  @Output() wishlistDeleted: EventEmitter<string> = new EventEmitter<string>();
  @Output() wishlistUpdated: EventEmitter<void> = new EventEmitter<void>();

  menuItems: MenuItem[] = [
    {
      label: 'Wishlist Actions',
      items: [
        {
          label: 'Edit',
          icon: 'pi pi-pencil',
          command: () => this.openEditModal(),
        },
        {
          label: 'Share',
          icon: 'pi pi-share-alt',
          command: () => this.openShareModal(),
        },
        {
          label: 'Delete',
          icon: 'pi pi-trash',
          command: () => this.deleteWishlist(this.wishlist.id),
        },
      ],
    },
  ];

  constructor(
    private wishlistsService: WishlistsService,
    private dialog: MatDialog,
  ) {}

  private openEditModal(): void {
    const dialogRef = this.dialog.open(WishlistModalComponent, {
      width: '560px',
      data: { wishlist: this.wishlist, mode: 'edit' },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.wishlistUpdated.emit();
      }
    });
  }

  private openShareModal(): void {
    this.dialog.open(WishlistAccessComponent, {
      data: { wishlistId: this.wishlist.id, wishlistName: this.wishlist.name },
    });
  }

  private deleteWishlist(wishlistId: string) {
    this.wishlistsService.delete(wishlistId).subscribe({
      next: () => {
        this.wishlistDeleted.emit(wishlistId);
      },
    });
  }
}
