using Microsoft.EntityFrameworkCore;
using RoomService.Entities;

namespace RoomService.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<RoomEntity> Rooms { get; set; }
}
