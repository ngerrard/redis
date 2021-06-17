using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisCache.Api
{
    public class RedisCache
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int Ttl { get; set; }
    }
}
