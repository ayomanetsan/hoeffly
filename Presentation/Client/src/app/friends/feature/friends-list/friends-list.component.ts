import { Component, OnInit } from '@angular/core';
import { FriendsService } from '../../data-access/friends.service';
import { UserResponse } from '../../ui/users';
import { FriendResponse, ManageFriendshipRequest } from '../../ui/friends';

@Component({
  selector: 'app-friends-list',
  templateUrl: './friends-list.component.html',
  styleUrl: './friends-list.component.sass'
})
export class FriendsListComponent implements OnInit {

  public selectedFilter: string = 'friends';
  public friends: FriendResponse[] = [];
  public users: UserResponse[] = [];

  constructor(private friendsService: FriendsService) { }

  ngOnInit(): void {
    this.getFriends();
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

  manageFriendRequest(manageFriendshipRequest: ManageFriendshipRequest): void {
    this.friendsService.manageFriendshipRequest(manageFriendshipRequest).subscribe((status) => {
      this.friends = this.friends.map(friend =>
        friend.id === manageFriendshipRequest.friendshipId ? { ...friend, status: manageFriendshipRequest.status } : friend
      );
    });
  }

  sendFriendRequest(email: string) {
    const sendFriendRequest = {
      email: email
    };

    this.friendsService.sendFriendshipRequest(sendFriendRequest).subscribe(() => {
      this.users = this.users.filter(user => user.email !== email);
    });
  }

  removeFriend(friendId: string) {
    this.friendsService.delete(friendId).subscribe(() => {
      this.friends = this.friends.filter(friend => friend.id !== friendId);
    });
  }
}
