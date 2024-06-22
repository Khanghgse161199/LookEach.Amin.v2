using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class ChatUser
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ChatId { get; set; }

    public virtual Chat Chat { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
