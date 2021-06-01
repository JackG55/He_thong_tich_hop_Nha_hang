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
   
    class Hoadon
    {
        public HttpClient _client;
        public HttpResponseMessage _response;
        public Hoadon()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44360/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<DatMon_HoaDon_MonAn>> GetHD(string maban)
        {
            _response = await _client.GetAsync($"/api/HoaDon/{maban}");
            var json = await _response.Content.ReadAsStringAsync();
            var listBan_HD = JsonConvert.DeserializeObject<List<DatMon_HoaDon_MonAn>>(json);
            return listBan_HD;
        }
    }
}
