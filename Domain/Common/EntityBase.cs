namespace Domain.Common;

public abstract class EntityBase
{
    public Guid Id { get; private set; }

    public DateTimeOffset CreatedAt { get; set; }
    
    public required string CreatedBy { get; set; }

    public DateTimeOffset LastModifiedAt { get; set; }
    
    public required string LastModifiedBy { get; set; }
}