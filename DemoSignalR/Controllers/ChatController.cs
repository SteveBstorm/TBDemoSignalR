using DemoSignalR.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private MessageManager _messageManager;

        public ChatController(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        [HttpGet]
        public IActionResult GetMessage()
        {
            return Ok(_messageManager.GetAll());
        }
    }
}
