using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace RedisService
{
    public class RedisConnectorHelper
    {
        static RedisConnectorHelper()
        {
            string ip = ConfigurationManager.AppSettings["IP"];
            string port = ConfigurationManager.AppSettings["Port"];

            var serializer = new NewtonsoftSerializer();

            _lazyConnection = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect($"{ip}:{port}"));

            _lazyConnectionExt = new Lazy<StackExchangeRedisCacheClient>(
                () => new StackExchangeRedisCacheClient(
                    ConnectionMultiplexer.Connect($"{ip}:{port}"), serializer));
        }

        private readonly static Lazy<ConnectionMultiplexer> _lazyConnection;

        private readonly static Lazy<StackExchangeRedisCacheClient> _lazyConnectionExt; 

        public static ConnectionMultiplexer Connection => _lazyConnection.Value;

        public static StackExchangeRedisCacheClient ConnectionExt => _lazyConnectionExt.Value;
    }
}
