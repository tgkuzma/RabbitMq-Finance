using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Integrations;
using Integrations.ReceiveingEvents;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TestConsole
{
    public class Program
    {
        private readonly ICustomerManager _customerManager;
        private readonly SharedIntegrationEvents _integrationEvents;

        public Program(ICustomerManager customerManager, SharedIntegrationEvents integrationEvents)
        {
            _customerManager = customerManager;
            _integrationEvents = integrationEvents;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("----------FINANCE----------");
            Console.WriteLine("Waiting for messages...");

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
