namespace Application.Users.Commands.DeleateFriend;

public class DeleteFriendCommandHandler(IFriendshipService friendshipService)
    : IRequestHandler<DeleteFriendCommand, Unit>
{
    public async Task<Unit> Handle(DeleteFriendCommand request, CancellationToken cancellationToken)
    {
        await friendshipService.DeleteFriendshipAsync(request.FriendshipId, cancellationToken);
        return Unit.Value;
    }
}
