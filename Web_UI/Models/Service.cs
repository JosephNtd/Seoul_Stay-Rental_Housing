using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_Services_GUID", IsUnique = true)]
public partial class Service
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("ServiceTypeID")]
    public long ServiceTypeId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public long? Duration { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(100)]
    public string? DayOfWeek { get; set; }

    [StringLength(100)]
    public string? DayOfMonth { get; set; }

    public long DailyCap { get; set; }

    public long BookingCap { get; set; }

    [InverseProperty("Service")]
    public virtual ICollection<AddonServiceDetail> AddonServiceDetails { get; set; } = new List<AddonServiceDetail>();

    [ForeignKey("ServiceTypeId")]
    [InverseProperty("Services")]
    public virtual ServiceType ServiceType { get; set; } = null!;
}
