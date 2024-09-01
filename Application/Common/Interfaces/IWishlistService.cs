namespace Application.Common.Interfaces;

public interface IWishlistService
{
    Task<(IEnumerable<Wishlist> wishlists, int totalPages)> GetWishlistsAsync(bool createdByCurrentUser, int pageNumber,
        int pageSize, CancellationToken cancellationToken);
}