using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_ItemPictures_GUID", IsUnique = true)]
public partial class ItemPicture
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("ItemID")]
    public long ItemId { get; set; }

    [StringLength(500)]
    public string PictureFileName { get; set; } = null!;

    public int DisplayOrder { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("ItemPictures")]
    public virtual Item Item { get; set; } = null!;
}
