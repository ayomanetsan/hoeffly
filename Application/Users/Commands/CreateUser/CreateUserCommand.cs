namespace Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Name, string Email, string FirebaseUid) : IRequest<Unit>;