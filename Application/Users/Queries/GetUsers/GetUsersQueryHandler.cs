using Application.Common.Models;

namespace Application.Users.Queries.GetUsers;

public class GetUsersQueryHandler(IUserService userService, IMapper mapper)
    : IRequestHandler<GetUsersQuery, PageResponse<UsersResponse>>
{
    public async Task<PageResponse<UsersResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var (users, totalPages) = await userService.GetUsersAsync(
            request.PageNumber, 
            request.PageSize, 
            cancellationToken);

        var mappedUsers = mapper.Map<IEnumerable<UsersResponse>>(users);
        
        return new PageResponse<UsersResponse>(
            mappedUsers, 
            request.PageNumber, 
            request.PageSize, 
            totalPages);
    }
}
