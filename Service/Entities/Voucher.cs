using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Voucher
{
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool IsActived { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public decimal? MaxPriceOff { get; set; }

    public decimal PriceCondition { get; set; }

    public int SlotAvailable { get; set; }

    public int SlotEachPerson { get; set; }

    public int CurrentSlot { get; set; }

    public double LevelOff { get; set; }

    public bool? IsSystem { get; set; }

    public int? Index { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<VoucherSourcing> VoucherSourcings { get; set; } = new List<VoucherSourcing>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
