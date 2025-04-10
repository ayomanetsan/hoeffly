import { Component } from '@angular/core';
import {WishlistBriefResponse} from "../../models/wishlist";
import {WishlistsService} from "../../data-access/wishlists.service";

@Component({
  selector: 'app-public-wishlists',
  templateUrl: './public-wishlists.component.html',
  styleUrl: './public-wishlists.component.sass'
})
export class PublicWishlistsComponent {
  wishlists: WishlistBriefResponse[] = [];

  constructor(private wishlistsService: WishlistsService) { }

  ngOnInit() {
    this.loadWishlists();
  }

  loadWishlists() {
    this.wishlistsService.getPublicWishlists().subscribe(
      response => {
        this.wishlists = response.collection;
      }
    );
  }
}
