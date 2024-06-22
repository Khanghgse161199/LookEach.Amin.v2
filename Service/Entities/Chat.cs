using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Chat
{
    public Guid Id { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ChatImage> ChatImages { get; set; } = new List<ChatImage>();

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual ICollection<ChatUser> ChatUsers { get; set; } = new List<ChatUser>();
}
