using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class BookingEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string CustomerName { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Required]
    public string RoomId { get; set; } = null!;
    public RoomEntity Room { get; set; } = null!;
}

