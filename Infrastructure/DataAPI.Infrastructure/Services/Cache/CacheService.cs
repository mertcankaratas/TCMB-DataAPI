using DataAPI.Application.Abstraction.Services.Cache;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAPI.Infrastructure.Services.Cache
{
    public class CacheService : ICacheService
    {
        IDatabase _cacheDb;
        IConfiguration _configuration;

        public CacheService(IConfiguration configuration)
        {
            _configuration = configuration;
            var redis = ConnectionMultiplexer.Connect(_configuration["ConnectionStrings:Redis"]);
            _cacheDb = redis.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = _cacheDb.StringGet(key);
            if(!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }

            return default;
        }
        public object RemoveData(string key)
        {
            var exist = _cacheDb.KeyExists(key);

            if (exist)
            {
                return _cacheDb.KeyDelete(key);
            }

            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expireTime = expirationTime.DateTime.Subtract(DateTime.Now); 
            return _cacheDb.StringSet(key,JsonSerializer.Serialize(value), expireTime);
        }
    }
}
