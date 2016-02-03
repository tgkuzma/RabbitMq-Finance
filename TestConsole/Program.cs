using System;
using Integrations;
using Integrations.ReceiveingEvents;

namespace TestConsole
{
    public class Program
    {
        public Program(SharedIntegrationEvents integrationEvents)
        {
            var integrationEvents1 = integrationEvents;

            var messagingManager = new MessagingManager("localhost");

            var customerAddedHandler = integrationEvents1.GetCustomerAddedHandler();
            var customerDeletedHandler = integrationEvents1.GetCustomerDeletedHandler();
            var customerModifiedHandler = integrationEvents1.GetCustomerModifiedHandler();

            messagingManager.Subscribe("Shared.Customer.Added", customerAddedHandler);
            messagingManager.Subscribe("Shared.Customer.Deleted", customerDeletedHandler);
            messagingManager.Subscribe("Shared.Customer.Modified", customerModifiedHandler);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("----------FINANCE----------");
            Console.WriteLine("Waiting for messages...");

            Console.Read();
        }
    }
}
