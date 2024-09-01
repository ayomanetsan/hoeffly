namespace Domain.Entities;

public class Gift : EntityBase
{
    public required string Name { get; set; }
    
    public required string Category { get; set; }
    
    public byte[]? Photo { get; set; }
    
    public string? PhotoLink { get; set; }
    
    public double Price { get; set; }
    
    public byte Priority { get; set; }
    
    public int LikeCount { get; set; }
    
    public bool IsReserved { get; set; }
    
    public ICollection<SharedGift> SharedGifts { get; set; } = new List<SharedGift>();
    
    public Guid WishlistId { get; set; }

    public Wishlist Wishlist { get; set; } = null!;
}