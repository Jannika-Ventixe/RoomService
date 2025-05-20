using System.ComponentModel.DataAnnotations;

namespace RoomService.Entities;

public class RoomEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string RoomId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string CustomerName { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

}
