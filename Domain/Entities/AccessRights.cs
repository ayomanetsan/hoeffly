using Domain.Enums;

namespace Domain.Entities;

public class AccessRights : EntityBase
{
    public AccessType Type { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid WishlistId { get; set; }

    public Wishlist Wishlist { get; set; } = null!;
}