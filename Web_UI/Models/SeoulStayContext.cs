using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_UI.Models;

public partial class SeoulStayContext : DbContext
{
    public SeoulStayContext()
    {
    }

    public SeoulStayContext(DbContextOptions<SeoulStayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddonService> AddonServices { get; set; }

    public virtual DbSet<AddonServiceDetail> AddonServiceDetails { get; set; }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Attraction> Attractions { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingCoupon> BookingCoupons { get; set; }

    public virtual DbSet<BookingDetail> BookingDetails { get; set; }

    public virtual DbSet<BookingStatusHistory> BookingStatusHistories { get; set; }

    public virtual DbSet<CancellationPolicy> CancellationPolicies { get; set; }

    public virtual DbSet<CancellationRefundFee> CancellationRefundFees { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<DimDate> DimDates { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Host> Hosts { get; set; }

    public virtual DbSet<HostBankAccount> HostBankAccounts { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemAmenity> ItemAmenities { get; set; }

    public virtual DbSet<ItemAttraction> ItemAttractions { get; set; }

    public virtual DbSet<ItemAvailability> ItemAvailabilities { get; set; }

    public virtual DbSet<ItemPicture> ItemPictures { get; set; }

    public virtual DbSet<ItemPrice> ItemPrices { get; set; }

    public virtual DbSet<ItemScore> ItemScores { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VwGuestBookingSummary> VwGuestBookingSummaries { get; set; }

    public virtual DbSet<VwHostPerformance> VwHostPerformances { get; set; }

    public virtual DbSet<VwUserRole> VwUserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Seoul_Stay;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddonService>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Booking).WithMany(p => p.AddonServices).HasConstraintName("FK_AddonServices_Bookings");

            entity.HasOne(d => d.Coupon).WithMany(p => p.AddonServices).HasConstraintName("FK_AddonServices_Coupons");

            entity.HasOne(d => d.User).WithMany(p => p.AddonServices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AddonServices_Users");
        });

        modelBuilder.Entity<AddonServiceDetail>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.NumberOfPeople).HasDefaultValue(1L);

            entity.HasOne(d => d.AddonService).WithMany(p => p.AddonServiceDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AddonServiceDetails_AddonServices");

            entity.HasOne(d => d.Service).WithMany(p => p.AddonServiceDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AddonServiceDetails_Services");
        });

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Attraction>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Area).WithMany(p => p.Attractions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attractions_Areas");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(e => e.BookingDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.BookingStatus).HasDefaultValue("Pending");
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.CancellationPolicy).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_CancellationPolicies");

            entity.HasOne(d => d.CheckInDateNavigation).WithMany(p => p.BookingCheckInDateNavigations)
                .HasPrincipalKey(p => p.Date)
                .HasForeignKey(d => d.CheckInDate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_CheckInDate_DimDates");

            entity.HasOne(d => d.CheckOutDateNavigation).WithMany(p => p.BookingCheckOutDateNavigations)
                .HasPrincipalKey(p => p.Date)
                .HasForeignKey(d => d.CheckOutDate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_CheckOutDate_DimDates");

            entity.HasOne(d => d.GuestUser).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Guests");

            entity.HasOne(d => d.Item).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Items");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Bookings).HasConstraintName("FK_Bookings_Transactions");
        });

        modelBuilder.Entity<BookingCoupon>(entity =>
        {
            entity.Property(e => e.AppliedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingCoupons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingCoupons_Bookings");

            entity.HasOne(d => d.Coupon).WithMany(p => p.BookingCoupons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingCoupons_Coupons");
        });

        modelBuilder.Entity<BookingDetail>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingDetails_Bookings");

            entity.HasOne(d => d.ItemPrice).WithMany(p => p.BookingDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingDetails_ItemPrices");

            entity.HasOne(d => d.RefundCancellationPolicy).WithMany(p => p.BookingDetails).HasConstraintName("FK_BookingDetails_RefundPolicy");
        });

        modelBuilder.Entity<BookingStatusHistory>(entity =>
        {
            entity.Property(e => e.ChangedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingStatusHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingStatusHistory_Bookings");

            entity.HasOne(d => d.ChangedByUser).WithMany(p => p.BookingStatusHistories).HasConstraintName("FK_BookingStatusHistory_ChangedByUser");
        });

        modelBuilder.Entity<CancellationPolicy>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<CancellationRefundFee>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.CancellationPolicy).WithMany(p => p.CancellationRefundFees).HasConstraintName("FK_CancellationRefundFees_CancellationPolicies");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StartDate).HasDefaultValueSql("(CONVERT([date],getdate()))");
        });

        modelBuilder.Entity<DimDate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.PreferredLanguage).HasDefaultValue("en");

            entity.HasOne(d => d.User).WithOne(p => p.Guest).HasConstraintName("FK_Guests_Users");
        });

        modelBuilder.Entity<Host>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.JoinedAsHostDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithOne(p => p.Host).HasConstraintName("FK_Hosts_Users");
        });

        modelBuilder.Entity<HostBankAccount>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.HostUser).WithMany(p => p.HostBankAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HostBankAccounts_Hosts");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MaximumNights).HasDefaultValue(365);
            entity.Property(e => e.MinimumNights).HasDefaultValue(1);

            entity.HasOne(d => d.Area).WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Items_Areas");

            entity.HasOne(d => d.HostUser).WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Items_Hosts");

            entity.HasOne(d => d.ItemType).WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Items_ItemTypes");
        });

        modelBuilder.Entity<ItemAmenity>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Amenity).WithMany(p => p.ItemAmenities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemAmenities_Amenities");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemAmenities).HasConstraintName("FK_ItemAmenities_Items");
        });

        modelBuilder.Entity<ItemAttraction>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Attraction).WithMany(p => p.ItemAttractions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemAttractions_Attractions");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemAttractions).HasConstraintName("FK_ItemAttractions_Items");
        });

        modelBuilder.Entity<ItemAvailability>(entity =>
        {
            entity.Property(e => e.IsAvailable).HasDefaultValue(true);

            entity.HasOne(d => d.DateNavigation).WithMany(p => p.ItemAvailabilities)
                .HasPrincipalKey(p => p.Date)
                .HasForeignKey(d => d.Date)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemAvailability_DimDates");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemAvailabilities).HasConstraintName("FK_ItemAvailability_Items");
        });

        modelBuilder.Entity<ItemPicture>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemPictures).HasConstraintName("FK_ItemPictures_Items");
        });

        modelBuilder.Entity<ItemPrice>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.CancellationPolicy).WithMany(p => p.ItemPrices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemPrices_CancellationPolicies");

            entity.HasOne(d => d.DateNavigation).WithMany(p => p.ItemPrices)
                .HasPrincipalKey(p => p.Date)
                .HasForeignKey(d => d.Date)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemPrices_DimDates");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemPrices).HasConstraintName("FK_ItemPrices_Items");
        });

        modelBuilder.Entity<ItemScore>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemScores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemScores_Items");

            entity.HasOne(d => d.Score).WithMany(p => p.ItemScores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemScores_Scores");

            entity.HasOne(d => d.User).WithMany(p => p.ItemScores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItemScores_Users");
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Booking).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Bookings");

            entity.HasOne(d => d.Item).WithMany(p => p.Reviews).HasConstraintName("FK_Reviews_Items");

            entity.HasOne(d => d.Reviewee).WithMany(p => p.ReviewReviewees).HasConstraintName("FK_Reviews_Reviewee");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.ReviewReviewers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Reviewer");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.BookingCap).HasDefaultValue(1L);
            entity.Property(e => e.DailyCap).HasDefaultValue(1L);
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.Services)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_ServiceTypes");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.TransactionDateNavigation).WithMany(p => p.Transactions)
                .HasPrincipalKey(p => p.Date)
                .HasForeignKey(d => d.TransactionDate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_DimDates");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_TransactionTypes");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Users");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<VwGuestBookingSummary>(entity =>
        {
            entity.ToView("vw_GuestBookingSummary");
        });

        modelBuilder.Entity<VwHostPerformance>(entity =>
        {
            entity.ToView("vw_HostPerformance");
        });

        modelBuilder.Entity<VwUserRole>(entity =>
        {
            entity.ToView("vw_UserRoles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
