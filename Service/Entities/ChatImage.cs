using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class ChatImage
{
    public Guid Id { get; set; }

    public Guid ChatId { get; set; }

    public Guid ImageId { get; set; }

    public Guid? ChatMessageId { get; set; }

    public virtual Chat Chat { get; set; } = null!;

    public virtual ChatMessage? ChatMessage { get; set; }

    public virtual Image Image { get; set; } = null!;
}
