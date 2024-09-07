using Application.Wishlists.Commands.CreateWishlist;
using Application.Wishlists.Commands.DeleteWishlist;
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
    public async Task<IActionResult> GetWishlists([FromQuery] GetFilteredWishlistsQuery query)
    {
        var response = await mediatr.Send(query);
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWishlist(Guid id)
    {
        var response = await mediatr.Send(new GetWishlistQuery(id));
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateWishlistCommand command)
    {
        var result = await mediatr.Send(command);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Create(Guid id)
    {
        var result = await mediatr.Send(new DeleteWishlistCommand(id));
        return Ok(result);
    }
}