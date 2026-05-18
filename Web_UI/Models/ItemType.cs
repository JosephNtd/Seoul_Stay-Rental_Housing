using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_ItemTypes_GUID", IsUnique = true)]
public partial class ItemType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string? Icon { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [InverseProperty("ItemType")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
