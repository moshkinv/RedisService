using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis.Extensions.Core.Extensions;

namespace RedisService
{
    class Program
    {
        static void Main(string[] args)
        {
            IRedisService redisService = new RedisService();
            
            #region ConnectionMultiplexerThatCreatedThisInstance
            var myConnectionMultiplexer = redisService.ConnectionMultiplexerThatCreatedThisInstance;
            Console.WriteLine($"IsConnected: {myConnectionMultiplexer.IsConnected}");
            Console.WriteLine($"ClientName: {myConnectionMultiplexer.ClientName}");
            Console.WriteLine($"Configuration: {myConnectionMultiplexer.Configuration}");
            Console.WriteLine($"IncludeDetailInExceptions: {myConnectionMultiplexer.IncludeDetailInExceptions}");
            Console.WriteLine($"OperationCount: {myConnectionMultiplexer.OperationCount}");
            Console.WriteLine($"PreserveAsyncOrder: {myConnectionMultiplexer.PreserveAsyncOrder}");
            Console.WriteLine($"StormLogThreshold: {myConnectionMultiplexer.StormLogThreshold}");
            Console.WriteLine($"TimeoutMilliseconds:{myConnectionMultiplexer.TimeoutMilliseconds}");
            Console.WriteLine(String.Empty);
            #endregion

            Console.ReadKey();
        }
    }

    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }    
    }
}
