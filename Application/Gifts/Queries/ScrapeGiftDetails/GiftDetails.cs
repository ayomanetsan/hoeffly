namespace Application.Gifts.Queries.ScrapeGiftDetails;

public record GiftDetails
(
    string Name = "",
    decimal? Price = null,
    string Currency = "",
    string ImageUrl = ""    
)
{
    public static readonly GiftDetails Empty = new();
    
    public bool IsEmpty => 
        string.IsNullOrEmpty(Name) && 
        Price == null && 
        string.IsNullOrEmpty(Currency) && 
        string.IsNullOrEmpty(ImageUrl);
}