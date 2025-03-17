namespace Application.Gifts.Commands.CancelGiftReservation;

public record CancelGiftReservationCommand(Guid GiftId) : IRequest<Unit>;
