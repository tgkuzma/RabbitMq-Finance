﻿using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Integrations
{
    public class MessagingManager
    {
        private readonly string _hostName;
        private static IModel _model;

        public MessagingManager(string hostName)
        {
            _hostName = hostName;

            if (_model != null) return;
            var factory = new ConnectionFactory() { HostName = _hostName };
            var connection = factory.CreateConnection();
            _model = connection.CreateModel();
        }

        public static IModel GetModel()
        {
            return _model;
        }

        public void CreateQueue(string queueName)
        {
            _model.QueueDeclare(queueName, true, false, false, null);
        }

        public void CreateTopic(string topicName)
        {
            _model.ExchangeDeclare(topicName, ExchangeType.Topic, true);
        }

        public void PublishCommand(string queueName, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _model.BasicPublish(string.Empty, queueName, null, body);
        }

        public void Subscribe(string queueName, EventHandler<BasicDeliverEventArgs> handler)
        {
            CreateQueue(queueName);
            var consumer = new EventingBasicConsumer(_model);
            consumer.Received += handler;
            _model.BasicConsume(queueName, true, consumer);
        }
    }
}