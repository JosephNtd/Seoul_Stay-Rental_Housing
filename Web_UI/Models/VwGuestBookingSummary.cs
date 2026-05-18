using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Keyless]
public partial class VwGuestBookingSummary
{
    [Column("UserID")]
    public long UserId { get; set; }

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    public int LoyaltyPoints { get; set; }

    public int? TotalBookings { get; set; }

    public int? CompletedBookings { get; set; }

    public int? CancelledBookings { get; set; }

    [Column(TypeName = "decimal(38, 2)")]
    public decimal TotalSpent { get; set; }
}
