using Microsoft.AspNetCore.Mvc;
using RoomService.Services;



namespace RoomService.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RoomController(IBookingService bookingService) : ControllerBase

{
    private readonly IBookingService _bookingService = bookingService;

    [HttpGet]
    public IActionResult GetAllRooms()
    {
        var result = _bookingService.GetAll();
        return Ok(result);
    }
}

