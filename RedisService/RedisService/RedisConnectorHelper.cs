using StackExchange.Redis;
using System;
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
            string allowAdmin = ConfigurationManager.AppSettings["allowAdmin"];

            var serializer = new NewtonsoftSerializer();

            _lazyConnectionExt = new Lazy<StackExchangeRedisCacheClient>(
                () => new StackExchangeRedisCacheClient(
                    ConnectionMultiplexer.Connect($"{ip}:{port}, allowAdmin={allowAdmin}"), serializer));
        }

        private static Lazy<StackExchangeRedisCacheClient> _lazyConnectionExt; 

        public static StackExchangeRedisCacheClient ConnectionExt => _lazyConnectionExt.Value;
    }
}
