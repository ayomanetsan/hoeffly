namespace Domain.Entities;

public class Team : EntityBase
{
    public required string Name { get; set; }
    
    public Guid WishlistId { get; set; }
    
    public Wishlist Wishlist { get; set; } = null!;
    
    public ICollection<TeamUser> TeamUsers { get; set; } = new List<TeamUser>();
    
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}