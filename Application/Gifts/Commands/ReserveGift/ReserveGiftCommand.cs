namespace Application.Gifts.Commands.ReserveGift;

public record ReserveGiftCommand(Guid GiftId) : IRequest<Guid>;
