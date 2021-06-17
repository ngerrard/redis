using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisCache.Repository
{
    public interface IRedisRepository
    {
        IEnumerable<string> GetAllKeys();
        Task<string> GetValueByKey(string key);
        Task RemoveValue(string key);
        Task SaveValue(string key, string value, int ttl);
        Task UpdateValue(string key, string value, int ttl);
    }
}
