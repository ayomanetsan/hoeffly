import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MenuItem } from 'primeng/api';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { WishlistsService } from '../../data-access/wishlists.service';
import { WishlistBriefResponse } from '../../models/wishlist';
import { CreateDialogComponent } from '../create-dialog/create-dialog.component';
import { WishlistAccessComponent } from '../wishlist-access/wishlist-access.component';

@Component({
  selector: 'app-wishlist-card',
  templateUrl: './wishlist-card.component.html',
  standalone: false,
})
export class WishlistCardComponent {
  @Input({ required: true }) wishlist!: WishlistBriefResponse;
  @Output() wishlistDeleted: EventEmitter<string> = new EventEmitter<string>();
  @Output() wishlistUpdated: EventEmitter<void> = new EventEmitter<void>();

  ref: DynamicDialogRef | undefined;
  menuItems: MenuItem[] = [
    {
      label: 'Wishlist Actions',
      items: [
        {
          label: 'Edit',
          icon: 'pi pi-pencil',
          command: () => this.openEditDialog(),
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
    private dialogService: DialogService,
  ) {}

  private openEditDialog(): void {
    this.ref = this.dialogService.open(CreateDialogComponent, {
      data: this.wishlist,
      modal: true,
      showHeader: false,
      width: '450px',
    });

    this.ref.onClose.subscribe((result) => {
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
