namespace Application.Users.Commands.SendFriendRequest;

public record SendFriendRequestCommand(string Email) : IRequest<Guid>;
