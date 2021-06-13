using Newtonsoft.Json;
using Nha_Bep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nha_Bep
{
    class MonAnCanLam
    {
        public HttpClient _client;
        public HttpResponseMessage _response;
        public MonAnCanLam()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44360/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<DatMon_HoaDon_MonAn>> GetMonAn()
        {
            _response = await _client.GetAsync($"/api/MonAnCanLam");
            var json = await _response.Content.ReadAsStringAsync();
            var listBan_MA = JsonConvert.DeserializeObject<List<DatMon_HoaDon_MonAn>>(json);
            return listBan_MA;
        }
    }
}
