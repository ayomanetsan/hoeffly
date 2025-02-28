namespace Application.Wishlists.Commands.CreateWishlist;

public record CreateWishlistCommand(string Name, bool IsPublic, DateTimeOffset OccasionDate, IEnumerable<string> categories) : IRequest<Unit>;
