
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.DL.Rabbit
{
    public class RabbitConsumer
    {
        public static void Consume(IModel channel)
        {

            channel.QueueDeclare(queue: "Envelope-Queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(model);
            };
            channel.BasicConsume(queue: "Envelope-Queue",
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
