namespace Application.Gifts.Commands.DeleteGift;

public class DeleteGiftCommandHandler(IGiftService giftService) : IRequestHandler<DeleteGiftCommand, Unit>
{
    public async Task<Unit> Handle(DeleteGiftCommand request, CancellationToken cancellationToken)
    {
        await giftService.DeleteGiftAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
