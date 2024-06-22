using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Image
{
    public Guid Id { get; set; }

    public string Url { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual ICollection<BrandImage> BrandImages { get; set; } = new List<BrandImage>();

    public virtual ICollection<CategoryImage> CategoryImages { get; set; } = new List<CategoryImage>();

    public virtual ICollection<ChatImage> ChatImages { get; set; } = new List<ChatImage>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
