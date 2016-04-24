using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisService
{
    public class RedisService : IRedisService
    {
        IDatabase redis;
        public RedisService()
        {
            redis = RedisConnectorHelper.Connection.GetDatabase();
        }

        #region Redis proparty
        public int NumericIdentifierOfThisDataBase
        {
            get { return redis.Database; }
        }

        public ConnectionMultiplexer ConnectionMultiplexerThatCreatedThisInstance
        {
            get { return redis.Multiplexer; }
        }
        #endregion

        #region Redis String
        public bool StringSet(string key, string value)
        {
            TimeSpan? expiry = null;
            return redis.StringSet(key, value, expiry, When.Always, CommandFlags.None);
        }

        public string StringGet(string key)
        {
            return redis.StringGet(key, CommandFlags.None);
        }

        public long StringAppend(string key, string value)
        {
            return redis.StringAppend(key, value, CommandFlags.None);
        }

        public long StringBitCount(string key)
        {
            long start = 0;
            long end = -1;
            return redis.StringBitCount(key, start, end, CommandFlags.None);
        }

        public long StringBitOperation(Bitwise bitwise, string destination, string firstKey, string secondKey)
        {
            return redis.StringBitOperation(bitwise, destination, firstKey, secondKey, CommandFlags.None);
        }

        public long StringBitPosition(string key, bool bit)
        {
            long start = 0;
            long end = -1;
            return redis.StringBitPosition(key, bit, start, end, CommandFlags.None);
        }

        public long StringDecrement(string key, long value = 1)
        {
            return redis.StringDecrement(key, value, CommandFlags.None);
        }

        public long StringIncrement(string key, long value = 1)
        {
            return redis.StringIncrement(key, value, CommandFlags.None);
        }

        public bool StringGetBit(string key, long offset)
        {
            return redis.StringGetBit(key, offset, CommandFlags.None);
        }

        public string StringGetRange(string key, long startIndex, long endIndex)
        {
            return redis.StringGetRange(key, startIndex, endIndex, CommandFlags.None);
        }

        public string StringGetSet(string key, string value)
        {
            return redis.StringGetSet(key, value, CommandFlags.None);
        }

        public RedisValueWithExpiry StringGetWithExpiry(string key, string value)
        {
            return redis.StringGetWithExpiry(key, CommandFlags.None);

        }

        public long StringLength(string key)
        {
            return redis.StringLength(key, CommandFlags.None);
        }

        public bool StringSetBit(string key, long offset, bool bit)
        {
            return redis.StringSetBit(key, offset, bit, CommandFlags.None);
        }

        public bool KeyDelete(string key)
        {
            return redis.KeyDelete(key, CommandFlags.None);
        }

        public string StringSetRange(string key, long offset, string value)
        {
            return redis.StringSetRange(key, offset, value, CommandFlags.None);
        }
        #endregion

    }
}
