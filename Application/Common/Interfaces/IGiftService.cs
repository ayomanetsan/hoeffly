namespace Application.Common.Interfaces;

public interface IGiftService
{
    Task<Guid> CreateGiftAsync(Gift gift, CancellationToken cancellationToken);
    
    Task UpdateGiftAsync(Gift gift, CancellationToken cancellationToken);

    Task DeleteGiftAsync(Guid id, CancellationToken cancellationToken);
}