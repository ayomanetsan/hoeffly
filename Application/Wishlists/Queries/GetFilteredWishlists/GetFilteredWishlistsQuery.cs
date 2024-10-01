using Application.Common.Models;

namespace Application.Wishlists.Queries.GetFilteredWishlists;

public record GetFilteredWishlistsQuery(bool CreatedByCurrentUser) : PageRequest<PageResponse<WishlistBriefResponse>>;