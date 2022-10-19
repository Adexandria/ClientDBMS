using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientDBMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IConfiguration _config;
        public TestController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("connection-string")]
        public IActionResult TestConnectionString()
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            return Ok(connectionString);
        }

        [HttpGet("message")]
        public IActionResult GetMessage()
        {
            var messages = _config.GetSection("Message");
            var chatMessage = messages["Chat"];
            return Ok(chatMessage);
        }
    }
}
