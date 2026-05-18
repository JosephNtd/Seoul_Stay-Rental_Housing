using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_TransactionTypes_GUID", IsUnique = true)]
public partial class TransactionType
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("TransactionType")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
