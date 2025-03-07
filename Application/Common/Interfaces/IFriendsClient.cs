namespace Application.Common.Interfaces;

public interface IFriendsClient
{
    Task ReceiveFriendRequest(Guid friendshipId, string senderName, string senderEmail);
    Task ReceiveFriendRequestStatus(Guid friendshipId, int status);
    Task ReceiveFriendRequestDelete(Guid friendshipId);
}
