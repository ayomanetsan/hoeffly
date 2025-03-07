using Application.Common.Models;
using Application.Wishlists.Queries.GetFilteredWishlists;

namespace Application.Users.Queries.GetFriends;

public record GetFriendsQuery() : PageRequest<PageResponse<FriendsResponse>>;
