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
            var monan = tbmonan.Get(maloaimon);
            if (monan != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, monan);

            }
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Khong co du lieu");
        }



    }
}