import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FriendResponse, InvitationStatus, ManageFriendshipRequest } from '../friends';

@Component({
  selector: 'app-friend-card',
  templateUrl: './friend-card.component.html',
  styleUrl: './friend-card.component.sass'
})
export class FriendCardComponent {

  @Input() friend!: FriendResponse;
  @Output() requestManaged = new EventEmitter<{ request: ManageFriendshipRequest, receiverEmail: string }>();
  @Output() requestDeleted = new EventEmitter<string>();

  protected readonly InvitationStatus = InvitationStatus;

  manageRequest(status: InvitationStatus): void {
    const manageFriendshipRequest = {
      status: status,
      friendshipId: this.friend.id,
    };
    const receiverEmail = this.friend.email;

    this.requestManaged.emit({ request: manageFriendshipRequest, receiverEmail });
  }

  deleteFriend() {
    this.requestDeleted.emit(this.friend.id);
  }

}
