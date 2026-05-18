using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_Amenities_GUID", IsUnique = true)]
public partial class Amenity
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string? IconName { get; set; }

    [InverseProperty("Amenity")]
    public virtual ICollection<ItemAmenity> ItemAmenities { get; set; } = new List<ItemAmenity>();
}
