using Application.Common.Models;
using Application.Users.Queries.GetFriends;

namespace Application.Users.Queries.GetUsers;

public record GetUsersQuery() : PageRequest<PageResponse<UsersResponse>>;
