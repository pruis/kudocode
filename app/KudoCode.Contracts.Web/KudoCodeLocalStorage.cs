using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KudoCode.Contracts.Web
{
    //Use dictionary to store data in memory 
    public class KudoCodeLocalStorage : IStorage
    {
        private readonly IConfiguration _configuration;

        //private readonly IJSRuntime _jsRuntime;
        private readonly ConcurrentDictionary<string, string> _tempStorage;

        public KudoCodeLocalStorage(IConfiguration configuration)
        {
            _configuration = configuration;
            //_jsRuntime = jsRuntime;
            _tempStorage = new ConcurrentDictionary<string, string>();
        }

        public void Remove(string key)
        {
            _tempStorage.Remove(key, out string value);
        }

        public void Set(string key, object result)
        {
            var json = JsonConvert.SerializeObject(result);

            //if (_tempStorage.TryGetValue(key, out string value))
            _tempStorage.TryRemove(key, out string value);

            _tempStorage.TryAdd(key, json);
        }

        public T Get<T>(string key)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(_tempStorage[key]);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }
        public T GetOrCreate<T>(string key)
        {
            try
            {
                string obj;
                if (_tempStorage.TryGetValue(key, out obj))
                    return JsonConvert.DeserializeObject<T>(_tempStorage[key]);
                return Activator.CreateInstance<T>();

            }
            catch (Exception e)
            {
                return default;
            }
        }
    }

}