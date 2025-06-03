using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace RoomService.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RoomController(IBookingService bookingService) : ControllerBase

{
    private readonly IBookingService _bookingService = bookingService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _bookingService.GetAllAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _bookingService.GetAsync(id);
        return result != null ? Ok(result) : NotFound();

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingRequest request)
    {

        if (!ModelState.IsValid)
        
            return BadRequest(ModelState);

            var result = await _bookingService.CreateBookingAsync(request);
            return result.Success ? Ok() : StatusCode(500, result.Error);
    }    
}

