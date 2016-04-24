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

            #region String
            redisService.StringSet(RedisUtils.KeyBuilder("Company", 1, "Name"), "Evolvice");
            redisService.StringSet(RedisUtils.KeyBuilder("Company", 1, "Code"), "EC");
            //redisService.KeyDelete(RedisUtils.KeyBuilder("Company", 1, "Code"));
            var name = redisService.StringGet(RedisUtils.KeyBuilder("Company", 1, "Name"));
            var code = redisService.StringGet(RedisUtils.KeyBuilder("Company", 1, "Code"));         
            Console.WriteLine($"CompanyName: <{name}> CompanyCode: <{code}>");
            #endregion


            Console.ReadKey();
        }
    }
}
