namespace Application.Wishlists.Commands.RevokeWishlistAccess;

public record RevokeWishlistAccessCommand(Guid AccessRightId) : IRequest<Unit>;
