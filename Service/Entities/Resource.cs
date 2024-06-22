using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Resource
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
