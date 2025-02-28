using Domain.Enums;

namespace Application.Users.Queries.GetFriends;

public record FriendsResponse(
    Guid Id,
    string Name, 
    string Email,
    InvitationStatus Status
    )
{
    public FriendsResponse() : this(Guid.Empty, "", "", InvitationStatus.Accepted){ }
};
