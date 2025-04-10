using System.Security.Claims;
using Domain.Enums;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class GiftService(
    IRepository<Gift> giftRepository,
    IRepository<Wishlist> wishlistRepository,
    IRepository<Category> categoryRepository,
    IRepository<SharedGift> sharedGiftRepository,
    IRepository<User> userRepository,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor)
    : IGiftService
{
    public async Task<Guid> CreateGiftAsync(Gift gift, string categoryName, CancellationToken cancellationToken)
    {
        if (!await wishlistRepository.GetQueryable().AnyAsync(w => w.Id == gift.WishlistId, cancellationToken))
        {
            throw new NotFoundException("Wishlist not found.");
        }

        var category = await categoryRepository.GetQueryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name == categoryName && c.Type == CategoryType.Gift, cancellationToken)
            ?? throw new NotFoundException("Category not found or invalid for gifts.");

        gift.CategoryId = category.Id;

        await giftRepository.AddAsync(gift, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return gift.Id;
    }

    public async Task UpdateGiftAsync(Gift gift, string categoryName, CancellationToken cancellationToken)
    {
        var updatedGift = await giftRepository.GetAsync(gift.Id, cancellationToken)
                          ?? throw new NotFoundException("Gift not found.");

        var email = GetUserEmailFromContext();
        if (updatedGift.CreatedBy != email)
        {
            throw new ForbiddenException("You are not authorized to update this gift.");
        }

        var category = await categoryRepository.GetQueryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name == categoryName && c.Type == CategoryType.Gift, cancellationToken)
            ?? throw new NotFoundException("Category not found or invalid for gifts.");

        updatedGift.Name = gift.Name;
        updatedGift.CategoryId = category.Id;
        updatedGift.Note = gift.Note;
        updatedGift.ShopLink = gift.ShopLink;

        // TODO: fix the update with the photo and thumbnail links
        // gift.PhotoLink = updatedGift.PhotoLink;
        // gift.ThumbnailLink = updatedGift.ThumbnailLink;
        updatedGift.Price = gift.Price;
        updatedGift.Currency = gift.Currency;
        updatedGift.Priority = gift.Priority;

        giftRepository.Update(updatedGift);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteGiftAsync(Guid id, CancellationToken cancellationToken)
    {
        var gift = await giftRepository.GetAsync(id, cancellationToken)
                   ?? throw new NotFoundException("Gift not found.");
        var email = GetUserEmailFromContext();

        if (gift.CreatedBy != email)
        {
            throw new ForbiddenException("You are not authorized to delete this gift.");
        }

        giftRepository.Delete(gift);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Gift> GetGiftAsync(Guid id, CancellationToken cancellationToken)
    {
        var gift = await giftRepository.GetAsync(id, cancellationToken)
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
        var gift = await giftRepository.GetAsync(sharedGift.GiftId, cancellationToken)
                   ?? throw new NotFoundException("Gift not found.");
        var email = GetUserEmailFromContext();
        var user = await userRepository.GetQueryable()
                       .AsNoTracking()
                       .FirstOrDefaultAsync(c => c.Email == email, cancellationToken)
                   ?? throw new NotFoundException("User not found.");

        sharedGift.UserId = user.Id;

        if (gift.IsReserved)
        {
            sharedGift.Status = SharedGiftStatus.Pending;
        }
        else
        {
            sharedGift.Status = SharedGiftStatus.Primary;
            gift.IsReserved = true;
        }

        await sharedGiftRepository.AddAsync(sharedGift, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return sharedGift.Id;
    }

    public async Task CancelGiftReservationAsync(Guid giftId, CancellationToken cancellationToken)
    {
        var email = GetUserEmailFromContext();
        var user = await userRepository.GetQueryable()
                       .AsNoTracking()
                       .FirstOrDefaultAsync(c => c.Email == email, cancellationToken)
                   ?? throw new NotFoundException("User not found.");

        var gift = await giftRepository.GetAsync(giftId, cancellationToken)
                   ?? throw new NotFoundException("Gift not found.");

        var userSharedGift = await sharedGiftRepository.GetQueryable()
            .FirstOrDefaultAsync(sg => sg.GiftId == giftId && sg.UserId == user.Id, cancellationToken);

        if (userSharedGift == null)
        {
            throw new NotFoundException("User has not reserved this gift.");
        }

        sharedGiftRepository.Delete(userSharedGift);

        if (userSharedGift.Status == SharedGiftStatus.Primary)
        {
            var nextAcceptedUser = await sharedGiftRepository.GetQueryable()
                .Where(sg => sg.GiftId == giftId &&
                             sg.Status == SharedGiftStatus.Accepted &&
                             sg.Id != userSharedGift.Id)
                .OrderBy(sg => sg.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);

            if (nextAcceptedUser != null)
            {
                nextAcceptedUser.Status = SharedGiftStatus.Primary;
                sharedGiftRepository.Update(nextAcceptedUser);
            }
            else
            {
                var nextPendingUser = await sharedGiftRepository.GetQueryable()
                    .Where(sg => sg.GiftId == giftId &&
                                 sg.Status == SharedGiftStatus.Pending &&
                                 sg.Id != userSharedGift.Id)
                    .OrderBy(sg => sg.CreatedAt)
                    .FirstOrDefaultAsync(cancellationToken);

                if (nextPendingUser != null)
                {
                    nextPendingUser.Status = SharedGiftStatus.Primary;
                    sharedGiftRepository.Update(nextPendingUser);
                }
                else
                {
                    gift.IsReserved = false;
                    giftRepository.Update(gift);
                }
            }
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task AcceptGiftReservation(string email, Guid giftId, CancellationToken cancellationToken)
    {
        var currentUserEmail = GetUserEmailFromContext();
        var userQuery = userRepository.GetQueryable().AsNoTracking();
        var currentUser = await userQuery
                              .FirstOrDefaultAsync(c => c.Email == currentUserEmail, cancellationToken)
                          ?? throw new NotFoundException("Current user not found.");
        var userToAccept = await userQuery
                               .FirstOrDefaultAsync(c => c.Email == email, cancellationToken)
                           ?? throw new NotFoundException("User to accept not found.");

        var giftQuery = sharedGiftRepository.GetQueryable().AsNoTracking();
        if (await giftQuery.FirstOrDefaultAsync(
                sg => sg.GiftId == giftId &&
                      sg.UserId == currentUser.Id &&
                      sg.Status == SharedGiftStatus.Primary, cancellationToken) is null)
        {
            throw new NotFoundException("The current user is not the primary one who is reserving this gift.");
        }
        var pendingSharedGift = await giftQuery
                                    .FirstOrDefaultAsync(
                                        sg => sg.GiftId == giftId &&
                                              sg.UserId == userToAccept.Id &&
                                              sg.Status == SharedGiftStatus.Pending, cancellationToken)
                                ?? throw new NotFoundException("Pending reservation not found for the specified user.");

        pendingSharedGift.Status = SharedGiftStatus.Accepted;

        sharedGiftRepository.Update(pendingSharedGift);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private string GetUserEmailFromContext() => httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
}