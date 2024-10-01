namespace Application.Common.Interfaces;

public interface IWishlistService
{
    Task<(IEnumerable<Wishlist> wishlists, int totalPages)> GetWishlistsAsync(bool createdByCurrentUser, int pageNumber,
        int pageSize, CancellationToken cancellationToken);
    
    Task CreateWishlistAsync(Wishlist wishlist, IEnumerable<string> categories, CancellationToken cancellationToken);
    
    Task UpdateWishlistAsync(Wishlist wishlist, IEnumerable<string> categories, CancellationToken cancellationToken);
    
    Task DeleteWishlistAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Wishlist> GetWishlistAsync(Guid id, CancellationToken cancellationToken);
}