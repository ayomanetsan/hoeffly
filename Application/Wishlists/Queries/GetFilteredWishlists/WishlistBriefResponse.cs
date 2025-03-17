namespace Application.Wishlists.Queries.GetFilteredWishlists;

public record WishlistBriefResponse(
    Guid Id,
    string Name, 
    bool IsPublic,
    DateTimeOffset OccasionDate,
    IEnumerable<string> Categories, 
    DateTimeOffset CreatedAt, 
    IEnumerable<string> PhotoUrls, 
    int GiftsCount) 
{
    public WishlistBriefResponse() : this(Guid.Empty, "", false, new DateTimeOffset(), new List<string>(), new DateTimeOffset(), new List<string>(), 0){ }
};
