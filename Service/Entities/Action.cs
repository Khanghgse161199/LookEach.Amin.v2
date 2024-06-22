using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Action
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Value { get; set; }

    public int Index { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
}
