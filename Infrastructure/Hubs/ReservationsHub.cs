using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Hubs;

[Authorize]
public class ReservationsHub : Hub<IReservationClient>
{
    public async Task ReserveGift(Guid giftId)
    {
        var reservedByEmail = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
        await Clients.Others.ReceiveGiftReservation(giftId, reservedByEmail!);
    }

    public async Task CancelReservation(Guid giftId)
    {
        var reservedByEmail = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
        await Clients.Others.ReceiveGiftReservationCancel(giftId, reservedByEmail!);
    }

    public async Task AcceptReservationRequest(Guid giftId, string reservedByEmail)
    {
        await Clients.Others.ReceiveGiftReservationAcceptance(giftId, reservedByEmail);
    }
}