namespace Application.Wishlists.Commands.DeleteWishlist;

public class DeleteWishlistCommandHandler : IRequestHandler<DeleteWishlistCommand, Unit>
{
    private readonly IWishlistService _wishlistService;

    public DeleteWishlistCommandHandler(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }

    public async Task<Unit> Handle(DeleteWishlistCommand request, CancellationToken cancellationToken)
    {
        await _wishlistService.DeleteWishlistAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
