namespace Application.Wishlists.Queries.GetFilteredWishlists;

public class GetFilteredWishlistsQueryProfile : Profile
{
    public GetFilteredWishlistsQueryProfile()
    {
        CreateMap<Wishlist, WishlistBriefResponse>()
            .ForMember(dest => dest.Categories,opt => opt.MapFrom(src => src.WishlistCategories.Select(wc => wc.Category.Name)))
            .ForMember(dest => dest.PhotoUrls, opt => opt.MapFrom(src => src.Gifts.Select(g => g.PhotoLink)))
            .ForMember(dest => dest.GiftsCount, opt => opt.MapFrom(src => src.Gifts.Count));
    }
}