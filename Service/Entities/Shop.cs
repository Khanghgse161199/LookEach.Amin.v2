using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class Shop
{
    public Guid Id { get; set; }

    public string? ClinicName { get; set; }

    public string? TaxCode { get; set; }

    public string? Description { get; set; }

    public int? LogoId { get; set; }

    public string? OwnerName { get; set; }

    public string? CitizenIdentityNumber { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
