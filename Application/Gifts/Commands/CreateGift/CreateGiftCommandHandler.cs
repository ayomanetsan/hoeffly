namespace Application.Gifts.Commands.CreateGift;

public sealed class CreateGiftCommandHandler(IMapper mapper, IGiftService giftService)
    : IRequestHandler<CreateGiftCommand, Guid>
{
    public async Task<Guid> Handle(CreateGiftCommand request, CancellationToken cancellationToken)
    {
        var gift = mapper.Map<Gift>(request);
        return await giftService.CreateGiftAsync(gift, request.CategoryName, cancellationToken);
    }
}