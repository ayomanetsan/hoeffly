using Application.Common.Models;
using Application.Wishlists.Queries.GetFilteredWishlists;

namespace Application.Wishlists.Queries.GetPublicWishlists;

public record GetPublicWishlistsQuery() : PageRequest<PageResponse<WishlistBriefResponse>>;
