using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class ProductSourcingImage
{
    public Guid Id { get; set; }

    public Guid? ProductSourcingId1 { get; set; }

    public virtual ProductSourcing? ProductSourcingId1Navigation { get; set; }
}
