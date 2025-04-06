namespace Application.Wishlists.Commands.UpdateWishlist;

public class UpdateWishlistCommandHandler : IRequestHandler<UpdateWishlistCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IWishlistService _wishlistService;

    public UpdateWishlistCommandHandler(IWishlistService wishlistService, IMapper mapper)
    {
        _mapper = mapper;
        _wishlistService = wishlistService;
    }

    public async Task<Unit> Handle(UpdateWishlistCommand request, CancellationToken cancellationToken)
    {
        var wishlist = _mapper.Map<Wishlist>(request);
        await _wishlistService.UpdateWishlistAsync(wishlist, request.categories, cancellationToken);

        return Unit.Value;
    }
}
