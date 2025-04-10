using Application.Common.Models;
using Application.Gifts.Queries;

namespace Application.Wishlists.Queries.GetWishlist;

public record WishlistResponse
{
    public required string Name { get; set; }

    public required PageResponse<GiftResponse> Gifts { get; set; } = null!;

    private sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Wishlist, WishlistResponse>();
        }
    }
}
