using Domain.Enums;

namespace Application.Common.Interfaces;

public interface IWishlistAccessService
{
    Task<Guid> ShareWishlistAsync(AccessRights accessRight, string email, CancellationToken cancellationToken);
    
    Task RevokeWishlistAccessAsync(Guid accessRightId, CancellationToken cancellationToken);

    Task<(IEnumerable<AccessRights> accessRights, int totalPages)> GetWishlistAccessRightAsync(Guid wishlistId, int pageNumber,
        int pageSize, CancellationToken cancellationToken);
}
