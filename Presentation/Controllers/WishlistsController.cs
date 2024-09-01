using Application.Wishlists.Queries.GetFilteredWishlists;
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
}