using Domain.Exceptions;

namespace Infrastructure.Services;

public class UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork) : IUserService
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
}