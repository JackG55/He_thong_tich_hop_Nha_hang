using Test1.Models;
using DevExpress.Utils.Internal;
using DevExpress.XtraPrinting.Native.WebClientUIControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    
    public class banan
    {
        public HttpClient _client;
        public HttpResponseMessage _response;
        public banan()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44360/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Ban>> Getlist()
        {
            _response = await _client.GetAsync($"/api/Ban");
            var json = await _response.Content.ReadAsStringAsync();
            var listBan = JsonConvert.DeserializeObject<List<Ban>>(json);
            return listBan;
        }
    }
}
