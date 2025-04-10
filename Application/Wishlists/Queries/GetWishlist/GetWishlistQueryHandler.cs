using Application.Common.Models;
using Application.Gifts.Queries;

namespace Application.Wishlists.Queries.GetWishlist;

public class GetWishlistQueryHandler(IWishlistService wishlistService, IMapper mapper)
    : IRequestHandler<GetWishlistQuery, WishlistResponse>
{
    public async Task<WishlistResponse> Handle(GetWishlistQuery request, CancellationToken cancellationToken)
    {
        var wishlist = await wishlistService.GetWishlistAsync(request.Id, cancellationToken);
        var (gifts, totalPages) = await wishlistService.GetPagedGiftsAsync(
            request.Id,
            request.PageNumber,
            request.PageSize,
            request.Filters,
            cancellationToken);

        return new WishlistResponse
        {
            Name = wishlist.Name,
            Gifts = new PageResponse<GiftResponse>(
                mapper.Map<IEnumerable<GiftResponse>>(gifts),
                request.PageNumber,
                request.PageSize,
                totalPages),
        };
    }
}
