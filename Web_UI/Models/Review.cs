using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_Reviews_GUID", IsUnique = true)]
public partial class Review
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("BookingID")]
    public long BookingId { get; set; }

    [Column("ReviewerID")]
    public long ReviewerId { get; set; }

    [Column("RevieweeID")]
    public long? RevieweeId { get; set; }

    [Column("ItemID")]
    public long? ItemId { get; set; }

    public byte Rating { get; set; }

    [StringLength(2000)]
    public string? Comment { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("Reviews")]
    public virtual Booking Booking { get; set; } = null!;

    [ForeignKey("ItemId")]
    [InverseProperty("Reviews")]
    public virtual Item? Item { get; set; }

    [ForeignKey("RevieweeId")]
    [InverseProperty("ReviewReviewees")]
    public virtual User? Reviewee { get; set; }

    [ForeignKey("ReviewerId")]
    [InverseProperty("ReviewReviewers")]
    public virtual User Reviewer { get; set; } = null!;
}
