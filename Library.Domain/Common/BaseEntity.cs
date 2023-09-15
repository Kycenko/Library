﻿namespace Library.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    //DateTime? DeletedDate { get; set; }
}