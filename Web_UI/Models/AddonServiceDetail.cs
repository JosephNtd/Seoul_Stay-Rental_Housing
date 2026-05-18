using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_AddonServiceDetails_GUID", IsUnique = true)]
public partial class AddonServiceDetail
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("AddonServiceID")]
    public long AddonServiceId { get; set; }

    [Column("ServiceID")]
    public long ServiceId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FromDate { get; set; }

    [StringLength(250)]
    public string? Notes { get; set; }

    public long NumberOfPeople { get; set; }

    [Column("isRefund")]
    public bool IsRefund { get; set; }

    [ForeignKey("AddonServiceId")]
    [InverseProperty("AddonServiceDetails")]
    public virtual AddonService AddonService { get; set; } = null!;

    [ForeignKey("ServiceId")]
    [InverseProperty("AddonServiceDetails")]
    public virtual Service Service { get; set; } = null!;
}
