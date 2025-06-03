using Application.Models;
using Persistence.Entities;
using Persistence.Repositories;

namespace Application.Services;

public class BookingService(IRoomRepository roomRepository, IBookingRepository bookingRepository) : IBookingService
{
    private readonly IRoomRepository _roomRepository = roomRepository;
    private readonly IBookingRepository _bookingRepository = bookingRepository;    

    public async Task<RoomResult<IEnumerable<Room>>> GetAllAsync()
    {
        var result = await _roomRepository.GetAllAsync();

        if (result.Success && result.Result != null)
        {
            var rooms = result.Result.Select(x => new Room
            {
                Id = x.Id,
                Image = x.Image,
                Title = x.Title,
                Description = x.Description,
               
            });

            return new RoomResult<IEnumerable<Room>> { Success = true, Result = rooms };
        }
        return new RoomResult<IEnumerable<Room>>
        {
            Success = false,
            Error = "Could not retrieve rooms."
        };
    }
    public async Task<RoomResult<Room?>> GetAsync(string roomId)
    {
        var result = await _roomRepository.GetAsync(x => x.Id == roomId);
        if (result.Success && result.Result != null)
        {
            var CurrentRoom = new Room
            {
                Image = result.Result.Image,
                Title = result.Result.Title,
                Description = result.Result.Description
            };
            return new RoomResult<Room?> { Success = true, Result = CurrentRoom };
        }
        return new RoomResult<Room?> { Success = false, Error = "Room not Found."};

    }   

    public async Task<RoomResult> CreateBookingAsync(CreateBookingRequest request)
    {
        try
        {
        var booking = new BookingEntity
        {
            Id = Guid.NewGuid().ToString(),
            CustomerName = request.CustomerName,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            RoomId = request.RoomId
        };

        var result = await _bookingRepository.AddAsync<BookingEntity>(booking);
            return result.Success
                ? new RoomResult { Success = true }
                : new RoomResult { Success = false, Error = result.Error };
        }
        catch (Exception ex)
        {
            return new RoomResult
            {
                Success = false,
                Error = ex.Message,
            };
        }        
    }
}

