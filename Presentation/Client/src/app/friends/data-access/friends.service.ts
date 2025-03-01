import { Injectable } from '@angular/core';
import {HttpService} from "../../shared/data-access/http.service";
import {PagedResponse} from "../../shared/models/pagedResponse";
import {FriendResponse, ManageFriendshipRequest, SendFriendshipRequest} from "../ui/friends";
import {UserResponse} from "../ui/users";

@Injectable({
  providedIn: 'root'
})
export class FriendsService {

  constructor(private http: HttpService) { }

  getFriends(pageNumber = 1, pageSize = 10) {
    return this.http.get<PagedResponse<FriendResponse>>(`/friendship?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  getPubicUsers(pageNumber = 1, pageSize = 10) {
    return this.http.get<PagedResponse<UserResponse>>(`/friendship/users?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  sendFriendshipRequest(friendshipRequest: SendFriendshipRequest) {
    return this.http.post<SendFriendshipRequest>('/friendship/send', friendshipRequest);
  }

  delete(id: string) {
    return this.http.delete('/friendship', id);
  }

  manageFriendshipRequest(id: string, manageFriendshipRequest: ManageFriendshipRequest) {
    return this.http.put<ManageFriendshipRequest>('/friendship/manage', manageFriendshipRequest);
  }
}
