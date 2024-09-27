import {Component, OnInit} from '@angular/core';
import { WishlistBriefResponse } from '../../models/wishlist';
import { MatDialog } from '@angular/material/dialog';
import { WishlistCreateComponent } from '../../ui/wishlist-create/wishlist-create.component';
import { WishlistsService } from '../../data-access/wishlists.service';

@Component({
  selector: 'app-wishlists-library',
  templateUrl: './wishlists-library.component.html',
  styleUrl: './wishlists-library.component.sass',
})
export class WishlistsLibraryComponent implements OnInit{

  wishlists: WishlistBriefResponse[] = [];

  constructor(private wishlistsService: WishlistsService, private dialogRef: MatDialog) { }

  ngOnInit() {
    this.loadWishlists();
  }

  loadWishlists() {
    this.wishlistsService.get(true).subscribe(
      response => {
        this.wishlists = response.collection;
      }
    );
  }

  openCreateModal() {
    const dialogRef = this.dialogRef.open(WishlistCreateComponent, { width: '560px' });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.loadWishlists();
      }
    });
  }

  onWishlistDeleted(wishlistId: string) {
    this.loadWishlists();
  }
}
