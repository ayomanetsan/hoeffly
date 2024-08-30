namespace Application.Common.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(User user, CancellationToken cancellationToken);
}