using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

public partial class Guest
{
    [Key]
    [Column("UserID")]
    public long UserId { get; set; }

    public int LoyaltyPoints { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? PreferredLanguage { get; set; }

    [Column("NationalID")]
    [StringLength(50)]
    public string? NationalId { get; set; }

    [Column("NationalIDVerified")]
    public bool NationalIdverified { get; set; }

    [InverseProperty("GuestUser")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [ForeignKey("UserId")]
    [InverseProperty("Guest")]
    public virtual User User { get; set; } = null!;
}
