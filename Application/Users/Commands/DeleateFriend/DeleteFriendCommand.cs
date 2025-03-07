namespace Application.Users.Commands.DeleateFriend;

public record DeleteFriendCommand(Guid FriendshipId) : IRequest<Unit>;
