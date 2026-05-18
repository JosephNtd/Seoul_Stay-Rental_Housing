using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_Areas_GUID", IsUnique = true)]
public partial class Area
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Area")]
    public virtual ICollection<Attraction> Attractions { get; set; } = new List<Attraction>();

    [InverseProperty("Area")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
