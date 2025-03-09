using Application.Wishlists.Commands.CreateWishlist;
using Application.Wishlists.Commands.DeleteWishlist;
using Application.Wishlists.Commands.DeleteWishlistAccess;
using Application.Wishlists.Commands.ShareWishlist;
using Application.Wishlists.Commands.UpdateWishlist;
using Application.Wishlists.Queries.GetFilteredWishlists;
using Application.Wishlists.Queries.GetWishlistById;
using MediatR;

namespace Presentation.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class WishlistsController(IMediator mediatr) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetWishlists([FromQuery] GetFilteredWishlistsQuery query, CancellationToken cancellationToken)
    {
        var response = await mediatr.Send(query, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWishlist([FromRoute] Guid id,
        CancellationToken cancellationToken,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var response = await mediatr.Send(new GetWishlistQuery(id, pageNumber, pageSize), cancellationToken);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateWishlistCommand command, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(command, cancellationToken);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateWishlistCommand command, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(command, cancellationToken);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(new DeleteWishlistCommand(id), cancellationToken);
        return Ok(result);
    }
    
    [HttpPost("{id}/share")]
    public async Task<IActionResult> ShareWishlist(Guid id, [FromBody] ShareWishlistCommand request, CancellationToken cancellationToken)
    {
        var command = new ShareWishlistCommand(id, request.Email, request.AccessType);
        var result = await mediatr.Send(command, cancellationToken);
        return Ok(result);
    }
    
    [HttpDelete("{id}/access")]
    public async Task<IActionResult> RevokeWishlistAccess(Guid id, CancellationToken cancellationToken)
    {
        await mediatr.Send(new RevokeWishlistAccessCommand(id), cancellationToken);
        return Ok();
    }
}
