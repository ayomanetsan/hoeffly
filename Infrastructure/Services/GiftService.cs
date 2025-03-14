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
    private readonly IRepository<SharedGift> _sharedGiftRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUnitOfWork _unitOfWork;

    public GiftService(
        IRepository<Gift> giftRepository, 
        IRepository<Wishlist> wishlistRepository, 
        IRepository<Category> categoryRepository, 
        IRepository<SharedGift> sharedGiftRepository,
        IRepository<User> userRepository,
        IUnitOfWork unitOfWork, 
        IHttpContextAccessor httpContextAccessor)
    {
        _giftRepository = giftRepository;
        _wishlistRepository = wishlistRepository;
        _categoryRepository = categoryRepository;
        _sharedGiftRepository = sharedGiftRepository;
        _userRepository = userRepository;
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
            throw new ForbiddenException("You are not authorized to see this gift.");
        }

        return gift;
    }

    public async Task<Guid> ReserveGiftAsync(SharedGift sharedGift, CancellationToken cancellationToken)
    {
        var gift = await _giftRepository.GetAsync(sharedGift.GiftId, cancellationToken)
                   ?? throw new NotFoundException("Gift not found.");
        var email = GetUserEmailFromContext();
        var user = await _userRepository.GetQueryable()
                       .AsNoTracking()
                       .FirstAsync(c => c.Email == email, cancellationToken)
                   ?? throw new NotFoundException("User not found.");
        
        sharedGift.UserId = user.Id;

        if (gift.IsReserved == false)
        {
            sharedGift.Status = SharedGiftStatus.Primary;
            gift.IsReserved = true;
        }
        else
        {
            sharedGift.Status = SharedGiftStatus.Pending;
        }

        await _sharedGiftRepository.AddAsync(sharedGift, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return sharedGift.Id;
    }

    public async Task CancelGiftReservationAsync(Guid giftId, CancellationToken cancellationToken)
    {
        var email = GetUserEmailFromContext();
        var user = await _userRepository.GetQueryable()
                       .AsNoTracking()
                       .FirstAsync(c => c.Email == email, cancellationToken)
                   ?? throw new NotFoundException("User not found.");

        var gift = await _giftRepository.GetAsync(giftId, cancellationToken)
                   ?? throw new NotFoundException("Gift not found.");

        var sharedGifts = await _sharedGiftRepository.GetQueryable()
                              .Where(sg => sg.GiftId == giftId)
                              .OrderBy(sg => sg.CreatedAt)
                              .ToListAsync(cancellationToken);

        var userSharedGift = sharedGifts.FirstOrDefault(sg => sg.UserId == user.Id);

        if (userSharedGift == null)
        {
            throw new NotFoundException("User has not reserved this gift.");
        }

        _sharedGiftRepository.Delete(userSharedGift);

        if (userSharedGift.Status == SharedGiftStatus.Primary)
        {
            var nextAcceptedUser = sharedGifts
                .Where(sg => sg.Status == SharedGiftStatus.Accepted && sg.Id != userSharedGift.Id).MinBy(sg => sg.CreatedAt);

            if (nextAcceptedUser != null)
            {
                nextAcceptedUser.Status = SharedGiftStatus.Primary;
                _sharedGiftRepository.Update(nextAcceptedUser);
            }
            else
            {
                var nextPendingUser = sharedGifts
                    .Where(sg => sg.Status == SharedGiftStatus.Pending && sg.Id != userSharedGift.Id).MinBy(sg => sg.CreatedAt);

                if (nextPendingUser != null)
                {
                    nextPendingUser.Status = SharedGiftStatus.Primary;
                    _sharedGiftRepository.Update(nextPendingUser);
                }
                else
                {
                    gift.IsReserved = false;
                    _giftRepository.Update(gift);
                }
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private string GetUserEmailFromContext() => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
}