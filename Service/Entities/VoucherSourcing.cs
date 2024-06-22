using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class VoucherSourcing
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid VoucherId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Voucher Voucher { get; set; } = null!;
}
