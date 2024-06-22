using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class File
{
    public int Id { get; set; }

    public Guid? FileName { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? FileSize { get; set; }

    public string? FileData { get; set; }

    public string? FileType { get; set; }

    public int? FileDuration { get; set; }

    public string? ThumbnailData { get; set; }
}
