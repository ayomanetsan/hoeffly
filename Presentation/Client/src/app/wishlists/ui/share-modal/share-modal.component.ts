import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { forkJoin } from 'rxjs';
import { AuthService } from '../../../auth/data-access/auth.service';
import { FriendsService } from '../../../friends/data-access/friends.service';
import { DropdownOption } from '../../../shared/models/dropdownOption';
import { UsersService } from '../../data-access/users.service';
import { WishlistsService } from '../../data-access/wishlists.service';
import {
  AccessRightsResponse,
  AccessType,
  AccessTypeOptions,
  ShareWishlistRequest,
} from '../../models/accessRights';

@Component({
  selector: 'app-share-modal',
  standalone: false,
  templateUrl: './share-modal.component.html',
  providers: [MessageService, ConfirmationService],
})
export class ShareModalComponent implements OnInit {
  wishlistId: string;
  wishlistName: string;
  accessTypeOptions: any[] = [
    { label: 'Friends', value: 'Friends', icon: 'pi pi-users' },
    { label: 'Email', value: 'Email', icon: 'pi pi-envelope' },
  ];
  selectedFilter = 'Friends';
  accessForm!: FormGroup;
  friendsDropdownOptions: any[] = [];
  friendsLoading = true;
  invitationLoading = false;
  peopleWithAccess: AccessRightsResponse[] = [];
  currentUserEmail!: string;
  isOwner = false;
  accessTypeDropdown: DropdownOption[] = AccessTypeOptions;
  changesLoading = false;

  constructor(
    config: DynamicDialogConfig,
    private dialogRef: DynamicDialogRef,
    private fb: FormBuilder,
    private friendsService: FriendsService,
    private usersService: UsersService,
    private wishlistService: WishlistsService,
    private authService: AuthService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
  ) {
    this.wishlistId = config.data.wishlistId;
    this.wishlistName = config.data.wishlistName;
  }

  ngOnInit(): void {
    this.initForm();
    this.initFriendsDropdownOptions();
    this.getPeopleWithAccess();
  }

  closeModal(): void {
    this.dialogRef.close();
  }

  shareAccess() {
    const email = this.accessForm.get('email')?.value;
    this.accessForm.reset();
    this.invitationLoading = true;

    if (this.peopleWithAccess.some((person) => person.email === email)) {
      this.messageService.add({
        severity: 'info',
        summary: 'Info',
        detail: 'User already has access to this wishlist',
      });
      this.invitationLoading = false;
      return;
    }

    this.usersService.getUserByEmail(email).subscribe({
      next: (user) => {
        this.peopleWithAccess.push({
          id: '',
          type: AccessType.Viewer,
          name: user.name,
          email: user.email,
        });
        this.invitationLoading = false;
      },
      error: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'User not found',
        });
        this.invitationLoading = false;
      },
    });
  }

  getInitials(fullName: string): string {
    const names = fullName.split(' ');
    let initials = '';
    for (let i = 0; i < names.length; i++) {
      initials += names[i].charAt(0).toUpperCase();
    }
    return initials;
  }

  updateAccessType(
    person: AccessRightsResponse,
    newAccessType: AccessType,
  ): void {
    person.type = newAccessType;
  }

  revokeAccess(person: AccessRightsResponse, event: Event): void {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: 'Do you want to delete this record?',
      header: 'Danger Zone',
      icon: 'pi pi-info-circle',
      rejectLabel: 'Cancel',
      rejectButtonProps: {
        label: 'Cancel',
        severity: 'secondary',
        outlined: true,
      },
      acceptButtonProps: {
        label: 'Delete',
        severity: 'danger',
      },

      accept: () => {
        if (person.id) {
          this.wishlistService.revokeAccess(person.id).subscribe(() => {
            this.peopleWithAccess = this.peopleWithAccess.filter(
              (p) => p.id !== person.id,
            );
          });
        } else {
          this.peopleWithAccess = this.peopleWithAccess.filter(
            (p) => p.email !== person.email,
          );
        }
      },
    });
  }

  saveChanges(): void {
    this.changesLoading = true;

    const requests = this.peopleWithAccess
      .filter((person) => person.initialType !== person.type)
      .map((person) => {
        const request: ShareWishlistRequest = {
          wishlistId: this.wishlistId,
          email: person.email,
          accessType: person.type,
        };
        return this.wishlistService.grantAccess(request);
      });

    if (requests.length === 0) {
      this.changesLoading = false;
      this.closeModal();
      return;
    }

    forkJoin(requests).subscribe({
      next: () => {
        this.changesLoading = false;
        this.closeModal();
      },
      error: (err) => {
        this.changesLoading = false;
      },
    });
  }

  private initForm(): void {
    this.accessForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
    });
  }

  private initFriendsDropdownOptions(): void {
    this.friendsService.getFriends().subscribe((response) => {
      this.friendsDropdownOptions = response.collection.map((friend) => {
        return {
          name: friend.name,
          email: friend.email,
        };
      });
      this.friendsLoading = false;
    });
  }

  private getPeopleWithAccess(): void {
    this.wishlistService
      .getAccess(this.wishlistId)
      .subscribe(async (pagedAccessRights) => {
        this.peopleWithAccess = pagedAccessRights.collection.map((user) => ({
          ...user,
          initialType: user.type,
        }));

        this.currentUserEmail =
          (await this.authService.getCurrentUserEmail()) as string;
        this.isOwner = this.peopleWithAccess.some(
          (person) =>
            person.email === this.currentUserEmail &&
            person.type === AccessType.Owner,
        );
      });
  }

  protected readonly AccessType = AccessType;
}
