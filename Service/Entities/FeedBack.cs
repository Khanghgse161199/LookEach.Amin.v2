using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class FeedBack
{
    public Guid ProductId { get; set; }

    public Guid UserId { get; set; }

    public string Comment { get; set; } = null!;

    public int Rating { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
