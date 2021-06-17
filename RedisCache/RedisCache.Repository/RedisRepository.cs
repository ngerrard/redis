using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisCache.Repository
{
    public class RedisRepository : IRedisRepository, IDisposable
    {
        private bool disposedValue;
        private ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

        public RedisRepository()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                redis.Dispose();
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RedisRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<string> GetAllKeys()
        {
            var endpoints = redis.GetEndPoints();
            var server = redis.GetServer(endpoints.First());
            return server.Keys().Select(x => x.ToString());
        }

        public async Task<string> GetValueByKey(string key)
        {
            var db = redis.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public async Task RemoveValue(string key)
        {
            var db = redis.GetDatabase();
            await db.KeyDeleteAsync(key);
        }

        public async Task SaveValue(string key, string value, int ttl)
        {
            var db = redis.GetDatabase();
            TimeSpan? expiration = null;
            if (ttl > -1)
            {
                expiration = new TimeSpan(0, 0, ttl);
            }
            await db.StringSetAsync(key, value, expiration);
        }

        public async Task UpdateValue(string key, string value, int ttl)
        {
            await SaveValue(key, value, ttl);
        }
    }
}
