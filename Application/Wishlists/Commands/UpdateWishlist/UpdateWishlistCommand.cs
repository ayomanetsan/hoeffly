namespace Application.Wishlists.Commands.UpdateWishlist;

public record UpdateWishlistCommand(Guid Id, string Name, DateTimeOffset OccasionDate, bool IsPublic, IEnumerable<string> categories) : IRequest<Unit>;
