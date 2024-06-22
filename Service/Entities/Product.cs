using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public Guid BrandId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public bool? IsActived { get; set; }

    public int Sold { get; set; }

    public int Version { get; set; }

    public decimal DollarPrice { get; set; }

    public string? Material { get; set; }

    public int? Height { get; set; }

    public int? Circumference { get; set; }

    public int? Waist { get; set; }

    public int? Hips { get; set; }

    public string? Origin { get; set; }

    public int? ObjectTypeId { get; set; }

    public Guid? CategoryId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Color> Colors { get; set; } = new List<Color>();

    public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();
}
