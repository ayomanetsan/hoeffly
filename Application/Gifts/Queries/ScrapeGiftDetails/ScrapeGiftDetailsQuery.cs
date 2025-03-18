namespace Application.Gifts.Queries.ScrapeGiftDetails;

public record ScrapeGiftDetailsQuery(string Url) : IRequest<GiftDetails>;