using System.Collections.Generic;

namespace RedisCache.Services
{
    public interface IRedisService
    {
        IEnumerable<string> GetAllKeys();
        string GetValueByKey(string key);
        void SaveValue(string key, string value, int ttl);
        void UpdateValue(string key, string value, int ttl);
        void RemoveValue(string key);
    }
}
