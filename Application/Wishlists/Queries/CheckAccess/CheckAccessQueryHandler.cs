using Domain.Enums;

namespace Application.Wishlists.Queries.CheckAccess;

public sealed class CheckAccessQueryHandler : IRequestHandler<CheckAccessQuery, AccessType?>
{
    private readonly IWishlistService _wishlistService;

    public CheckAccessQueryHandler(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }

    public async Task<AccessType?> Handle(CheckAccessQuery request, CancellationToken cancellationToken)
    {
        var accessRights = await _wishlistService.CheckAccessRightsAsync(request.WishlistId, cancellationToken);
        return accessRights;
    }
}