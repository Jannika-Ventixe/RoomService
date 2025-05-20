using RoomService.Models;

namespace RoomService.Services;

public interface IBookingService
{
    List<Room> GetAll();
}

