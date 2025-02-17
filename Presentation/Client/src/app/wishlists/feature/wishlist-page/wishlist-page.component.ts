import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WishlistsService } from '../../data-access/wishlists.service';
import { GiftResponse } from '../../../gifts/models/gift';
import { MatDialog } from '@angular/material/dialog';
import { GiftModalComponent } from '../../../gifts/ui/gift-modal/gift-modal.component';

@Component({
  selector: 'app-wishlist-page',
  templateUrl: './wishlist-page.component.html',
  styleUrl: './wishlist-page.component.sass'
})
export class WishlistPageComponent implements OnInit {

  private wishlistId!: string;
  gifts: GiftResponse[] = [];

  constructor(private route: ActivatedRoute,
    private wishlistsService: WishlistsService,
    private dialogRef: MatDialog
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.wishlistId = params['id'];
      this.wishlistsService.getById(this.wishlistId).subscribe(res => {
        this.gifts = res.gifts.collection;
      });
    });
  }

  openCreateModal() {
    const dialogRef = this.dialogRef.open(GiftModalComponent, {
      data: {
        wishlistId: this.wishlistId
      }
    });
  }
}
