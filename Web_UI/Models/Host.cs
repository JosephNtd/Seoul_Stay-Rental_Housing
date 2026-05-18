using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

public partial class Host
{
    [Key]
    [Column("UserID")]
    public long UserId { get; set; }

    [StringLength(100)]
    public string? BusinessLicense { get; set; }

    [StringLength(50)]
    public string? TaxCode { get; set; }

    public bool IsVerified { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VerifiedDate { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal? Rating { get; set; }

    public int TotalReviews { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime JoinedAsHostDate { get; set; }

    [InverseProperty("HostUser")]
    public virtual ICollection<HostBankAccount> HostBankAccounts { get; set; } = new List<HostBankAccount>();

    [InverseProperty("HostUser")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    [ForeignKey("UserId")]
    [InverseProperty("Host")]
    public virtual User User { get; set; } = null!;
}
