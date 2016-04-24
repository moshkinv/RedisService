using System;
using System.Collections.Generic;
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
            //redis.StringGet() 
            //RedisKey
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

        public bool StringSet(string key, string value)
        {
            TimeSpan? expiry = null;
            return redis.StringSet(key, value, expiry, When.Always, CommandFlags.None);
        }

        public string StringGet(string key)
        {
            return redis.StringGet(key, CommandFlags.None);
        }

        public string KeyBuilder(string objectType, object id, string field = null)
        {
            if (field == null)
            {
                return $"{objectType}:{id.ToString()}";
            }
            else
            {
                return $"{objectType}:{id.ToString()}:{field}";
            }
            
        }

    }
}
