using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RedisService
{
    public class RedisConnectorHelper
    {
        static RedisConnectorHelper()
        {
            string ip = ConfigurationManager.AppSettings["IP"];
            string port = ConfigurationManager.AppSettings["Port"];

            RedisConnectorHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                //return ConnectionMultiplexer.Connect("localhost:6379");
                //return ConnectionMultiplexer.Connect("server1: 6379, server2: 6379");
                return ConnectionMultiplexer.Connect($"{ip}:{port}");
            });
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
