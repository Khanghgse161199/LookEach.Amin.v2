using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class ChatMessage
{
    public Guid Id { get; set; }

    public Guid ChatId { get; set; }

    public Guid UserId { get; set; }

    public string Text { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual Chat Chat { get; set; } = null!;

    public virtual ICollection<ChatImage> ChatImages { get; set; } = new List<ChatImage>();

    public virtual User User { get; set; } = null!;
}
