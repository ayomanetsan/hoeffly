using Application.Common.Models;

namespace Application.Users.Queries.GetFriends;

public class GetFriendsQueryHandler(IFriendshipService friendshipService, IMapper mapper)
    : IRequestHandler<GetFriendsQuery, PageResponse<FriendsResponse>>
{
    public async Task<PageResponse<FriendsResponse>> Handle(GetFriendsQuery request, CancellationToken cancellationToken)
    {
        var (friends, totalPages, userEmail) = await friendshipService.GetFriendsAsync(
            request.PageNumber,
            request.PageSize,
            cancellationToken);

        var mappedFriends = mapper.Map<IEnumerable<FriendsResponse>>(friends, opt =>
        {
            opt.Items["UserEmail"] = userEmail;
        });

        return new PageResponse<FriendsResponse>(
            mappedFriends,
            request.PageNumber,
            request.PageSize,
            totalPages);
    }
}
