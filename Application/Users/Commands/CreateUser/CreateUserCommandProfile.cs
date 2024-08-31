namespace Application.Users.Commands.CreateUser;

public class CreateUserCommandProfile : Profile
{
    public CreateUserCommandProfile()
    {
        CreateMap<CreateUserCommand, User>();
    }
}