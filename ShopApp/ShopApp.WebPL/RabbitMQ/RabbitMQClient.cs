using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace ShopApp.WebPL.RabbitMQ
{
    public class RabbitMQClient
    {
        string QUEUE;
        string rabbitHost;
        ConnectionFactory rabbitFactory;
        public RabbitMQClient()
        {
            QUEUE = "NOTIFICATION_QUEUE";
            rabbitHost = "localhost";
            rabbitFactory = new ConnectionFactory()
            {
                //Uri = new Uri("amqp://guest:guest@localhost:5672/"),
                HostName = rabbitHost,
                UserName = "guest",
                Password = "guest",
                //Ssl =
                //{
                //    ServerName = rabbitHost,
                //    Enabled = true
                //}
            };

        }
        public void Send(string message)
        {
            using (var rabbitConnection = rabbitFactory.CreateConnection())
            using (var rabbitChannel = rabbitConnection.CreateModel())
            {
                rabbitChannel.QueueDeclare(queue: QUEUE,
                                              durable: true,
                                              exclusive: false,
                                              autoDelete: false,
                                              arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                rabbitChannel.BasicPublish(exchange: "",
                               routingKey: QUEUE,
                               basicProperties: null,
                               body: body);
            }
        }

    }
}
