using Antlr.Runtime.Tree;
using API_QL_Nha_hang.Models;
using API_QL_Nha_hang.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace API_QL_Nha_hang.Controllers
{
    public class MenuController:ApiController
    {
        private LoaiMonRepository tbloaimon = new LoaiMonRepository();
        private MonAnRepository tbmonan = new MonAnRepository();
        private DatMonRepository tbdatmon = new DatMonRepository();
        public Data_Nha_hang context = new Data_Nha_hang();

        /// <summary>
        /// Lấy ra các loại món 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/LoaiMon")]
        public HttpResponseMessage GetLoaiMon()
        {
            var loaimon = tbloaimon.List();
            if (loaimon != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, tbloaimon.List());

            }
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Khong co du lieu");
        }


        /// <summary>
        /// Lấy ra món ăn theo từng mã loại món
        /// </summary>
        /// <param name="maloaimon"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MonAn/{maloaimon}")]
        public HttpResponseMessage GetMonAn(int maloaimon)
        {
            List<MonAn> monan = new List<MonAn>();
            if(maloaimon == -1)   //lấy tất cả món ăn
            {
                monan = tbmonan.List();
                   
            }
            else
            {
                monan = tbmonan.Get(maloaimon);
            }
           
            if (monan != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, monan);

            }
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Khong co du lieu");
        }


        /// <summary>
        /// lấy ra các món ăn đã đặt
        /// </summary>
        /// <param name="maban"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MonAnDaDat/{maban}")]
        public HttpResponseMessage GetMonAnDaGiao (string maban)
        {
            var datmon_ban = context.Ban_HoaDon.Find(maban);
            var mahoadon = datmon_ban.MaHoaDon;

            var list = context.Database.SqlQuery<int>("SELECT MaMonAn FROM dbo.DatMon WHERE TrangThai = '1' AND MaHoaDon = " + mahoadon).ToList();
            List<MonAn> monan = new List<MonAn>();
            foreach(int item in list)
            {
                monan.Add(context.MonAns.Where(x => x.MaMonAn == item).FirstOrDefault());
            }
            return Request.CreateResponse(HttpStatusCode.OK, monan);

        }


        /// <summary>
        /// Ghi món ăn đã đặt vào cơ sở dữ liệu
        /// </summary>
        /// <param name="datMon"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/DatMon")]
        public HttpResponseMessage DatMon([FromBody] DatMon datMon)
        {
            tbdatmon.Add(datMon);
            return Request.CreateResponse(HttpStatusCode.OK);
        }







    }
}