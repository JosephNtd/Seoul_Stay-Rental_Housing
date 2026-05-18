using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_ItemAmenities_GUID", IsUnique = true)]
[Index("ItemId", "AmenityId", Name = "UQ_ItemAmenities_Pair", IsUnique = true)]
public partial class ItemAmenity
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("ItemID")]
    public long ItemId { get; set; }

    [Column("AmenityID")]
    public long AmenityId { get; set; }

    [ForeignKey("AmenityId")]
    [InverseProperty("ItemAmenities")]
    public virtual Amenity Amenity { get; set; } = null!;

    [ForeignKey("ItemId")]
    [InverseProperty("ItemAmenities")]
    public virtual Item Item { get; set; } = null!;
}
