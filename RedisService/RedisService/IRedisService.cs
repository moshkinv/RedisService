using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisService
{
    public interface IRedisService
    {
        int NumericIdentifierOfThisDataBase { get; }
        ConnectionMultiplexer ConnectionMultiplexerThatCreatedThisInstance { get; }

        bool StringSet(string key, string value);
        string StringGet(string key);

        string KeyBuilder(string objectType, object id, string field = null);
    }
}
