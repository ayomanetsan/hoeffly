using Domain.Enums;

namespace Application.Gifts.Commands.UpdateGift;

public record UpdateGiftCommand(
    Guid Id, 
    string Name, 
    string CategoryName,
    string? Note, 
    string? ShopLink,
    string? PhotoLink, 
    string? ThumbnailLink, 
    double Price, 
    Currency Currency,
    PriorityLevel Priority,
    Guid WishlistId) : IRequest<Unit>;
    