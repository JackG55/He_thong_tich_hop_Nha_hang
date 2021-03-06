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
    public class LoaiMonRepository
    {
        public HttpClient _client;
        public HttpResponseMessage _response;

        public LoaiMonRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44360/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<LoaiMon>> Getlist()
        {
            _response = await _client.GetAsync($"/api/LoaiMon");
            var json = await _response.Content.ReadAsStringAsync();
            var listMonAn = JsonConvert.DeserializeObject<List<LoaiMon>>(json);
            return listMonAn;
        }

        public void Add(LoaiMon loai)
        {
            var loaimon = JsonConvert.SerializeObject(loai);
            var buffer = Encoding.UTF8.GetBytes(loaimon);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PostAsync("", byteContent);
        }

        public void Delete(int id)
        {
            _client.DeleteAsync($"api/delete/{id}");
        }


    }
}
