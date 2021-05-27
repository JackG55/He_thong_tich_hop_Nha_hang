using API_QL_Nha_hang.Models;
using API_QL_Nha_hang.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_QL_Nha_hang.Controllers
{
    public class ThanhToanController : ApiController
    {
        private BanRepository tbBan = new BanRepository();
        private DatMonRepository tbDatMon = new DatMonRepository();

        /// <summary>
        /// lấy toàn bộ các bàn có trong cửa hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Ban")]
        public HttpResponseMessage GetBan()
        {
            var ban = tbBan.List();
            if (ban != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ban);

            }
            else return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Khong co du lieu");
        }


       


    }
}
