using Application.Models;

namespace Application.Services;

public interface IBookingService
{
    Task<RoomResult<IEnumerable<Room>>> GetAllAsync();
    Task<RoomResult<Room?>> GetAsync(string roomId);
    Task<RoomResult> CreateBookingAsync(CreateBookingRequest request);
}

