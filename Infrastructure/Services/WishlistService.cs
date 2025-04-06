using System.Security.Claims;
using Application.Common.Models;
using Domain.Enums;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class WishlistService(
    IRepository<Wishlist> wishlistRepository,
    IRepository<WishlistCategory> wishlistCategoryRepository,
    IRepository<Category> categoryRepository,
    IRepository<Gift> giftRepository,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork,
    IRepository<User> userRepository,
    IRepository<AccessRights> accessRightsRepository)
    : IWishlistService, IWishlistAccessService
{
    public async Task<(IEnumerable<Wishlist> wishlists, int totalPages)> GetWishlistsAsync(
        int accessType,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken)
    {
        var currentUserEmail = GetUserEmailFromContext();
        var currentUser = await userRepository
            .GetQueryable()
            .Where(u => u.Email == currentUserEmail)
            .FirstOrDefaultAsync(cancellationToken);
        if (currentUser == null)
        {
            throw new NotFoundException($"User with email {currentUserEmail} not found.");
        }

        var wishlistIds = await accessRightsRepository
            .GetQueryable()
            .Where(ar => ar.UserId == currentUser.Id && ar.Type == (AccessType)accessType).
            Select(ar => ar.WishlistId)
            .ToListAsync(cancellationToken);

        var queryable = wishlistRepository
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
            var dbCategory = await categoryRepository.GetQueryable()
                .AsNoTracking()
                .Where(c => c.Name == category)
                .FirstAsync(cancellationToken);

            var wishlistCategory = new WishlistCategory()
            {
                CategoryId = dbCategory.Id,
                WishlistId = wishlist.Id,
                CreatedBy = GetUserEmailFromContext(),
                LastModifiedBy = GetUserEmailFromContext(),
            };

            await wishlistCategoryRepository.AddAsync(wishlistCategory, cancellationToken);

            wishlist.WishlistCategories.Add(wishlistCategory);
        }

        await wishlistRepository.AddAsync(wishlist, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var currentUserEmail = GetUserEmailFromContext();
        var currentUser = await userRepository
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

        await accessRightsRepository.AddAsync(accessRight, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateWishlistAsync(Wishlist wishlist, IEnumerable<string> categories, CancellationToken cancellationToken)
    {
        var updatedWishlist = await wishlistRepository.GetAsync(wishlist.Id, cancellationToken)
                              ?? throw new NotFoundException("Wishlist not found.");

        updatedWishlist.Name = wishlist.Name;
        updatedWishlist.IsPublic = wishlist.IsPublic;
        updatedWishlist.OccasionDate = wishlist.OccasionDate;

        var existingWishlistCategories = await wishlistCategoryRepository.GetQueryable()
            .Where(wc => wc.WishlistId == updatedWishlist.Id)
            .ToListAsync(cancellationToken);

        foreach (var existingWishlistCategory in existingWishlistCategories)
        {
            wishlistCategoryRepository.Delete(existingWishlistCategory);
        }

        updatedWishlist.WishlistCategories.Clear();

        foreach (var category in categories)
        {
            var dbCategory = await categoryRepository.GetQueryable()
                .AsNoTracking()
                .Where(c => c.Name == category)
                .FirstAsync(cancellationToken);

            var wishlistCategory = new WishlistCategory()
            {
                CategoryId = dbCategory.Id,
                WishlistId = updatedWishlist.Id,
                CreatedBy = GetUserEmailFromContext(),
                LastModifiedBy = GetUserEmailFromContext(),
            };

            await wishlistCategoryRepository.AddAsync(wishlistCategory, cancellationToken);

            updatedWishlist.WishlistCategories.Add(wishlistCategory);
        }

        wishlistRepository.Update(updatedWishlist);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteWishlistAsync(Guid id, CancellationToken cancellationToken)
    {
        var wishlist = await wishlistRepository.GetAsync(id, cancellationToken)
                       ?? throw new NotFoundException("Wishlist not found.");

        var email = GetUserEmailFromContext();

        if (wishlist.CreatedBy != email)
        {
            throw new ForbiddenException("You are not authorized to delete this wishlist.");
        }

        wishlistRepository.Delete(wishlist);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Wishlist> GetWishlistAsync(Guid id, CancellationToken cancellationToken)
    {
        var wishlist = await wishlistRepository.GetAsync(id, cancellationToken)
                       ?? throw new NotFoundException("Wishlist not found.");

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
        var giftsQuery = giftRepository.GetQueryable()
            .Where(g => g.WishlistId == wishlistId);

        if (filters != null)
        {
            if (filters.CategoryNames != null && filters.CategoryNames.Any())
            {
                var categoryIds = await categoryRepository.GetQueryable()
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

    public async Task<Guid> ShareWishlistAsync(AccessRights accessRight, string email, CancellationToken cancellationToken)
    {
        var sharedFromEmail = GetUserEmailFromContext();
        var sharedFrom = await userRepository
            .GetQueryable()
            .Where(u => u.Email == sharedFromEmail)
            .FirstOrDefaultAsync(cancellationToken);

        if (sharedFrom == null)
        {
            throw new NotFoundException($"User with email {sharedFromEmail} not found.");
        }

        var sharedTo = await userRepository
            .GetQueryable()
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync(cancellationToken);

        if (sharedTo == null)
        {
            throw new NotFoundException($"User with email {email} not found.");
        }

        var wishlist = await wishlistRepository
            .GetQueryable()
            .Where(w => w.Id == accessRight.WishlistId)
            .FirstOrDefaultAsync(cancellationToken);

        if (wishlist == null)
        {
            throw new NotFoundException($"Wishlist with ID {accessRight.WishlistId} not found.");
        }

        var existingAccess = await accessRightsRepository
            .GetQueryable()
            .Where(a => a.WishlistId == accessRight.WishlistId && a.UserId == sharedTo.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingAccess != null)
        {
            existingAccess.Type = accessRight.Type;
            accessRightsRepository.Update(existingAccess);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return existingAccess.Id;
        }

        accessRight.UserId = sharedTo.Id;
        await accessRightsRepository.AddAsync(accessRight, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return accessRight.Id;
    }

    public async Task RevokeWishlistAccessAsync(Guid accessRightId, CancellationToken cancellationToken)
    {
        var accessRight = await accessRightsRepository.GetAsync(accessRightId, cancellationToken)
                            ?? throw new NotFoundException("Access right not found.");

        var wishlist = await wishlistRepository.GetAsync(accessRight.WishlistId, cancellationToken)
                       ?? throw new NotFoundException("Wishlist not found.");

        var email = GetUserEmailFromContext();

        if (wishlist.CreatedBy != email)
        {
            throw new ForbiddenException("You are not authorized to delete this access right.");
        }

        accessRightsRepository.Delete(accessRight);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<(IEnumerable<AccessRights> accessRights, int totalPages)> GetWishlistAccessRightAsync(Guid wishlistId, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        if (!await wishlistRepository.ExistsAsync(wishlistId, cancellationToken))
        {
            throw new NotFoundException("Wishlist not found.");
        }

        var queryable = accessRightsRepository
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
        var accessType = (await accessRightsRepository.GetQueryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.WishlistId == requestWishlistId && a.User.Email == GetUserEmailFromContext(), cancellationToken))?.Type;

        if (accessType != null)
        {
            return accessType;
        }

        var isPublic = await wishlistRepository.GetQueryable()
            .AsNoTracking()
            .AnyAsync(w => w.IsPublic && w.Id == requestWishlistId, cancellationToken);

        return isPublic ? AccessType.Viewer : null;
    }

    private string GetUserEmailFromContext() => httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
}