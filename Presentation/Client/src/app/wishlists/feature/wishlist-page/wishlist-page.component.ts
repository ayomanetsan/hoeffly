import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { WishlistsService } from '../../data-access/wishlists.service';
import { GiftResponse, ReserveAction, SharedGiftResponse, SharedGiftStatus } from '../../../gifts/models/gift';
import { MatDialog } from '@angular/material/dialog';
import { GiftModalComponent } from '../../../gifts/ui/gift-modal/gift-modal.component';
import { GiftService } from '../../../gifts/data-access/gift.service';
import { AccessType } from '../../models/accessRights';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../../auth/data-access/auth.service';
import { ReservationsHubService } from '../../../gifts/data-access/reservations-hub.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-wishlist-page',
  templateUrl: './wishlist-page.component.html',
  styleUrl: './wishlist-page.component.sass'
})
export class WishlistPageComponent implements OnInit {
  private giftReservationSubscription!: Subscription;
  private giftReservationCancelSubscription!: Subscription;

  private wishlistId!: string;
  gifts: GiftResponse[] = [];
  accessType!: AccessType;
  wishlistName!: string;
  currentUserEmail!: string;

  constructor(
      private location: Location,
      private route: ActivatedRoute,
      private router: Router,
      private wishlistsService: WishlistsService,
      private giftService: GiftService,
      private dialogRef: MatDialog,
      private toastr: ToastrService,
      private authService: AuthService,
      private reservationsHub: ReservationsHubService
  ) { }

  // TODO: separate ngOnInit into smaller methods
  async ngOnInit(): Promise<void> {
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

        // Hub methods
        this.reservationsHub.startConnection();

        this.giftReservationSubscription = this.reservationsHub.giftReservationReceived$.subscribe((response: { giftId: string, reservedByEmail: string }) => {
          const sharedGift: SharedGiftResponse = {
            userEmail: response.reservedByEmail,
            status: SharedGiftStatus.Primary,
          };

          this.gifts = this.gifts.map(gift =>
            gift.id === response.giftId
              ? { ...gift, isReserved: true, sharedGifts: [...gift.sharedGifts, sharedGift] }
              : gift
          );
        });

        this.giftReservationCancelSubscription = this.reservationsHub.giftReservationCancelReceived$.subscribe((response: { giftId: string, reservedByEmail: string }) => {
          this.gifts = this.gifts.map(gift => {
            if (gift.id !== response.giftId) return gift;

            // Remove the user from sharedGifts
            const updatedSharedGifts = gift.sharedGifts.filter(g => g.userEmail !== response.reservedByEmail);

            // If there are users left, make the first one Primary
            if (updatedSharedGifts.length > 0) {
              updatedSharedGifts[0] = { ...updatedSharedGifts[0], status: SharedGiftStatus.Primary };
            }

            return {
              ...gift,
              isReserved: updatedSharedGifts.length > 0,
              sharedGifts: updatedSharedGifts
            };
          });
        });
      });
    });

    // The current user is guaranteed to be authenticated at this point
    this.currentUserEmail = await this.authService.getCurrentUserEmail() as string;
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

  onReserve({ giftId, reserveAction }: { giftId: string, reserveAction: ReserveAction }): void {
    // TODO: implement real-time reservation
    switch (reserveAction) {
      case ReserveAction.Reserve:
        this.giftService.reserve(giftId).subscribe(() => {
          this.toastr.success('Gift reserved successfully');
          this.reservationsHub.reserveGift(giftId);
        });
        break;
      case ReserveAction.CancelReservation:
        this.giftService.cancelReservation(giftId).subscribe(() => {
          this.toastr.success('Gift reservation canceled');
          this.reservationsHub.cancelReservation(giftId);
        });
        break;
      case ReserveAction.RequestSharedReservation:
        this.giftService.reserve(giftId).subscribe(() => {
          this.toastr.success('Reservation join requested successfully');
        });
        break;
    }
  }

  protected readonly AccessType = AccessType;
}
