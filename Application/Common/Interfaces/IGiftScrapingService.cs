using Application.Gifts.Queries.ScrapeGiftDetails;

namespace Application.Common.Interfaces;

public interface IGiftScrapingService
{
    Task<GiftDetails> ScrapeGiftDetailsAsync(string url);
}