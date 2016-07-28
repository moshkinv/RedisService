using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core.Extensions;

namespace RedisService
{
    class Program
    {
        static void Main(string[] args)
        {
            IRedisService redisService = new RedisService();
            var user = new User();
            
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

            var info = redisService.GetInfo();
            #endregion

            #region String

            //Add
            bool added = redisService.Add<User>(user.Id, user);
            //bool added = redisService.Add<User>(user.Id, user, DateTimeOffset.Now.AddMinutes(10));     
            //bool added = redisService.Add<User>(user.Id, user, TimeSpan.FromMinutes(10));

            //Get
            var cachedUser = redisService.Get<User>(user.Id);
            Console.WriteLine($"<<User.Id:{user.Id}, User.Email:{user.Email}>>");

            //GetAll
            var cachedUsers = redisService.GetAll<User>(new List<object>() {user.Id, 2, 3});

            //AddAll
            IList<Tuple<string, User>> values = new List<Tuple<string, User>>();
            values.Add(new Tuple<string, User>("1", new User()));
            values.Add(new Tuple<string, User>("2", new User()));
            values.Add(new Tuple<string, User>("3", new User()));
            bool addedAll = redisService.AddAll(values);

            //Exist
            var existKey = redisService.Exists<User>(user.Id);

            //Remove
            var remove = redisService.Remove("User:1");
            redisService.RemoveAll(new List<string>() { "User:1", "User:2" });

            //Replace
            var replace = redisService.Replace<User>("User:1", user);

            //Search Keys
            var startWithKeys = redisService.SearchKeys("myCacheKey*");
            var endWithKeys = redisService.SearchKeys("*myCacheKey");
            var containsKeys = redisService.SearchKeys("*myCacheKey*");
            #endregion

            #region Hash
            //HashSet
            var hashSet = redisService.HashSet("User", "Id", user.Id.ToString());
            redisService.HashSet("User", new Dictionary<string, string>
                { { nameof(user.Email), user.Email }, {nameof(User.FirstName), user.FirstName}});

            //HashExists
            var isUserId = redisService.HashExists("User", "Id");

            //HashgGet
            var userId = redisService.HashGet<int>("User", "Id");

            //HashGetAll 
            var hashUser = redisService.HashGetAll<string>("User");

            //HashIncerementBy
            //var hashIncrem = redisService.HashIncerementBy("User", "Id", 1);

            //HashKeys
            var hashKeys = redisService.HashKeys("User");

            //HashValues
            var hashValues = redisService.HashValues<string>("User");

            //HashScan 
            var hashScan = redisService.HashScan<string>("User", "id*");

            //HashDelete
            var hashDelete = redisService.HashDelete("User", "Id");
            var hashDeleteAll = redisService.HashDelete("User", new List<string>() {"Id", "Name"});
            #endregion

            #region List
            //ListAddToLeft
            var listAddToLeft = redisService.ListAddToLeft("Colours", "Red");

            //ListAddToRight
            var listAddToRight = redisService.ClientNative.ListRightPush("Colours", "Black");

            //ListGetFromRight
            //var listGetFromRight = redisService.ClientNative.ListRightPop("Colours");

            //ListGetFromLeft
            //var listGetFromLeft = redisService.ClientNative.ListLeftPop("Colours");

            //ListLength
            var listLength = redisService.ClientNative.ListLength("Colours");
            #endregion

            #region Set
            //SetAdd
            var setAdd = redisService.SetAdd<string>("Cars", "BMW");
            redisService.SetAdd<string>("Cars", "VW");
            redisService.SetAdd<string>("Cars", "Kia");

            redisService.SetAdd<string>("OldCars", "BMW");
            redisService.SetAdd<string>("OldCars", "Deo");

            //SetMember
            var setMember = redisService.SetMember("Cars");

            var unionCars = redisService.ClientNative.SetCombine(SetOperation.Union, "Cars", "OldCars");
            #endregion

            #region SortedSet
            //SortedSet Add
            redisService.ClientNative.SortedSetAdd("Score", "Arkadiy", 100);
            redisService.ClientNative.SortedSetAdd("Score", "JonSkeet", 89);
            redisService.ClientNative.SortedSetAdd("Score", "JeffreyRichter", 999);

            //SortedSetScore
            var sortedSetScore = redisService.ClientNative.SortedSetScore("Score", "Arkadiy");

            //SortedSetRangeByRankWithScores
            var sortedSetRangeByRankWithScores = redisService.ClientNative.SortedSetRangeByRankWithScores("Score");

            //SortedSetRangeByRank
            var sortedSetRangeByRank = redisService.ClientNative.SortedSetRangeByRank("Score");

            //ScoreSet
            #endregion

            #region DB operations

            //Save
            //redisService.Save(SaveType.BackgroundSave);

            //FlushDb
            //redisService.FlushDb();

            #endregion

            #region Pub/Sub
            redisService.Subscribe<string>("Facebook", mesasge => Console.WriteLine("\n\n" + mesasge));

            redisService.Publish("Facebook", "HelloWorld Facebook");
            #endregion

            #region Transactions

            string key = "Evolvice";

            var tran = redisService.ClientNative.CreateTransaction();
            tran.AddCondition(Condition.KeyExists(key));
            tran.SetAddAsync(key, "Caramba");

            bool committed = tran.Execute();

            #endregion

            Console.ReadKey();
        }
    }
}
