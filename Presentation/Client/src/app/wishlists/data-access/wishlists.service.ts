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

  get(accessType = 0, pageNumber = 1, pageSize = 10) {
    return this.http.get<PagedResponse<WishlistBriefResponse>>(`/wishlists?accessType=${accessType}&pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  getPublicWishlists(pageNumber = 1, pageSize = 10) {
    return this.http.get<PagedResponse<WishlistBriefResponse>>(`/wishlists/public`);
  }

  getById(id: string, filters?: {
    categoryNames?: string[],
    isReserved?: boolean,
    priorities?: number[]
  }) {
    let url = `/wishlists/${id}`;

    if (filters) {
      const params = new URLSearchParams();

      if (filters.categoryNames && filters.categoryNames.length > 0) {
        filters.categoryNames.forEach(categoryName => {
          params.append('categoryNames', categoryName);
        });
      }

      if (filters.isReserved !== undefined && filters.isReserved !== null) {
        params.append('isReserved', filters.isReserved.toString());
      }

      if (filters.priorities && filters.priorities.length > 0) {
        filters.priorities.forEach(priority => {
          params.append('priorities', priority.toString());
        });
      }

      url += `?${params.toString()}`;
    }

    return this.http.get<WishlistWithGifts>(url);
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

  checkAccess(id: string) {
    return this.http.get<AccessType | undefined>(`/wishlists/${id}/access/check`);
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
