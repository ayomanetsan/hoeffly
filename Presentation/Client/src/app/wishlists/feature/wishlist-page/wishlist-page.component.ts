import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WishlistsService } from '../../data-access/wishlists.service';
import { GiftResponse } from '../../../gifts/models/gift';
import { MatDialog } from '@angular/material/dialog';
import { GiftModalComponent } from '../../../gifts/ui/gift-modal/gift-modal.component';
import { GiftService } from '../../../gifts/data-access/gift.service';
import { AccessType } from '../../models/accessRights';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-wishlist-page',
  templateUrl: './wishlist-page.component.html',
  styleUrl: './wishlist-page.component.sass'
})
export class WishlistPageComponent implements OnInit {

  private wishlistId!: string;
  gifts: GiftResponse[] = [];
  accessType!: AccessType;
  wishlistName!: string;

  constructor(
      private location: Location,
      private route: ActivatedRoute,
      private router: Router,
      private wishlistsService: WishlistsService,
      private giftService: GiftService,
      private dialogRef: MatDialog,
      private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.wishlistId = params['id'];

      this.wishlistsService.checkAccess(this.wishlistId).subscribe(async accessType => {
        if (!accessType && accessType !== AccessType.Owner) {
          // Redirect to the not found page if the user has no access to the wishlist
          // TODO: create the not found page
          await this.router.navigate(['/']);
          return;
        }

        // TODO: alter the page based on access type
        this.accessType = accessType;
        this.loadGifts();
      });
    });
  }

  navigateToPreviousPage(): void {
    this.location.back();
  }

  loadGifts(): void {
    this.wishlistsService.getById(this.wishlistId).subscribe(res => {
      this.wishlistName = res.name;
      this.gifts = res.gifts.collection;
    });
  }

  openCreateModal(): void {
    const dialogRef = this.dialogRef.open(GiftModalComponent, {
      data: {
        wishlistId: this.wishlistId
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadGifts(); // Reload gifts if the modal was closed with a result
      }
    });
  }

  onDelete(giftId: string): void {
    this.giftService.delete(giftId).subscribe(() => {
      this.loadGifts(); // Reload gifts after deletion
    });
  }

  onUpdate(gift: GiftResponse): void {
    const dialogRef = this.dialogRef.open(GiftModalComponent, {
      data: {
        gift, // Pass the gift object to the modal for editing
        wishlistId: this.wishlistId
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.loadGifts(); // Reload gifts if the modal was closed with a result
      }
    });
  }

  onReserve({ giftId, toBeReserved }: { giftId: string, toBeReserved: boolean }): void {
    if (toBeReserved) {
      this.giftService.reserve(giftId).subscribe(() => {
        this.toastr.success('Gift reserved successfully');
      });
    } else {
      this.giftService.cancelReservation(giftId).subscribe(() => {
        this.toastr.success('Gift reservation canceled');
      });
    }
  }

  protected readonly AccessType = AccessType;
}
