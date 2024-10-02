using Application.Gifts.Commands.CreateGift;

namespace Application.Gifts.Commands;

public sealed class CreateGiftCommandHandler : IRequestHandler<CreateGiftCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IGiftService _giftService;

    public CreateGiftCommandHandler(IMapper mapper, IGiftService giftService)
    {
        _mapper = mapper;
        _giftService = giftService;
    }

    public async Task<Guid> Handle(CreateGiftCommand request, CancellationToken cancellationToken)
    {
        var gift = _mapper.Map<Gift>(request);
        return await _giftService.CreateGiftAsync(gift, cancellationToken);
    }
}