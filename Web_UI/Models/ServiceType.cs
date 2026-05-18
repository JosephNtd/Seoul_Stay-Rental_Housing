using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_ServiceTypes_GUID", IsUnique = true)]
public partial class ServiceType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string? IconName { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }

    [InverseProperty("ServiceType")]
    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
