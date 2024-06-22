using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class BrandImage
{
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }

    public Guid ImageId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Image Image { get; set; } = null!;
}
