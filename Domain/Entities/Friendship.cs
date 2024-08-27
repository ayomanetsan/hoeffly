using Domain.Enums;

namespace Domain.Entities;

public class Friendship : EntityBase
{
    public InvitationStatus Status { get; set; }

    public Guid RequesterId { get; set; }
    
    public User Requester { get; set; } = null!;
    
    public Guid RecipientId { get; set; }
    
    public User Recipient { get; set; } = null!;
}