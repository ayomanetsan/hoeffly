namespace Application.Gifts.Commands.UpdateGift;

public class UpdateGiftCommandHandler : IRequestHandler<UpdateGiftCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IGiftService _giftService;
    
    public UpdateGiftCommandHandler(IGiftService giftService, IMapper mapper)
    {
        _mapper = mapper;
        _giftService = giftService;
    }
    
    public async Task<Unit> Handle(UpdateGiftCommand request, CancellationToken cancellationToken)
    {
        var gift = _mapper.Map<Gift>(request);
        await _giftService.UpdateGiftAsync(gift, cancellationToken);
        
        return Unit.Value;
    }
}