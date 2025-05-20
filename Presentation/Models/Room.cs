namespace RoomService.Models;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
}