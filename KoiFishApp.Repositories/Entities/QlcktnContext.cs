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

    public virtual DbSet<KoiFish> KoiFishes { get; set; }
    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<KoiGrowth> KoiGrowths { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<WaterParameter> WaterParameters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=VA;Initial Catalog=QLCKTN;Persist Security Info=True;User ID=sa;Password=123;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PK__KoiFish__E03435B888980DC7");

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
            entity
                .HasNoKey()
                .ToTable("KoiGrowth");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.KoiId).HasColumnName("KoiID");

            entity.HasOne(d => d.Koi).WithMany()
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK__KoiGrowth__KoiID__3F466844");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasKey(e => e.PondId).HasName("PK__Pond__D18BF85482D33ECE");

            entity.ToTable("Pond");

            entity.Property(e => e.PondId)
                .ValueGeneratedNever()
                .HasColumnName("PondID");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC27D84273A5");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<WaterParameter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WaterParameter");

            entity.Property(e => e.MeasurementDate).HasColumnType("datetime");
            entity.Property(e => e.No2).HasColumnName("NO2");
            entity.Property(e => e.No3).HasColumnName("NO3");
            entity.Property(e => e.Ph).HasColumnName("PH");
            entity.Property(e => e.Po4).HasColumnName("PO4");
            entity.Property(e => e.PondId).HasColumnName("PondID");

            entity.HasOne(d => d.Pond).WithMany()
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK__WaterPara__PondI__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
