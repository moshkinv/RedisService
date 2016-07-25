using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;

namespace RedisService
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _clientNative;
        private readonly ICacheClient _clientExt;
        public RedisService()
        {
            _clientNative = RedisConnectorHelper.Connection.GetDatabase();
            _clientExt = RedisConnectorHelper.ConnectionExt;
        }

        public IDatabase ClientNative
        {
            get { return _clientNative; }
        }

        #region _clientNative proparty
        public int NumericIdentifierOfThisDataBase => _clientNative.Database;

        public ConnectionMultiplexer ConnectionMultiplexerThatCreatedThisInstance => _clientNative.Multiplexer;

        #endregion

        #region Redis String
        public bool StringSet(string key, string value)
        {
            TimeSpan? expiry = null;
            return _clientNative.StringSet(key, value, expiry, When.Always);
        }

        public string StringGet(string key)
        {
            return _clientNative.StringGet(key);
        }

        public long StringAppend(string key, string value)
        {
            return _clientNative.StringAppend(key, value);
        }

        public long StringBitCount(string key)
        {
            long start = 0;
            long end = -1;
            return _clientNative.StringBitCount(key, start, end);
        }

        public long StringBitOperation(Bitwise bitwise, string destination, string firstKey, string secondKey)
        {
            return _clientNative.StringBitOperation(bitwise, destination, firstKey, secondKey);
        }

        public long StringBitPosition(string key, bool bit)
        {
            long start = 0;
            long end = -1;
            return _clientNative.StringBitPosition(key, bit, start, end);
        }

        public long StringDecrement(string key, long value = 1)
        {
            return _clientNative.StringDecrement(key, value);
        }

        public long StringIncrement(string key, long value = 1)
        {
            return _clientNative.StringIncrement(key, value);
        }

        public bool StringGetBit(string key, long offset)
        {
            return _clientNative.StringGetBit(key, offset);
        }

        public string StringGetRange(string key, long startIndex, long endIndex)
        {
            return _clientNative.StringGetRange(key, startIndex, endIndex);
        }

        public string StringGetSet(string key, string value)
        {
            return _clientNative.StringGetSet(key, value);
        }

        public RedisValueWithExpiry StringGetWithExpiry(string key, string value)
        {
            return _clientNative.StringGetWithExpiry(key);

        }

        public long StringLength(string key)
        {
            return _clientNative.StringLength(key);
        }

        public bool StringSetBit(string key, long offset, bool bit)
        {
            return _clientNative.StringSetBit(key, offset, bit);
        }

        public bool KeyDelete(string key)
        {
            return _clientNative.KeyDelete(key);
        }

        public string StringSetRange(string key, long offset, string value)
        {
            return _clientNative.StringSetRange(key, offset, value);
        }
        #endregion

        #region ClientExtensions

        public bool Add<T>(string key, T value)
        {
            return _clientExt.Add(RedisUtils.KeyBuilder<T>(key), value);
        }

        public bool Add<T>(string key, T value, TimeSpan expiresIn)
        {
            return _clientExt.Add(RedisUtils.KeyBuilder<T>(key), value, expiresIn);
        }

        public bool Add<T>(string key, T value, DateTimeOffset expiresAt)
        {
            return _clientExt.Add(RedisUtils.KeyBuilder<T>(key), value, expiresAt);
        }

        public bool AddAll<T>(IList<Tuple<string, T>> items)
        {
            return _clientExt.AddAll(items);
        }

        public Task<bool> AddAsync<T>(string key, T value)
        {
            return _clientExt.AddAsync(RedisUtils.KeyBuilder<T>(key), value);
        }

        public Task<bool> AddAsync<T>(string key, T value, TimeSpan expiresIn)
        {
            return _clientExt.AddAsync(RedisUtils.KeyBuilder<T>(key), value, expiresIn);
        }

        public Task<bool> AddAsync<T>(string key, T value, DateTimeOffset expiresAt)
        {
            return _clientExt.AddAsync(RedisUtils.KeyBuilder<T>(key), value, expiresAt);
        }

        public Task<bool> AddAllAsync<T>(IList<Tuple<string, T>> items)
        {
            return _clientExt.AddAllAsync(items);
        }

        public bool Exists<T>(string key)
        {
            return _clientExt.Exists(RedisUtils.KeyBuilder<T>(key));
        }
        public Task<bool> ExistsAsync<T>(string key)
        {
            return _clientExt.ExistsAsync(RedisUtils.KeyBuilder<T>(key));
        }

        public void FlushDb()
        {
            _clientExt.FlushDb();
        }

        public Task FlushDbAsync()
        {
            return _clientExt.FlushDbAsync();
        }

        public T Get<T>(string key)
        {
            return _clientExt.Get<T>(RedisUtils.KeyBuilder<T>(key));
        }

        public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            return _clientExt.GetAll<T>(RedisUtils.KeysBuilder<T>(keys));
        }

        public Task<IDictionary<string, T>> GetAllAsync<T>(IEnumerable<string> keys)
        {
            return _clientExt.GetAllAsync<T>(RedisUtils.KeysBuilder<T>(keys));
        }

        public Task<T> GetAsync<T>(string key)
        {
            return _clientExt.GetAsync<T>(RedisUtils.KeyBuilder<T>(key));
        }

        public Dictionary<string, string> GetInfo()
        {
            return _clientExt.GetInfo();
        }

        public Task<Dictionary<string, string>> GetInfoAsync()
        {
            return _clientExt.GetInfoAsync();
        }

        public bool HashDelete(string hashKey, string key)
        {
            return _clientExt.HashDelete(hashKey, key);
        }

        public long HashDelete(string hashKey, IEnumerable<string> keys)
        {
            return _clientExt.HashDelete(hashKey, keys);
        }

        public Task<bool> HashDeleteAsync(string hashKey, string key)
        {
            return _clientExt.HashDeleteAsync(hashKey, key);
        }

        public Task<long> HashDeleteAsync(string hashKey, IEnumerable<string> keys)
        {
            return _clientExt.HashDeleteAsync(hashKey, keys);
        }

        public bool HashExists(string hashKey, string key)
        {
            return _clientExt.HashExists(hashKey, key);
        }

        public Task<bool> HashExistsAsync(string hashKey, string key)
        {
            return _clientExt.HashExistsAsync(hashKey, key);
        }

        public T HashGet<T>(string hashKey, string key)
        {
            return _clientExt.HashGet<T>(hashKey, key);
        }

        public Dictionary<string, T> HashGet<T>(string hashKey, IEnumerable<string> keys)
        {
            return _clientExt.HashGet<T>(hashKey, keys);
        }

        public Dictionary<string, T> HashGetAll<T>(string hashKey)
        {
            return _clientExt.HashGetAll<T>(hashKey);
        }

        public Task<Dictionary<string, T>> HashGetAsync<T>(string hashKey, IEnumerable<string> keys)
        {
            return _clientExt.HashGetAsync<T>(hashKey, keys);
        }

        public Task<Dictionary<string, T>> HashGetAllAsync<T>(string hashKey)
        {
            return _clientExt.HashGetAllAsync<T>(hashKey);
        }

        public Task<T> HashGetAsync<T>(string hashKey, string key)
        {
            return _clientExt.HashGetAsync<T>(hashKey, key);
        }

        public long HashIncerementBy(string hashKey, string key, long value)
        {
            return _clientExt.HashIncerementBy(hashKey, key, value);
        }

        public double HashIncerementBy(string hashKey, string key, double value)
        {
            return _clientExt.HashIncerementBy(hashKey, key, value);
        }

        public Task<double> HashIncerementByAsync(string hashKey, string key, double value)
        {
            return _clientExt.HashIncerementByAsync(hashKey, key, value);
        }

        public Task<long> HashIncerementByAsync(string hashKey, string key, long value)
        {
            return _clientExt.HashIncerementByAsync(hashKey, key, value);
        }

        public IEnumerable<string> HashKeys(string hashKey)
        {
            return _clientExt.HashKeys(hashKey);
        }

        public Task<IEnumerable<string>> HashKeysAsync(string hashKey)
        {
            return _clientExt.HashKeysAsync(hashKey);
        }

        public long HashLength(string hashKey)
        {
            return _clientExt.HashLength(hashKey);
        }

        public Task<long> HashLengthAsync(string hashKey)
        {
            return _clientExt.HashLengthAsync(hashKey);
        }

        public Dictionary<string, T> HashScan<T>(string hashKey, string pattern, int pageSize = 10)
        {
            return _clientExt.HashScan<T>(hashKey, pattern, pageSize);
        }

        public Task<Dictionary<string, T>> HashScanAsync<T>(string hashKey, string pattern, int pageSize = 10)
        {
            return _clientExt.HashScanAsync<T>(hashKey, pattern, pageSize);
        }

        public void HashSet<T>(string hashKey, Dictionary<string, T> values)
        {
            _clientExt.HashSet(hashKey, values);
        }

        public bool HashSet<T>(string hashKey, string key, T value, bool nx = false)
        {
            return _clientExt.HashSet(hashKey, key, value, nx);
        }

        public Task HashSetAsync<T>(string hashKey, IDictionary<string, T> values)
        {
            return _clientExt.HashSetAsync(hashKey, values);
        }

        public Task<bool> HashSetAsync<T>(string hashKey, string key, T value, bool nx = false)
        {
            return _clientExt.HashSetAsync(hashKey, key, value, nx);
        }

        public IEnumerable<T> HashValues<T>(string hashKey)
        {
            return _clientExt.HashValues<T>(hashKey);
        }

        public Task<IEnumerable<T>> HashValuesAsync<T>(string hashKey)
        {
            return _clientExt.HashValuesAsync<T>(hashKey);
        }

        public long ListAddToLeft<T>(string key, T item) where T : class
        {
            return _clientExt.ListAddToLeft(key, item);
        }

        public Task<long> ListAddToLeftAsync<T>(string key, T item) where T : class
        {
            return _clientExt.ListAddToLeftAsync(key, item);
        }

        public T ListGetFromRight<T>(string key) where T : class
        {
            return _clientExt.ListGetFromRight<T>(key);
        }

        public Task<T> ListGetFromRightAsync<T>(string key) where T : class
        {
            return _clientExt.ListGetFromRightAsync<T>(key);
        }

        public long Publish<T>(RedisChannel channel, T message)
        {
            return _clientExt.Publish<T>(channel, message);
        }

        public Task<long> PublishAsync<T>(RedisChannel channel, T message)
        {
            return _clientExt.PublishAsync<T>(channel, message);
        }

        public bool Remove(string key)
        {
            return _clientExt.Remove(key);
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
            _clientExt.RemoveAll(keys);
        }

        public Task RemoveAllAsync(IEnumerable<string> keys)
        {
            return _clientExt.RemoveAllAsync(keys);
        }

        public Task<bool> RemoveAsync(string key)
        {
            return _clientExt.RemoveAsync(key);
        }

        public bool Replace<T>(string key, T value)
        {
            return _clientExt.Replace<T>(key, value);
        }

        public bool Replace<T>(string key, T value, TimeSpan expiresIn)
        {
            return _clientExt.Replace(key, value, expiresIn);
        }

        public bool Replace<T>(string key, T value, DateTimeOffset expiresAt)
        {
            return _clientExt.Replace(key, value, expiresAt);
        }

        public Task<bool> ReplaceAsync<T>(string key, T value)
        {
            return _clientExt.ReplaceAsync<T>(key, value);
        }

        public Task<bool> ReplaceAsync<T>(string key, T value, DateTimeOffset expiresAt)
        {
            return _clientExt.ReplaceAsync(key, value, expiresAt);
        }

        public Task<bool> ReplaceAsync<T>(string key, T value, TimeSpan expiresIn)
        {
            return _clientExt.ReplaceAsync(key, value, expiresIn);
        }

        public void Save(SaveType saveType)
        {
            _clientExt.Save(saveType);
        }

        public void SaveAsync(SaveType saveType)
        {
            _clientExt.Save(saveType);
        }

        public IEnumerable<string> SearchKeys(string pattern)
        {
            return _clientExt.SearchKeys(pattern);
        }

        public Task<IEnumerable<string>> SearchKeysAsync(string pattern)
        {
            return _clientExt.SearchKeysAsync(pattern);
        }

        public bool SetAdd(string memberName, string key)
        {
            return _clientExt.SetAdd(memberName, key);
        }

        public bool SetAdd<T>(string key, T item) where T : class
        {
            return _clientExt.SetAdd<T>(key, item);
        }   

        public Task<bool> SetAddAsync(string memberName, string key)
        {
            return _clientExt.SetAddAsync(memberName, key);
        }

        public Task<bool> SetAddAsync<T>(string key, T item) where T : class
        {
            return _clientExt.SetAddAsync<T>(key, item);
        }

        public string[] SetMember(string memberName)
        {
            return _clientExt.SetMember(memberName);
        }

        public Task<string[]> SetMemberAsync(string memberName)
        {
            return _clientExt.SetMemberAsync(memberName);
        }

        public Task<IEnumerable<T>> SetMembersAsync<T>(string key)
        {
            return _clientExt.SetMembersAsync<T>(key);
        }

        public void Subscribe<T>(RedisChannel channel, Action<T> handler)
        {
            _clientExt.Subscribe<T>(channel, handler);
        }

        public Task SubscribeAsync<T>(RedisChannel channel, Func<T, Task> handler)
        {
            return _clientExt.SubscribeAsync<T>(channel, handler);
        }

        public void Unsubscribe<T>(RedisChannel channel, Action<T> handler)
        {
            _clientExt.Unsubscribe<T>(channel, handler);
        }

        public void UnsubscribeAll()
        {
            _clientExt.UnsubscribeAll();
        }

        public Task UnsubscribeAllAsync()
        {
            return _clientExt.UnsubscribeAllAsync();
        }

        public Task UnsubscribeAsync<T>(RedisChannel channel, Func<T, Task> handler)
        {
            return _clientExt.UnsubscribeAsync<T>(channel, handler);
        }

        #endregion
    }
}
