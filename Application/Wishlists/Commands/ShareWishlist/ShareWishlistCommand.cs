using Domain.Enums;

namespace Application.Wishlists.Commands.ShareWishlist;

public record ShareWishlistCommand(Guid WishlistId, string Email, AccessType AccessType) : IRequest<Unit>;
