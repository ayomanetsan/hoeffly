import { Injectable } from '@angular/core';
import { HttpService } from "../../shared/data-access/http.service";
import {WishlistBriefResponse, WishlistCreateRequest, WishlistUpdateRequest} from "../models/wishlist";
import { PagedResponse } from "../../shared/models/pagedResponse";

@Injectable({
  providedIn: 'root'
})
export class WishlistsService {

  constructor(private http: HttpService) { }

  get(createdByCurrentUser = false, pageNumber = 1, pageSize = 10) {
    return this.http.get<PagedResponse<WishlistBriefResponse>>(`/wishlists?createdByCurrentUser=${createdByCurrentUser}&pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  getById(id: string) {
    return this.http.getById<WishlistBriefResponse>(`/wishlists`, id);
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
}
