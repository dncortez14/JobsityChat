using Azure.Storage.Queues;
using JobsityChat.Interfaces;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace JobsityChat.Infrastructure
{
    public class QueueService: IQueueService
    {
        public QueueService(string connection)
        {
            StorageConnectionString = connection;
        }

        public string StorageConnectionString { get; set; }

        public async Task SendMessageAsync<T>(string queueName, T message) where T : class
        {
            QueueClient queueClient = new QueueClient(StorageConnectionString, queueName);

            await queueClient.CreateIfNotExistsAsync();

            if (queueClient.Exists())
            {
                var json = JsonConvert.SerializeObject(message);
                var messageForQueue = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
                await queueClient.SendMessageAsync(messageForQueue);
            }
        }
    }
}
