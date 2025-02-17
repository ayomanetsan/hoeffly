import { PagedResponse } from '../../shared/models/pagedResponse';
import { GiftResponse } from '../../gifts/models/gift';

export interface WishlistBriefResponse {
  id: string;
  name: string;
  isPublic: boolean;
  categories: string[];
  createdAt: Date;
  photoUrls: string[];
  giftsCount: number;
}

export interface WishlistCreateRequest {
  name: string;
  isPublic: boolean;
  categories: string[];
}

export interface WishlistUpdateRequest {
  id: string;
  name: string;
  isPublic: boolean;
  categories: string[];
}

export interface WishlistWithGifts {
  name: string
  gifts: PagedResponse<GiftResponse>
}