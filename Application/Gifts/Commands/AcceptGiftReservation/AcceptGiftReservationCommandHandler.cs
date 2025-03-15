namespace Application.Gifts.Commands.AcceptGiftReservation;

public class AcceptGiftReservationCommandHandler(IGiftService giftService) : IRequestHandler<AcceptGiftReservationCommand, Unit>
{
    public async Task<Unit> Handle(AcceptGiftReservationCommand request, CancellationToken cancellationToken)
    {
        await giftService.AcceptGiftReservation(request.Email, request.GiftId, cancellationToken);
        return Unit.Value;
    }
}
