using Application.Common.Models;
using Application.Gifts.Queries;
using Application.Wishlists.Queries.GetWishlist;
using Domain.Enums;

namespace Application.Common.Interfaces;

public interface IWishlistService
{
    Task<(IEnumerable<Wishlist> wishlists, int totalPages)> GetWishlistsAsync(
        int accessType,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);

    Task CreateWishlistAsync(Wishlist wishlist, IEnumerable<string> categories, CancellationToken cancellationToken);

    Task UpdateWishlistAsync(Wishlist wishlist, IEnumerable<string> categories, CancellationToken cancellationToken);

    Task DeleteWishlistAsync(Guid id, CancellationToken cancellationToken);

    Task<Wishlist> GetWishlistAsync(Guid id, CancellationToken cancellationToken);

    Task<(IEnumerable<Gift> gifts, int totalPages)> GetPagedGiftsAsync(
        Guid wishlistId,
        int pageNumber,
        int pageSize,
        GiftFilterParameters? filters,
        CancellationToken cancellationToken);

    Task<AccessType?> CheckAccessRightsAsync(Guid requestWishlistId, CancellationToken cancellationToken);
}