using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobsityChat.Filters
{
    public class BotFilter : IHubFilter
    {
        public async ValueTask<object> InvokeMethodAsync(HubInvocationContext invocationContext,
            Func<HubInvocationContext, ValueTask<object>> next)
        {
            const string STOCK = "/stock=";
            string message = invocationContext.HubMethodArguments.First().ToString();

            if (message.StartsWith(STOCK))
            {
                //todo send message to a queue
                throw new HubException("error");
            }
            else
                return await next(invocationContext);
        }
    }
}
