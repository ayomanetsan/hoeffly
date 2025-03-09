using System.ComponentModel.DataAnnotations;

namespace Application.Wishlists.Commands.ShareWishlist;

public class ShareWishlistCommandHandler(IWishlistAccessService wishlistAccessService, IMapper mapper) : IRequestHandler<ShareWishlistCommand, Unit>
{
    public async Task<Unit> Handle(ShareWishlistCommand request, CancellationToken cancellationToken)
    {
        var accessRight = mapper.Map<AccessRights>(request);
         await wishlistAccessService.ShareWishlistAsync(accessRight, request.Email, cancellationToken);
         return Unit.Value;
    }
}
