using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public string Address { get; set; } = null!;

    public string? Email { get; set; }

    public string Phone { get; set; } = null!;

    public string Status { get; set; } = null!;

    public Guid UserId { get; set; }

    public decimal? DollarAmount { get; set; }

    public Guid? VoucherShopId { get; set; }

    public Guid? VoucherSystemId { get; set; }

    public Guid? MerchantId { get; set; }

    public bool? IsActive { get; set; }

    public string? Note { get; set; }

    public decimal Amount { get; set; }

    public double? ShipCost { get; set; }

    public double? Tax { get; set; }

    public decimal? Total { get; set; }

    public Guid? PaymentMethodId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<PayPalOrder> PayPalOrders { get; set; } = new List<PayPalOrder>();

    public virtual ICollection<TransactionMaster> TransactionMasters { get; set; } = new List<TransactionMaster>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

    public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
}
