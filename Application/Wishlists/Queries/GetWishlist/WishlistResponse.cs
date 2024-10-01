namespace Application.Wishlists.Queries.GetWishlistById;

public record WishlistResponse
{
    public required string Name { get; set; }
    
    //TODO: Add fields
    
    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Wishlist, WishlistResponse>();
        }
    }
}
