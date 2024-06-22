using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Permission
{
    public Guid Id { get; set; }

    public Guid RoleId { get; set; }

    public Guid ResourceId { get; set; }

    public int PermissionValue { get; set; }

    public virtual Resource Resource { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
