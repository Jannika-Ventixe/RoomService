using Persistence.Entities;

namespace Application.Models;

public class Room
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Image { get; set; }
    public string Description { get; set; } = null!;
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
}


   
    
