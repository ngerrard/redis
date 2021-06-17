using RedisCache.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisCache.Services
{
    public class RedisService : IRedisService
    {
        private IRedisRepository redisRepository;
        public RedisService(IRedisRepository redisRepository)
        {
            this.redisRepository = redisRepository;
        }

        public IEnumerable<string> GetAllKeys()
        {
            return redisRepository.GetAllKeys();
        }

        public async Task<string> GetValueByKey(string key)
        {
            return await redisRepository.GetValueByKey(key);
        }

        public async Task RemoveValue(string key)
        {
            await redisRepository.RemoveValue(key);
        }

        public async Task SaveValue(string key, string value, int ttl)
        {
            await redisRepository .SaveValue(key, value, ttl);
        }

        public async Task UpdateValue(string key, string value, int ttl)
        {
            await redisRepository.UpdateValue(key, value, ttl);
        }
    }
}
