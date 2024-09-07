using Application.Common.Interfaces;

namespace Application.Wishlists.Commands.CreateWishlist;

public sealed class CreateWishlistCommandHandler : IRequestHandler<CreateWishlistCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IWishlistService _wishlistService;

    public CreateWishlistCommandHandler(IWishlistService wishlistService, IMapper mapper)
    {
        _mapper = mapper;
        _wishlistService = wishlistService;
    }
    
    public async Task<Unit> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
    {
        var wishlist = _mapper.Map<Wishlist>(request);
        await _wishlistService.CreateWishlistAsync(wishlist, cancellationToken);
        
        return Unit.Value;
    }
}
