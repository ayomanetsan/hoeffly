using System.Reflection;
using System.Security.Claims;
using Domain.Common;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : DbContext(options)
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

    public override int SaveChanges()
    {
        ApplyAuditInfo();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditInfo();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditInfo()
    {
        ChangeTracker.DetectChanges();

        var currentUserEmail = GetUserEmailFromContext();
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is EntityBase && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            if (entry.Entity is EntityBase entity)
            {
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = currentUserEmail;
                    entity.CreatedAt = DateTime.UtcNow;
                }

                entity.LastModifiedBy = currentUserEmail;
                entity.LastModifiedAt = DateTime.UtcNow;
            }
        }
    }

    private string GetUserEmailFromContext() => httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
}