using Domain.Enums;

namespace Application.Common.Interfaces;

public interface IFriendshipService
{
    Task<Guid> SendFriendRequestAsync(string email, CancellationToken cancellationToken);
    
    Task<InvitationStatus> ManageFriendRequestAsync(InvitationStatus status, Guid friendshipId, CancellationToken cancellationToken);
    
    Task DeleteFriendshipAsync(Guid id, CancellationToken cancellationToken);
    
    Task<(IEnumerable<Friendship> friends, int totalPages, string userEmail)> GetFriendsAsync(int pageNumber,
        int pageSize, CancellationToken cancellationToken);
}
