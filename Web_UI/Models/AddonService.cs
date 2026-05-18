using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_AddonServices_GUID", IsUnique = true)]
public partial class AddonService
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [Column("BookingID")]
    public long? BookingId { get; set; }

    [Column("CouponID")]
    public long? CouponId { get; set; }

    [InverseProperty("AddonService")]
    public virtual ICollection<AddonServiceDetail> AddonServiceDetails { get; set; } = new List<AddonServiceDetail>();

    [ForeignKey("BookingId")]
    [InverseProperty("AddonServices")]
    public virtual Booking? Booking { get; set; }

    [ForeignKey("CouponId")]
    [InverseProperty("AddonServices")]
    public virtual Coupon? Coupon { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("AddonServices")]
    public virtual User User { get; set; } = null!;
}
