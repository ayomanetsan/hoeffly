using Application.Gifts.Commands.CreateGift;
using Application.Gifts.Commands.DeleteGift;
using Application.Gifts.Commands.UpdateGift;
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
    
    [HttpPut]
    public async Task<IActionResult> UpdateGiftAsync(UpdateGiftCommand command, CancellationToken cancellationToken)
    {
        await mediatr.Send(command, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGiftAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(new DeleteGiftCommand(id), cancellationToken);
        return Ok(result);
    }
}