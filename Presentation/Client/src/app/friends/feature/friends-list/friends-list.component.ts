import { Component, OnDestroy, OnInit } from '@angular/core';
import { FriendsService } from '../../data-access/friends.service';
import { UserResponse } from '../../ui/users';
import { FriendResponse, InvitationStatus, ManageFriendshipRequest } from '../../ui/friends';
import { FriendsHubService } from '../../data-access/friends-hub.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-friends-list',
  templateUrl: './friends-list.component.html',
  styleUrl: './friends-list.component.sass'
})
export class FriendsListComponent implements OnInit, OnDestroy {

  public selectedFilter: string = 'friends';
  public friends: FriendResponse[] = [];
  public users: UserResponse[] = [];
  private friendRequestSubscription!: Subscription;
  private friendRequestStatusSubscription!: Subscription;
  private friendRequestDeleteSubscription!: Subscription;

  constructor(private friendsService: FriendsService, private friendsHubService: FriendsHubService) { }

  ngOnInit(): void {
    this.getFriends();
    this.friendsHubService.startConnection();

    this.friendRequestSubscription = this.friendsHubService.friendRequestReceived$.subscribe(friend => {
      this.friends.push(friend);
    });

    this.friendRequestStatusSubscription = this.friendsHubService.friendRequestStatusReceived$.subscribe(friendship => {
      this.friends = this.friends.map(friend =>
        friend.id === friendship.friendshipId ? { ...friend, status: friendship.status } : friend
      );
    });

    this.friendRequestDeleteSubscription = this.friendsHubService.friendRequestDeleteReceived$.subscribe(friendshipId => {
      this.friends = this.friends.filter(friend => friend.id !== friendshipId);
    });
  }

  ngOnDestroy(): void {
    if (this.friendRequestSubscription) {
      this.friendRequestSubscription.unsubscribe();
    }

    if (this.friendRequestStatusSubscription) {
      this.friendRequestStatusSubscription.unsubscribe();
    }

    if (this.friendRequestDeleteSubscription) {
      this.friendRequestDeleteSubscription.unsubscribe();
    }

    this.friendsHubService.stopConnection();
  }

  changeFilter(selectedFilter: string): void {
    if (this.selectedFilter === selectedFilter) {
      return;
    }

    this.selectedFilter = selectedFilter;

    switch (this.selectedFilter) {
      case 'friends':
        this.getFriends();
        break;
      case 'users':
        this.getUsers();
        break
    }
  }

  private getFriends(): void {
    this.friendsService.getFriends().subscribe(friends => {
      this.friends = friends.collection;
    });
  }

  private getUsers(): void {
    this.friendsService.getPubicUsers().subscribe(users => {
      this.users = users.collection;
    });
  }

  manageFriendRequest(data: { request: ManageFriendshipRequest, receiverEmail: string }): void {
    this.friendsService.manageFriendshipRequest(data.request).subscribe(() => {
      this.friends = this.friends.map(friend =>
        friend.id === data.request.friendshipId ? { ...friend, status: data.request.status } : friend
      );

      this.friendsHubService.manageFriendRequest(data.receiverEmail, data.request.friendshipId, data.request.status);
    });
  }

  sendFriendRequest(email: string) {
    const sendFriendRequest = {
      email: email
    };

    this.friendsService.sendFriendshipRequest(sendFriendRequest).subscribe((friendshipId) => {
      // Get the display name from the local storage, because the current user is the sender
      const senderName = localStorage.getItem('displayName')!;
      this.friendsHubService.sendFriendRequest(email, friendshipId, senderName);

      this.users = this.users.filter(user => user.email !== email);
    });
  }

  removeFriend(friendId: string) {
    this.friendsService.delete(friendId).subscribe(() => {
      const receiverEmail = this.friends.find(friend => friend.id === friendId)?.email!;
      this.friends = this.friends.filter(friend => friend.id !== friendId);

      this.friendsHubService.deleteFriendRequest(receiverEmail, friendId);
    });
  }
}
