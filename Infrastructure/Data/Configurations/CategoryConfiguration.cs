using Domain.Enums;
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
        var wishlistCategories = new[]
        {
            "New Year",
            "Birthday",
            "Christmas",
            "Anniversary",
            "Valentine's Day",
            "Wedding",
            "Baby Shower",
            "Graduation",
            "Housewarming",
            "Retirement",
            "Easter",
            "Halloween",
            "Thanksgiving",
            "Black Friday",
            "Summer Vacation",
        };

        var giftCategories = new[]
        {
            "Home",
            "Fashion",
            "Electronics",
            "Books",
            "Personal Care",
            "Sports",
            "Toys",
            "Jewelry",
            "Kitchen",
            "Experiences",
            "Wellness",
            "Music",
            "Office",
            "Garden",
            "Gourmet"
        };

        return CreateCategories(wishlistCategories, CategoryType.Wishlist)
            .Concat(CreateCategories(giftCategories, CategoryType.Gift))
            .ToList();
    }

    private IEnumerable<Category> CreateCategories(IEnumerable<string> names, CategoryType categoryType)
    {
        return names.Select(name => new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            Type = categoryType,
            CreatedBy = "system",
            CreatedAt = DateTimeOffset.UtcNow,
            LastModifiedBy = "system",
        });
    }
}
