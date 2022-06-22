using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace JobsityChat.Hubs
{
    public class RoomChatHub : Hub
    {
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.OthersInGroup(groupName).SendAsync("ReceiveMessage", "pedro has join to the room");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.OthersInGroup(groupName).SendAsync("ReceiveMessage", "pedro has left the room");
        }
    }
}
