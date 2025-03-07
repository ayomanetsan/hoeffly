using Domain.Enums;

namespace Application.Users.Commands.ManageFriendRequest;

public class ManageFriendRequestCommandHandler(IFriendshipService friendshipService)
    : IRequestHandler<ManageFriendRequestCommand, InvitationStatus>
{
    public async Task<InvitationStatus> Handle(ManageFriendRequestCommand request, CancellationToken cancellationToken)
    {
        return await friendshipService.ManageFriendRequestAsync(request.Status, request.FriendshipId, cancellationToken);
    }
}
