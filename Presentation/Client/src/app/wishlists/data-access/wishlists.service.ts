import { Injectable } from '@angular/core';
import { HttpService } from "../../shared/data-access/http.service";
import {
  WishlistBriefResponse,
  WishlistCreateRequest,
  WishlistUpdateRequest,
  WishlistWithGifts
} from '../models/wishlist';
import { PagedResponse } from "../../shared/models/pagedResponse";
import { AccessRightsResponse, AccessType, ShareWishlistRequest } from '../models/accessRights';

@Injectable({
  providedIn: 'root'
})
export class WishlistsService {

  constructor(private http: HttpService) { }

  get(createdByCurrentUser = false, pageNumber = 1, pageSize = 10) {
    return this.http.get<PagedResponse<WishlistBriefResponse>>(`/wishlists?createdByCurrentUser=${createdByCurrentUser}&pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  getById(id: string) {
    return this.http.getById<WishlistWithGifts>(`/wishlists`, id);
  }

  create(wishlist: WishlistCreateRequest) {
    return this.http.post<WishlistCreateRequest>('/wishlists', wishlist);
  }

  delete(id: string) {
    return this.http.delete('/wishlists', id);
  }

  update(id: string, wishlist: WishlistUpdateRequest) {
    return this.http.put<WishlistUpdateRequest>('/wishlists', wishlist);
  }

  getAccess(id: string, pageNumber = 1, pageSize = 10) {
    return this.http.get<PagedResponse<AccessRightsResponse>>(`/wishlists/${id}/access?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  revokeAccess(accessRightsId: string) {
    return this.http.delete(`/wishlists/${accessRightsId}/access`, '');
  }

  grantAccess(request: ShareWishlistRequest) {
    return this.http.post('/wishlists/share', request);
  }
}
