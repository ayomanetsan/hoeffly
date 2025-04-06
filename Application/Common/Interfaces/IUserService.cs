namespace Application.Common.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(User user, CancellationToken cancellationToken);

    Task<(IEnumerable<User> users, int totalPages)> GetUsersAsync(
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);

    Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}
