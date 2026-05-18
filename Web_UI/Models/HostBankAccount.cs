using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_HostBankAccounts_GUID", IsUnique = true)]
public partial class HostBankAccount
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("HostUserID")]
    public long HostUserId { get; set; }

    [StringLength(100)]
    public string BankName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string AccountNumber { get; set; } = null!;

    [StringLength(100)]
    public string AccountHolder { get; set; } = null!;

    public bool IsPrimary { get; set; }

    public bool IsVerified { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("HostUserId")]
    [InverseProperty("HostBankAccounts")]
    public virtual Host HostUser { get; set; } = null!;
}
