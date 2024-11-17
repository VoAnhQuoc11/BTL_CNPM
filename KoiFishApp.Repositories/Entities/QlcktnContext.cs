using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiFishApp.Repositories.Entities;

public partial class QlcktnContext : DbContext
{
    public QlcktnContext()
    {
    }

    public QlcktnContext(DbContextOptions<QlcktnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<KoiGrowth> KoiGrowths { get; set; }

    public virtual DbSet<KoiGrowthReport> KoiGrowthReports { get; set; }

    public virtual DbSet<KoiQuantity> KoiQuantities { get; set; }

    public virtual DbSet<OrderSummary> OrderSummaries { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<SaleReport> SaleReports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WaterParameter> WaterParameters { get; set; }

    public virtual DbSet<WaterQuality> WaterQualities { get; set; }

    public virtual DbSet<WaterQualityReport> WaterQualityReports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=VA;Initial Catalog=QLCKTN;Persist Security Info=True;User ID=sa;Password=123;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__GioHang__B40CC6EDAD359036");

            entity.ToTable("GioHang");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__KoiFish__E03435B881E3BD36");

            entity.ToTable("KoiFish");

            entity.Property(e => e.KoiId)
                .ValueGeneratedNever()
                .HasColumnName("KoiID");
            entity.Property(e => e.BodyShape).HasMaxLength(100);
            entity.Property(e => e.Breed).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Origin).HasMaxLength(100);
            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pond).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK__KoiFish__PondID__3B75D760");
        });

        modelBuilder.Entity<KoiGrowth>(entity =>
        {
            entity.HasKey(e => e.KoiGrowthId).HasName("PK__KoiGrowt__2BFF0917B5175535");

            entity.ToTable("KoiGrowth");

            entity.Property(e => e.KoiGrowthId).HasColumnName("KoiGrowthID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.FoodAmount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.KoiId).HasColumnName("KoiID");

            entity.HasOne(d => d.Koi).WithMany(p => p.KoiGrowths)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__KoiGrowth__KoiID__4316F928");
        });

        modelBuilder.Entity<KoiGrowthReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Koi_Growth_Reports");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<KoiQuantity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Koi_Quan__3214EC2741846F3E");

            entity.ToTable("Koi_Quantity");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<OrderSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Order_Summary");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasKey(e => e.PondId).HasName("PK__Pond__D18BF8547F69CE42");

            entity.ToTable("Pond");

            entity.Property(e => e.PondId)
                .ValueGeneratedNever()
                .HasColumnName("PondID");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6EDF0ADE0C4");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<SaleReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sale_Reports");

            entity.Property(e => e.Tongdoanhthu).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC2779C4BB6F");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<WaterParameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WaterPar__3214EC0746E04D32");

            entity.ToTable("WaterParameter");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MeasurementDate).HasColumnType("datetime");
            entity.Property(e => e.No2).HasColumnName("NO2");
            entity.Property(e => e.No3).HasColumnName("NO3");
            entity.Property(e => e.Ph).HasColumnName("PH");
            entity.Property(e => e.Po4).HasColumnName("PO4");
            entity.Property(e => e.PondId).HasColumnName("PondID");

            entity.HasOne(d => d.Pond).WithMany(p => p.WaterParameters)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK__WaterPara__PondI__3E52440B");
        });

        modelBuilder.Entity<WaterQuality>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Water_Quality");

            entity.Property(e => e.PoindId).HasColumnName("PoindID");
        });

        modelBuilder.Entity<WaterQualityReport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Water_Quality_Reports");

            entity.Property(e => e.PondId).HasColumnName("PondID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
