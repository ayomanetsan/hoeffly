namespace Application.Wishlists.Commands.CreateWishlist;

public sealed class CreateWishlistCommandProfile : Profile
{
    public CreateWishlistCommandProfile()
    {
        CreateMap<CreateWishlistCommand, Wishlist>();
    }
}
