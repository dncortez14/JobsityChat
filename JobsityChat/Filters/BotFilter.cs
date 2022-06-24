using JobsityChat.Interfaces;
using JobsityChat.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobsityChat.Filters
{
    public class BotFilter : IHubFilter
    {
        private readonly IQueueService _queueService;

        public BotFilter(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public async ValueTask<object> InvokeMethodAsync(HubInvocationContext invocationContext,
            Func<HubInvocationContext, ValueTask<object>> next)
        {
            const string STOCK = "/stock=";
            string message = invocationContext.HubMethodArguments.First().ToString();

            if (message.StartsWith(STOCK))
            {
                var userName = invocationContext.Context.User.Identity.Name;
                var roomName = invocationContext.Context.GetHttpContext().Request.Query["roomName"];

                var qmsg = new QueueMessage(userName, message, roomName);
                await _queueService.SendMessageAsync("stock", qmsg);
                throw new HubException("error");
            }
            else
                return await next(invocationContext);
        }
    }
}
