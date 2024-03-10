using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class OrganizedTripsContext : DbContext
{
    public OrganizedTripsContext()
    {
    }

    public OrganizedTripsContext(DbContextOptions<OrganizedTripsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrderPlace> OrderPlaces { get; set; }

    public virtual DbSet<TheTrip> TheTrips { get; set; }

    public virtual DbSet<TypesTrip> TypesTrips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-E0FAPSB\\SQLEXPRESS;Initial Catalog=OrganizedTrips; Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderPlace>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__OrderPla__C8AAF6FF71CAD611");

            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.IdTrip).HasColumnName("idTrip");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.NumberPlaces).HasColumnName("numberPlaces");
            entity.Property(e => e.OrderDate)
                .HasColumnType("date")
                .HasColumnName("orderDate");
            entity.Property(e => e.OrderTime).HasColumnName("orderTime");

            entity.HasOne(d => d.IdTripNavigation).WithMany(p => p.OrderPlaces)
                .HasForeignKey(d => d.IdTrip)
                .HasConstraintName("FK__OrderPlac__idTri__2D27B809");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.OrderPlaces)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__OrderPlac__idUse__2C3393D0");
        });

        modelBuilder.Entity<TheTrip>(entity =>
        {
            entity.HasKey(e => e.IdTrip).HasName("PK__TheTrips__B90DB49C6A8C1164");

            entity.Property(e => e.IdTrip).HasColumnName("idTrip");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.IdType).HasColumnName("idType");
            entity.Property(e => e.Image)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LeavingTime).HasColumnName("leavingTime");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TargetTripe)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("targetTripe");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.TheTrips)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TheTrips__idType__29572725");
        });

        modelBuilder.Entity<TypesTrip>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PK__TypesTri__4BB98BC6B268104E");

            entity.Property(e => e.IdType).HasColumnName("idType");
            entity.Property(e => e.NameType)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("nameType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__3717C982A4ECFEC1");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Users__85FB4E385D94F4B5").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstAidCertificate).HasColumnName("firstAidCertificate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.PasswordIn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("passwordIn");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
