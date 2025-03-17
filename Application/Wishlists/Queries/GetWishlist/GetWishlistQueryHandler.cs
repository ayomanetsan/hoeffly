using Application.Common.Models;
using Application.Gifts.Queries;

namespace Application.Wishlists.Queries.GetWishlist;

public class GetWishlistQueryHandler : IRequestHandler<GetWishlistQuery, WishlistResponse>
{
    private readonly IWishlistService _wishlistService;
    private readonly IMapper _mapper;

    public GetWishlistQueryHandler(IWishlistService wishlistService, IMapper mapper)
    {
        _wishlistService = wishlistService;
        _mapper = mapper;
    }
    
    public async Task<WishlistResponse> Handle(GetWishlistQuery request, CancellationToken cancellationToken)
    {
        var wishlist = await _wishlistService.GetWishlistAsync(request.Id, cancellationToken);
        var (gifts, totalPages) = await _wishlistService.GetPagedGiftsAsync(
            request.Id, 
            request.PageNumber, 
            request.PageSize,
            request.Filters,
            cancellationToken);
        
        return new WishlistResponse
        {
            Name = wishlist.Name,
            Gifts = new PageResponse<GiftResponse>(
                _mapper.Map<IEnumerable<GiftResponse>>(gifts),
                request.PageNumber,
                request.PageSize,
                totalPages
            )
        };
    }
}
