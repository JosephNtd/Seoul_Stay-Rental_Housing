using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_ItemAttractions_GUID", IsUnique = true)]
[Index("ItemId", "AttractionId", Name = "UQ_ItemAttractions_Pair", IsUnique = true)]
public partial class ItemAttraction
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("ItemID")]
    public long ItemId { get; set; }

    [Column("AttractionID")]
    public long AttractionId { get; set; }

    [Column(TypeName = "decimal(5, 1)")]
    public decimal? Distance { get; set; }

    public int? DurationOnFoot { get; set; }

    public int? DurationByCar { get; set; }

    [ForeignKey("AttractionId")]
    [InverseProperty("ItemAttractions")]
    public virtual Attraction Attraction { get; set; } = null!;

    [ForeignKey("ItemId")]
    [InverseProperty("ItemAttractions")]
    public virtual Item Item { get; set; } = null!;
}
