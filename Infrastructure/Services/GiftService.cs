using System.Security.Claims;
using Domain.Enums;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class GiftService : IGiftService
{
    private readonly IRepository<Gift> _giftRepository;
    private readonly IRepository<Wishlist> _wishlistRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUnitOfWork _unitOfWork;

    public GiftService(
        IRepository<Gift> giftRepository, 
        IRepository<Wishlist> wishlistRepository, 
        IRepository<Category> categoryRepository, 
        IUnitOfWork unitOfWork, 
        IHttpContextAccessor httpContextAccessor)
    {
        _giftRepository = giftRepository;
        _wishlistRepository = wishlistRepository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid> CreateGiftAsync(Gift gift, string categoryName, CancellationToken cancellationToken)
    {
        if (!await _wishlistRepository.GetQueryable().AnyAsync(w => w.Id == gift.WishlistId, cancellationToken))
        {
            throw new NotFoundException("Wishlist not found.");
        }

        var category = await _categoryRepository.GetQueryable()
            .AsNoTracking()
            .FirstAsync(c => c.Name == categoryName && c.Type == CategoryType.Gift, cancellationToken)
            ?? throw new NotFoundException("Category not found or invalid for gifts.");

        gift.CategoryId = category.Id;
        
        await _giftRepository.AddAsync(gift, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return gift.Id;
    }

    public async Task UpdateGiftAsync(Gift updatedGift, string categoryName, CancellationToken cancellationToken)
    {
        var gift = await _giftRepository.GetAsync(updatedGift.Id, cancellationToken)
                       ?? throw new NotFoundException("Gift not found.");
        
        var email = GetUserEmailFromContext();
        if (gift.CreatedBy != email)
        {
            throw new ForbiddenException("You are not authorized to update this gift.");
        }
        
        var category = await _categoryRepository.GetQueryable()
            .AsNoTracking()
            .FirstAsync(c => c.Name == categoryName && c.Type == CategoryType.Gift, cancellationToken)
            ?? throw new NotFoundException("Category not found or invalid for gifts.");
        
        gift.Name = updatedGift.Name;
        gift.CategoryId = category.Id;
        gift.Note = updatedGift.Note;
        gift.ShopLink = updatedGift.ShopLink;
        // TODO: fix the update with the photo and thumbnail links
        // gift.PhotoLink = updatedGift.PhotoLink;
        // gift.ThumbnailLink = updatedGift.ThumbnailLink;
        gift.Price = updatedGift.Price;
        gift.Currency = updatedGift.Currency;
        gift.Priority = updatedGift.Priority;
        
        _giftRepository.Update(gift);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteGiftAsync(Guid id, CancellationToken cancellationToken)
    {
        var gift = await _giftRepository.GetAsync(id, cancellationToken)
                   ?? throw new NotFoundException("Gift not found.");
        var email = GetUserEmailFromContext();

        if (gift.CreatedBy != email)
        {
            throw new ForbiddenException("You are not authorized to delete this gift.");
        }
        
        _giftRepository.Delete(gift);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Gift> GetGiftAsync(Guid id, CancellationToken cancellationToken)
    {
        var gift = await _giftRepository.GetAsync(id, cancellationToken)
                   ?? throw new NotFoundException("Gift not found.");
        var email = GetUserEmailFromContext();

        if (gift.CreatedBy != email)
        {
            throw new ForbiddenException("You are not authorized to delete this gift.");
        }

        return gift;
    }

    private string GetUserEmailFromContext() => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
}