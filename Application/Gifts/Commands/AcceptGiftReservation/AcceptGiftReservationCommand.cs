namespace Application.Gifts.Commands.AcceptGiftReservation;

public record AcceptGiftReservationCommand(string Email, Guid GiftId) : IRequest<Unit>;
