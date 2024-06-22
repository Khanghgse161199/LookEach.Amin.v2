using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Cart
{
    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public Guid SizeId { get; set; }

    public int Amount { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsActive { get; set; }
}
