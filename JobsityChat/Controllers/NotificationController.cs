using JobsityChat.Hubs;
using JobsityChat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace JobsityChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<RoomChatHub> _hubContext;

        public NotificationController(IHubContext<RoomChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<StatusCodeResult> Post(QueueMessage queueMessage)
        {
            await _hubContext.Clients.Group(queueMessage.RoomName).SendAsync("Notifications", queueMessage.SenderUser, queueMessage.Text, queueMessage.datetime.ToShortTimeString());
            return Ok();
        }

    }
}
