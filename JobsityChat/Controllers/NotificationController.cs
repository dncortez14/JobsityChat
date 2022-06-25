using JobsityChat.Hubs;
using JobsityChat.Models;
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
            if (string.IsNullOrEmpty(queueMessage.ConnectionId))
                await _hubContext.Clients.Group(queueMessage.RoomName).SendAsync("Notifications", queueMessage.SenderUser, queueMessage.Text, queueMessage.datetime.ToShortTimeString());
            else
                await _hubContext.Clients.Client(queueMessage.ConnectionId).SendAsync("Notifications", queueMessage.SenderUser, queueMessage.Text, queueMessage.datetime.ToShortTimeString());
            
            return Ok();
        }
    }
}
