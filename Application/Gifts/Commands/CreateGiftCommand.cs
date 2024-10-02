using Domain.Enums;

namespace Application.Gifts.Commands;

public record CreateGiftCommand(
    string Name, 
    string Category, 
    string? PhotoLink, 
    string? ThumbnailLink, 
    double Price, 
    Currency Currency,
    PriorityLevel Priority,
    Guid WishlistId
) : IRequest<Guid>;