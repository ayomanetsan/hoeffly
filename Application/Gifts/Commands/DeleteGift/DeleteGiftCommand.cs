namespace Application.Gifts.Commands.DeleteGift;

public record DeleteGiftCommand(Guid Id) : IRequest<Unit>;
