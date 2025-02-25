namespace Application.Gifts.Queries.GetGift;

public record GetGiftQuery(Guid Id) : IRequest<GiftResponse>;
