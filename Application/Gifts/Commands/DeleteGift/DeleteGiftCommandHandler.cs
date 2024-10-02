namespace Application.Gifts.Commands.DeleteGift;

public class DeleteGiftCommandHandler : IRequestHandler<DeleteGiftCommand, Unit>
{
    private readonly IGiftService _giftService;

    public DeleteGiftCommandHandler(IGiftService giftService)
    {
        _giftService = giftService;
    }
    
    public async Task<Unit> Handle(DeleteGiftCommand request, CancellationToken cancellationToken)
    {
        await _giftService.DeleteGiftAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
