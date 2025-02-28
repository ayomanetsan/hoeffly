namespace Application.Users.Commands.SendFriendRequest;

public class SendFriendRequestCommandHandler(IFriendshipService friendshipService)
    : IRequestHandler<SendFriendRequestCommand, Guid>
{
    public async Task<Guid> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
    {
        return await friendshipService.SendFriendRequestAsync(request.Email, cancellationToken);
    }
}
