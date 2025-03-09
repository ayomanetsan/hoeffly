using System.ComponentModel.DataAnnotations;

namespace Application.Wishlists.Commands.ShareWishlist;

public class ShareWishlistCommandHandler(IWishlistAccessService wishlistAccessService, IMapper mapper) : IRequestHandler<ShareWishlistCommand, Guid>
{
    public async Task<Guid> Handle(ShareWishlistCommand request, CancellationToken cancellationToken)
    {
        var accessRight = mapper.Map<AccessRights>(request);
        var id = await wishlistAccessService.ShareWishlistAsync(accessRight, request.Email, cancellationToken);
        return id;
    }
}
