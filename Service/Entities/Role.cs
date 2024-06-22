using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual ICollection<SuperAdmin> SuperAdmins { get; set; } = new List<SuperAdmin>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
