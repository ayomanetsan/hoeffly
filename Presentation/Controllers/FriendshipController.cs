using Application.Users.Commands.DeleateFriend;
using Application.Users.Commands.ManageFriendRequest;
using Application.Users.Commands.SendFriendRequest;
using Application.Users.Queries.GetFriends;
using Application.Users.Queries.GetUsers;
using MediatR;

namespace Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FriendshipController(IMediator mediatr) : ControllerBase
{
    [HttpPost("send")]
    public async Task<IActionResult> SendFriendRequest([FromBody] SendFriendRequestCommand command, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPut("manage")]
    public async Task<IActionResult> ManageFriendRequest([FromBody] ManageFriendRequestCommand command, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFriend(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(new DeleteFriendCommand(id), cancellationToken);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetFriends([FromQuery] GetFriendsQuery query, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetPublicUsers([FromQuery] GetUsersQuery query, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(query, cancellationToken);
        return Ok(result);
    }
}
