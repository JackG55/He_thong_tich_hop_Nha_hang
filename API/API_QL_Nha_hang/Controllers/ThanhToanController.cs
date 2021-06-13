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



        [HttpPut]
        [Route("api/NhanBan/{maban}")]
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
                //ban_hien_tai.MaBan = maban;
                ban_hien_tai.MaHoaDon = ma_hoa_don;
                ban_hien_tai.GioVao = hoa_don_moi.GioVao;

                context.SaveChanges();
                
                return Request.CreateResponse(HttpStatusCode.OK, "Nhận bàn thành công");
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
            int ma_hoa_don = context.Database.SqlQuery<int>("SELECT MaHoaDon FROM dbo.Ban_HoaDon WHERE MaBan = '" + maban + "'").FirstOrDefault();


            //truy van ra cac thong tin cua hoa don 
            var mon = context.Database.SqlQuery<DatMon_HoaDon_MonAn>("SELECT MaDatMon, DatMon.MaMonAn, TenMonAn, HinhAnh, SoLuong, MonAn.GiaMon,GiaKhuyenMai, DatMon.TrangThai FROM dbo.DatMon JOIN dbo.MonAn ON MonAn.MaMonAn = DatMon.MaMonAn WHERE MaHoaDon = '" + ma_hoa_don+ "'").ToList();
            
            if(mon!= null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mon);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Khong co du lieu");
            }
        }

        
        /// <summary>
        /// thanh toán hoá đơn
        /// </summary>
        /// <param name="hoa_don"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/ThanhToan/{ma_hoa_don}")]
        public HttpResponseMessage ThanhToan(int ma_hoa_don, int tong_tien)
        {
            try
            {
                //cap nhat hoa don
                var obj = context.HoaDons.SingleOrDefault(s => s.MaHoaDon == ma_hoa_don);
                obj.GioRa = System.DateTime.Now;
                obj.TongTien = tong_tien;
                obj.TrangThai = 1;

                context.SaveChanges();

                //cap nhat trang thai ban
                string ma_ban = context.Database.SqlQuery<string>("SELECT MaBan FROM dbo.Ban_HoaDon WHERE MaHoaDon =" + ma_hoa_don).FirstOrDefault();
                var ban = context.Bans.SingleOrDefault(s => s.MaBan == ma_ban);
                ban.TrangThai = 0;

                context.SaveChanges();

                //cap nhat lai bang Ban_Hoa_don
                var ban_hd = context.Ban_HoaDon.SingleOrDefault(s => s.MaBan == ma_ban);
                ban_hd.GioVao = null;
                ban_hd.HoaDon = null;
                context.SaveChanges();


                return Request.CreateResponse(HttpStatusCode.OK, "Thanh toan thanh cong");
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Thanh toan khong thanh cong");
            }
        
        }


        /// <summary>
        /// lấy ra các món ăn đang làm
        /// </summary>
        /// <param name="maban"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/MonAnDangLam/{maban}")]
        public HttpResponseMessage GetMonAnDangLam(string maban)
        {
            var datmon_ban = context.Ban_HoaDon.Find(maban);
            var mahoadon = datmon_ban.MaHoaDon;

            var list = context.Database.SqlQuery<int>("SELECT MaMonAn FROM dbo.DatMon WHERE TrangThai = '0' AND MaHoaDon = '" + mahoadon + "'").ToList();
            List<MonAn> monan = new List<MonAn>();
            foreach (int item in list)
            {
                monan.Add(context.MonAns.Where(x => x.MaMonAn == item).FirstOrDefault());
            }
            return Request.CreateResponse(HttpStatusCode.OK, monan);

        }


        /// <summary>
        /// Lấy ra mã hoá đơn từ mã bàn
        /// </summary>
        /// <param name="maban"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetIdHoaDon/{maban}")]
        public HttpResponseMessage getIdHoaDon(int maban)
        {
            var id = context.Database.SqlQuery<Ban_HoaDon>("select * from Ban_HoaDon where MaBan = '" + maban + "'");
            return Request.CreateResponse(HttpStatusCode.OK, id);

        }


    }
}
