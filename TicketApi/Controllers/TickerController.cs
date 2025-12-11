using Microsoft.AspNetCore.Mvc;

namespace TicketApi.Controllers
{

    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult Get() => Ok("ok");
    }
}