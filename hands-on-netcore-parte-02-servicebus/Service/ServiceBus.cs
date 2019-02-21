using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace hands_on_netcore.Service
{
    public class ServiceBus : IServiceBus
    {
        private readonly IConfiguration _configuration;

        public ServiceBus(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Publicar(string messageId, string body)
        {
            try
            {
                ITopicClient topicClient = new TopicClient(_configuration.GetConnectionString("ServiceBus"),
                    _configuration.GetValue<string>("ServiceBus:NomeTopico"));
                var message = new Message(Encoding.UTF8.GetBytes(body));
                message.MessageId = messageId;
                await topicClient.SendAsync(message);
                await topicClient.CloseAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}