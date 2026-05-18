using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_Attractions_GUID", IsUnique = true)]
public partial class Attraction
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("AreaID")]
    public long AreaId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string Address { get; set; } = null!;

    [ForeignKey("AreaId")]
    [InverseProperty("Attractions")]
    public virtual Area Area { get; set; } = null!;

    [InverseProperty("Attraction")]
    public virtual ICollection<ItemAttraction> ItemAttractions { get; set; } = new List<ItemAttraction>();
}
