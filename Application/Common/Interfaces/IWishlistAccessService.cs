using Domain.Enums;

namespace Application.Common.Interfaces;

public interface IWishlistAccessService
{
    Task ShareWishlistAsync(AccessRights accessRight, string email, CancellationToken cancellationToken);
}
