namespace Application.Gifts.Commands.ReserveGift;

public class ReserveGiftCommandHandler(IGiftService giftService, IMapper mapper) : IRequestHandler<ReserveGiftCommand, Guid>
{
    public async Task<Guid> Handle(ReserveGiftCommand request, CancellationToken cancellationToken)
    {
        var sharedGift = mapper.Map<SharedGift>(request);
        var sharedGiftId = await giftService.ReserveGiftAsync(sharedGift, cancellationToken);
        return sharedGiftId;
    }
}
