namespace Domain.Entities;

public class Category : EntityBase
{
    public required string Name { get; set; }
    
    public ICollection<WishlistCategory> WishlistCategories { get; set; } = new List<WishlistCategory>();
}