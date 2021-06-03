using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class ThanhToan
    {
        public HttpClient _client;
        public HttpResponseMessage _response;
        public ThanhToan()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44360/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
