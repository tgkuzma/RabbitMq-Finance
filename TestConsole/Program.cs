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
            var messagingManager = new MessagingManager("localhost");

            var handler = new EventHandler<BasicDeliverEventArgs>(
                (model, ea) =>
                {
                    var msg = Encoding.UTF8.GetString(ea.Body);
                    Console.WriteLine(msg);
                });

            messagingManager.Subscribe("Shared.Customer.Added", handler);
            messagingManager.Subscribe("Shared.Customer.Deleted", handler);
            messagingManager.Subscribe("Shared.Customer.Modified", handler);

            Console.Read();
        }
    }
}
