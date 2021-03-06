USE [QLCuaHangBanDia]
GO
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 27/05/2019 21:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan](
	[SoHDB] [nvarchar](50) NOT NULL,
	[MaNhanVien] [nvarchar](50) NULL,
	[NgayBan] [datetime] NULL,
	[MaKhach] [nvarchar](50) NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_HoaDonBann] PRIMARY KEY CLUSTERED 
(
	[SoHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoDia]    Script Date: 27/05/2019 21:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoDia](
	[MaDia] [nvarchar](50) NOT NULL,
	[TenDia] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[DonGiaBan] [int] NULL,
	[DonGiaNhap] [int] NULL,
	[MaNSX] [nvarchar](50) NULL,
	[MaTheLoai] [nvarchar](50) NULL,
	[Anh] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhoDiaa] PRIMARY KEY CLUSTERED 
(
	[MaDia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHDB]    Script Date: 27/05/2019 21:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDB](
	[SoHDB] [nvarchar](50) NOT NULL,
	[MaDia] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[GiamGia] [int] NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK_ChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[SoHDB] ASC,
	[MaDia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[quy1]    Script Date: 27/05/2019 21:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[quy1] as
SELECT  KhoDia.MaDia FROM  KhoDia EXCEPT SELECT ChiTietHDB.MaDia FROM  ChiTietHDB,HoaDonBan
where ChiTietHDB.SoHDB = HoaDonBan.SoHDB and 
(MONTH(NgayBan)=1 or  MONTH(NgayBan)=2 or MONTH(NgayBan)=3)
GO
/****** Object:  View [dbo].[quy2]    Script Date: 27/05/2019 21:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[quy2] as
SELECT  KhoDia.MaDia FROM  KhoDia EXCEPT SELECT ChiTietHDB.MaDia FROM  ChiTietHDB,HoaDonBan
where ChiTietHDB.SoHDB = HoaDonBan.SoHDB and 
(MONTH(NgayBan)=4 or  MONTH(NgayBan)=5 or MONTH(NgayBan)=6)
GO
/****** Object:  View [dbo].[quy3]    Script Date: 27/05/2019 21:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[quy3] as
SELECT  KhoDia.MaDia FROM  KhoDia EXCEPT SELECT ChiTietHDB.MaDia FROM  ChiTietHDB,HoaDonBan
where ChiTietHDB.SoHDB = HoaDonBan.SoHDB and 
(MONTH(NgayBan)=7 or  MONTH(NgayBan)=8 or MONTH(NgayBan)=9)
GO
/****** Object:  View [dbo].[quy4]    Script Date: 27/05/2019 21:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[quy4] as
SELECT  KhoDia.MaDia FROM  KhoDia EXCEPT SELECT ChiTietHDB.MaDia FROM  ChiTietHDB,HoaDonBan
where ChiTietHDB.SoHDB = HoaDonBan.SoHDB and 
(MONTH(NgayBan)=10 or  MONTH(NgayBan)=11 or MONTH(NgayBan)=12)
GO
/****** Object:  Table [dbo].[ChiTietHDN]    Script Date: 27/05/2019 21:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDN](
	[SoHDN] [nvarchar](50) NOT NULL,
	[MaDia] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
	[GiamGia] [int] NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK_ChiTietHDNN] PRIMARY KEY CLUSTERED 
(
	[SoHDN] ASC,
	[MaDia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongViec]    Script Date: 27/05/2019 21:22:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongViec](
	[MaCongViec] [nvarchar](50) NOT NULL,
	[TenCongViec] [nvarchar](50) NULL,
 CONSTRAINT [PK_CongViec] PRIMARY KEY CLUSTERED 
(
	[MaCongViec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 27/05/2019 21:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhap](
	[SoHDN] [nvarchar](50) NOT NULL,
	[MaNhanVien] [nvarchar](50) NULL,
	[NgayNhap] [datetime] NULL,
	[MaNCC] [nvarchar](50) NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_HoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[SoHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 27/05/2019 21:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhach] [nvarchar](50) NOT NULL,
	[TenKhach] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatHongDia]    Script Date: 27/05/2019 21:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatHongDia](
	[SoLanMat] [int] NOT NULL,
	[MaDia] [nvarchar](50) NOT NULL,
	[SoLuongMat] [int] NULL,
	[NgayMat] [datetime] NULL,
 CONSTRAINT [PK_MatHongDiaa] PRIMARY KEY CLUSTERED 
(
	[SoLanMat] ASC,
	[MaDia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 27/05/2019 21:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [nvarchar](50) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhaCungcapp] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 27/05/2019 21:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nvarchar](50) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[DienThoai] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[MaCongViec] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVienn] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 27/05/2019 21:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[MaNSX] [nvarchar](50) NOT NULL,
	[TenNSX] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhaSX] PRIMARY KEY CLUSTERED 
(
	[MaNSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 27/05/2019 21:22:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MaTheLoai] [nvarchar](50) NOT NULL,
	[TenTheLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHDB] ([SoHDB], [MaDia], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB01', N'01', 2, 1100, 0, 2200)
INSERT [dbo].[ChiTietHDB] ([SoHDB], [MaDia], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB01', N'02', 7, 11000, 7000, 70000)
INSERT [dbo].[ChiTietHDN] ([SoHDN], [MaDia], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDN01', N'01', 2, 1000, 0, 20000)
INSERT [dbo].[ChiTietHDN] ([SoHDN], [MaDia], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDN01', N'02', 2, 10000, 0, 20000)
INSERT [dbo].[ChiTietHDN] ([SoHDN], [MaDia], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDN01', N'03', 10, 10000, 0, 100000)
INSERT [dbo].[ChiTietHDN] ([SoHDN], [MaDia], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDN02', N'02', 3, 10000, 0, 30000)
INSERT [dbo].[ChiTietHDN] ([SoHDN], [MaDia], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDN03', N'01', 2, 10000, 0, 20000)
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec]) VALUES (N'CV01', N'Bảo vệ')
INSERT [dbo].[CongViec] ([MaCongViec], [TenCongViec]) VALUES (N'CV02', N'Thu ngân')
INSERT [dbo].[HoaDonBan] ([SoHDB], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB01', N'NV01', CAST(N'2019-05-18T00:00:00.000' AS DateTime), N'K01', 72200)
INSERT [dbo].[HoaDonBan] ([SoHDB], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB02', N'NV01', CAST(N'2019-05-19T00:00:00.000' AS DateTime), N'K02', 0)
INSERT [dbo].[HoaDonBan] ([SoHDB], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB03', N'NV01', CAST(N'2019-05-19T00:00:00.000' AS DateTime), N'K01', 0)
INSERT [dbo].[HoaDonNhap] ([SoHDN], [MaNhanVien], [NgayNhap], [MaNCC], [TongTien]) VALUES (N'HDN01', N'NV01', CAST(N'2019-05-11T00:00:00.000' AS DateTime), N'NCC01', 140000)
INSERT [dbo].[HoaDonNhap] ([SoHDN], [MaNhanVien], [NgayNhap], [MaNCC], [TongTien]) VALUES (N'HDN02', N'NV01', CAST(N'2019-05-11T00:00:00.000' AS DateTime), N'NCC02', 190000)
INSERT [dbo].[HoaDonNhap] ([SoHDN], [MaNhanVien], [NgayNhap], [MaNCC], [TongTien]) VALUES (N'HDN03', N'NV01', CAST(N'2019-05-19T00:00:00.000' AS DateTime), N'NCC01', 0)
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai]) VALUES (N'K01', N'Bùi Như Lạc', N'Hà Nội', N'01332651')
INSERT [dbo].[KhachHang] ([MaKhach], [TenKhach], [DiaChi], [DienThoai]) VALUES (N'K02', N'Trần Như Nhuộng', N'Hà Nội', N'01122121')
INSERT [dbo].[KhoDia] ([MaDia], [TenDia], [SoLuong], [DonGiaBan], [DonGiaNhap], [MaNSX], [MaTheLoai], [Anh], [GhiChu]) VALUES (N'01', N'PHIM MA THÁI', 14, 11000, 10000, N'NSX01', N'TL01', N'D:\Resources\logo.jpg', N'ok')
INSERT [dbo].[KhoDia] ([MaDia], [TenDia], [SoLuong], [DonGiaBan], [DonGiaNhap], [MaNSX], [MaTheLoai], [Anh], [GhiChu]) VALUES (N'02', N'Hài Tết', 10, 11000, 10000, N'NSX01', N'TL02', N'D:\Resources\v.jpg', N'')
INSERT [dbo].[KhoDia] ([MaDia], [TenDia], [SoLuong], [DonGiaBan], [DonGiaNhap], [MaNSX], [MaTheLoai], [Anh], [GhiChu]) VALUES (N'03', N'PHIM MA NHẬT', 18, 11000, 10000, N'NSX02', N'TL01', N'D:\Resources\logo.jpg', N'ok')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC01', N'Tràng Tiền', N'Hà Nội', N'0132533256')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai]) VALUES (N'NCC02', N'Long An', N'Hà Nội', N'0232352326')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DienThoai], [DiaChi], [MaCongViec]) VALUES (N'NV01', N'Phạm Văn Bằng', N'Nam', CAST(N'1998-11-11T00:00:00.000' AS DateTime), N'02323556', N'Hà Nội', N'CV01')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DienThoai], [DiaChi], [MaCongViec]) VALUES (N'NV02', N'Trần Văn Thành', N'Nam', CAST(N'1998-02-01T00:00:00.000' AS DateTime), N'0135522551', N'Hà Nam', N'CV02')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX]) VALUES (N'NSX01', N'LONG AN')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX]) VALUES (N'NSX02', N'TRÀNG TIỀN')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL01', N'PHIM MA')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL02', N'PHIM HÀI')
ALTER TABLE [dbo].[ChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDB_HoaDonBan] FOREIGN KEY([SoHDB])
REFERENCES [dbo].[HoaDonBan] ([SoHDB])
GO
ALTER TABLE [dbo].[ChiTietHDB] CHECK CONSTRAINT [FK_ChiTietHDB_HoaDonBan]
GO
ALTER TABLE [dbo].[ChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDB_KhoDia] FOREIGN KEY([MaDia])
REFERENCES [dbo].[KhoDia] ([MaDia])
GO
ALTER TABLE [dbo].[ChiTietHDB] CHECK CONSTRAINT [FK_ChiTietHDB_KhoDia]
GO
ALTER TABLE [dbo].[ChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDN_HoaDonNhap] FOREIGN KEY([SoHDN])
REFERENCES [dbo].[HoaDonNhap] ([SoHDN])
GO
ALTER TABLE [dbo].[ChiTietHDN] CHECK CONSTRAINT [FK_ChiTietHDN_HoaDonNhap]
GO
ALTER TABLE [dbo].[ChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDN_KhoDia] FOREIGN KEY([MaDia])
REFERENCES [dbo].[KhoDia] ([MaDia])
GO
ALTER TABLE [dbo].[ChiTietHDN] CHECK CONSTRAINT [FK_ChiTietHDN_KhoDia]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_KhachHang] FOREIGN KEY([MaKhach])
REFERENCES [dbo].[KhachHang] ([MaKhach])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_NhanVien]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhap_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK_HoaDonNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhap_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK_HoaDonNhap_NhanVien]
GO
ALTER TABLE [dbo].[KhoDia]  WITH CHECK ADD  CONSTRAINT [FK_KhoDia_NhaSanXuat] FOREIGN KEY([MaNSX])
REFERENCES [dbo].[NhaSanXuat] ([MaNSX])
GO
ALTER TABLE [dbo].[KhoDia] CHECK CONSTRAINT [FK_KhoDia_NhaSanXuat]
GO
ALTER TABLE [dbo].[KhoDia]  WITH CHECK ADD  CONSTRAINT [FK_KhoDia_TheLoai] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[TheLoai] ([MaTheLoai])
GO
ALTER TABLE [dbo].[KhoDia] CHECK CONSTRAINT [FK_KhoDia_TheLoai]
GO
ALTER TABLE [dbo].[MatHongDia]  WITH CHECK ADD  CONSTRAINT [FK_MatHongDia_KhoDia] FOREIGN KEY([MaDia])
REFERENCES [dbo].[KhoDia] ([MaDia])
GO
ALTER TABLE [dbo].[MatHongDia] CHECK CONSTRAINT [FK_MatHongDia_KhoDia]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_CongViec] FOREIGN KEY([MaCongViec])
REFERENCES [dbo].[CongViec] ([MaCongViec])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_CongViec]
GO
