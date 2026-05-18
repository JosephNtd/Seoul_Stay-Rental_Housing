using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Keyless]
public partial class VwHostPerformance
{
    [Column("HostUserID")]
    public long HostUserId { get; set; }

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    public bool IsVerified { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal? Rating { get; set; }

    public int TotalReviews { get; set; }

    public int? TotalListings { get; set; }

    public int? TotalBookingsReceived { get; set; }

    [Column(TypeName = "decimal(38, 2)")]
    public decimal TotalRevenue { get; set; }
}
