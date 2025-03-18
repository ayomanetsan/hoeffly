import { DropdownOption } from '../../shared/models/dropdownOption';

export interface GiftResponse {
    id: string
    name: string
    categoryId: string
    categoryName: string
    note: string
    shopLink: string
    photoLink: string
    thumbnailLink: string
    price: number
    currency: Currency
    priority: number
    likeCount: number
    isReserved: boolean
    sharedGifts: SharedGiftResponse[]
}

export enum Currency {
    EUR = 0,
    UAH = 1,
    USD = 2,
}

export enum Priority {
    MustHave,
    ReallyWanted,
    WouldLike,
    NiceToHave,
    Optional
}

export interface SharedGiftResponse {
  userEmail: string;
  status: SharedGiftStatus;
}

export enum SharedGiftStatus {
  Pending,
  Accepted,
  Primary
}

export enum ReserveAction {
  Reserve,
  CancelReservation,
  RequestSharedReservation
}

export interface GiftCreateRequest {
  name: string;
  categoryName: string;
  note: string;
  shopLink: string;
  photoLink: string;
  thumbnailLink: string;
  price: number;
  currency: Currency;
  priority: number;
  wishlistId: string;
}

export interface GiftUpdateRequest extends GiftCreateRequest {
  id: string;
}

export interface AcceptGiftReservationRequest {
  giftId: string;
  email: string;
}

export interface GiftDetails {
  name: string;
  price: number;
  currency: string;
  imageUrl: string;
  isEmpty: boolean;
}

export const GiftCategories: DropdownOption[] = [
    { value: 'Home', text: 'Home' },
    { value: 'Fashion', text: 'Fashion' },
    { value: 'Electronics', text: 'Electronics' },
    { value: 'Books', text: 'Books' },
    { value: 'Personal care', text: 'Personal care' },
    { value: 'Sports', text: 'Sports' },
    { value: 'Toys', text: 'Toys' },
    { value: 'Jewelry', text: 'Jewelry' },
    { value: 'Kitchen', text: 'Kitchen' },
    { value: 'Experiences', text: 'Experiences' },
    { value: 'Wellness', text: 'Wellness' },
    { value: 'Music', text: 'Music' },
    { value: 'Office', text: 'Office' },
    { value: 'Garden', text: 'Garden' },
    { value: 'Gourmet', text: 'Gourmet' }
];

export const CurrencyCategories: DropdownOption[] = [
    { value: Currency.EUR, text: 'EUR' },
    { value: Currency.UAH, text: 'UAH' },
    { value: Currency.USD, text: 'USD' }
];

export const PriorityCategories: DropdownOption[] = [
    { value: Priority.MustHave, text: 'Must Have' },
    { value: Priority.ReallyWanted, text: 'Really Wanted' },
    { value: Priority.WouldLike, text: 'Would Like' },
    { value: Priority.NiceToHave, text: 'Nice to Have' },
    { value: Priority.Optional, text: 'Optional' }
];

export const ReservationCategories: DropdownOption[] = [
  { value: true, text: 'Reserved' },
  { value: false, text: 'Not reserved' },
];
