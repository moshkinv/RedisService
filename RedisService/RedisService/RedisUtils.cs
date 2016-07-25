using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RedisService
{
    public static class RedisUtils
    {
        public static string KeyBuilder<T>(object id = null, object field = null)
        {
            if (id == null)
            {
                return $"{typeof (T).Name}";
            }
            else if (field == null)
            {
                return $"{typeof (T).Name}:{id}";
            }
            else
            {
                return $"{typeof(T).Name}:{id}:{field}";
            }        
        }

        public static IEnumerable<string> KeysBuilder<T>(IEnumerable<object> ids)
        {
            return ids.Select(id => $"{typeof(T).Name}:{id}");
        }
    }
}
