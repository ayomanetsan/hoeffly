namespace Application.Users.Queries.GetUsers;

public sealed class GetUsersQueryProfile : Profile
{
    public GetUsersQueryProfile()
    {
        CreateMap<User, UsersResponse>();
    }
}
