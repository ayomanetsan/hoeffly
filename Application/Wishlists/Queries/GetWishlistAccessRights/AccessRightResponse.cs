using Domain.Enums;

namespace Application.Wishlists.Queries.GetWishlistAccessRights;

public record AccessRightResponse(
    AccessType Type,
    string Name,
    string Email
    )
{
    public AccessRightResponse() : this(AccessType.Owner,"", ""){ }
}
