using Application.Gifts.Commands.AcceptGiftReservation;
using Application.Gifts.Commands.CancelGiftReservation;
using Application.Gifts.Commands.CreateGift;
using Application.Gifts.Commands.DeleteGift;
using Application.Gifts.Commands.ReserveGift;
using Application.Gifts.Commands.UpdateGift;
using Application.Gifts.Queries.GetGift;
using Application.Gifts.Queries.ScrapeGiftDetails;
using MediatR;

namespace Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GiftsController(IMediator mediatr) : ControllerBase
{
    [HttpGet("scrape")]
    public async Task<IActionResult> Scrape([FromQuery] string url, CancellationToken cancellationToken)
    {
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return BadRequest("Invalid URL");
        }

        var giftDetails = await mediatr.Send(new ScrapeGiftDetailsQuery(url), cancellationToken);
        return Ok(giftDetails);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var gift = await mediatr.Send(new GetGiftQuery(id), cancellationToken);
        return Ok(gift);
    }
    
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
    
    [HttpPost("{id}/reserve")]
    public async Task<IActionResult> ReserveGiftAsync(Guid id, CancellationToken cancellationToken)
    {
        var sharedGiftId = await mediatr.Send(new ReserveGiftCommand(id), cancellationToken);
        return Ok(sharedGiftId);
    }
    
    [HttpDelete("{id}/cancel-reservation")]
    public async Task<IActionResult> CancelGiftReservationAsync(Guid id, CancellationToken cancellationToken)
    {
        await mediatr.Send(new CancelGiftReservationCommand(id), cancellationToken);
        return Ok();
    }
    
    [HttpPut("accept-reservation")]
    public async Task<IActionResult> AcceptGiftReservationAsync(
        [FromBody] AcceptGiftReservationCommand request, 
        CancellationToken cancellationToken)
    {
        await mediatr.Send(request, cancellationToken);
        return Ok();
    }
}
