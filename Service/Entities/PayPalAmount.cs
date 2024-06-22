using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class PayPalAmount
{
    public Guid Id { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal Value { get; set; }

    public string ItemTotalCurrencyCode { get; set; } = null!;

    public decimal ItemTotalValue { get; set; }

    public Guid PaypalOrderId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual PayPalOrder PaypalOrder { get; set; } = null!;
}
