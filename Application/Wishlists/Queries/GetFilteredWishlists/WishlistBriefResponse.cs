namespace Application.Wishlists.Queries.GetFilteredWishlists;

public record WishlistBriefResponse(
    string Name, 
    bool IsPublic, 
    IEnumerable<string> Categories, 
    DateTimeOffset CreatedAt, 
    IEnumerable<string> PhotoUrls, 
    int GiftsCount)
{
    public WishlistBriefResponse() : this("", false, new List<string>(), new DateTimeOffset(), new List<string>(), 0){ }
};
