using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisService
{
    public interface IRedisService
    {
        IDatabase ClientNative {get;}

        int NumericIdentifierOfThisDataBase { get; }
        ConnectionMultiplexer ConnectionMultiplexerThatCreatedThisInstance { get; }

        bool StringSet(string key, string value);
        string StringGet(string key);
        bool KeyDelete(string key);

        bool Add<T>(string key, T value);

        bool Add<T>(string key, T value, TimeSpan expiresIn);

        bool Add<T>(string key, T value, DateTimeOffset expiresAt);

        bool AddAll<T>(IList<Tuple<string, T>> items);

        Task<bool> AddAllAsync<T>(IList<Tuple<string, T>> items);

        Task<bool> AddAsync<T>(string key, T value);

        Task<bool> AddAsync<T>(string key, T value, TimeSpan expiresIn);

        Task<bool> AddAsync<T>(string key, T value, DateTimeOffset expiresAt);

        bool Exists<T>(string key);

        Task<bool> ExistsAsync<T>(string key);

        void FlushDb();

        Task FlushDbAsync();

        T Get<T>(string key);

        IDictionary<string, T> GetAll<T>(IEnumerable<string> keys);

        Task<IDictionary<string, T>> GetAllAsync<T>(IEnumerable<string> keys);

        Task<T> GetAsync<T>(string key);
      
        Dictionary<string, string> GetInfo();
      
        Task<Dictionary<string, string>> GetInfoAsync();

        bool HashDelete(string hashKey, string key);

        long HashDelete(string hashKey, IEnumerable<string> keys);

        Task<long> HashDeleteAsync(string hashKey, IEnumerable<string> keys);

        Task<bool> HashDeleteAsync(string hashKey, string key);

        bool HashExists(string hashKey, string key);

        Task<bool> HashExistsAsync(string hashKey, string key);

        T HashGet<T>(string hashKey, string key);

        Dictionary<string, T> HashGet<T>(string hashKey, IEnumerable<string> keys);
  
        Dictionary<string, T> HashGetAll<T>(string hashKey);

        Task<Dictionary<string, T>> HashGetAllAsync<T>(string hashKey);

        Task<Dictionary<string, T>> HashGetAsync<T>(string hashKey, IEnumerable<string> keys);

        Task<T> HashGetAsync<T>(string hashKey, string key);

        long HashIncerementBy(string hashKey, string key, long value);

        double HashIncerementBy(string hashKey, string key, double value);

        Task<double> HashIncerementByAsync(string hashKey, string key, double value);

        Task<long> HashIncerementByAsync(string hashKey, string key, long value);

        IEnumerable<string> HashKeys(string hashKey);

        Task<IEnumerable<string>> HashKeysAsync(string hashKey);

        long HashLength(string hashKey);

        Task<long> HashLengthAsync(string hashKey);

        Dictionary<string, T> HashScan<T>(string hashKey, string pattern, int pageSize = 10);

        Task<Dictionary<string, T>> HashScanAsync<T>(string hashKey, string pattern, int pageSize = 10);

        void HashSet<T>(string hashKey, Dictionary<string, T> values);

        bool HashSet<T>(string hashKey, string key, T value, bool nx = false);

        Task HashSetAsync<T>(string hashKey, IDictionary<string, T> values);

        Task<bool> HashSetAsync<T>(string hashKey, string key, T value, bool nx = false);

        IEnumerable<T> HashValues<T>(string hashKey);

        Task<IEnumerable<T>> HashValuesAsync<T>(string hashKey);

        long ListAddToLeft<T>(string key, T item) where T : class;

        Task<long> ListAddToLeftAsync<T>(string key, T item) where T : class;

        T ListGetFromRight<T>(string key) where T : class;

        Task<T> ListGetFromRightAsync<T>(string key) where T : class;

        long Publish<T>(RedisChannel channel, T message);

        Task<long> PublishAsync<T>(RedisChannel channel, T message);

        bool Remove(string key);

        void RemoveAll(IEnumerable<string> keys);

        Task RemoveAllAsync(IEnumerable<string> keys);

        Task<bool> RemoveAsync(string key);

        bool Replace<T>(string key, T value);

        bool Replace<T>(string key, T value, TimeSpan expiresIn);

        bool Replace<T>(string key, T value, DateTimeOffset expiresAt);

        Task<bool> ReplaceAsync<T>(string key, T value);

        Task<bool> ReplaceAsync<T>(string key, T value, DateTimeOffset expiresAt);

        Task<bool> ReplaceAsync<T>(string key, T value, TimeSpan expiresIn);

        void Save(SaveType saveType);

        void SaveAsync(SaveType saveType);

        IEnumerable<string> SearchKeys(string pattern);

        Task<IEnumerable<string>> SearchKeysAsync(string pattern);

        bool SetAdd(string memberName, string key);

        bool SetAdd<T>(string key, T item) where T : class;

        Task<bool> SetAddAsync(string memberName, string key);

        Task<bool> SetAddAsync<T>(string key, T item) where T : class;

        string[] SetMember(string memberName);

        Task<string[]> SetMemberAsync(string memberName);

        Task<IEnumerable<T>> SetMembersAsync<T>(string key);

        void Subscribe<T>(RedisChannel channel, Action<T> handler);

        Task SubscribeAsync<T>(RedisChannel channel, Func<T, Task> handler);

        void Unsubscribe<T>(RedisChannel channel, Action<T> handler);

        void UnsubscribeAll();

        Task UnsubscribeAllAsync();

        Task UnsubscribeAsync<T>(RedisChannel channel, Func<T, Task> handler);
    }
}
