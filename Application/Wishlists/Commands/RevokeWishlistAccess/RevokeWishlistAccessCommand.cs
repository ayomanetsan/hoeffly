namespace Application.Wishlists.Commands.DeleteWishlistAccess;

public record RevokeWishlistAccessCommand(Guid AccessRightId): IRequest<Unit>;