using Application.Users.Queries.GetUsers;

namespace Application.Users.Queries.GetUserByEmail;

public record GetUserByEmailQuery(string Email) : IRequest<UsersResponse>;
