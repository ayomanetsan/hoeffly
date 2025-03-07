using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Infrastructure.Hubs;

[Authorize]
public class FriendsHub : Hub<IFriendsClient>
{
    public override async Task OnConnectedAsync()
    {
        var email = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
        await Groups.AddToGroupAsync(Context.ConnectionId, email!);

        await base.OnConnectedAsync();
    }

    public async Task SendFriendRequest(string receiverEmail, Guid friendshipId, string senderName)
    {
        var senderEmail = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
        await Clients.Group(receiverEmail).ReceiveFriendRequest(friendshipId, senderName, senderEmail!);
    }

    public async Task ManageFriendRequest(string receiverEmail, Guid friendshipId, int status)
    {
        await Clients.Group(receiverEmail).ReceiveFriendRequestStatus(friendshipId, status);
    }
    
    public async Task DeleteFriendRequest(string receiverEmail, Guid friendshipId)
    {
        await Clients.Group(receiverEmail).ReceiveFriendRequestDelete(friendshipId);
    }
}
