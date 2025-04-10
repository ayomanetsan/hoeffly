namespace Application.Gifts.Queries.GetGift;

public sealed class GetGiftQueryHandler(IGiftService giftService, IMapper mapper)
    : IRequestHandler<GetGiftQuery, GiftResponse>
{
    public async Task<GiftResponse> Handle(GetGiftQuery request, CancellationToken cancellationToken)
    {
        var gift = await giftService.GetGiftAsync(request.Id, cancellationToken);
        return mapper.Map<GiftResponse>(gift);
    }
}
