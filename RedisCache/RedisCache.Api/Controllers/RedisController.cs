using Microsoft.AspNetCore.Mvc;
using RedisCache.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedisCache.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private IRedisService redisService;
        public RedisController(IRedisService redisService)
        {
            this.redisService = redisService;
        }

        // GET: api/<RedisController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return redisService.GetAllKeys();
        }

        // GET api/<RedisController>/5
        [HttpGet("{key}")]
        public async Task<string> Get(string key)
        {
            return await redisService.GetValueByKey(key);
        }

        // POST api/<RedisController>
        [HttpPost]
        public async Task Post([FromBody] RedisCache redisCache)
        {
            await redisService.SaveValue(redisCache.Key, redisCache.Value, redisCache.Ttl);
        }

        // PUT api/<RedisController>/5
        [HttpPut("{key}")]
        public async Task Put(string key, [FromBody] RedisCache redisCache)
        {
            await redisService .UpdateValue(key, redisCache.Value, redisCache.Ttl);
        }

        // DELETE api/<RedisController>/5
        [HttpDelete("{key}")]
        public async Task Delete(string key)
        {
            await redisService .RemoveValue(key);
        }
    }
}
