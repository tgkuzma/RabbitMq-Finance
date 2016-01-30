using System;
using System.Text;
using Integrations;
using NUnit.Framework;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Tests
{
    [TestFixture]
    public class MessagingManagerTests
    {
        private static readonly string _hostName = "localhost";

        [Test]
        public void CanPostAndSubscribe()
        {
            //Arrange
            var messagingManager = new MessagingManager(_hostName);
            var queueName = "testQueue";
            var message = "Test";
            var messageReceived = "";
            var handler = new EventHandler<BasicDeliverEventArgs>((model, ea) => messageReceived = Encoding.UTF8.GetString(ea.Body));

            messagingManager.CreateQueue(queueName);
            messagingManager.Subscribe(queueName, handler);

            //Act
            messagingManager.PublishCommand(queueName, message);

            //Assert
            Poller poller = new Poller(() =>
            {
                Assert.That(messageReceived, Is.EqualTo(message));
            });
            poller.PollFor(2000);
            
        }
    }
}
