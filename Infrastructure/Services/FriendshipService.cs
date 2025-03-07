using System.Security.Claims;
using Domain.Enums;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class FriendshipService(
    IRepository<Friendship> friendshipRepository,
    IRepository<User> userRepository,
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor)
    : IFriendshipService
{
    public async Task<Guid> SendFriendRequestAsync(string recipientEmail, CancellationToken cancellationToken)
    {
        var requester = await GetUserByEmailAsync(GetUserEmailFromContext(), cancellationToken);
        var recipient = await GetUserByEmailAsync(recipientEmail, cancellationToken);
        
        if (requester == null)
            throw new NotFoundException("Requester not found.");
        if (recipient == null)
            throw new NotFoundException("Recipient not found.");
        
        if (requester.Id == recipient.Id)
            throw new ConflictException("You can't add yourself as a friend.");
        
        var existingFriendship = await GetExistingFriendshipAsync(requester.Id, recipient.Id, cancellationToken);
        if (existingFriendship != null)
            throw new ConflictException("Friend request already exists or you are already friends.");

        var friendship = new Friendship
        {
            RecipientId = recipient.Id,
            RequesterId = requester.Id,
            Status = InvitationStatus.Pending,
            CreatedBy = requester.Email,
            LastModifiedBy = requester.Email
        };

        await friendshipRepository.AddAsync(friendship, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return friendship.Id;
    }

    public async Task<InvitationStatus> ManageFriendRequestAsync(InvitationStatus status, Guid friendshipId, CancellationToken cancellationToken)
    {
        var friendship = await GetExistingFriendshipAsync(friendshipId, cancellationToken);
        if (friendship == null)
            throw new NotFoundException("Friendship not found.");

        if (friendship.Status != InvitationStatus.Pending)
            throw new ConflictException("Friend request is already processed.");
        
        var userEmail = GetUserEmailFromContext();
        if (friendship.Recipient.Email != userEmail)
            throw new ForbiddenException("Only the recipient can manage the friend request.");
        
        friendship.Status = status;
        
        friendshipRepository.Update(friendship);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return friendship.Status;
    }

    public async Task DeleteFriendshipAsync(Guid id, CancellationToken cancellationToken)
    {
        var friendship = await GetExistingFriendshipAsync(id, cancellationToken) 
                         ?? throw new NotFoundException("Friendship not found.");
        
        var email = GetUserEmailFromContext();
        if(friendship.Recipient.Email != email && friendship.Requester.Email != email)
        {
            throw new ForbiddenException("You can only delete your own friendships.");
        }
        
        friendshipRepository.Delete(friendship);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<(IEnumerable<Friendship> friends, int totalPages, string userEmail)> GetFriendsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var userEmail = GetUserEmailFromContext();

        var queryable = friendshipRepository
            .GetQueryable()
            .Where(f => f.Requester.Email == userEmail || f.Recipient.Email == userEmail);
        
        var totalItems = await queryable.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        
        var friends = await queryable
            .AsNoTracking()
            .OrderByDescending(w => w.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(f => f.Requester)
            .Include(f => f.Recipient)
            .ToListAsync(cancellationToken);
    
        return (friends, totalPages, userEmail);
    }

    private async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await userRepository
            .GetQueryable()
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
            throw new NotFoundException($"User with email {email} not found.");

        return user;
    }
    
    private async Task<Friendship?> GetExistingFriendshipAsync(Guid requesterId, Guid recipientId, CancellationToken cancellationToken)
    {
        return await friendshipRepository
            .GetQueryable()
            .Where(f => (f.RequesterId == requesterId && f.RecipientId == recipientId) ||
                        (f.RequesterId == recipientId && f.RecipientId == requesterId))
            .FirstOrDefaultAsync(cancellationToken);
    }
    
    private async Task<Friendship?> GetExistingFriendshipAsync(Guid friendshipId, CancellationToken cancellationToken)
    {
        return await friendshipRepository
            .GetQueryable()
            .Include(f => f.Recipient)
            .Include(f => f.Requester)
            .FirstOrDefaultAsync(f => f.Id == friendshipId, cancellationToken);
    }
    
    private string GetUserEmailFromContext() => httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
}
