using System;
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
        private readonly Dictionary<string, string> _tempStorage;

        public KudoCodeLocalStorage(IConfiguration configuration)
        {
            _configuration = configuration;
            //_jsRuntime = jsRuntime;
            _tempStorage = new Dictionary<string, string>();
        }

        public void Remove(string key)
        {
            _tempStorage.Remove(key);
        }

        public void Set(string key, object result)
        {
            var json = JsonConvert.SerializeObject(result);
            _tempStorage.Add(key, json);
            //_jsRuntime.InvokeAsync<object>($"storage.set", key, json);
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
    }

}