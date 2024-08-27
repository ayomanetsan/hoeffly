using Domain.Enums;

namespace Domain.Entities;

public class TeamUser : EntityBase
{
    public TeamRole Role { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; } = null!;
    
    public Guid TeamId { get; set; }
    
    public Team Team { get; set; } = null!;
}