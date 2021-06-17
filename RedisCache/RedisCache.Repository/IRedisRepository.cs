using System;
using System.Collections.Generic;
using System.Text;

namespace RedisCache.Repository
{
    public interface IRedisRepository
    {
        IEnumerable<string> GetAllKeys();
        string GetValueByKey(string key);
        void RemoveValue(string key);
        void SaveValue(string key, string value, int ttl);
        void UpdateValue(string key, string value, int ttl);
    }
}
