using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrations;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var factory = new ConnectionFactory() { HostName = "localhost" };
            
            //var connection = factory.CreateConnection();
            var messagingManager = new MessagingManager("localhost");

            var handler = new EventHandler<BasicDeliverEventArgs>(
                (model, ea) =>
                {
                    var msg = Encoding.UTF8.GetString(ea.Body);
                    Console.WriteLine(msg);
                });

            messagingManager.Subscribe("Finance.Customer.Added", handler);
            messagingManager.Subscribe("Finance.Customer.Deleted", handler);
            messagingManager.Subscribe("Finance.Customer.Modified", handler);

            Console.Read();
        }
    }
}
