using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Application.Common.Models;
using Domain.Enums;
using Domain.Exceptions;

namespace Infrastructure.Services;

public class WishlistService : IWishlistService, IWishlistAccessService
{
    private readonly IRepository<Wishlist> _wishlistRepository;
    private readonly IRepository<WishlistCategory> _wishlistCategoryRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Gift> _giftRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<AccessRights> _accessRightsRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUnitOfWork _unitOfWork;


    public WishlistService(
        IRepository<Wishlist> wishlistRepository,
        IRepository<WishlistCategory> wishlistCategoryRepository, 
        IRepository<Category> categoryRepository, 
        IRepository<Gift> giftRepository, 
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork, 
        IRepository<User> userRepository, 
        IRepository<AccessRights> accessRightsRepository
        ) 
    {
        _wishlistRepository = wishlistRepository;
        _wishlistCategoryRepository = wishlistCategoryRepository;
        _categoryRepository = categoryRepository;
        _giftRepository = giftRepository;
        _httpContextAccessor = httpContextAccessor;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _accessRightsRepository = accessRightsRepository;
    }

    public async Task<(IEnumerable<Wishlist> wishlists, int totalPages)> GetWishlistsAsync(int accessType,
        int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var currentUserEmail = GetUserEmailFromContext();
        var currentUser = await _userRepository
            .GetQueryable()
            .Where(u => u.Email == currentUserEmail)
            .FirstOrDefaultAsync(cancellationToken);
        if (currentUser == null)
        {
            throw new NotFoundException($"User with email {currentUserEmail} not found.");
        }
        
        var wishlistIds = await _accessRightsRepository
            .GetQueryable()
            .Where(ar => ar.UserId == currentUser.Id && ar.Type == (AccessType)accessType).
            Select(ar => ar.WishlistId)
            .ToListAsync(cancellationToken);
        
        var queryable = _wishlistRepository
            .GetQueryable()
            .Where(w => wishlistIds.Contains(w.Id));

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
        
        var currentUserEmail = GetUserEmailFromContext();
        var currentUser = await _userRepository
            .GetQueryable()
            .Where(u => u.Email == currentUserEmail)
            .FirstOrDefaultAsync(cancellationToken);
    
        if (currentUser == null)
        {
            throw new NotFoundException($"User with email {currentUserEmail} not found.");
        }
        var accessRight = new AccessRights
        {
            WishlistId = wishlist.Id,
            UserId = currentUser.Id,
            Type = AccessType.Owner,
            CreatedBy = currentUserEmail,
            LastModifiedBy = currentUserEmail,
        };
        
        await _accessRightsRepository.AddAsync(accessRight, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateWishlistAsync(Wishlist updatedWishlist, IEnumerable<string> categories, CancellationToken cancellationToken)
    {
        var wishlist = await _wishlistRepository.GetAsync(updatedWishlist.Id, cancellationToken)
                       ?? throw new NotFoundException("Wishlist not found.");
        
        wishlist.Name = updatedWishlist.Name;
        wishlist.IsPublic = updatedWishlist.IsPublic;
        wishlist.OccasionDate = updatedWishlist.OccasionDate;
        
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
        
        // TODO: Update the 
        if (await CheckAccessRightsAsync(id, cancellationToken) == null)
        {
            throw new ForbiddenException("You are not authorized to view this wishlist.");
        }

        return wishlist;
    }
    
    public async Task<(IEnumerable<Gift> gifts, int totalPages)> GetPagedGiftsAsync(
        Guid wishlistId, 
        int pageNumber, 
        int pageSize, 
        GiftFilterParameters? filters,
        CancellationToken cancellationToken)
    {
        var giftsQuery = _giftRepository.GetQueryable()
            .Where(g => g.WishlistId == wishlistId);
        
        if (filters != null)
        {
            if (filters.CategoryNames != null && filters.CategoryNames.Any())
            {
                var categoryIds = await _categoryRepository.GetQueryable()
                    .Where(c => filters.CategoryNames.Contains(c.Name))
                    .Select(c => c.Id)
                    .ToListAsync(cancellationToken);
                
                giftsQuery = giftsQuery.Where(g => categoryIds.Contains(g.CategoryId));
            }

            if (filters.IsReserved.HasValue)
            {
                giftsQuery = giftsQuery.Where(g => g.IsReserved == filters.IsReserved.Value);
            }

            if (filters.Priorities != null && filters.Priorities.Any())
            {
                giftsQuery = giftsQuery.Where(g => filters.Priorities.Contains(g.Priority));
            }
        }
        
        giftsQuery = giftsQuery
            .Include(g => g.Category)
            .Include(g => g.SharedGifts)
            .ThenInclude(sg => sg.User);

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
    
    private string GetUserEmailFromContext() => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
    
    public async Task<Guid> ShareWishlistAsync(AccessRights accessRight, string email, CancellationToken cancellationToken)
    {
        var sharedFromEmail = GetUserEmailFromContext();
        var sharedFrom = await _userRepository
            .GetQueryable()
            .Where(u => u.Email == sharedFromEmail)
            .FirstOrDefaultAsync(cancellationToken);
    
        if (sharedFrom == null)
        {
            throw new NotFoundException($"User with email {sharedFromEmail} not found.");
        }

        var sharedTo = await _userRepository
            .GetQueryable()
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync(cancellationToken);
        
        if (sharedTo == null)
        {
            throw new NotFoundException($"User with email {email} not found.");
        }
        
        var wishlist = await _wishlistRepository
            .GetQueryable()
            .Where(w => w.Id == accessRight.WishlistId)
            .FirstOrDefaultAsync(cancellationToken);

        if (wishlist == null)
        {
            throw new NotFoundException($"Wishlist with ID {accessRight.WishlistId} not found.");
        }
        
        var existingAccess = await _accessRightsRepository
            .GetQueryable()
            .Where(a => a.WishlistId == accessRight.WishlistId && a.UserId == sharedTo.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingAccess != null)
        {
            existingAccess.Type = accessRight.Type;
            _accessRightsRepository.Update(existingAccess);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return existingAccess.Id;
        }
        
        accessRight.UserId = sharedTo.Id;
        await _accessRightsRepository.AddAsync(accessRight, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return accessRight.Id;
    }

    public async Task RevokeWishlistAccessAsync(Guid accessRightId, CancellationToken cancellationToken)
    {
        var accessRight = await _accessRightsRepository.GetAsync(accessRightId, cancellationToken)
                            ?? throw new NotFoundException("Access right not found.");
        
        var wishlist = await _wishlistRepository.GetAsync(accessRight.WishlistId, cancellationToken)
                       ?? throw new NotFoundException("Wishlist not found.");
        
        var email = GetUserEmailFromContext();

        if (wishlist.CreatedBy != email)
        {
            throw new ForbiddenException("You are not authorized to delete this access right.");
        }
        
        _accessRightsRepository.Delete(accessRight);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<(IEnumerable<AccessRights> accessRights, int totalPages)> GetWishlistAccessRightAsync(Guid wishlistId, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        if (!await _wishlistRepository.ExistsAsync(wishlistId, cancellationToken))
        {
            throw new NotFoundException("Wishlist not found.");
        }
        
        var queryable = _accessRightsRepository
            .GetQueryable()
            .AsNoTracking()
            .Where(a => a.WishlistId == wishlistId)
            .Include(a => a.User);
        
        var totalItems = await queryable.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        
        var accessRights = await queryable
            .OrderBy(a => a.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        
        return (accessRights, totalPages);
    }
    
    public async Task<AccessType?> CheckAccessRightsAsync(Guid requestWishlistId, CancellationToken cancellationToken)
    {
        var accessType = (await _accessRightsRepository.GetQueryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.WishlistId == requestWishlistId && a.User.Email == GetUserEmailFromContext(), cancellationToken))?.Type;

        if (accessType != null)
        {
            return accessType;
        }
        
        var isPublic = await _wishlistRepository.GetQueryable()
            .AsNoTracking()
            .AnyAsync(w => w.IsPublic && w.Id == requestWishlistId, cancellationToken);
        
        return isPublic ? AccessType.Viewer : null;
    }
}