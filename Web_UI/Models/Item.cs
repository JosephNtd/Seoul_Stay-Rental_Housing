using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

[Index("Guid", Name = "UQ_Items_GUID", IsUnique = true)]
public partial class Item
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [Column("HostUserID")]
    public long HostUserId { get; set; }

    [Column("ItemTypeID")]
    public long ItemTypeId { get; set; }

    [Column("AreaID")]
    public long AreaId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public int Capacity { get; set; }

    public int NumberOfBeds { get; set; }

    public int NumberOfBedrooms { get; set; }

    public int NumberOfBathrooms { get; set; }

    [StringLength(500)]
    public string ExactAddress { get; set; } = null!;

    [StringLength(250)]
    public string ApproximateAddress { get; set; } = null!;

    [StringLength(2000)]
    public string Description { get; set; } = null!;

    [StringLength(2000)]
    public string HostRules { get; set; } = null!;

    public int MinimumNights { get; set; }

    public int MaximumNights { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("Items")]
    public virtual Area Area { get; set; } = null!;

    [InverseProperty("Item")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [ForeignKey("HostUserId")]
    [InverseProperty("Items")]
    public virtual Host HostUser { get; set; } = null!;

    [InverseProperty("Item")]
    public virtual ICollection<ItemAmenity> ItemAmenities { get; set; } = new List<ItemAmenity>();

    [InverseProperty("Item")]
    public virtual ICollection<ItemAttraction> ItemAttractions { get; set; } = new List<ItemAttraction>();

    [InverseProperty("Item")]
    public virtual ICollection<ItemAvailability> ItemAvailabilities { get; set; } = new List<ItemAvailability>();

    [InverseProperty("Item")]
    public virtual ICollection<ItemPicture> ItemPictures { get; set; } = new List<ItemPicture>();

    [InverseProperty("Item")]
    public virtual ICollection<ItemPrice> ItemPrices { get; set; } = new List<ItemPrice>();

    [InverseProperty("Item")]
    public virtual ICollection<ItemScore> ItemScores { get; set; } = new List<ItemScore>();

    [ForeignKey("ItemTypeId")]
    [InverseProperty("Items")]
    public virtual ItemType ItemType { get; set; } = null!;

    [InverseProperty("Item")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
