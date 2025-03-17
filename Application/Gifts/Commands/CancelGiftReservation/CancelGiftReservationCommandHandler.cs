namespace Application.Gifts.Commands.CancelGiftReservation;

public class CancelGiftReservationCommandHandler(IGiftService giftService) : IRequestHandler<CancelGiftReservationCommand, Unit>
{
    public async Task<Unit> Handle(CancelGiftReservationCommand request, CancellationToken cancellationToken)
    {
        await giftService.CancelGiftReservationAsync(request.GiftId, cancellationToken);
        return Unit.Value;
    }
}
