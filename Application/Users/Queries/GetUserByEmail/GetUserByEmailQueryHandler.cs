using Application.Users.Queries.GetUsers;

namespace Application.Users.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler(IUserService userService, IMapper mapper) : IRequestHandler<GetUserByEmailQuery, UsersResponse>
{
    public async Task<UsersResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await userService.GetUserByEmailAsync(request.Email, cancellationToken);
        var mappedUser = mapper.Map<UsersResponse>(user);

        return mappedUser;
    }
}
