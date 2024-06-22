using System;
using System.Collections.Generic;

namespace Service.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Thumbnail { get; set; }

    public bool EmailConfirm { get; set; }

    public string Password { get; set; } = null!;

    public bool IsActived { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid ModifiedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public string? AccountNumber { get; set; }

    public string? BankName { get; set; }

    public string? AccountOwner { get; set; }

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual ICollection<ChatUser> ChatUsers { get; set; } = new List<ChatUser>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<VoucherSourcing> VoucherSourcings { get; set; } = new List<VoucherSourcing>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
