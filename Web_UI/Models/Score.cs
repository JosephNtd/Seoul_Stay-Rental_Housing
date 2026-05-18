using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_Scores_GUID", IsUnique = true)]
public partial class Score
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Score")]
    public virtual ICollection<ItemScore> ItemScores { get; set; } = new List<ItemScore>();
}
