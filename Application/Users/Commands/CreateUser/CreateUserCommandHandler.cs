using Application.Common.Interfaces;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler(IUserService userService, IMapper mapper)
    : IRequestHandler<CreateUserCommand, Unit>
{
    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);
        await userService.CreateUserAsync(user, cancellationToken);

        return Unit.Value;
    }
}