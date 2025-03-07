using Domain.Enums;

namespace Application.Users.Commands.ManageFriendRequest;

public record ManageFriendRequestCommand(InvitationStatus Status, Guid FriendshipId) : IRequest<InvitationStatus>;
