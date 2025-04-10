namespace Application.Wishlists.Commands.UpdateWishlist;

public sealed class UpdateWishlistCommandProfile : Profile
{
    public UpdateWishlistCommandProfile()
    {
        CreateMap<UpdateWishlistCommand, Wishlist>();
    }
}
