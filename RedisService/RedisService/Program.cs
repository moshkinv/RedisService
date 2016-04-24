using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisService
{
    class Program
    {
        static void Main(string[] args)
        {
            IRedisService redisService = new RedisService();

            #region ConnectionMultiplexerThatCreatedThisInstance
            Console.WriteLine($"IsConnected: {redisService.ConnectionMultiplexerThatCreatedThisInstance.IsConnected}");
            Console.WriteLine($"ClientName: {redisService.ConnectionMultiplexerThatCreatedThisInstance.ClientName}");
            Console.WriteLine($"Configuration: {redisService.ConnectionMultiplexerThatCreatedThisInstance.Configuration}");
            Console.WriteLine($"IncludeDetailInExceptions: {redisService.ConnectionMultiplexerThatCreatedThisInstance.IncludeDetailInExceptions}");
            Console.WriteLine($"OperationCount: {redisService.ConnectionMultiplexerThatCreatedThisInstance.OperationCount}");
            Console.WriteLine($"PreserveAsyncOrder: {redisService.ConnectionMultiplexerThatCreatedThisInstance.PreserveAsyncOrder}");
            Console.WriteLine($"StormLogThreshold: {redisService.ConnectionMultiplexerThatCreatedThisInstance.StormLogThreshold}");
            Console.WriteLine($"TimeoutMilliseconds:{redisService.ConnectionMultiplexerThatCreatedThisInstance.TimeoutMilliseconds}");
            Console.WriteLine(String.Empty);
            #endregion

            #region String
            redisService.StringSet(redisService.KeyBuilder("Company","1","Name"), "Evolvice");
            redisService.StringSet(redisService.KeyBuilder("Company", "1", "Code"), "EC");
            var name = redisService.StringGet(redisService.KeyBuilder("Company", "2", "Name"));
            var code = redisService.StringGet(redisService.KeyBuilder("Company", "2", "Name"));
            Console.WriteLine(value);
            #endregion


            Console.ReadKey();
        }
    }
}
