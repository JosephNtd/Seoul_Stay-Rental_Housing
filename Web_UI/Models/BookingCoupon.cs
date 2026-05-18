using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_BookingCoupons_GUID", IsUnique = true)]
[Index("BookingId", "CouponId", Name = "UQ_BookingCoupons_Pair", IsUnique = true)]
public partial class BookingCoupon
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("BookingID")]
    public long BookingId { get; set; }

    [Column("CouponID")]
    public long CouponId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal DiscountApplied { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AppliedDate { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("BookingCoupons")]
    public virtual Booking Booking { get; set; } = null!;

    [ForeignKey("CouponId")]
    [InverseProperty("BookingCoupons")]
    public virtual Coupon Coupon { get; set; } = null!;
}
