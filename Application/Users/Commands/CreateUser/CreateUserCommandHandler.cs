using Application.Common.Interfaces;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);
        await _userService.CreateUserAsync(user, cancellationToken);

        return Unit.Value;
    }
}