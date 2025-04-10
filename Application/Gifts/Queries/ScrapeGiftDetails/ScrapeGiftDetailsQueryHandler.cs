namespace Application.Gifts.Queries.ScrapeGiftDetails;

public sealed class ScrapeGiftDetailsQueryHandler : IRequestHandler<ScrapeGiftDetailsQuery, GiftDetails>
{
    private readonly IGiftScrapingService _giftScrapingService;

    public ScrapeGiftDetailsQueryHandler(IGiftScrapingService giftScrapingService)
    {
        _giftScrapingService = giftScrapingService;
    }

    public Task<GiftDetails> Handle(ScrapeGiftDetailsQuery request, CancellationToken cancellationToken)
    {
        return _giftScrapingService.ScrapeGiftDetailsAsync(request.Url);
    }
}