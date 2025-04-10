using Domain.Enums;

namespace Domain.Entities;

public class Gift : EntityBase
{
    public required string Name { get; set; }

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public string? Note { get; set; }

    public string? ShopLink { get; set; }

    public string? PhotoLink { get; set; }

    public string? ThumbnailLink { get; set; }

    public double Price { get; set; }

    public Currency Currency { get; set; }

    public PriorityLevel Priority { get; set; }

    public int LikeCount { get; set; }

    public bool IsReserved { get; set; }

    public ICollection<SharedGift> SharedGifts { get; set; } = new List<SharedGift>();

    public Guid WishlistId { get; set; }

    public Wishlist Wishlist { get; set; } = null!;
}