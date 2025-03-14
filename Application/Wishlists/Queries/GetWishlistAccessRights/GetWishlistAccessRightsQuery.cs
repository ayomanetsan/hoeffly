using Application.Common.Models;

namespace Application.Wishlists.Queries.GetWishlistAccessRights;

public record GetWishlistAccessRightsQuery(Guid WishlistId, int PageNumber, int PageSize) : PageRequest<PageResponse<AccessRightResponse>>(PageNumber, PageSize);
