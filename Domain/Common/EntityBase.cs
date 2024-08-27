﻿namespace Domain.Common;

public abstract class EntityBase
{
    public Guid Id { get; private set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
}