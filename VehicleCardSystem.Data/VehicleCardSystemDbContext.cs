using Microsoft.EntityFrameworkCore;
using System;
using VehicleCardSystem.Core.Models;
namespace VehicleCardSystem.Data
{
    public class VehicleCardSystemDbContext : DbContext
    {
        public VehicleCardSystemDbContext(DbContextOptions<VehicleCardSystemDbContext> options)
           : base(options)
        {
        }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(e => e.VehicletypeId);

                entity.ToTable("VEHICLETYPE");

                entity.Property(e => e.VehicletypeId)
                .HasColumnName("VEHICLETYPEID")
                .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Brand)
              .HasMaxLength(50)
              .HasColumnName("BRAND");

                entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .HasColumnName("MODELNAME");

                entity.Property(e => e.CapacityKg)
                .HasColumnName("CAPACITYKG");

                entity.Property(e => e.CapacityM3)
                .HasColumnName("CAPACITYM3");
            });
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.ToTable("VEHICLE");

                entity.Property(e => e.VehicleId)
                .HasColumnName("VEHICLEID")
                .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Plate)
               .HasMaxLength(10)
               .HasColumnName("PLATE");               

                entity.Property(e => e.ModelYear)               
                .HasColumnName("MODELYEAR");

                entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("COLOR");

                entity.Property(e => e.VehicletypeId)
               .HasColumnName("VEHICLETYPEID");

                entity.HasOne(v => v.VehicleTypes)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(v => v.VehicletypeId)
                .OnDelete(DeleteBehavior.Cascade);
            });
      
        }
    }
}
