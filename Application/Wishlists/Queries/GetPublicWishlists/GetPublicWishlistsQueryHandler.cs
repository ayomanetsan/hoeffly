using Application.Common.Models;
using Application.Wishlists.Queries.GetFilteredWishlists;

namespace Application.Wishlists.Queries.GetPublicWishlists;

public class GetPublicWishlistsQueryHandler(IWishlistService wishlistService, IMapper mapper) : IRequestHandler<GetPublicWishlistsQuery, PageResponse<WishlistBriefResponse>>
{
    public async Task<PageResponse<WishlistBriefResponse>> Handle(GetPublicWishlistsQuery request, CancellationToken cancellationToken)
    {
        var (wishlists, totalPages) = await wishlistService.GetPublicWishlistsAsync(
            request.PageNumber, 
            request.PageSize, 
            cancellationToken);

        var mappedWishlists = mapper.Map<IEnumerable<WishlistBriefResponse>>(wishlists);

        return new PageResponse<WishlistBriefResponse>(
            mappedWishlists, 
            request.PageNumber, 
            request.PageSize, 
            totalPages);
    }
}