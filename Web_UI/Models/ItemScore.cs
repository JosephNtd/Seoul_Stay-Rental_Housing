using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_ItemScores_GUID", IsUnique = true)]
[Index("UserId", "ItemId", "ScoreId", Name = "UQ_ItemScores_Pair", IsUnique = true)]
public partial class ItemScore
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [Column("ItemID")]
    public long ItemId { get; set; }

    [Column("ScoreID")]
    public long ScoreId { get; set; }

    public long Value { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("ItemScores")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("ScoreId")]
    [InverseProperty("ItemScores")]
    public virtual Score Score { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ItemScores")]
    public virtual User User { get; set; } = null!;
}
