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
        private GroupManager _groupManager;

        public ChatController(MessageManager messageManager, GroupManager groupManager)
        {
            _messageManager = messageManager;
            _groupManager = groupManager;
        }

        [HttpGet]
        public IActionResult GetMessage()
        {
            return Ok(_messageManager.GetAll());
        }

        [HttpGet("group")]
        public IActionResult GetGroups()
        {
            return Ok(_groupManager.GetGroups());
        }
    }
}
