namespace Application.Wishlists.Commands.DeleteWishlistAccess;

public class RevokeWishlistAccessCommandHandler(IWishlistAccessService wishlistService) : IRequestHandler<RevokeWishlistAccessCommand, Unit>
{
    public async Task<Unit> Handle(RevokeWishlistAccessCommand request, CancellationToken cancellationToken)
    {
        await wishlistService.RevokeWishlistAccessAsync(request.AccessRightId, cancellationToken);
        return Unit.Value;
    }
}
