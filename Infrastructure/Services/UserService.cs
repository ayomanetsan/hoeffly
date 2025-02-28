using System.Security.Claims;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) 
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
        
        var publicUsersQuery = userRepository
            .GetQueryable()
            .Where(u => u.IsPublic && u.Email != userEmail);

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