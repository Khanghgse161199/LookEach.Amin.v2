using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Brand
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual ICollection<BrandImage> BrandImages { get; set; } = new List<BrandImage>();

    public virtual ICollection<ProductSourcing> ProductSourcings { get; set; } = new List<ProductSourcing>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
