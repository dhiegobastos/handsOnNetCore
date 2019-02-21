using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace hands_on_netcore.Service
{
    public class ServiceBusHandler
    {
        private static ISubscriptionClient _subscriptionClient;

        public static void RegistrarCapturaMensagem(IConfiguration configuration)
        {
            _subscriptionClient = new SubscriptionClient(configuration.GetConnectionString("ServiceBus"),
                    configuration.GetValue<string>("ServiceBus:NomeTopico"),
                    configuration.GetValue<string>("ServiceBus:NomeSubscription"));

            var handlerOptions = new MessageHandlerOptions(CapturarException)
            {
                MaxConcurrentCalls = 10,
                AutoComplete = false
            };

            _subscriptionClient.RegisterMessageHandler(ProcessarMensagemAsync, handlerOptions);
        }

        static async Task ProcessarMensagemAsync(Message mensagem, CancellationToken token)
        {
            // Process the message.
            Console.WriteLine("##############################");
            Console.WriteLine("######################################################");
            Console.WriteLine($"Mensagem recebida: Número Sequência:{mensagem.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(mensagem.Body)}");
            Console.WriteLine("######################################################");
            Console.WriteLine("##############################");

            // Marca a mensagem como completa para que não seja reprocessada novamente
            await _subscriptionClient.CompleteAsync(mensagem.SystemProperties.LockToken);
        }

        static Task CapturarException(ExceptionReceivedEventArgs args)
        {
            Console.WriteLine($"Handler encontrou uma exception {args.Exception}.");
            var context = args.ExceptionReceivedContext;
            Console.WriteLine("Exception:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Action: {context.Action}");
            return Task.CompletedTask;
        }

    }
}