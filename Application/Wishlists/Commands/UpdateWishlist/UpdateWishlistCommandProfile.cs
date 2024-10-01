namespace Application.Wishlists.Commands.UpdateWishlist;

public class UpdateWishlistCommandProfile : Profile
{
    public UpdateWishlistCommandProfile()
    {
        CreateMap<UpdateWishlistCommand, Wishlist>();
    }
}
