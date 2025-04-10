namespace Application.Wishlists.Commands.CreateWishlist;

public sealed class CreateWishlistCommandHandler(IWishlistService wishlistService, IMapper mapper)
    : IRequestHandler<CreateWishlistCommand, Unit>
{
    public async Task<Unit> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
    {
        var wishlist = mapper.Map<Wishlist>(request);
        await wishlistService.CreateWishlistAsync(wishlist, request.categories, cancellationToken);

        return Unit.Value;
    }
}
