namespace Domain.Entities;

public class WishlistCategory : EntityBase
{
    public Guid WishlistId { get; set; }
    
    public Wishlist Wishlist { get; set; } = null!;
    
    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}