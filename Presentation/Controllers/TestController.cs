using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoomService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            
            return Ok("funkar");
        }
    }
}
