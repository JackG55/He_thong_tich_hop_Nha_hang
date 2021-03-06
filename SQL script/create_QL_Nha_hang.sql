create database QL_NhaHang
go

USE [QL_NhaHang]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 5/19/2021 8:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ban](
	[MaBan] [char](10) NOT NULL,
	[TenBan] [varchar](50) NULL,
	[TrangThai] [int] NOT NULL,
	[Vitri] [nvarchar](20) NULL,
 CONSTRAINT [FK_Ban] PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ban_HoaDon]    Script Date: 5/19/2021 8:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ban_HoaDon](
	[MaBan] [char](10) NOT NULL,
	[MaHoaDon] [int] NULL,
	[GioVao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatMon]    Script Date: 5/19/2021 8:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatMon](
	[MaDatMon] [int] NOT NULL,
	[MaBan] [char](10) NOT NULL,
	[MaMonAn] [int] NOT NULL,
	[ThoiGian] [datetime] NULL,
	[SoLuong] [int] NULL,
	[GiaMon] [decimal](10, 0) NOT NULL,
	[TrangThai] [int] NOT NULL,
	[MaHoaDon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDatMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 5/19/2021 8:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] NOT NULL,
	[GioVao] [datetime] NULL,
	[GioRa] [datetime] NULL,
	[TongTien] [int] NULL,
	[KhuyenMai] [float] NULL,
	[NguoiLapHoaDon] [char](10) NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiMon]    Script Date: 5/19/2021 8:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiMon](
	[MaLoaiMon] [int] NOT NULL,
	[TenLoaiMon] [nvarchar](200) NULL,
	[TieuDe] [varchar](200) NULL,
	[NgayTao] [datetime] NULL,
	[ThuTuXuatHien] [int] NULL,
	[TuKhoaTimKiem] [nvarchar](200) NULL,
 CONSTRAINT [PK_LoaiMon] PRIMARY KEY CLUSTERED 
(
	[MaLoaiMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 5/19/2021 8:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[MaMonAn] [int] NOT NULL,
	[TenMonAn] [nvarchar](200) NULL,
	[MoTa] [nvarchar](250) NULL,
	[HinhAnh] [nvarchar](200) NULL,
	[GiaMon] [decimal](10, 0) NOT NULL,
	[GiaKhuyenMai] [decimal](10, 0) NULL,
	[MaLoaiMon] [int] NOT NULL,
	[NgayTao] [datetime] NULL,
	[ThuTuXuatHien] [int] NULL,
	[TuKhoaTimKiem] [nvarchar](200) NULL,
	[TrangThai] [int] NOT NULL,
	[TopHot] [date] NULL,
	[DonViTinh] [nvarchar](20) NULL,
 CONSTRAINT [PK_MonAn] PRIMARY KEY CLUSTERED 
(
	[MaMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanHoi]    Script Date: 5/19/2021 8:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanHoi](
	[MaPhanHoi] [char](10) NOT NULL,
	[TenKhachHang] [nvarchar](100) NULL,
	[Email] [varchar](100) NOT NULL,
	[ChuDe] [nvarchar](100) NULL,
	[LoiNhan] [ntext] NULL,
	[MaMonAn] [int] NOT NULL,
	[ThoiGian] [datetime] NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_FeedBack] PRIMARY KEY CLUSTERED 
(
	[MaPhanHoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLy]    Script Date: 5/19/2021 8:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLy](
	[TenDangNhap] [char](10) NOT NULL,
	[MatKhau] [varchar](50) NOT NULL,
	[VaiTro] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuanLy] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinNguoiQuanLy]    Script Date: 5/19/2021 8:01:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinNguoiQuanLy](
	[TenDangNhap] [char](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [char](3) NULL,
	[DiaChi] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai], [Vitri]) VALUES (N'1         ', N'Bàn 101', 0, N'Tầng 1')
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai], [Vitri]) VALUES (N'2         ', N'Bàn 102', 1, N'Tầng 1')
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai], [Vitri]) VALUES (N'3         ', N'Bàn 103', 0, N'Tầng 1')
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai], [Vitri]) VALUES (N'4         ', N'Bàn 104', 0, N'Tầng 1')
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai], [Vitri]) VALUES (N'5         ', N'Bàn 105', 0, N'Tầng 1')
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai], [Vitri]) VALUES (N'6         ', N'Bàn 106', 0, N'Tầng 1')
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai], [Vitri]) VALUES (N'7         ', N'Bàn 107', 0, N'Tầng 1')
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai], [Vitri]) VALUES (N'8         ', N'Bàn 108', 0, N'Tầng 1')
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai], [Vitri]) VALUES (N'9         ', N'Bàn 201', 0, N'Tầng 2')
INSERT [dbo].[Ban_HoaDon] ([MaBan], [MaHoaDon], [GioVao]) VALUES (N'1         ', NULL, NULL)
INSERT [dbo].[Ban_HoaDon] ([MaBan], [MaHoaDon], [GioVao]) VALUES (N'2         ', 14, CAST(N'2021-05-19T15:48:25.153' AS DateTime))
INSERT [dbo].[Ban_HoaDon] ([MaBan], [MaHoaDon], [GioVao]) VALUES (N'3         ', NULL, NULL)
INSERT [dbo].[Ban_HoaDon] ([MaBan], [MaHoaDon], [GioVao]) VALUES (N'4         ', NULL, NULL)
INSERT [dbo].[Ban_HoaDon] ([MaBan], [MaHoaDon], [GioVao]) VALUES (N'5         ', NULL, NULL)
INSERT [dbo].[Ban_HoaDon] ([MaBan], [MaHoaDon], [GioVao]) VALUES (N'6         ', NULL, NULL)
INSERT [dbo].[Ban_HoaDon] ([MaBan], [MaHoaDon], [GioVao]) VALUES (N'7         ', NULL, NULL)
INSERT [dbo].[Ban_HoaDon] ([MaBan], [MaHoaDon], [GioVao]) VALUES (N'8         ', NULL, NULL)
INSERT [dbo].[Ban_HoaDon] ([MaBan], [MaHoaDon], [GioVao]) VALUES (N'9         ', NULL, NULL)
INSERT [dbo].[DatMon] ([MaDatMon], [MaBan], [MaMonAn], [ThoiGian], [SoLuong], [GiaMon], [TrangThai], [MaHoaDon]) VALUES (1, N'1         ', 1, CAST(N'2020-12-24T23:54:29.113' AS DateTime), 1, CAST(40000 AS Decimal(10, 0)), 1, 1)
INSERT [dbo].[DatMon] ([MaDatMon], [MaBan], [MaMonAn], [ThoiGian], [SoLuong], [GiaMon], [TrangThai], [MaHoaDon]) VALUES (2, N'1         ', 3, CAST(N'2020-12-25T00:14:59.353' AS DateTime), 1, CAST(70000 AS Decimal(10, 0)), 1, 5)
INSERT [dbo].[DatMon] ([MaDatMon], [MaBan], [MaMonAn], [ThoiGian], [SoLuong], [GiaMon], [TrangThai], [MaHoaDon]) VALUES (4, N'2         ', 3, CAST(N'2020-12-25T08:26:50.453' AS DateTime), 1, CAST(70000 AS Decimal(10, 0)), 1, 13)
INSERT [dbo].[DatMon] ([MaDatMon], [MaBan], [MaMonAn], [ThoiGian], [SoLuong], [GiaMon], [TrangThai], [MaHoaDon]) VALUES (5, N'2         ', 3, CAST(N'2020-12-25T08:31:38.540' AS DateTime), 1, CAST(70000 AS Decimal(10, 0)), 1, 13)
INSERT [dbo].[DatMon] ([MaDatMon], [MaBan], [MaMonAn], [ThoiGian], [SoLuong], [GiaMon], [TrangThai], [MaHoaDon]) VALUES (6, N'2         ', 12, CAST(N'2020-12-25T08:31:38.603' AS DateTime), 1, CAST(45000 AS Decimal(10, 0)), 1, 13)
INSERT [dbo].[DatMon] ([MaDatMon], [MaBan], [MaMonAn], [ThoiGian], [SoLuong], [GiaMon], [TrangThai], [MaHoaDon]) VALUES (7, N'2         ', 2, CAST(N'2020-12-25T08:31:38.617' AS DateTime), 1, CAST(45000 AS Decimal(10, 0)), 1, 13)
INSERT [dbo].[DatMon] ([MaDatMon], [MaBan], [MaMonAn], [ThoiGian], [SoLuong], [GiaMon], [TrangThai], [MaHoaDon]) VALUES (8, N'2         ', 4, CAST(N'2020-12-25T08:31:38.627' AS DateTime), 1, CAST(75000 AS Decimal(10, 0)), 1, 13)
INSERT [dbo].[DatMon] ([MaDatMon], [MaBan], [MaMonAn], [ThoiGian], [SoLuong], [GiaMon], [TrangThai], [MaHoaDon]) VALUES (9, N'2         ', 10, CAST(N'2020-12-25T08:31:38.643' AS DateTime), 1, CAST(30000 AS Decimal(10, 0)), 1, 13)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (1, CAST(N'2020-10-11T09:42:26.227' AS DateTime), CAST(N'2020-10-11T10:03:09.277' AS DateTime), 70000, NULL, N'user1     ', 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (2, CAST(N'2020-10-11T09:43:07.653' AS DateTime), CAST(N'2020-10-11T10:03:23.057' AS DateTime), 80000, NULL, N'user1     ', 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (3, CAST(N'2020-10-11T09:43:52.393' AS DateTime), CAST(N'2020-10-11T10:03:28.870' AS DateTime), 300000, NULL, N'user1     ', 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (4, CAST(N'2020-10-11T09:43:59.610' AS DateTime), CAST(N'2020-10-11T10:03:34.857' AS DateTime), 150000, NULL, N'user2     ', 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (5, CAST(N'2020-12-25T00:12:49.033' AS DateTime), CAST(N'2020-12-25T00:17:55.357' AS DateTime), 70000, NULL, NULL, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (7, CAST(N'2020-12-25T08:16:53.723' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (8, CAST(N'2020-12-25T08:17:27.250' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (9, CAST(N'2020-12-25T08:18:24.593' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (10, CAST(N'2020-12-25T08:18:52.053' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (11, CAST(N'2020-12-25T08:19:04.373' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (12, CAST(N'2020-12-25T08:23:12.723' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (13, CAST(N'2020-12-25T08:23:30.977' AS DateTime), CAST(N'2020-12-25T08:34:28.973' AS DateTime), 335000, NULL, NULL, 1)
INSERT [dbo].[HoaDon] ([MaHoaDon], [GioVao], [GioRa], [TongTien], [KhuyenMai], [NguoiLapHoaDon], [TrangThai]) VALUES (14, CAST(N'2021-05-19T15:48:25.153' AS DateTime), NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon], [TieuDe], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem]) VALUES (1, N'Món ăn đặc sắc', N'Mon-an-dac-sac', CAST(N'2020-10-06T21:27:42.750' AS DateTime), 1, NULL)
INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon], [TieuDe], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem]) VALUES (2, N'Món mặn', N'Mon-man', CAST(N'2020-10-06T21:28:36.100' AS DateTime), NULL, NULL)
INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon], [TieuDe], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem]) VALUES (3, N'Món rau', NULL, CAST(N'2020-10-06T21:28:40.803' AS DateTime), NULL, NULL)
INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon], [TieuDe], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem]) VALUES (4, N'Đồ uống', NULL, CAST(N'2020-10-06T21:28:42.463' AS DateTime), NULL, NULL)
INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon], [TieuDe], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem]) VALUES (5, N'Gia vị', NULL, CAST(N'2020-10-06T21:28:43.513' AS DateTime), NULL, NULL)
INSERT [dbo].[LoaiMon] ([MaLoaiMon], [TenLoaiMon], [TieuDe], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem]) VALUES (6, N'Combo', NULL, CAST(N'2020-10-06T21:28:44.277' AS DateTime), NULL, NULL)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (1, N'Bánh mì sốt mật ong', N'Bánh mì, mật ong, dưa chuột', N'breakfast-2.jpg', CAST(40000 AS Decimal(10, 0)), NULL, 3, CAST(N'2020-10-06T22:29:08.607' AS DateTime), NULL, NULL, 1, NULL, N'chiếc')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (2, N'Bún bò Huế', N'Bún, chả mọc, chân giò, thịt bò', N'dinner-2.jpg', CAST(45000 AS Decimal(10, 0)), NULL, 2, CAST(N'2020-10-06T22:33:35.780' AS DateTime), NULL, NULL, 1, NULL, N'bát')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (3, N'Cá hồi áp chảo', N'Cá hồi, cà chua', N'breakfast-7.jpg', CAST(70000 AS Decimal(10, 0)), NULL, 1, CAST(N'2020-10-06T22:34:57.117' AS DateTime), NULL, NULL, 0, NULL, N'đĩa')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (4, N'Tôm sốt', N'Tôm, mật ong', N'lunch-4.jpg', CAST(75000 AS Decimal(10, 0)), NULL, 2, CAST(N'2020-10-06T22:36:11.490' AS DateTime), NULL, NULL, 1, NULL, N'đĩa')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (5, N'Rượu Mockup', NULL, N'wine-4.jpg', CAST(200000 AS Decimal(10, 0)), NULL, 4, CAST(N'2020-10-06T22:37:15.837' AS DateTime), NULL, NULL, 1, NULL, N'chai')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (6, N'Nước cam tươi', NULL, N'drink-3.jpg', CAST(25000 AS Decimal(10, 0)), NULL, 4, CAST(N'2020-10-06T22:38:37.620' AS DateTime), NULL, NULL, 0, NULL, N'ly')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (7, N'Bánh kem tầng dâu tây', N'Kem, dâu tây', N'dessert-1.jpg', CAST(40000 AS Decimal(10, 0)), CAST(30000 AS Decimal(10, 0)), 4, CAST(N'2020-10-09T14:16:50.477' AS DateTime), NULL, NULL, 1, NULL, N'chiếc')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (8, N'Kem tươi', N'', N'dessert-4.jpg', CAST(20000 AS Decimal(10, 0)), NULL, 4, CAST(N'2020-10-09T14:24:06.617' AS DateTime), NULL, NULL, 1, NULL, N'ly')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (9, N'Gà sốt chua ngọt', N'Gà, đường, ớt, chanh', N'lunch-7.jpg', CAST(50000 AS Decimal(10, 0)), NULL, 2, CAST(N'2020-10-09T14:27:49.717' AS DateTime), NULL, NULL, 1, NULL, N'đĩa')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (10, N'Trứng cuộn xúc xích', N'Trứng, cà chua, xúc xích', N'dinner-3.jpg', CAST(30000 AS Decimal(10, 0)), NULL, 2, CAST(N'2020-10-09T14:29:49.870' AS DateTime), NULL, NULL, 0, NULL, N'đĩa')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (11, N'Mỳ Ý', N'Mì ống, thịt bò', N'dinner-5.jpg', CAST(45000 AS Decimal(10, 0)), NULL, 1, CAST(N'2020-10-09T14:31:30.267' AS DateTime), NULL, NULL, 1, NULL, N'đĩa')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (12, N'Salad thịt', N'Thịt lợn, salad', N'dinner-1.jpg', CAST(45000 AS Decimal(10, 0)), NULL, 1, CAST(N'2020-10-09T14:32:44.213' AS DateTime), NULL, NULL, 1, NULL, N'đĩa')
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [HinhAnh], [GiaMon], [GiaKhuyenMai], [MaLoaiMon], [NgayTao], [ThuTuXuatHien], [TuKhoaTimKiem], [TrangThai], [TopHot], [DonViTinh]) VALUES (13, N'Bánh mì trứng cải', N'Bánh mì, trứng, bắp cải', N'breakfast-6.jpg', CAST(30000 AS Decimal(10, 0)), NULL, 3, CAST(N'2020-10-09T14:34:45.360' AS DateTime), NULL, NULL, 1, NULL, N'đĩa')
INSERT [dbo].[PhanHoi] ([MaPhanHoi], [TenKhachHang], [Email], [ChuDe], [LoiNhan], [MaMonAn], [ThoiGian], [TrangThai]) VALUES (N'000001    ', NULL, N'linh@gmail.com', NULL, N'Rượu tuyệt vời', 5, CAST(N'2020-10-11T10:08:40.690' AS DateTime), 1)
INSERT [dbo].[PhanHoi] ([MaPhanHoi], [TenKhachHang], [Email], [ChuDe], [LoiNhan], [MaMonAn], [ThoiGian], [TrangThai]) VALUES (N'000002    ', NULL, N'k@gmail.com', NULL, N'Bánh mì hơi khô', 1, CAST(N'2020-10-11T10:08:40.723' AS DateTime), 0)
INSERT [dbo].[PhanHoi] ([MaPhanHoi], [TenKhachHang], [Email], [ChuDe], [LoiNhan], [MaMonAn], [ThoiGian], [TrangThai]) VALUES (N'000003    ', NULL, N'd@g.com', NULL, N'Tôm to, ngọt', 4, CAST(N'2020-10-11T10:09:08.107' AS DateTime), 1)
INSERT [dbo].[PhanHoi] ([MaPhanHoi], [TenKhachHang], [Email], [ChuDe], [LoiNhan], [MaMonAn], [ThoiGian], [TrangThai]) VALUES (N'000004    ', NULL, N'e@h.com', NULL, N'Mì chuẩn vị', 11, CAST(N'2020-10-11T10:10:52.190' AS DateTime), 0)
INSERT [dbo].[QuanLy] ([TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'1         ', N'1', N'Client')
INSERT [dbo].[QuanLy] ([TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'2         ', N'2', N'Client')
INSERT [dbo].[QuanLy] ([TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'user1     ', N'12345', N'Admin')
INSERT [dbo].[QuanLy] ([TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'user2     ', N'12345', N'Admin')
INSERT [dbo].[ThongTinNguoiQuanLy] ([TenDangNhap], [HoTen], [NgaySinh], [GioiTinh], [DiaChi]) VALUES (N'1         ', N'Bàn 101', NULL, NULL, NULL)
INSERT [dbo].[ThongTinNguoiQuanLy] ([TenDangNhap], [HoTen], [NgaySinh], [GioiTinh], [DiaChi]) VALUES (N'2         ', N'Bàn 102', NULL, NULL, NULL)
INSERT [dbo].[ThongTinNguoiQuanLy] ([TenDangNhap], [HoTen], [NgaySinh], [GioiTinh], [DiaChi]) VALUES (N'user1     ', N'Nguyen Thuy Linh', CAST(N'1990-06-02' AS Date), N'Nu ', NULL)
INSERT [dbo].[ThongTinNguoiQuanLy] ([TenDangNhap], [HoTen], [NgaySinh], [GioiTinh], [DiaChi]) VALUES (N'user2     ', N'Le The Long', CAST(N'1995-07-30' AS Date), N'Nam', NULL)
ALTER TABLE [dbo].[DatMon] ADD  DEFAULT (getdate()) FOR [ThoiGian]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT (getdate()) FOR [GioVao]
GO
ALTER TABLE [dbo].[LoaiMon] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[MonAn] ADD  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[PhanHoi] ADD  DEFAULT (getdate()) FOR [ThoiGian]
GO
ALTER TABLE [dbo].[Ban_HoaDon]  WITH CHECK ADD FOREIGN KEY([MaBan])
REFERENCES [dbo].[Ban] ([MaBan])
GO
ALTER TABLE [dbo].[Ban_HoaDon]  WITH CHECK ADD FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[DatMon]  WITH CHECK ADD  CONSTRAINT [FK_DatMon_Ban] FOREIGN KEY([MaBan])
REFERENCES [dbo].[Ban] ([MaBan])
GO
ALTER TABLE [dbo].[DatMon] CHECK CONSTRAINT [FK_DatMon_Ban]
GO
ALTER TABLE [dbo].[DatMon]  WITH CHECK ADD  CONSTRAINT [FK_DatMon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[DatMon] CHECK CONSTRAINT [FK_DatMon_HoaDon]
GO
ALTER TABLE [dbo].[DatMon]  WITH CHECK ADD  CONSTRAINT [FK_DatMon_MonAn] FOREIGN KEY([MaMonAn])
REFERENCES [dbo].[MonAn] ([MaMonAn])
GO
ALTER TABLE [dbo].[DatMon] CHECK CONSTRAINT [FK_DatMon_MonAn]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([NguoiLapHoaDon])
REFERENCES [dbo].[QuanLy] ([TenDangNhap])
GO
ALTER TABLE [dbo].[MonAn]  WITH CHECK ADD  CONSTRAINT [FK_MonAn] FOREIGN KEY([MaLoaiMon])
REFERENCES [dbo].[LoaiMon] ([MaLoaiMon])
GO
ALTER TABLE [dbo].[MonAn] CHECK CONSTRAINT [FK_MonAn]
GO
ALTER TABLE [dbo].[PhanHoi]  WITH CHECK ADD  CONSTRAINT [FK_FeedBack] FOREIGN KEY([MaMonAn])
REFERENCES [dbo].[MonAn] ([MaMonAn])
GO
ALTER TABLE [dbo].[PhanHoi] CHECK CONSTRAINT [FK_FeedBack]
GO
ALTER TABLE [dbo].[QuanLy]  WITH CHECK ADD FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[ThongTinNguoiQuanLy] ([TenDangNhap])
GO
ALTER TABLE [dbo].[ThongTinNguoiQuanLy]  WITH CHECK ADD CHECK  (([GioiTinh]='Nu' OR [GioiTinh]='Nam'))
GO
/****** Object:  StoredProcedure [dbo].[GetDetailBill]    Script Date: 5/19/2021 8:01:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDetailBill](@mahoadon INT)
AS
BEGIN
	SELECT HoaDon.MaHoaDon, HoaDon_Ban.TenBan, GioVao, GioRa, TongTien,KhuyenMai, NguoiLapHoaDon
	FROM (SELECT DISTINCT DatMon.MaHoaDon,TenBan
	FROM dbo.HoaDon JOIN dbo.DatMon ON DatMon.MaHoaDon = HoaDon.MaHoaDon 
	JOIN dbo.Ban ON Ban.MaBan = DatMon.MaBan) AS HoaDon_Ban JOIN dbo.HoaDon ON HoaDon.MaHoaDon = HoaDon_Ban.MaHoaDon
	WHERE HoaDon.MaHoaDon = @mahoadon
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetQuantityFood]    Script Date: 5/19/2021 8:01:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetQuantityFood]
AS
BEGIN 
	SELECT LoaiMon.MaLoaiMon, TenLoaiMon, COUNT(dbo.MonAn.MaLoaiMon) AS SoLuongMonAn
	FROM dbo.LoaiMon LEFT JOIN dbo.MonAn ON MonAn.MaLoaiMon = LoaiMon.MaLoaiMon
	GROUP BY LoaiMon.MaLoaiMon,TenLoaiMon
END
GO
/****** Object:  StoredProcedure [dbo].[LayDatMon]    Script Date: 5/19/2021 8:01:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LayDatMon](@maban CHAR(10))
AS
BEGIN

	SELECT DatMon.MaMonAn, TenMonAn,MaBan,MaHoaDon,SoLuong,DatMon.GiaMon,
	(CAST(dbo.DatMon.GiaMon AS int) * SoLuong) AS Gia,ThoiGian,DatMon.TrangThai,MaDatMon,HinhAnh 
	FROM dbo.DatMon JOIN dbo.MonAn ON MonAn.MaMonAn = DatMon.MaMonAn,
		(SELECT MaHoaDon AS MHD FROM dbo.Ban_HoaDon WHERE MaBan = @maban) AS HD
	WHERE MaBan = @maban AND MaHoaDon = HD.MHD
END
GO
