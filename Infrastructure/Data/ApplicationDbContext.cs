using System.Reflection;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    
    public DbSet<Wishlist> Wishlists => Set<Wishlist>();
    
    public DbSet<Gift> Gifts => Set<Gift>();
    
    public DbSet<Team> Teams => Set<Team>();
    
    public DbSet<Friendship> Friendships => Set<Friendship>();
    
    public DbSet<AccessRights> AccessRights => Set<AccessRights>();
    
    public DbSet<Occasion> Occasions => Set<Occasion>();
    
    public DbSet<WishlistCategory> WishlistCategories => Set<WishlistCategory>();
    
    public DbSet<Category> Categories => Set<Category>();
    
    public DbSet<SharedGift> SharedGifts => Set<SharedGift>();
    
    public DbSet<TeamUser> TeamUsers => Set<TeamUser>();
    
    public DbSet<Message> Messages => Set<Message>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}