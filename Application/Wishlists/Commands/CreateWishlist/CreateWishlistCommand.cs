namespace Application.Wishlists.Commands.CreateWishlist;

public record CreateWishlistCommand(string Name, bool IsPublic, IEnumerable<string> categories) : IRequest<Unit>;
