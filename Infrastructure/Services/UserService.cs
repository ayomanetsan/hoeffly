using System.Security.Claims;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class UserService(
    IRepository<User> userRepository, 
    IRepository<Friendship> friendshipRepository, 
    IUnitOfWork unitOfWork, 
    IHttpContextAccessor httpContextAccessor) 
    : IUserService
{
    public async Task CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        var userQueryable = userRepository.GetQueryable();

        if (await userQueryable.AnyAsync(u => u.Email == user.Email, cancellationToken: cancellationToken))
        {
            throw new ConflictException("User with the same email already exists.");
        }
        
        await userRepository.AddAsync(user, cancellationToken); 
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<(IEnumerable<User> users, int totalPages)> GetUsersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var userEmail = GetUserEmailFromContext();
    
        var currentUser = await userRepository.GetQueryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == userEmail, cancellationToken)
            ?? throw new NotFoundException("Current user not found.");
    
        // Get the list of user IDs that are friends with the current user
        var friendIds = await friendshipRepository.GetQueryable()
            .AsNoTracking()
            .Where(f => f.RequesterId == currentUser.Id || f.RecipientId == currentUser.Id)
            .Select(f => f.RequesterId == currentUser.Id ? f.RecipientId : f.RequesterId)
            .ToListAsync(cancellationToken);

        // Query the users excluding those who are friends with the current user
        var publicUsersQuery = userRepository
            .GetQueryable()
            .AsNoTracking()
            .Where(u => u.IsPublic && u.Email != userEmail && !friendIds.Contains(u.Id));

        var totalItems = await publicUsersQuery.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        var users = await publicUsersQuery
            .AsNoTracking()
            .OrderByDescending(w => w.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (users, totalPages);
    }
    
    private string GetUserEmailFromContext() => httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
}