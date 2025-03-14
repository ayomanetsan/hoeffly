using Application.Common.Models;

namespace Application.Wishlists.Queries.GetWishlistAccessRights;

public class GetWishlistAccessRightsQueryHandler(IWishlistAccessService wishlistService, IMapper mapper)
    : IRequestHandler<GetWishlistAccessRightsQuery, PageResponse<AccessRightResponse>>
{
    public async Task<PageResponse<AccessRightResponse>> Handle(GetWishlistAccessRightsQuery request, CancellationToken cancellationToken)
    {
        var (accessRights, totalPages) = await wishlistService.GetWishlistAccessRightAsync(
            request.WishlistId,
            request.PageNumber, 
            request.PageSize, 
            cancellationToken);

        var mappedAccessRights = mapper.Map<IEnumerable<AccessRightResponse>>(accessRights);
        
        return new PageResponse<AccessRightResponse>(
            mappedAccessRights, 
            request.PageNumber, 
            request.PageSize, 
            totalPages);
    }
}
