using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisService
{
    public static class RedisUtils
    {
        public static string KeyBuilder(string objectType, object id, string field = null)
        {
            if (field == null)
                return $"{objectType}:{id.ToString()}";           
            else
                return $"{objectType}:{id.ToString()}:{field}";          
        }
    }
}
