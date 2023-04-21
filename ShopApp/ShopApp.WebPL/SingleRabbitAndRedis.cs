using ShopApp.WebPL.RabbitMQ;
using ShopApp.WebPL.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebPL
{
    public class SingleRabbitAndRedis
    {
        private static SingleRabbitAndRedis _instance;
        public static SingleRabbitAndRedis Instance => _instance = _instance ?? new SingleRabbitAndRedis();
        public RabbitMQClient Rabbit => new RabbitMQClient();
        public RedisStorageClient Redis => new RedisStorageClient();

    }
}
