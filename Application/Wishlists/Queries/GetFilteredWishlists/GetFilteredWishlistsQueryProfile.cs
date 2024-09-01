namespace Application.Wishlists.Queries.GetFilteredWishlists;

public class GetFilteredWishlistsQueryProfile : Profile
{
    public GetFilteredWishlistsQueryProfile()
    {
        CreateMap<Wishlist, WishlistBriefResponse>()
            .ForMember(dest => dest.GiftsCount, opt => opt.MapFrom(src => src.Gifts.Count));
    }
}