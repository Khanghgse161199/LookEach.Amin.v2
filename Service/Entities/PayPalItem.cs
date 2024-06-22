using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class PayPalItem
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Quantity { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal Value { get; set; }

    public Guid PaypalOrderId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual PayPalOrder PaypalOrder { get; set; } = null!;
}
