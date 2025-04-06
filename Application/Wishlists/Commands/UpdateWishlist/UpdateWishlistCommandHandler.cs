namespace Application.Wishlists.Commands.UpdateWishlist;

public class UpdateWishlistCommandHandler(IWishlistService wishlistService, IMapper mapper)
    : IRequestHandler<UpdateWishlistCommand, Unit>
{
    public async Task<Unit> Handle(UpdateWishlistCommand request, CancellationToken cancellationToken)
    {
        var wishlist = mapper.Map<Wishlist>(request);
        await wishlistService.UpdateWishlistAsync(wishlist, request.categories, cancellationToken);

        return Unit.Value;
    }
}
