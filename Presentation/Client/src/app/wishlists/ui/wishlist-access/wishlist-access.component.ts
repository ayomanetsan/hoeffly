import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { WishlistsService } from '../../data-access/wishlists.service';
import { AccessRightsResponse, AccessType, AccessTypeOptions, ShareWishlistRequest } from '../../models/accessRights';
import { FriendsService } from '../../../friends/data-access/friends.service';
import { FriendResponse } from '../../../friends/ui/friends';
import { DropdownOption } from '../../../shared/models/dropdownOption';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsersService } from '../../data-access/users.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../../auth/data-access/auth.service';

@Component({
  selector: 'app-wishlist-access',
  templateUrl: './wishlist-access.component.html',
  styleUrl: './wishlist-access.component.sass'
})
export class WishlistAccessComponent implements OnInit {
  accessForm!: FormGroup;
  selectedFilter: string = 'friends';
  friendsDropdown: DropdownOption[] = [];
  peopleWithAccess: AccessRightsResponse[] = [];
  accessTypeDropdown: DropdownOption[] = AccessTypeOptions;
  isOwner!: boolean;
  currentUserEmail!: string;

  constructor(private fb: FormBuilder,
    private friendsService: FriendsService,
    private wishlistService: WishlistsService,
    private usersService: UsersService,
    private authService: AuthService,
    private toastr: ToastrService,
    private dialogRef: MatDialogRef<WishlistAccessComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { wishlistId: string, wishlistName: string }
  ) { }

  ngOnInit() {
    this.initForm();

    this.friendsService.getFriends().subscribe(pagedFriends => {
      this.friendsDropdown = pagedFriends.collection.map((friend: FriendResponse) => {
        return {
          text: friend.name,
          value: friend.email
        };
      });
    });

    this.wishlistService.getAccess(this.data.wishlistId).subscribe(async pagedAccessRights => {
      this.peopleWithAccess = pagedAccessRights.collection.map(user => ({
        ...user,
        initialType: user.type
      }));

      this.currentUserEmail = await this.authService.getCurrentUserEmail() as string;
      this.isOwner = this.peopleWithAccess.some(person => person.email === this.currentUserEmail && person.type === AccessType.Owner);
    });
  }

  closeModal() {
    this.dialogRef.close();
  }

  changeFilter(selectedFilter: string): void {
    if (this.selectedFilter === selectedFilter) {
      return;
    }

    this.selectedFilter = selectedFilter;
  }

  getUserDetails() {
    const email = this.accessForm.get('email')?.value;
    this.accessForm.reset();

    if (this.peopleWithAccess.some(person => person.email === email)) {
      this.toastr.info('User already has access');
      return;
    }

    this.usersService.getUserByEmail(email).subscribe({
      next: user => {
        this.peopleWithAccess.push({
          id: '',
          type: AccessType.Viewer,
          name: user.name,
          email: user.email,
        });
      },
      error: () => {
        this.toastr.error('User not found');
      }
    });
  }

  updateAccessType(person: AccessRightsResponse, newAccessType: AccessType): void {
    person.type = newAccessType;
  }

  revokeAccess(person: AccessRightsResponse): void {
    if (person.id) {
      this.wishlistService.revokeAccess(person.id).subscribe(() => {
        this.peopleWithAccess = this.peopleWithAccess.filter(p => p.id !== person.id);
      });
    } else {
      this.peopleWithAccess = this.peopleWithAccess.filter(p => p.email !== person.email);
    }

    this.toastr.success('Access revoked');
  }

  updateAccess() {
    this.peopleWithAccess.forEach(person => {
      if (person.initialType !== person.type) {
        const request: ShareWishlistRequest = {
          wishlistId: this.data.wishlistId,
          email: person.email,
          accessType: person.type
        };
        this.wishlistService.grantAccess(request).subscribe();
      }
    });

    this.toastr.success('Access rights updated');
    this.dialogRef.close();
  }

  private initForm(): void {
    this.accessForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  protected readonly AccessType = AccessType;
}
