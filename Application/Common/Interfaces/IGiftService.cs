namespace Application.Common.Interfaces;

public interface IGiftService
{
    Task<Guid> CreateGiftAsync(Gift gift, string categoryName, CancellationToken cancellationToken);
    
    Task UpdateGiftAsync(Gift gift, string categoryName, CancellationToken cancellationToken);

    Task DeleteGiftAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Gift> GetGiftAsync(Guid id, CancellationToken cancellationToken);
    
    Task<Guid> ReserveGiftAsync(SharedGift sharedGift, CancellationToken cancellationToken);
    
    Task CancelGiftReservationAsync(Guid giftId, CancellationToken cancellationToken);
}
