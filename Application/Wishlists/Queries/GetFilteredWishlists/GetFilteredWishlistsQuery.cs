using Application.Common.Models;

namespace Application.Wishlists.Queries.GetFilteredWishlists;

public record GetFilteredWishlistsQuery(int AccessType) : PageRequest<PageResponse<WishlistBriefResponse>>;
