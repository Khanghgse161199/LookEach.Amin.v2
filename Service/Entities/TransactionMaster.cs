﻿using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class TransactionMaster
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid PaymentMethodId { get; set; }

    public bool IsCompleted { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
