using API_QL_Nha_hang.Models;
using API_QL_Nha_hang.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;

namespace API_QL_Nha_hang.Controllers
{
    public class ThanhToanController : ApiController
    {
        private BanRepository tbBan = new BanRepository();
        private DatMonRepository tbDatMon = new DatMonRepository();
        private Data_Nha_hang context = new Data_Nha_hang();

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




        public HttpResponseMessage NhanBan(string maban)
        {
            try
            {
                //doi trang thai ban 
                Ban b = context.Bans.SingleOrDefault(s => s.MaBan == maban);
                b.TrangThai = 1;

                context.SaveChanges();

                int ma_hoa_don = context.Database.SqlQuery<int>("SELECT MAX(MaHoaDon) FROM dbo.HoaDon").FirstOrDefault() + 1;

                //ghi vao bang Hoadon
                var hoa_don_moi = new HoaDon();
                hoa_don_moi.MaHoaDon = ma_hoa_don;
                hoa_don_moi.GioVao = System.DateTime.Now;

                //them nguoi lap vao day 

                hoa_don_moi.TrangThai = 0;

                context.HoaDons.Add(hoa_don_moi);

                //ghi vao bang Ban_Hoadon


                Ban_HoaDon ban_hien_tai = context.Ban_HoaDon.SingleOrDefault(s => s.MaBan == maban);
                ban_hien_tai.MaBan = maban;
                ban_hien_tai.MaHoaDon = ma_hoa_don;
                ban_hien_tai.GioVao = hoa_don_moi.GioVao;

                context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Nhan ban thanh cong");
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Khong the nhan ban");
            }

            



        }



        /// <summary>
        /// Lấy ra hoá đơn của bàn tương ứng
        /// </summary>
        /// <param name="maban"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/HoaDon/{maban}")]
        public HttpResponseMessage GetHoaDon(string maban)
        {
            //truy van de lay ra ma hoa don tu bang Ban-HoaDon
            int ma_hoa_don = context.Database.SqlQuery<int>("SELECT MaHoaDon FROM dbo.Ban_HoaDon WHERE MaBan = " + maban).FirstOrDefault();


            //truy van ra cac thong tin cua hoa don 
            var mon = context.Database.SqlQuery<DatMon_HoaDon_MonAn>("SELECT MaDatMon, DatMon.MaMonAn, TenMonAn, HinhAnh, SoLuong, MonAn.GiaMon,GiaKhuyenMai, DatMon.TrangThai FROM dbo.DatMon JOIN dbo.MonAn ON MonAn.MaMonAn = DatMon.MaMonAn WHERE MaHoaDon = " + ma_hoa_don).ToList();
            
            if(mon!= null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mon);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Khong co du lieu");
            }
        }

        
        
        [HttpPost]
        [Route("api/ThanhToan")]
        public HttpResponseMessage ThanhToan([FromBody] HoaDon hoa_don)
        {
            try
            {
                //cap nhat hoa don
                var obj = context.HoaDons.SingleOrDefault(s => s.MaHoaDon == hoa_don.MaHoaDon);
                obj.GioRa = System.DateTime.Now;
                obj.TongTien = hoa_don.TongTien;
                obj.TrangThai = 1;

                context.SaveChanges();

                //cap nhat trang thai ban
                string ma_ban = context.Database.SqlQuery<string>("SELECT MaBan FROM dbo.Ban_HoaDon WHERE MaHoaDon =" + hoa_don.MaHoaDon).FirstOrDefault();
                var ban = context.Bans.SingleOrDefault(s => s.MaBan == ma_ban);
                ban.TrangThai = 0;

                context.SaveChanges();

                //cap nhat lai bang Ban_Hoa_don
                var ban_hd = context.Ban_HoaDon.SingleOrDefault(s => s.MaBan == ma_ban);
                ban_hd.GioVao = null;
                ban_hd.HoaDon = null;
                context.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.OK, "Thah toan thanh cong");
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Thanh toan khong thanh cong");
            }
        
        }


    }
}
