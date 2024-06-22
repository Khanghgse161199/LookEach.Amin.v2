using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class VnpayTransactionRefund
{
    public Guid Id { get; set; }

    public string ResponseId { get; set; } = null!;

    public string TmnCode { get; set; } = null!;

    public string TxnRef { get; set; } = null!;

    public double Amount { get; set; }

    public string BankCode { get; set; } = null!;

    public DateTime PayDate { get; set; }

    public string TransactionNo { get; set; } = null!;

    public Guid OrderId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
}
