using Domain.Enums;

namespace Application.Wishlists.Queries.GetWishlistAccessRights;

public record AccessRightResponse(
    Guid Id,
    AccessType Type,
    string Name,
    string Email
    )
{
    public AccessRightResponse() : this(Guid.Empty, AccessType.Owner,"", ""){ }
}
