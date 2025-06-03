using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class RoomEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Image { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<RoomPackagesEntity> Packages { get; set; } = [];
    public ICollection<BookingEntity> Bookings { get; set; } = [];
}

