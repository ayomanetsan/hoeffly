using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        var categories = SeedCategories();
        builder.HasData(categories);
    }

    private IEnumerable<Category> SeedCategories()
    {
        var categories = new string[]
        {
            "Home",
            "Fashion",
            "Electronics",
            "Books",
            "Personal care",
            "Sports",
            "Toys",
            "Jewelery",
            "Kitchen",
            "Experiences",
            "Wellness",
            "Music",
            "Office",
            "Garden",
            "Gourmet"
        };

        return categories.Select(name => new Category
        {
            Id = Guid.NewGuid(), Name = name, CreatedBy = "system", CreatedAt = DateTimeOffset.UtcNow, LastModifiedBy = "system"
        }).ToList();
    }
}