using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<RoomEntity> Rooms { get; set; }
    public DbSet<PackageEntity> Packages { get; set; }
    public DbSet<RoomPackagesEntity> RoomsPackages { get; set; }
    public DbSet<BookingEntity> RoomBookings { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RoomEntity>()
            .HasMany(x => x.Bookings)
            .WithOne(x => x.Room)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RoomPackagesEntity>()
            .HasKey(x => new {x.RoomId, x.PackageId});

        modelBuilder.Entity<RoomPackagesEntity>()
            .HasOne(rp => rp.Room)
            .WithMany(r => r.Packages)
            .HasForeignKey(rp => rp.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

      

        modelBuilder.Entity<BookingEntity>()
            .HasOne(b => b.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Restrict);



    }


}

