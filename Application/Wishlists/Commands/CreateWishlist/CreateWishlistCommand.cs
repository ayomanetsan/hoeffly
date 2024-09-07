namespace Application.Wishlists.Commands.CreateWishlist;

public record CreateWishlistCommand(string Name, bool IsPublic) : IRequest<Unit>;
