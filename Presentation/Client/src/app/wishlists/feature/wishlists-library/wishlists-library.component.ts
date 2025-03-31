import {Component, OnInit} from '@angular/core';
import { WishlistBriefResponse } from '../../models/wishlist';
import { MatDialog } from '@angular/material/dialog';
import { WishlistModalComponent } from '../../ui/wishlist-modal/wishlist-modal.component';
import { WishlistsService } from '../../data-access/wishlists.service';
import {AccessType} from "../../models/accessRights";

@Component({
    selector: 'app-wishlists-library',
    templateUrl: './wishlists-library.component.html',
    styleUrl: './wishlists-library.component.sass',
    standalone: false
})
export class WishlistsLibraryComponent implements OnInit{

  wishlists: WishlistBriefResponse[] = [];
  public selectedFilter: number = AccessType.Owner;

  constructor(private wishlistsService: WishlistsService, private dialogRef: MatDialog) { }

  ngOnInit() {
    this.loadWishlists();
  }

  loadWishlists() {
    this.wishlistsService.get(this.selectedFilter).subscribe(
      response => {
        this.wishlists = response.collection;
      }
    );
  }

  changeFilter(selectedFilter: number): void {
    if (this.selectedFilter === selectedFilter) {
      return;
    }

    this.selectedFilter = selectedFilter;

    switch (this.selectedFilter) {
      case 0:
        this.getWishlistsWithAccessTypeOwner();
        break;
      case 1:
        this.getWishlistsWithAccessTypeEditor();
        break
      case 2:
        this.getWishlistsWithAccessTypeViewer();
        break
    }
  }

  private getWishlistsWithAccessTypeOwner(): void {
    this.wishlistsService.get(0).subscribe(
      response => {
        this.wishlists = response.collection;
      }
    );
  }
  private getWishlistsWithAccessTypeEditor(): void {
    this.wishlistsService.get(1).subscribe(
      response => {
        this.wishlists = response.collection;
      }
    );
  }
  private getWishlistsWithAccessTypeViewer(): void {
    this.wishlistsService.get(2).subscribe(
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

  protected readonly AccessType = AccessType;
}
