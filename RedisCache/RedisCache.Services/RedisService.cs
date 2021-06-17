using RedisCache.Repository;
using System;
using System.Collections.Generic;
using System.Text;

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

        public string GetValueByKey(string key)
        {
            return redisRepository.GetValueByKey(key);
        }

        public void RemoveValue(string key)
        {
            redisRepository.RemoveValue(key);
        }

        public void SaveValue(string key, string value, int ttl)
        {
            redisRepository.SaveValue(key, value, ttl);
        }

        public void UpdateValue(string key, string value, int ttl)
        {
            redisRepository.UpdateValue(key, value, ttl);
        }
    }
}
