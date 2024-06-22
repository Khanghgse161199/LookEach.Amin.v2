using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class AccessToken
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Token { get; set; } = null!;

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public string RefreshToken { get; set; } = null!;
}
