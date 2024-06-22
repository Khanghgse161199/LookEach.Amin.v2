using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class PayPalOrder
{
    public Guid Id { get; set; }

    public string Token { get; set; } = null!;

    public string? CaptureId { get; set; }

    public string Intent { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string PayeeEmailAddress { get; set; } = null!;

    public string MerchantId { get; set; } = null!;

    public decimal ExchangeCurrency { get; set; }

    public Guid OrderId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual PayPalAmount? PayPalAmount { get; set; }

    public virtual ICollection<PayPalItem> PayPalItems { get; set; } = new List<PayPalItem>();
}
