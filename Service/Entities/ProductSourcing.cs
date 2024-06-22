using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class ProductSourcing
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public Guid BrandId { get; set; }

    public int Version { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public int Sold { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<ProductSourcingImage> ProductSourcingImages { get; set; } = new List<ProductSourcingImage>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Color> Colors { get; set; } = new List<Color>();

    public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();
}
