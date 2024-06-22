using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class ProductFile
{
    public Guid ProductId { get; set; }

    public int FileId { get; set; }
}
