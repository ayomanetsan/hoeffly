import {Component, EventEmitter, HostListener, Input, OnInit, Output} from '@angular/core';
import { WishlistBriefResponse } from '../../models/wishlist';
import {Subscription} from "rxjs";
import {WishlistCardStateService} from "../../data-access/wishlist-card-state.service";
import {WishlistsService} from "../../data-access/wishlists.service";
import {WishlistModalComponent} from "../wishlist-modal/wishlist-modal.component";
import {MatDialog} from "@angular/material/dialog";
import { WishlistAccessComponent } from '../wishlist-access/wishlist-access.component';

@Component({
  selector: 'app-wishlist-card',
  templateUrl: './wishlist-card.component.html',
  styleUrl: './wishlist-card.component.sass',
})
export class WishlistCardComponent implements OnInit {
  @Input({ required: true }) wishlist!: WishlistBriefResponse;
  @Output() wishlistDeleted: EventEmitter<string> = new EventEmitter<string>();
  @Output() wishlistUpdated: EventEmitter<void> = new EventEmitter<void>();

  isMenuOpen = false;
  private subscription: Subscription = new Subscription();

  constructor(private wishlistCardStateService: WishlistCardStateService, private wishlistsService: WishlistsService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.subscription = this.wishlistCardStateService.menuOpened$.subscribe(openedWishlistId => {
      if (openedWishlistId !== this.wishlist.id) {
        this.isMenuOpen = false;
      }
    });
  }

  toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
    if (this.isMenuOpen) {
      this.wishlistCardStateService.notifyMenuOpened(this.wishlist.id);
    }
  }

  handleAction(action: string): void {
    this.isMenuOpen = false;

    switch (action) {
      case 'edit':
        this.openEditModal();
        break;
      case 'share':
        this.openShareModal();
        break;
      case 'remove':
        this.deleteWishlist(this.wishlist.id);
        break;
      case 'done':
        console.log('Mark wishlist as done');
        // TODO: done
        break;
      default:
        console.log('Unknown action');
    }
  }

  openEditModal(): void {
    const dialogRef = this.dialog.open(WishlistModalComponent, {
      width: '560px',
      data: { wishlist: this.wishlist, mode: "edit" },
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.wishlistUpdated.emit();
      }
    });
  }

  private openShareModal(): void {
    const dialogRef = this.dialog.open(WishlistAccessComponent, {
      data: { wishlistId: this.wishlist.id, wishlistName: this.wishlist.name },
    });
  }

  deleteWishlist(wishlistId: string) {
    this.wishlistsService.delete(wishlistId).subscribe({
      next: () => {
        this.wishlistDeleted.emit(wishlistId);
      }
    });
  }

  @HostListener('document:click', ['$event'])
  onDocumentClick(event: MouseEvent) {
    const target = event.target as HTMLElement;
    const isMenuButton = target.closest('.actions-menu-button');
    const isMenuContent = target.closest('.actions-menu');

    if (!isMenuButton && !isMenuContent) {
      this.isMenuOpen = false;
    }
  }
}
