using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Keyless]
public partial class VwUserRole
{
    [Column("UserID")]
    public long UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public int IsHost { get; set; }

    public int IsGuest { get; set; }

    public bool? HostVerified { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal? HostRating { get; set; }

    public int? GuestLoyaltyPoints { get; set; }
}
