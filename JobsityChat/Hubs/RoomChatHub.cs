using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using JobsityChat.Data;
using JobsityChat.Models;

namespace JobsityChat.Hubs
{
    public class RoomChatHub : Hub
    {
        private ApplicationDbContext context;

        public RoomChatHub(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public string GroupName { get { return Context.GetHttpContext().Request.Query["roomName"]; } }

        public int GroupId { get { return Int32.Parse(Context.GetHttpContext().Request.Query["roomId"]); } }

        public string UserName { get { return Context.GetHttpContext().User.Identity.Name; } }

        public async Task<string> SendMessage(string message)
        {
            var msg = new Message(UserName, message, GroupId);
            context.Add(msg);
            await context.SaveChangesAsync();

            var time = msg.datetime.ToShortTimeString();
            await Clients.OthersInGroup(GroupName).SendAsync("ReceiveMessage", message, UserName, time);
            return time;
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
            await Clients.OthersInGroup(GroupName).SendAsync("Notifications", $"{UserName} has join to the room");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupName);
            await Clients.OthersInGroup(GroupName).SendAsync("Notifications", $"{UserName} has left the room");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
