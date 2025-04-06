namespace Application.Wishlists.Commands.ShareWishlist;

public sealed class ShareWishlistCommandProfile : Profile
{
    public ShareWishlistCommandProfile()
    {
        CreateMap<ShareWishlistCommand, AccessRights>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.AccessType));
    }
}
