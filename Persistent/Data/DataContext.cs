using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<RoomEntity> Rooms { get; set; }
    public DbSet<PackageEntity> Packages { get; set; }
    public DbSet<RoomPackagesEntity> RoomsPackages { get; set; }
    public DbSet<BookingEntity> Bookings { get; set; }

}


