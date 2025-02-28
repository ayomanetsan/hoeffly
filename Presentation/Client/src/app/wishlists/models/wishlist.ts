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
  occasionDate: Date;
}

export interface WishlistCreateRequest {
  name: string;
  isPublic: boolean;
  categories: string[];
  occasionDate: Date;
}

export interface WishlistUpdateRequest {
  id: string;
  name: string;
  isPublic: boolean;
  categories: string[];
  occasionDate: Date;
}

export interface WishlistWithGifts {
  name: string
  gifts: PagedResponse<GiftResponse>
}
