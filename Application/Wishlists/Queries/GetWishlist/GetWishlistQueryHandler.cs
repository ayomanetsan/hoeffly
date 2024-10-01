namespace Application.Wishlists.Queries.GetWishlistById;

public class GetWishlistQueryHandler : IRequestHandler<GetWishlistQuery, WishlistResponse>
{
    private readonly IWishlistService _wishlistService;
    private readonly IMapper _mapper;

    public GetWishlistQueryHandler(IWishlistService wishlistService, IMapper mapper)
    {
        _wishlistService = wishlistService;
        _mapper = mapper;
    }
    
    public async Task<WishlistResponse> Handle(GetWishlistQuery request, CancellationToken cancellationToken)
    {
        var wishlist = await _wishlistService.GetWishlistAsync(request.Id, cancellationToken);
        return _mapper.Map<WishlistResponse>(wishlist);
    }
}
