using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class ParticipantChat
{
    public Guid Id { get; set; }

    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }

    public Guid ChatId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
}
