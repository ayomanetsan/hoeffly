namespace Application.Gifts.Commands.UpdateGift;

public class UpdateGiftCommandHandler(IGiftService giftService, IMapper mapper)
    : IRequestHandler<UpdateGiftCommand, Unit>
{
    public async Task<Unit> Handle(UpdateGiftCommand request, CancellationToken cancellationToken)
    {
        var gift = mapper.Map<Gift>(request);
        await giftService.UpdateGiftAsync(gift, request.CategoryName, cancellationToken);

        return Unit.Value;
    }
}