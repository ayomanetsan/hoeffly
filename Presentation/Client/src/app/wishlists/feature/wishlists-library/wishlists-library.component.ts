import { Component, OnInit } from '@angular/core';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { WishlistsService } from '../../data-access/wishlists.service';
import { AccessType } from '../../models/accessRights';
import { WishlistBriefResponse } from '../../models/wishlist';
import { CreateDialogComponent } from '../../ui/create-dialog/create-dialog.component';

@Component({
  selector: 'app-wishlists-library',
  templateUrl: './wishlists-library.component.html',
  standalone: false,
  providers: [DialogService],
})
export class WishlistsLibraryComponent implements OnInit {
  ref: DynamicDialogRef | undefined;
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
    private dialogService: DialogService,
  ) {}

  ngOnInit() {
    this.loadWishlists();
  }

  openCreateDialog() {
    this.ref = this.dialogService.open(CreateDialogComponent, {
      modal: true,
      showHeader: false,
      width: '450px',
    });

    this.ref.onClose.subscribe((result) => {
      if (result) {
        this.loadWishlists();
      }
    });
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

  onWishlistDeleted(wishlistId: string) {
    this.wishlists = this.wishlists.filter(
      (wishlist) => wishlist.id !== wishlistId,
    );
  }

  onWishlistUpdated() {
    this.loadWishlists();
  }
}
