namespace Application.Users.Queries.GetUsers;

public class GetUsersQueryProfile : Profile
{
    public GetUsersQueryProfile()
    {
        CreateMap<User, UsersResponse>();
    }
}
