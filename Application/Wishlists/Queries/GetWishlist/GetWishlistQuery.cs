using Application.Common.Models;

namespace Application.Wishlists.Queries.GetWishlist;

public record GetWishlistQuery(Guid Id, int PageNumber = 1, int PageSize = 10, GiftFilterParameters? Filters = null) 
    : IRequest<WishlistResponse>;
