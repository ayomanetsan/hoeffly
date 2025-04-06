namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandProfile : Profile
{
    public CreateUserCommandProfile()
    {
        CreateMap<CreateUserCommand, User>();
    }
}