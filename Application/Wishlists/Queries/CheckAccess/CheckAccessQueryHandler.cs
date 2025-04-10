using Domain.Enums;

namespace Application.Wishlists.Queries.CheckAccess;

public sealed class CheckAccessQueryHandler(IWishlistService wishlistService)
    : IRequestHandler<CheckAccessQuery, AccessType?>
{
    public async Task<AccessType?> Handle(CheckAccessQuery request, CancellationToken cancellationToken)
    {
        var accessRights = await wishlistService.CheckAccessRightsAsync(request.WishlistId, cancellationToken);
        return accessRights;
    }
}