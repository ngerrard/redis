using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public string GetValueByKey(string key)
        {
            var db = redis.GetDatabase();
            return db.StringGet(key);
        }

        public void RemoveValue(string key)
        {
            var db = redis.GetDatabase();
            db.KeyDelete(key);
        }

        public void SaveValue(string key, string value, int ttl)
        {
            var db = redis.GetDatabase();
            TimeSpan? expiration = null;
            if (ttl > -1)
            {
                expiration = new TimeSpan(0, 0, ttl);
            }
            db.StringSet(key, value, expiration);
        }

        public void UpdateValue(string key, string value, int ttl)
        {
            SaveValue(key, value, ttl);
        }
    }
}
