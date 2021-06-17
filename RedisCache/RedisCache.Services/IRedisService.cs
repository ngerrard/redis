using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisCache.Services
{
    public interface IRedisService
    {
        IEnumerable<string> GetAllKeys();
        Task<string> GetValueByKey(string key);
        Task SaveValue(string key, string value, int ttl);
        Task UpdateValue(string key, string value, int ttl);
        Task RemoveValue(string key);
    }
}
