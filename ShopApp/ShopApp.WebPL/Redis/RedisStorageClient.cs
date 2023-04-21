using Newtonsoft.Json;
using ShopApp.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopApp.WebPL.Redis
{
    public class RedisStorageClient
    {


        private string _host;
        private string _port;
        private string _password;
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public RedisStorageClient()
        {


            this._host = "localhost";
            this._port = "6379";
            this._password = null;



            if (string.IsNullOrEmpty(this._password))
            {
                this._connectionMultiplexer = ConnectionMultiplexer.Connect(
                    new ConfigurationOptions
                    {
                        EndPoints = { $"{this._host}:{this._port}" },
                        AbortOnConnectFail = false
                    });
            }
            else
            {
                this._connectionMultiplexer = ConnectionMultiplexer.Connect(
                   new ConfigurationOptions
                   {
                       EndPoints = { $"{this._host}:{this._port}" },
                       Password = this._password
                   });
            }
        }

        public User GetUser(string key)
        {
            return this.Get<User>(key);
        }

        private T Get<T>(string key) where T : class
        {
            //try
           // {
                var client = _connectionMultiplexer.GetDatabase();
                var stringVal = client.StringGet(key);
                if (string.IsNullOrEmpty(stringVal))
                {
                    return null;
                }
                return JsonConvert.DeserializeObject<T>(stringVal);
          //  }
           // catch (Exception exc)
           // {
            //    Console.WriteLine(exc);
           //     return default(T);
           // }
        }

        public void SetUser(string key, User value, int expirationSeconds)
        {
            this.Set<User>(key, value, TimeSpan.FromSeconds(expirationSeconds));
        }

        private void Set<T>(string key, T value, TimeSpan expiration)
        {
           // try
           // {
                var client = _connectionMultiplexer.GetDatabase();
                client.StringSet(key, JsonConvert.SerializeObject(value), expiration);
           // }
           // catch (Exception exc)
          //  {
           //     Console.WriteLine(exc);
           // }
        }

        public void SetGlobalItem<T>(string key, T value, TimeSpan time) where T : class
        {
            this.Set(key, value, time);
        }

        public bool TryGetGlobalItem<T>(string key, out T value) where T : class
        {
            value = this.Get<T>(key);
            if (value == null)
            {
                return false;
            }
            return true;
        }

        public void Remove(string key)
        {
            try
            {
                var client = _connectionMultiplexer.GetDatabase();
                client.KeyDelete(key);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

    }
}
