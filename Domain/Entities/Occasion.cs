namespace Domain.Entities;

public class Occasion : EntityBase
{
    public required string Name { get; set; }
    
    public DateTime Date { get; set; }
    
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
}