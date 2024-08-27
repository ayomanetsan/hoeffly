namespace Domain.Entities;

public class Wishlist : EntityBase
{
    public required string Name { get; set; }
    
    public bool IsPublic { get; set; }
    
    public ICollection<AccessRights> AccessRights { get; set; } = new List<AccessRights>();
    
    public ICollection<WishlistCategory> WishlistCategories { get; set; } = new List<WishlistCategory>();
    
    public ICollection<Team> Teams { get; set; } = new List<Team>();
    
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}