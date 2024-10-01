using Application.Common.Models;

namespace Application.Wishlists.Queries.GetFilteredWishlists;

public sealed class GetFilteredWishlistsQueryHandler :
    IRequestHandler<GetFilteredWishlistsQuery, PageResponse<WishlistBriefResponse>>
{
    private readonly IWishlistService _wishlistService;
    private readonly IMapper _mapper;

    public GetFilteredWishlistsQueryHandler(IWishlistService wishlistService, IMapper mapper)
    {
        _wishlistService = wishlistService;
        _mapper = mapper;
    }

    public async Task<PageResponse<WishlistBriefResponse>> Handle(GetFilteredWishlistsQuery request, 
        CancellationToken cancellationToken)
    {
        var (wishlists, totalPages) = await _wishlistService.GetWishlistsAsync(
            request.CreatedByCurrentUser, 
            request.PageNumber, 
            request.PageSize, 
            cancellationToken);

        var mappedWishlists = _mapper.Map<IEnumerable<WishlistBriefResponse>>(wishlists);

        return new PageResponse<WishlistBriefResponse>(
            mappedWishlists, 
            request.PageNumber, 
            request.PageSize, 
            totalPages);
    }
}