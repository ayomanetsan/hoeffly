using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services;

public class WishlistService : IWishlistService
{
    private readonly IRepository<Wishlist> _wishlistRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WishlistService(IRepository<Wishlist> wishlistRepository, IHttpContextAccessor httpContextAccessor)
    {
        _wishlistRepository = wishlistRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<(IEnumerable<Wishlist> wishlists, int totalPages)> GetWishlistsAsync(bool createdByCurrentUser,
        int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var queryable = _wishlistRepository.GetQueryable();

        queryable = createdByCurrentUser
            ? FilterByCurrentUser(queryable)
            : queryable.Where(w => w.IsPublic);

        var totalItems = await queryable.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        var wishlists = await queryable
            .AsNoTracking()
            .OrderByDescending(w => w.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(w => w.Gifts)
            .ToListAsync(cancellationToken);
    
        return (wishlists, totalPages);
    }
    
    private IQueryable<Wishlist> FilterByCurrentUser(IQueryable<Wishlist> queryable)
    {
        var email = GetUserEmailFromContext();
        return queryable.Where(w => w.CreatedBy == email);
    }
    
    private string GetUserEmailFromContext() => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
}