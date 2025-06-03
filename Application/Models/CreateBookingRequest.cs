using System.ComponentModel.DataAnnotations;

namespace Application.Models;

public class CreateBookingRequest
{
    [Required]
    public string RoomId { get; set; } = null!;
    public string? Image { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CustomerName { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

}
