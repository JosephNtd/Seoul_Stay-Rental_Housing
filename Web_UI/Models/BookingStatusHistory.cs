using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Table("BookingStatusHistory")]
[Index("Guid", Name = "UQ_BookingStatusHistory_GUID", IsUnique = true)]
public partial class BookingStatusHistory
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("BookingID")]
    public long BookingId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? OldStatus { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NewStatus { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ChangedDate { get; set; }

    [Column("ChangedByUserID")]
    public long? ChangedByUserId { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [ForeignKey("BookingId")]
    [InverseProperty("BookingStatusHistories")]
    public virtual Booking Booking { get; set; } = null!;

    [ForeignKey("ChangedByUserId")]
    [InverseProperty("BookingStatusHistories")]
    public virtual User? ChangedByUser { get; set; }
}
