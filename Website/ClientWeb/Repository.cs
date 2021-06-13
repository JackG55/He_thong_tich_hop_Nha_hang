using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web;

namespace ClientWeb
{
    public class Repository
    {
        public HttpClient _client;
        public HttpResponseMessage _response;

        public Repository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://192.168.8.101:8080/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string ReturnMessage(string api_action)
        {
            _response = _client.GetAsync(api_action).Result;
            var json = _response.Content.ReadAsStringAsync().Result;
            return json;
            
        }
    }
}