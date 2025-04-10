namespace Application.Wishlists.Commands.DeleteWishlist;

public class DeleteWishlistCommandHandler(IWishlistService wishlistService)
    : IRequestHandler<DeleteWishlistCommand, Unit>
{
    public async Task<Unit> Handle(DeleteWishlistCommand request, CancellationToken cancellationToken)
    {
        await wishlistService.DeleteWishlistAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
