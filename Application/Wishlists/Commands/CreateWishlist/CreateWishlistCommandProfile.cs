namespace Application.Wishlists.Commands.CreateWishlist;

public class CreateWishlistCommandProfile : Profile
{
    public CreateWishlistCommandProfile()
    {
        CreateMap<CreateWishlistCommand, Wishlist>();
    }
}
