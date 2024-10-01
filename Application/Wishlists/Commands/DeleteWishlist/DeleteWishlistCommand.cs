namespace Application.Wishlists.Commands.DeleteWishlist;

public record DeleteWishlistCommand(Guid Id) : IRequest<Unit>;
