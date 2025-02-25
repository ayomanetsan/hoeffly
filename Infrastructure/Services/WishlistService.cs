using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Domain.Exceptions;

namespace Infrastructure.Services;

public class WishlistService : IWishlistService
{
    private readonly IRepository<Wishlist> _wishlistRepository;
    private readonly IRepository<WishlistCategory> _wishlistCategoryRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Gift> _giftRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUnitOfWork _unitOfWork;


    public WishlistService(IRepository<Wishlist> wishlistRepository,
        IRepository<WishlistCategory> wishlistCategoryRepository, 
        IRepository<Category> categoryRepository, 
        IRepository<Gift> giftRepository, 
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
    )
    {
        _wishlistRepository = wishlistRepository;
        _wishlistCategoryRepository = wishlistCategoryRepository;
        _categoryRepository = categoryRepository;
        _giftRepository = giftRepository;
        _httpContextAccessor = httpContextAccessor;
        _unitOfWork = unitOfWork;
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
            .Include(w => w.WishlistCategories)
            .ThenInclude(wc => wc.Category)
            .ToListAsync(cancellationToken);
    
        return (wishlists, totalPages);
    }

    public async Task CreateWishlistAsync(Wishlist wishlist, IEnumerable<string> categories, CancellationToken cancellationToken)
    {
        foreach (var category in categories)
        {
            var dbCategory = await _categoryRepository.GetQueryable()
                .AsNoTracking()
                .Where(c => c.Name == category)
                .FirstAsync(cancellationToken);
            
            var wishlistCategory = new WishlistCategory()
            {
                CategoryId = dbCategory.Id,
                WishlistId = wishlist.Id,
                CreatedBy = GetUserEmailFromContext(),
                LastModifiedBy = GetUserEmailFromContext()
            };
            
            await _wishlistCategoryRepository.AddAsync(wishlistCategory, cancellationToken);
            
            wishlist.WishlistCategories.Add(wishlistCategory);
        }
        await _wishlistRepository.AddAsync(wishlist, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateWishlistAsync(Wishlist updatedWishlist, IEnumerable<string> categories, CancellationToken cancellationToken)
    {
        var wishlist = await _wishlistRepository.GetAsync(updatedWishlist.Id, cancellationToken)
                       ?? throw new NotFoundException("Wishlist not found.");
        
        wishlist.Name = updatedWishlist.Name;
        wishlist.IsPublic = updatedWishlist.IsPublic;
        
        var existingWishlistCategories = await _wishlistCategoryRepository.GetQueryable()
            .Where(wc => wc.WishlistId == wishlist.Id)
            .ToListAsync(cancellationToken);

        foreach (var existingWishlistCategory in existingWishlistCategories)
        {
            _wishlistCategoryRepository.Delete(existingWishlistCategory);
        }

        wishlist.WishlistCategories.Clear();
        
        foreach (var category in categories)
        {
            var dbCategory = await _categoryRepository.GetQueryable()
                .AsNoTracking()
                .Where(c => c.Name == category)
                .FirstAsync(cancellationToken);
            
            var wishlistCategory = new WishlistCategory()
            {
                CategoryId = dbCategory.Id,
                WishlistId = wishlist.Id,
                CreatedBy = GetUserEmailFromContext(),
                LastModifiedBy = GetUserEmailFromContext()
            };
            
            await _wishlistCategoryRepository.AddAsync(wishlistCategory, cancellationToken);
            
            wishlist.WishlistCategories.Add(wishlistCategory);
        }
        
        _wishlistRepository.Update(wishlist);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteWishlistAsync(Guid id, CancellationToken cancellationToken)
    {
        var wishlist = await _wishlistRepository.GetAsync(id, cancellationToken)
                       ?? throw new NotFoundException("Wishlist not found.");
        
        var email = GetUserEmailFromContext();

        if (wishlist.CreatedBy != email)
        {
            throw new ForbiddenException("You are not authorized to delete this wishlist.");
        }
        
        _wishlistRepository.Delete(wishlist);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Wishlist> GetWishlistAsync(Guid id, CancellationToken cancellationToken)
    {
        var wishlist = await _wishlistRepository.GetAsync(id, cancellationToken)
                       ?? throw new NotFoundException("Wishlist not found.");
        
        var email = GetUserEmailFromContext();

        if (wishlist.CreatedBy != email && !wishlist.IsPublic)
        {
            throw new ForbiddenException("You are not authorized to view this wishlist.");
        }

        return wishlist;
    }
    
    public async Task<(IEnumerable<Gift> gifts, int totalPages)> GetPagedGiftsAsync(Guid wishlistId, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var giftsQuery = _giftRepository.GetQueryable()
            .Where(g => g.WishlistId == wishlistId)
            .Include(g => g.Category);

        int totalGifts = await giftsQuery.CountAsync(cancellationToken);
        int totalPages = (int)Math.Ceiling(totalGifts / (double)pageSize);
        
        var gifts = await giftsQuery
            .AsNoTracking()
            .OrderByDescending(g => g.LikeCount)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (gifts, totalPages);
    }

    private IQueryable<Wishlist> FilterByCurrentUser(IQueryable<Wishlist> queryable)
    {
        var email = GetUserEmailFromContext();
        return queryable.Where(w => w.CreatedBy == email);
    }
    
    private string GetUserEmailFromContext() => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
}