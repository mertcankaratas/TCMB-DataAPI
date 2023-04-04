using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.Application.Abstraction.Services.Cache
{
    public interface ICacheService
    {
        //public Task<T> GetAsync<T>(string key);
        //public  Task SetAsync<T>(string key, T value);

        T GetData<T>(string key);
        bool SetData<T>(string key, T value, DateTimeOffset expirationTime);

        object RemoveData(string key);
        
    }
}
