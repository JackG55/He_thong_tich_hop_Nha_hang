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
using System.Windows.Forms;

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


        /// <summary>
        /// lấy hoá đơn của bàn 
        /// </summary>
        /// <param name="maban">mã bàn</param>
        /// <returns>món ăn của bàn đó </returns>
        public async Task<List<DatMon_HoaDon_MonAn>> GetHD(string maban)
        {
            _response = await _client.GetAsync($"/api/HoaDon/{maban}");
            var json = await _response.Content.ReadAsStringAsync();
            var listBan_HD = JsonConvert.DeserializeObject<List<DatMon_HoaDon_MonAn>>(json);
            return listBan_HD;
        }


        public async Task<int> Get_Ma_Hoa_Don(string maban)
        {
            _response = await _client.GetAsync($"api/GetIdHoaDon/{maban}");
            var json = await _response.Content.ReadAsStringAsync();
            var ma_hoa_don = JsonConvert.DeserializeObject<List<Ban_HoaDon>>(json);
             

            return Convert.ToInt32(ma_hoa_don[0].MaHoaDon);
        }



        /// <summary>
        /// thanh toán hoá đơn
        /// </summary>
        /// <param name="ma_hoa_don"></param>
        /// <param name="so_tien"></param>
        public void ThanhToan(int ma_hoa_don, int so_tien)
        {
            var sotien = JsonConvert.SerializeObject(so_tien);
            var buffer = Encoding.UTF8.GetBytes(sotien);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            _client.PutAsync($"api/ThanhToan/{ma_hoa_don}?tong_tien={so_tien}", byteContent);
        }
       
    }
}
