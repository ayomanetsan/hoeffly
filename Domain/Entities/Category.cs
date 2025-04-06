using Domain.Enums;

namespace Domain.Entities;

public class Category : EntityBase
{
    public required string Name { get; set; }

    public CategoryType Type { get; set; }

    public ICollection<WishlistCategory> WishlistCategories { get; set; } = new List<WishlistCategory>();
}