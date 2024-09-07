namespace Application.Wishlists.Queries.GetWishlistById;

public record GetWishlistQuery(Guid Id) : IRequest<WishlistResponse>;
