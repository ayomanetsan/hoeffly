using Domain.Enums;

namespace Application.Wishlists.Queries.CheckAccess;

public record CheckAccessQuery(Guid WishlistId) : IRequest<AccessType?>;