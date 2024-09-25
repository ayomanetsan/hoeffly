export interface WishlistBriefResponse {
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
