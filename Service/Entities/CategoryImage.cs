using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class CategoryImage
{
    public Guid Id { get; set; }

    public Guid CategoryId { get; set; }

    public Guid ImageId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Image Image { get; set; } = null!;
}
