using Application.Common.Models;
using Application.Wishlists.Commands.CreateWishlist;
using Application.Wishlists.Commands.DeleteWishlist;
using Application.Wishlists.Commands.DeleteWishlistAccess;
using Application.Wishlists.Commands.ShareWishlist;
using Application.Wishlists.Commands.UpdateWishlist;
using Application.Wishlists.Queries.CheckAccess;
using Application.Wishlists.Queries.GetFilteredWishlists;
using Application.Wishlists.Queries.GetWishlistAccessRights;
using Application.Wishlists.Queries.GetWishlist;
using Domain.Enums;
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
        [FromQuery] int pageSize = 10,
        [FromQuery] List<string>? categoryNames = null,
        [FromQuery] bool? isReserved = null,
        [FromQuery] List<PriorityLevel>? priorities = null)
    {
        var filters = new GiftFilterParameters
        {
            CategoryNames = categoryNames,
            IsReserved = isReserved,
            Priorities = priorities
        };
        
        var response = await mediatr.Send(new GetWishlistQuery(id, pageNumber, pageSize, filters), cancellationToken);
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
    
    [HttpPost("share")]
    public async Task<IActionResult> ShareWishlist([FromBody] ShareWishlistCommand request, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(request, cancellationToken);
        return Ok(result);
    }
    
    [HttpDelete("{id}/access")]
    public async Task<IActionResult> RevokeWishlistAccess(Guid id, CancellationToken cancellationToken)
    {
        await mediatr.Send(new RevokeWishlistAccessCommand(id), cancellationToken);
        return Ok();
    }
    
    [HttpGet("{id}/access")]
    public async Task<IActionResult> GetWishlistAccessRights(
        Guid id, 
        CancellationToken cancellationToken,
        [FromQuery] int pageNumber = 1, 
        [FromQuery] int pageSize = 10
        )
    {
        var result = await mediatr.Send(new GetWishlistAccessRightsQuery(id, pageNumber, pageSize), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}/access/check")]
    public async Task<IActionResult> CheckAccess(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(new CheckAccessQuery(id), cancellationToken);
        return Ok(result);
    }
}
