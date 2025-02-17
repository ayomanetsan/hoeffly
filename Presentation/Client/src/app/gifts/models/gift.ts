export interface GiftResponse {
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
