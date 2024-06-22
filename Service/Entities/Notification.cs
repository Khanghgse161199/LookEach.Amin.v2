using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Notification
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public string Content { get; set; } = null!;

    public int StatusId { get; set; }

    public int TypeId { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsActive { get; set; }
}
