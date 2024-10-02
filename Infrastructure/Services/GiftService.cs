using Domain.Exceptions;

namespace Infrastructure.Services;

public class GiftService : IGiftService
{
    private readonly IRepository<Gift> _giftRepository;
    private readonly IRepository<Wishlist> _wishlistRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GiftService(IRepository<Gift> giftRepository, IRepository<Wishlist> wishlistRepository, IUnitOfWork unitOfWork)
    {
        _giftRepository = giftRepository;
        _wishlistRepository = wishlistRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> CreateGiftAsync(Gift gift, CancellationToken cancellationToken)
    {
        if (!await _wishlistRepository.GetQueryable().AnyAsync(w => w.Id == gift.WishlistId, cancellationToken))
        {
            throw new NotFoundException("Wishlist not found.");
        }
        await _giftRepository.AddAsync(gift, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return gift.Id;
    }
}