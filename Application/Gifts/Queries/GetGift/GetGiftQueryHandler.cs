namespace Application.Gifts.Queries.GetGift;

public sealed class GetGiftQueryHandler : IRequestHandler<GetGiftQuery, GiftResponse>
{
    private readonly IGiftService _giftService;
    private readonly IMapper _mapper;

    public GetGiftQueryHandler(IGiftService giftService, IMapper mapper)
    {
        _giftService = giftService;
        _mapper = mapper;
    }

    public async Task<GiftResponse> Handle(GetGiftQuery request, CancellationToken cancellationToken)
    {
        var gift = await _giftService.GetGiftAsync(request.Id, cancellationToken);
        return _mapper.Map<GiftResponse>(gift);
    }
}
