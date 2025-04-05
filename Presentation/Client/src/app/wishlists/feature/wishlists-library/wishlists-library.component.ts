import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { WishlistsService } from '../../data-access/wishlists.service';
import { AccessType } from '../../models/accessRights';
import { WishlistBriefResponse } from '../../models/wishlist';
import { WishlistModalComponent } from '../../ui/wishlist-modal/wishlist-modal.component';

@Component({
  selector: 'app-wishlists-library',
  templateUrl: './wishlists-library.component.html',
  standalone: false,
})
export class WishlistsLibraryComponent implements OnInit {
  selectedFilter: AccessType = AccessType.Owner;
  accessTypeOptions: any[] = [
    { label: 'Owner', value: AccessType.Owner },
    { label: 'Editor', value: AccessType.Editor },
    { label: 'Viewer', value: AccessType.Viewer },
  ];
  wishlists: WishlistBriefResponse[] = [];
  loading = false;

  constructor(
    private wishlistsService: WishlistsService,
    private dialogRef: MatDialog,
  ) {}

  ngOnInit() {
    this.loadWishlists();
  }

  loadWishlists() {
    this.loading = true;
    this.wishlistsService.get(this.selectedFilter).subscribe({
      next: (response) => {
        this.wishlists = response.collection;
      },
      complete: () => {
        this.loading = false;
      },
    });
  }

  openCreateModal() {
    const defaultWishlist: WishlistBriefResponse = {
      id: '',
      name: '',
      isPublic: false,
      categories: [],
      createdAt: new Date(),
      photoUrls: [],
      giftsCount: 0,
      occasionDate: new Date(),
    };

    const dialogRef = this.dialogRef.open(WishlistModalComponent, {
      width: '560px',
      data: { wishlist: defaultWishlist, mode: 'create' },
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.loadWishlists();
      }
    });
  }

  onWishlistDeleted(wishlistId: string) {
    this.wishlists = this.wishlists.filter(
      (wishlist) => wishlist.id !== wishlistId,
    );
  }

  onWishlistUpdated() {
    this.loadWishlists();
  }
}
