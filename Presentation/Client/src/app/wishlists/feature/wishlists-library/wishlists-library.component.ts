import {Component, OnInit} from '@angular/core';
import { WishlistBriefResponse } from '../../models/wishlist';
import { MatDialog } from '@angular/material/dialog';
import { WishlistModalComponent } from '../../ui/wishlist-modal/wishlist-modal.component';
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
    const defaultWishlist: WishlistBriefResponse = {
      id: '',
      name: '',
      isPublic: false,
      categories: [],
      createdAt: new Date(),
      photoUrls: [],
      giftsCount: 0,
      occasionDate: new Date()
    };


    const dialogRef = this.dialogRef.open(WishlistModalComponent, {
      width: '560px',
      data: { wishlist: defaultWishlist, mode: "create" }
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.loadWishlists();
      }
    });
  }

  onWishlistDeleted(wishlistId: string) {
    this.wishlists = this.wishlists.filter(wishlist => wishlist.id !== wishlistId);
  }


  onWishlistUpdated() {
    this.loadWishlists();
  }
}
