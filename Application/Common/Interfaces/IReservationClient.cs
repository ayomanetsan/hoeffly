namespace Application.Common.Interfaces;

public interface IReservationClient
{
    Task ReceiveGiftReservation(Guid giftId, string reservedByEmail);
    Task ReceiveGiftReservationCancel(Guid giftId, string reservedByEmail);
}