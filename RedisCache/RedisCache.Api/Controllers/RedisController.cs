using Microsoft.AspNetCore.Mvc;
using RedisCache.Services;
using System.Collections.Generic;

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
        public string Get(string key)
        {
            return redisService.GetValueByKey(key);
        }

        // POST api/<RedisController>
        [HttpPost]
        public void Post([FromBody] string key, [FromBody] string value, [FromBody] int ttl = -1)
        {
            redisService.SaveValue(key, value, ttl);
        }

        // PUT api/<RedisController>/5
        [HttpPut("{key}")]
        public void Put(string key, [FromBody] string value, [FromBody] int ttl = -1)
        {
            redisService.UpdateValue(key, value, ttl);
        }

        // DELETE api/<RedisController>/5
        [HttpDelete("{key}")]
        public void Delete(string key)
        {
            redisService.RemoveValue(key);
        }
    }
}
