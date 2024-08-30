using Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
}