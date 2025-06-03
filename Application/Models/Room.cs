using Persistence.Entities;

namespace Application.Models;

public class Room
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Image { get; set; }
    public string Description { get; set; } = null!;
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }
}


   
    
