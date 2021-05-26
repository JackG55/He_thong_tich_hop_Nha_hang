namespace API_QL_Nha_hang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ban_HoaDon",
                c => new
                    {
                        MaBan = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaHoaDon = c.Int(),
                        GioVao = c.DateTime(),
                    })
                .PrimaryKey(t => t.MaBan)
                .ForeignKey("dbo.Ban", t => t.MaBan)
                .ForeignKey("dbo.HoaDon", t => t.MaHoaDon)
                .Index(t => t.MaBan)
                .Index(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.Ban",
                c => new
                    {
                        MaBan = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        TenBan = c.String(maxLength: 50, unicode: false),
                        TrangThai = c.Int(nullable: false),
                        Vitri = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaBan);
            
            CreateTable(
                "dbo.DatMon",
                c => new
                    {
                        MaDatMon = c.Int(nullable: false),
                        MaBan = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaMonAn = c.Int(nullable: false),
                        ThoiGian = c.DateTime(),
                        SoLuong = c.Int(),
                        GiaMon = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TrangThai = c.Int(nullable: false),
                        MaHoaDon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDatMon)
                .ForeignKey("dbo.HoaDon", t => t.MaHoaDon)
                .ForeignKey("dbo.MonAn", t => t.MaMonAn)
                .ForeignKey("dbo.Ban", t => t.MaBan)
                .Index(t => t.MaBan)
                .Index(t => t.MaMonAn)
                .Index(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false),
                        GioVao = c.DateTime(),
                        GioRa = c.DateTime(),
                        TongTien = c.Int(),
                        KhuyenMai = c.Double(),
                        NguoiLapHoaDon = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        TrangThai = c.Int(),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.QuanLy", t => t.NguoiLapHoaDon)
                .Index(t => t.NguoiLapHoaDon);
            
            CreateTable(
                "dbo.QuanLy",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MatKhau = c.String(nullable: false, maxLength: 50, unicode: false),
                        VaiTro = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.TenDangNhap)
                .ForeignKey("dbo.ThongTinNguoiQuanLy", t => t.TenDangNhap)
                .Index(t => t.TenDangNhap);
            
            CreateTable(
                "dbo.ThongTinNguoiQuanLy",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        HoTen = c.String(maxLength: 50),
                        NgaySinh = c.DateTime(storeType: "date"),
                        GioiTinh = c.String(maxLength: 3, fixedLength: true, unicode: false),
                        DiaChi = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.TenDangNhap);
            
            CreateTable(
                "dbo.MonAn",
                c => new
                    {
                        MaMonAn = c.Int(nullable: false),
                        TenMonAn = c.String(maxLength: 200),
                        MoTa = c.String(maxLength: 250),
                        HinhAnh = c.String(maxLength: 200),
                        GiaMon = c.Decimal(nullable: false, precision: 10, scale: 0),
                        GiaKhuyenMai = c.Decimal(precision: 10, scale: 0),
                        MaLoaiMon = c.Int(nullable: false),
                        NgayTao = c.DateTime(),
                        ThuTuXuatHien = c.Int(),
                        TuKhoaTimKiem = c.String(maxLength: 200),
                        TrangThai = c.Int(nullable: false),
                        TopHot = c.DateTime(storeType: "date"),
                        DonViTinh = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaMonAn)
                .ForeignKey("dbo.LoaiMon", t => t.MaLoaiMon)
                .Index(t => t.MaLoaiMon);
            
            CreateTable(
                "dbo.LoaiMon",
                c => new
                    {
                        MaLoaiMon = c.Int(nullable: false),
                        TenLoaiMon = c.String(maxLength: 200),
                        TieuDe = c.String(maxLength: 200, unicode: false),
                        NgayTao = c.DateTime(),
                        ThuTuXuatHien = c.Int(),
                        TuKhoaTimKiem = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MaLoaiMon);
            
            CreateTable(
                "dbo.PhanHoi",
                c => new
                    {
                        MaPhanHoi = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        TenKhachHang = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        ChuDe = c.String(maxLength: 100),
                        LoiNhan = c.String(storeType: "ntext"),
                        MaMonAn = c.Int(nullable: false),
                        ThoiGian = c.DateTime(),
                        TrangThai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhanHoi)
                .ForeignKey("dbo.MonAn", t => t.MaMonAn)
                .Index(t => t.MaMonAn);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatMon", "MaBan", "dbo.Ban");
            DropForeignKey("dbo.PhanHoi", "MaMonAn", "dbo.MonAn");
            DropForeignKey("dbo.MonAn", "MaLoaiMon", "dbo.LoaiMon");
            DropForeignKey("dbo.DatMon", "MaMonAn", "dbo.MonAn");
            DropForeignKey("dbo.QuanLy", "TenDangNhap", "dbo.ThongTinNguoiQuanLy");
            DropForeignKey("dbo.HoaDon", "NguoiLapHoaDon", "dbo.QuanLy");
            DropForeignKey("dbo.DatMon", "MaHoaDon", "dbo.HoaDon");
            DropForeignKey("dbo.Ban_HoaDon", "MaHoaDon", "dbo.HoaDon");
            DropForeignKey("dbo.Ban_HoaDon", "MaBan", "dbo.Ban");
            DropIndex("dbo.PhanHoi", new[] { "MaMonAn" });
            DropIndex("dbo.MonAn", new[] { "MaLoaiMon" });
            DropIndex("dbo.QuanLy", new[] { "TenDangNhap" });
            DropIndex("dbo.HoaDon", new[] { "NguoiLapHoaDon" });
            DropIndex("dbo.DatMon", new[] { "MaHoaDon" });
            DropIndex("dbo.DatMon", new[] { "MaMonAn" });
            DropIndex("dbo.DatMon", new[] { "MaBan" });
            DropIndex("dbo.Ban_HoaDon", new[] { "MaHoaDon" });
            DropIndex("dbo.Ban_HoaDon", new[] { "MaBan" });
            DropTable("dbo.PhanHoi");
            DropTable("dbo.LoaiMon");
            DropTable("dbo.MonAn");
            DropTable("dbo.ThongTinNguoiQuanLy");
            DropTable("dbo.QuanLy");
            DropTable("dbo.HoaDon");
            DropTable("dbo.DatMon");
            DropTable("dbo.Ban");
            DropTable("dbo.Ban_HoaDon");
        }
    }
}
