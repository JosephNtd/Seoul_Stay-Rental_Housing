using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_CancellationPolicies_GUID", IsUnique = true)]
public partial class CancellationPolicy
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal PlatformCommissionRate { get; set; }

    [InverseProperty("RefundCancellationPolicy")]
    public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();

    [InverseProperty("CancellationPolicy")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("CancellationPolicy")]
    public virtual ICollection<CancellationRefundFee> CancellationRefundFees { get; set; } = new List<CancellationRefundFee>();

    [InverseProperty("CancellationPolicy")]
    public virtual ICollection<ItemPrice> ItemPrices { get; set; } = new List<ItemPrice>();
}
