using Domain.Enums;

namespace Domain.Entities;

public class SharedGift : EntityBase
{
    public InvitationStatus Status { get; set; }
    
    public Guid GiftId { get; set; }

    public Gift Gift { get; set; } = null!;
    
    public Guid UserId { get; set; }
    
    public User User { get; set; } = null!;
}