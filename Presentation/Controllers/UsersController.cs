using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUserByEmail;
using MediatR;

namespace Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediatr) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        var result = await mediatr.Send(command);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
    {
        // TODO: update schema to include photo url
        var result = await mediatr.Send(new GetUserByEmailQuery(email));
        return Ok(result);
    }
}