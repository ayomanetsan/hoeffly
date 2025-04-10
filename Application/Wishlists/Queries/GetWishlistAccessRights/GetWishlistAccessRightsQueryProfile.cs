namespace Application.Wishlists.Queries.GetWishlistAccessRights;

public sealed class GetWishlistAccessRightsQueryProfile : Profile
{
    public GetWishlistAccessRightsQueryProfile()
    {
        CreateMap<AccessRights, AccessRightResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
    }
}
