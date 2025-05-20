using RoomService.Models;

namespace RoomService.Services;

public class BookingService : IBookingService
{
    public List<Room> GetAll()
    {
        return new List<Room>
        {
            new Room { Id = 1, Name = "Standard Room", Description = "Basic room with bed and desk.", PricePerNight = 1995, IsAvailable = true },
            new Room { Id = 2, Name = "Deluxe Room", Description = "Spacious room with a view.", PricePerNight = 2495, IsAvailable = false },
            new Room { Id = 3, Name = "Suite", Description = "Luxury suite with living area.", PricePerNight = 4195, IsAvailable = true }
        };
    }

}

