using Application.Common.Models;

namespace Application.Wishlists.Queries.GetFilteredWishlists;

public sealed class GetFilteredWishlistsQueryHandler(IWishlistService wishlistService, IMapper mapper) :
    IRequestHandler<GetFilteredWishlistsQuery, PageResponse<WishlistBriefResponse>>
{
    public async Task<PageResponse<WishlistBriefResponse>> Handle(
        GetFilteredWishlistsQuery request,
        CancellationToken cancellationToken)
    {
        var (wishlists, totalPages) = await wishlistService.GetWishlistsAsync(
            request.AccessType,
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