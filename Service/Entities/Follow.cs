using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Follow
{
    public Guid UserId { get; set; }

    public Guid MerchantId { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
