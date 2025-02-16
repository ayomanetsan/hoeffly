namespace Application.Wishlists.Queries.GetWishlistById;

public record GetWishlistQuery(Guid Id, int PageNumber = 1, int PageSize = 10) 
    : IRequest<WishlistResponse>;
