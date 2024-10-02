using Application.Gifts.Commands;
using MediatR;

namespace Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GiftsController(IMediator mediatr) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGiftAsync(CreateGiftCommand command, CancellationToken cancellationToken)
    {
        var id = await mediatr.Send(command, cancellationToken);
        return Ok(id);
    }
    
}