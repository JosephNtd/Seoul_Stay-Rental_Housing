using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_CancellationRefundFees_GUID", IsUnique = true)]
public partial class CancellationRefundFee
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("CancellationPolicyID")]
    public long CancellationPolicyId { get; set; }

    public int DaysLeft { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal PenaltyPercentage { get; set; }

    [ForeignKey("CancellationPolicyId")]
    [InverseProperty("CancellationRefundFees")]
    public virtual CancellationPolicy CancellationPolicy { get; set; } = null!;
}
