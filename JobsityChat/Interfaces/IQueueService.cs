using System.Threading.Tasks;

namespace JobsityChat.Interfaces
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(string queueName, T message) where T : class;
    }
}
