import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WishlistsService } from '../../data-access/wishlists.service';
import { GiftResponse } from '../../../gifts/models/gift';

@Component({
  selector: 'app-wishlist-page',
  templateUrl: './wishlist-page.component.html',
  styleUrl: './wishlist-page.component.sass'
})
export class WishlistPageComponent implements OnInit {

  gifts: GiftResponse[] = [];

  constructor(private route: ActivatedRoute,
    private wishlistsService: WishlistsService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.wishlistsService.getById(params['id']).subscribe(res => {
        this.gifts = res.gifts.collection;
      });
    });
  }
}
