USE [master]
GO
/****** Object:  Database [QLKS]    Script Date: 09/12/2025 1:24:37 CH ******/
CREATE DATABASE [QLKS]
GO
ALTER DATABASE [QLKS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKS] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLKS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLKS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLKS] SET  MULTI_USER 
GO
ALTER DATABASE [QLKS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLKS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLKS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QLKS] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLKS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLKS]
GO
/****** Object:  Table [dbo].[CSKH_ThongBao]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CSKH_ThongBao](
	[MaTB] [nvarchar](5) NOT NULL,
	[MaCTDP] [nvarchar](7) NOT NULL,
	[NoiDung] [nvarchar](255) NOT NULL,
	[Ngaylap] [smalldatetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTDP]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDP](
	[MaCTDP] [nvarchar](7) NOT NULL,
	[SoNguoi] [int] NULL,
	[MaPT] [nvarchar](5) NOT NULL,
	[MaPH] [nvarchar](5) NOT NULL,
	[CheckIn] [smalldatetime] NOT NULL,
	[CheckOut] [smalldatetime] NOT NULL,
	[TrangThai] [nvarchar](20) NOT NULL,
	[DonGia] [money] NULL,
	[ThanhTien] [money] NULL,
	[DaXoa] [bit] NULL,
	[TheoGio] [bit] NULL,
	[TienDatCoc] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTDP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTDV]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDV](
	[MaCTDP] [nvarchar](7) NOT NULL,
	[MaDV] [nvarchar](5) NOT NULL,
	[DonGia] [money] NOT NULL,
	[SL] [int] NOT NULL,
	[DaXoa] [bit] NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_CTDV] PRIMARY KEY CLUSTERED 
(
	[MaCTDP] ASC,
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTTN]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTTN](
	[MaLPH] [nvarchar](5) NOT NULL,
	[MaTN] [nvarchar](5) NOT NULL,
	[SL] [int] NULL,
	[DaXoa] [bit] NULL,
 CONSTRAINT [PK_CTTN] PRIMARY KEY CLUSTERED 
(
	[MaLPH] ASC,
	[MaTN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDV] [nvarchar](5) NOT NULL,
	[TenDV] [nvarchar](20) NOT NULL,
	[DonGia] [money] NOT NULL,
	[SLConLai] [int] NULL,
	[LoaiDV] [nvarchar](20) NOT NULL,
	[DaXoa] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [nvarchar](5) NOT NULL,
	[NgHD] [smalldatetime] NULL,
	[TriGia] [money] NULL,
	[MaNV] [nvarchar](5) NULL,
	[TrangThai] [nvarchar](20) NOT NULL,
	[MaCTDP] [nvarchar](7) NOT NULL,
	[DaXoa] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [nvarchar](5) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[SDT] [nvarchar](10) NULL,
	[CCCD/Passport] [nvarchar](12) NOT NULL,
	[QuocTich] [nvarchar](30) NOT NULL,
	[GioiTinh] [nvarchar](3) NOT NULL,
	[Email] [varchar](100) NULL,
	[DaXoa] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[MaLPH] [nvarchar](5) NOT NULL,
	[TenLPH] [nvarchar](20) NOT NULL,
	[SoGiuong] [int] NOT NULL,
	[SoNguoiToiDa] [int] NOT NULL,
	[GiaNgay] [money] NOT NULL,
	[GiaGio] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLPH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](5) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[ChucVu] [nvarchar](50) NOT NULL,
	[Luong] [money] NOT NULL,
	[SDT] [nvarchar](10) NOT NULL,
	[CCCD] [nvarchar](12) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[GioiTinh] [nvarchar](3) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[DaXoa] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuThue]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuThue](
	[MaPT] [nvarchar](5) NOT NULL,
	[NgPT] [smalldatetime] NOT NULL,
	[MaKH] [nvarchar](5) NOT NULL,
	[MaNV] [nvarchar](5) NOT NULL,
	[DaXoa] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[MaPH] [nvarchar](5) NOT NULL,
	[TTPH] [nvarchar](20) NOT NULL,
	[TTDD] [nvarchar](20) NOT NULL,
	[GhiChu] [nvarchar](100) NULL,
	[MaLPH] [nvarchar](5) NOT NULL,
	[Tang] [int] NOT NULL,
	[DaXoa] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenTK] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](1000) NOT NULL,
	[CapDoQuyen] [int] NOT NULL,
	[MaNV] [nvarchar](5) NOT NULL,
	[DaXoa] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TenTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TienNghi]    Script Date: 09/12/2025 1:24:38 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TienNghi](
	[MaTN] [nvarchar](5) NOT NULL,
	[TenTN] [nvarchar](50) NOT NULL,
	[SoLuong] [int] NULL,
	[DaXoa] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CSKH_ThongBao] ([MaTB], [MaCTDP], [NoiDung], [Ngaylap]) VALUES (N'TB001', N'CTDP001', N'Khách yêu cầu thêm 2 chai nước suối vào phòng.', CAST(N'2025-08-12T07:15:00' AS SmallDateTime))
INSERT [dbo].[CSKH_ThongBao] ([MaTB], [MaCTDP], [NoiDung], [Ngaylap]) VALUES (N'TB002', N'CTDP003', N'Bộ phận dịch vụ đã giao đủ nước suối theo yêu cầu.', CAST(N'2025-08-12T07:25:00' AS SmallDateTime))
INSERT [dbo].[CSKH_ThongBao] ([MaTB], [MaCTDP], [NoiDung], [Ngaylap]) VALUES (N'TB003', N'CTDP026', N'Khách phòng P303 đề nghị bổ sung khăn tắm.', CAST(N'2025-10-12T07:20:00' AS SmallDateTime))
INSERT [dbo].[CSKH_ThongBao] ([MaTB], [MaCTDP], [NoiDung], [Ngaylap]) VALUES (N'TB004', N'CTDP026', N'Nhân viên đã mang khăn tắm đến phòng.', CAST(N'2025-10-12T07:30:00' AS SmallDateTime))
GO
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP001', 2, N'PT001', N'P101', CAST(N'2025-05-11T00:00:00' AS SmallDateTime), CAST(N'2025-05-15T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP002', 2, N'PT001', N'P103', CAST(N'2025-06-11T00:00:00' AS SmallDateTime), CAST(N'2025-06-15T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1600000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP003', 2, N'PT002', N'P201', CAST(N'2025-07-15T00:00:00' AS SmallDateTime), CAST(N'2025-07-18T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP004', 2, N'PT003', N'P104', CAST(N'2025-09-16T00:00:00' AS SmallDateTime), CAST(N'2025-09-20T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP005', 2, N'PT003', N'P204', CAST(N'2025-12-01T00:00:00' AS SmallDateTime), CAST(N'2025-12-06T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 1500000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP006', 2, N'PT004', N'P105', CAST(N'2022-11-08T00:00:00' AS SmallDateTime), CAST(N'2022-12-10T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 600000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP007', 2, N'PT023', N'P101', CAST(N'2022-12-10T00:00:00' AS SmallDateTime), CAST(N'2022-12-20T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 3000000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP008', 2, N'PT022', N'P301', CAST(N'2022-12-17T00:00:00' AS SmallDateTime), CAST(N'2022-12-20T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 900000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP009', 2, N'PT005', N'P201', CAST(N'2025-09-30T00:00:00' AS SmallDateTime), CAST(N'2025-10-05T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP010', 2, N'PT006', N'P101', CAST(N'2022-12-03T00:00:00' AS SmallDateTime), CAST(N'2022-12-20T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP011', 2, N'PT007', N'P301', CAST(N'2022-12-20T00:00:00' AS SmallDateTime), CAST(N'2022-12-25T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP012', 2, N'PT008', N'P401', CAST(N'2025-08-08T00:00:00' AS SmallDateTime), CAST(N'2025-08-15T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP013', 2, N'PT008', N'P501', CAST(N'2025-10-09T00:00:00' AS SmallDateTime), CAST(N'2025-10-11T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP014', 2, N'PT009', N'P202', CAST(N'2025-07-18T00:00:00' AS SmallDateTime), CAST(N'2025-07-20T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP015', 2, N'PT010', N'P203', CAST(N'2025-11-11T00:00:00' AS SmallDateTime), CAST(N'2025-11-20T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP017', 2, N'PT012', N'P105', CAST(N'2025-09-17T00:00:00' AS SmallDateTime), CAST(N'2025-09-21T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP018', 2, N'PT013', N'P302', CAST(N'2023-01-01T00:00:00' AS SmallDateTime), CAST(N'2023-01-03T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP019', 2, N'PT014', N'P303', CAST(N'2022-12-15T00:00:00' AS SmallDateTime), CAST(N'2022-12-20T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP020', 2, N'PT015', N'P102', CAST(N'2023-02-04T00:00:00' AS SmallDateTime), CAST(N'2023-02-07T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP021', 2, N'PT016', N'P101', CAST(N'2023-02-03T00:00:00' AS SmallDateTime), CAST(N'2023-02-07T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP022', 2, N'PT017', N'P105', CAST(N'2023-02-02T00:00:00' AS SmallDateTime), CAST(N'2023-02-08T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP023', 2, N'PT018', N'P202', CAST(N'2023-02-03T00:00:00' AS SmallDateTime), CAST(N'2023-02-09T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP024', 2, N'PT019', N'P303', CAST(N'2023-01-15T00:00:00' AS SmallDateTime), CAST(N'2023-01-17T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP025', 2, N'PT020', N'P401', CAST(N'2023-01-17T00:00:00' AS SmallDateTime), CAST(N'2023-01-19T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP026', 2, N'PT021', N'P302', CAST(N'2023-01-20T00:00:00' AS SmallDateTime), CAST(N'2023-01-25T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
GO
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP001', N'DV01', 10000.0000, 2, 0, 20000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP001', N'DV02', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP001', N'DV06', 100000.0000, 1, 0, 100000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP002', N'DV01', 10000.0000, 1, 0, 10000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP002', N'DV04', 20000.0000, 1, 0, 20000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP002', N'DV06', 100000.0000, 1, 0, 100000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP003', N'DV04', 20000.0000, 1, 0, 20000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP004', N'DV07', 25000.0000, 1, 0, 25000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP005', N'DV04', 20000.0000, 2, 0, 40000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP007', N'DV01', 10000.0000, 2, 0, 20000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP008', N'DV02', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP008', N'DV03', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP009', N'DV01', 10000.0000, 2, 0, 20000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP010', N'DV05', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP011', N'DV04', 20000.0000, 2, 0, 40000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP012', N'DV02', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP013', N'DV07', 25000.0000, 2, 0, 50000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP014', N'DV02', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP015', N'DV01', 10000.0000, 2, 0, 20000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP015', N'DV06', 100000.0000, 2, 0, 200000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP017', N'DV02', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP018', N'DV03', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP019', N'DV06', 100000.0000, 2, 0, 200000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP020', N'DV05', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP021', N'DV04', 20000.0000, 2, 0, 40000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP022', N'DV02', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP023', N'DV05', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP024', N'DV03', 15000.0000, 2, 0, 30000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP025', N'DV01', 10000.0000, 2, 0, 20000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP025', N'DV02', 15000.0000, 2, 0, 30000.0000)
GO
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR01', N'TN002', 2, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR01', N'TN004', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR01', N'TN005', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR01', N'TN006', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR01', N'TN007', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR01', N'TN010', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR01', N'TN011', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR01', N'TN012', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR02', N'TN002', 3, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR02', N'TN004', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR02', N'TN005', 2, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR02', N'TN006', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR02', N'TN007', 2, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR02', N'TN010', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR02', N'TN011', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'NOR02', N'TN012', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP01', N'TN001', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP01', N'TN004', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP01', N'TN005', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP01', N'TN006', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP01', N'TN007', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP01', N'TN009', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP01', N'TN010', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP01', N'TN011', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP01', N'TN012', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP02', N'TN001', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP02', N'TN004', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP02', N'TN005', 2, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP02', N'TN006', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP02', N'TN007', 2, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP02', N'TN009', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP02', N'TN010', 1, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP02', N'TN011', 2, 0)
INSERT [dbo].[CTTN] ([MaLPH], [MaTN], [SL], [DaXoa]) VALUES (N'VIP02', N'TN012', 1, 0)
GO
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV01', N'Nước suối', 10000.0000, 100, N'Thức uống', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV02', N'Coca cola', 15000.0000, 100, N'Thức uống', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV03', N'Pepsi', 15000.0000, 100, N'Thức uống', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV04', N'Bia Sài Gòn', 20000.0000, 100, N'Thức uống', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV05', N'Mì ăn liền', 15000.0000, 100, N'Đồ ăn', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV06', N'Đưa đón', 100000.0000, -1, N'Dịch vụ', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV07', N'Giặt ủi', 25000.0000, -1, N'Dịch vụ', 0)
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD001', CAST(N'2025-05-15T00:00:00' AS SmallDateTime), 1350000.0000, N'NV001', N'Đã thanh toán', N'CTDP001', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD002', CAST(N'2025-06-15T00:00:00' AS SmallDateTime), 1730000.0000, N'NV001', N'Đã thanh toán', N'CTDP002', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD003', CAST(N'2025-07-18T00:00:00' AS SmallDateTime), 1220000.0000, N'NV001', N'Đã thanh toán', N'CTDP003', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD004', CAST(N'2025-09-20T00:00:00' AS SmallDateTime), 1225000.0000, N'NV001', N'Đã thanh toán', N'CTDP004', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD005', CAST(N'2025-12-06T00:00:00' AS SmallDateTime), 1540000.0000, N'NV001', N'Đã thanh toán', N'CTDP005', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD006', CAST(N'2022-12-10T00:00:00' AS SmallDateTime), 600000.0000, N'NV001', N'Đã thanh toán', N'CTDP006', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD007', CAST(N'2022-12-20T00:00:00' AS SmallDateTime), 3020000.0000, N'NV001', N'Đã thanh toán', N'CTDP007', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD008', CAST(N'2022-12-20T00:00:00' AS SmallDateTime), 960000.0000, N'NV001', N'Đã thanh toán', N'CTDP008', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD009', CAST(N'2025-10-05T00:00:00' AS SmallDateTime), 1220000.0000, N'NV001', N'Đã thanh toán', N'CTDP009', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD010', CAST(N'2022-12-20T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP010', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD011', CAST(N'2022-12-25T00:00:00' AS SmallDateTime), 1240000.0000, N'NV001', N'Đã thanh toán', N'CTDP011', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD012', CAST(N'2022-12-18T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP012', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD013', CAST(N'2025-08-15T00:00:00' AS SmallDateTime), 1250000.0000, N'NV001', N'Đã thanh toán', N'CTDP013', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD014', CAST(N'2025-07-20T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP014', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD015', CAST(N'2025-11-20T00:00:00' AS SmallDateTime), 1420000.0000, N'NV001', N'Đã thanh toán', N'CTDP015', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD018', CAST(N'2023-01-03T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP018', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD019', CAST(N'2022-12-20T00:00:00' AS SmallDateTime), 1400000.0000, N'NV001', N'Đã thanh toán', N'CTDP019', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD020', CAST(N'2023-02-07T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD021', CAST(N'2023-02-07T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD022', CAST(N'2023-02-08T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD023', CAST(N'2023-02-09T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD024', CAST(N'2023-01-17T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD025', CAST(N'2023-01-19T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD026', CAST(N'2023-01-25T00:00:00' AS SmallDateTime), 1230000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH001', N'Nguyễn Văn A', N'092391233', N'072001056912', N'Việt Nam', N'Nam', N'vana001@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH002', N'Nguyễn Văn B', N'092391234', N'072001056913', N'Việt Nam', N'Nam', N'vanb002@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH003', N'Nguyễn Văn C', N'092391235', N'072001056914', N'Việt Nam', N'Nam', N'vanc003@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH004', N'Phạm Thị P', N'092361213', N'072001546231', N'Việt Nam', N'Nữ', N'thip004@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH005', N'Phạm Thị G', N'082361233', N'072001012231', N'Việt Nam', N'Nữ', N'thig005@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH006', N'Nguyễn Văn D', N'092391236', N'072001056952', N'Việt Nam', N'Nam', N'vand006@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH007', N'Nguyễn Văn E', N'092391237', N'072001056911', N'Việt Nam', N'Nam', N'vane007@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH008', N'Phạm Thị H', N'096361233', N'072001078231', N'Việt Nam', N'Nữ', N'thih008@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH009', N'Nguyễn Văn F', N'092391238', N'072001056976', N'Việt Nam', N'Nam', N'vanf009@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH010', N'Nguyễn Văn G', N'092391229', N'072001056919', N'Việt Nam', N'Nam', N'vang010@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH011', N'Phạm Thị U', N'071236123', N'072071756231', N'Việt Nam', N'Nữ', N'thiu011@gmail.com', 0)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [Email], [DaXoa]) VALUES (N'KH012', N'Phạm Thị T', N'022361233', N'072041056231', N'Việt Nam', N'Nữ', N'thit012@gmail.com', 0)
GO
INSERT [dbo].[LoaiPhong] ([MaLPH], [TenLPH], [SoGiuong], [SoNguoiToiDa], [GiaNgay], [GiaGio]) VALUES (N'NOR01', N'Thường đơn', 1, 2, 300000.0000, 80000.0000)
INSERT [dbo].[LoaiPhong] ([MaLPH], [TenLPH], [SoGiuong], [SoNguoiToiDa], [GiaNgay], [GiaGio]) VALUES (N'NOR02', N'Thường đôi', 2, 4, 400000.0000, 120000.0000)
INSERT [dbo].[LoaiPhong] ([MaLPH], [TenLPH], [SoGiuong], [SoNguoiToiDa], [GiaNgay], [GiaGio]) VALUES (N'VIP01', N'VIP đơn', 1, 2, 500000.0000, 150000.0000)
INSERT [dbo].[LoaiPhong] ([MaLPH], [TenLPH], [SoGiuong], [SoNguoiToiDa], [GiaNgay], [GiaGio]) VALUES (N'VIP02', N'VIP đôi', 2, 4, 700000.0000, 200000.0000)
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'AD001', N'Nguyễn Phúc Bình', N'Quản lý', 40000000.0000, N'0907219273', N'072000001212', CAST(N'2003-09-30' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'21520638@gm.uit.edu.vn', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'AD002', N'Phan Tuấn Thành', N'Quản lý', 45000000.0000, N'071223431', N'072000001213', CAST(N'2003-10-11' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'21520455@gm.uit.edu.vn', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'AD003', N'Lê Thanh Tuấn', N'Quản lý', 50000000.0000, N'010311231', N'072000001214', CAST(N'1989-06-10' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'21520519@gm.uit.edu.vn', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV001', N'Trần Thị B', N'Tiếp tân', 5500000.0000, N'091311231', N'072000001217', CAST(N'1993-01-23' AS Date), N'Nữ', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV545205119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV002', N'Nguyễn Phuc C ', N'Tiếp tân', 5500000.0000, N'092311231', N'072000001220', CAST(N'1986-11-21' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV6152051@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV003', N'Lê Văn D', N'Tiếp tân', 5500000.0000, N'090317231', N'072000001221', CAST(N'1990-07-05' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV2152119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV004', N'Hồ Văn E', N'Bảo vệ', 5500000.0000, N'090312231', N'072000001282', CAST(N'2000-10-27' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV715205119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV005', N'Nguyễn Văn F', N'Nhân viên vệ sinh', 5500000.0000, N'090111231', N'072000009012', CAST(N'1998-02-24' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV52015119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV006', N'Phạm Thị P', N'Nhân viên vệ sinh', 5500000.0000, N'090311232', N'072000002134', CAST(N'2001-08-02' AS Date), N'Nữ', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV15205119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV007', N'Nguyễn Văn G', N'Bảo vệ', 5500000.0000, N'090311233', N'072000028912', CAST(N'2002-09-12' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV215595119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'QL001', N'Phạm Thị A', N'Tiếp tân', 5500000.0000, N'095411231', N'072000001215', CAST(N'1995-03-09' AS Date), N'Nữ', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV215235119@gmail.com', 0)
GO
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT001', CAST(N'2025-05-10T00:00:00' AS SmallDateTime), N'KH002', N'NV002', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT002', CAST(N'2025-06-12T00:00:00' AS SmallDateTime), N'KH004', N'QL001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT003', CAST(N'2025-07-15T00:00:00' AS SmallDateTime), N'KH003', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT004', CAST(N'2025-11-28T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT005', CAST(N'2025-08-28T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT006', CAST(N'2025-05-28T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT007', CAST(N'2025-03-28T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT008', CAST(N'2023-01-05T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT009', CAST(N'2023-02-03T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT010', CAST(N'2023-02-04T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT011', CAST(N'2023-01-06T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT012', CAST(N'2023-02-08T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT013', CAST(N'2023-02-09T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT014', CAST(N'2025-02-10T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT015', CAST(N'2022-12-28T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT016', CAST(N'2025-11-11T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT017', CAST(N'2025-10-15T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT018', CAST(N'2025-09-18T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT019', CAST(N'2025-08-30T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT020', CAST(N'2023-01-26T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT021', CAST(N'2025-11-27T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT022', CAST(N'2025-06-11T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT023', CAST(N'2025-11-11T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
GO
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P101', N'Bình thường', N'Đã dọn dẹp', NULL, N'NOR01', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P102', N'Bình thường', N'Đã dọn dẹp', NULL, N'NOR01', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P103', N'Bình thường', N'Chưa dọn dẹp', NULL, N'NOR02', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P104', N'Đang sửa chữa', N'Đã dọn dẹp', N'Hư điều hòa', N'NOR01', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P105', N'Bình thường', N'Đã dọn dẹp', NULL, N'NOR02', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P106', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP01', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P201', N'Bình thường', N'Chưa dọn dẹp', NULL, N'NOR02', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P202', N'Bình thường', N'Đã dọn dẹp', NULL, N'NOR01', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P203', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P204', N'Bình thường', N'Chưa dọn dẹp', NULL, N'VIP02', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P301', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP01', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P302', N'Bình thường', N'Chưa dọn dẹp', NULL, N'NOR01', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P303', N'Bình thường', N'Đã dọn dẹp', NULL, N'NOR02', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P304', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P305', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP01', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P401', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P402', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P403', N'Bình thường', N'Chưa dọn dẹp', NULL, N'VIP01', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P404', N'Bình thường', N'Chưa dọn dẹp', NULL, N'VIP01', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P501', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 1, 0)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [Tang], [DaXoa]) VALUES (N'P502', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 1, 0)
GO
INSERT [dbo].[TaiKhoan] ([TenTK], [Password], [CapDoQuyen], [MaNV], [DaXoa]) VALUES (N'admin', N'1234', 3, N'AD001', 0)
INSERT [dbo].[TaiKhoan] ([TenTK], [Password], [CapDoQuyen], [MaNV], [DaXoa]) VALUES (N'admin1', N'1234', 3, N'AD002', 0)
INSERT [dbo].[TaiKhoan] ([TenTK], [Password], [CapDoQuyen], [MaNV], [DaXoa]) VALUES (N'admin2', N'1234', 3, N'AD003', 0)
INSERT [dbo].[TaiKhoan] ([TenTK], [Password], [CapDoQuyen], [MaNV], [DaXoa]) VALUES (N'NhanVien', N'1234', 1, N'NV001', 0)
INSERT [dbo].[TaiKhoan] ([TenTK], [Password], [CapDoQuyen], [MaNV], [DaXoa]) VALUES (N'Quanly', N'1234', 2, N'QL001', 0)
GO
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN001', N'Máy lạnh', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN002', N'Máy quạt', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN003', N'Tủ lạnh', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN004', N'Tivi', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN005', N'Đèn ngủ', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN006', N'Bàn', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN007', N'Ghế', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN008', N'Bàn trang điểm', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN009', N'Bồn tắm', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN010', N'Vòi sen', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN011', N'Máy sấy tóc', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [SoLuong], [DaXoa]) VALUES (N'TN012', N'Máy nước nóng', 0, 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__F7905DCDA52564E0]    Script Date: 09/12/2025 1:24:41 CH ******/
ALTER TABLE [dbo].[KhachHang] ADD UNIQUE NONCLUSTERED 
(
	[CCCD/Passport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__A955A0AA5BC88806]    Script Date: 09/12/2025 1:24:41 CH ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[CCCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__A9D10534AAB3C66E]    Script Date: 09/12/2025 1:24:41 CH ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__CA1930A58FB8A208]    Script Date: 09/12/2025 1:24:41 CH ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[SDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CTDP] ADD  DEFAULT ((0)) FOR [ThanhTien]
GO
ALTER TABLE [dbo].[CTDP] ADD  DEFAULT ((0)) FOR [DaXoa]
GO
ALTER TABLE [dbo].[CTDP] ADD  DEFAULT ((0)) FOR [TheoGio]
GO
ALTER TABLE [dbo].[CTDP] ADD  DEFAULT ((0)) FOR [TienDatCoc]
GO
ALTER TABLE [dbo].[CTDV] ADD  DEFAULT ((0)) FOR [DaXoa]
GO
ALTER TABLE [dbo].[CTDV] ADD  DEFAULT ((0)) FOR [ThanhTien]
GO
ALTER TABLE [dbo].[CTTN] ADD  DEFAULT ((-1)) FOR [SL]
GO
ALTER TABLE [dbo].[CTTN] ADD  DEFAULT ((0)) FOR [DaXoa]
GO
ALTER TABLE [dbo].[DichVu] ADD  DEFAULT ((-1)) FOR [SLConLai]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [TriGia]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [DaXoa]
GO
ALTER TABLE [dbo].[PhieuThue] ADD  DEFAULT ((0)) FOR [DaXoa]
GO
ALTER TABLE [dbo].[Phong] ADD  CONSTRAINT [DF_Phong_Tang]  DEFAULT ((1)) FOR [Tang]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT ((0)) FOR [DaXoa]
GO
ALTER TABLE [dbo].[TienNghi] ADD  DEFAULT ((0)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[CSKH_ThongBao]  WITH CHECK ADD  CONSTRAINT [FK_MaCTDP] FOREIGN KEY([MaCTDP])
REFERENCES [dbo].[CTDP] ([MaCTDP])
GO
ALTER TABLE [dbo].[CSKH_ThongBao] CHECK CONSTRAINT [FK_MaCTDP]
GO
ALTER TABLE [dbo].[CTDP]  WITH CHECK ADD  CONSTRAINT [CTDP_MaPH_Forein] FOREIGN KEY([MaPH])
REFERENCES [dbo].[Phong] ([MaPH])
GO
ALTER TABLE [dbo].[CTDP] CHECK CONSTRAINT [CTDP_MaPH_Forein]
GO
ALTER TABLE [dbo].[CTDP]  WITH CHECK ADD  CONSTRAINT [CTDP_MaPT_Forein] FOREIGN KEY([MaPT])
REFERENCES [dbo].[PhieuThue] ([MaPT])
GO
ALTER TABLE [dbo].[CTDP] CHECK CONSTRAINT [CTDP_MaPT_Forein]
GO
ALTER TABLE [dbo].[CTDV]  WITH CHECK ADD  CONSTRAINT [CTDV_MaCTDP_foreign] FOREIGN KEY([MaCTDP])
REFERENCES [dbo].[CTDP] ([MaCTDP])
GO
ALTER TABLE [dbo].[CTDV] CHECK CONSTRAINT [CTDV_MaCTDP_foreign]
GO
ALTER TABLE [dbo].[CTDV]  WITH CHECK ADD  CONSTRAINT [CTDV_MaDV_foreign] FOREIGN KEY([MaDV])
REFERENCES [dbo].[DichVu] ([MaDV])
GO
ALTER TABLE [dbo].[CTDV] CHECK CONSTRAINT [CTDV_MaDV_foreign]
GO
ALTER TABLE [dbo].[CTTN]  WITH CHECK ADD  CONSTRAINT [CTTN_MaLPH_foreign] FOREIGN KEY([MaLPH])
REFERENCES [dbo].[LoaiPhong] ([MaLPH])
GO
ALTER TABLE [dbo].[CTTN] CHECK CONSTRAINT [CTTN_MaLPH_foreign]
GO
ALTER TABLE [dbo].[CTTN]  WITH CHECK ADD  CONSTRAINT [CTTN_MaTN_foreign] FOREIGN KEY([MaTN])
REFERENCES [dbo].[TienNghi] ([MaTN])
GO
ALTER TABLE [dbo].[CTTN] CHECK CONSTRAINT [CTTN_MaTN_foreign]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [hoadon_MaCTDP_foreign] FOREIGN KEY([MaCTDP])
REFERENCES [dbo].[CTDP] ([MaCTDP])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [hoadon_MaCTDP_foreign]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [hoadon_manv_foreign] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [hoadon_manv_foreign]
GO
ALTER TABLE [dbo].[PhieuThue]  WITH CHECK ADD  CONSTRAINT [phieuthue_makh_foreign] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[PhieuThue] CHECK CONSTRAINT [phieuthue_makh_foreign]
GO
ALTER TABLE [dbo].[PhieuThue]  WITH CHECK ADD  CONSTRAINT [phieuthue_manv_foreign] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuThue] CHECK CONSTRAINT [phieuthue_manv_foreign]
GO
ALTER TABLE [dbo].[Phong]  WITH CHECK ADD  CONSTRAINT [phong_malph_foreign] FOREIGN KEY([MaLPH])
REFERENCES [dbo].[LoaiPhong] ([MaLPH])
GO
ALTER TABLE [dbo].[Phong] CHECK CONSTRAINT [phong_malph_foreign]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [TaiKhoan_manv_foreign] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [TaiKhoan_manv_foreign]
GO
/****** Object:  Trigger [dbo].[CapNhatGiaDV]    Script Date: 09/12/2025 1:24:41 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[CapNhatGiaDV] ON [dbo].[CTDV] FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @MaCTDP NVARCHAR(7), @MaDV NVARCHAR(5), @GiaTien MONEY, @SL INT
	SET @MaCTDP = (SELECT MaCTDP FROM inserted)
	SET @MaDV = (SELECT MaDV FROM inserted)
	SET @GiaTien = (SELECT DonGia FROM DichVu WHERE DichVu.MaDV=@MaDV)
	SET @SL = (SELECT SL FROM inserted)
	UPDATE CTDV
	SET DonGia=@GiaTien
	WHERE  MaDV  = @MaDV AND MaCTDP = @MaCTDP
	UPDATE CTDV
	SET ThanhTien= @SL * @GiaTien
	WHERE  MaDV  = @MaDV AND MaCTDP = @MaCTDP
END
-- TRIGGER udpate giá trị hóa đơn
GO
ALTER TABLE [dbo].[CTDV] ENABLE TRIGGER [CapNhatGiaDV]
GO
/****** Object:  Trigger [dbo].[CapNhatGiaTriHoaDon]    Script Date: 09/12/2025 1:25:42 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[CapNhatGiaTriHoaDon] ON [dbo].[HoaDon] FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @MaHD NVARCHAR(5), @MaCTDP NVARCHAR(7), @TongTienHD MONEY, @TongTienDV MONEY, @TongTienPhong MONEY
	SET @MaHD = (SELECT MaHD FROM inserted)
	SET @MaCTDP = (SELECT MaCTDP FROM inserted)
	SET @TongTienDV = 0
	SET @TongTienDV = (SELECT SUM(ThanhTien) FROM CTDV WHERE MaCTDP = @MaCTDP GROUP BY MaCTDP)
	SET @TongTienPhong = (SELECT ThanhTien FROM CTDP WHERE MaCTDP=@MaCTDP)
	IF ( NOT EXISTS( SELECT * FROM CTDV WHERE MaCTDP = @MaCTDP))
	BEGIN 
		SET @TongTienDV = 0
	END
	UPDATE HoaDon
	SET TriGia = @TongTienDV+@TongTienPhong
	WHERE MaHD=@MaHD
END
GO
ALTER TABLE [dbo].[HoaDon] ENABLE TRIGGER [CapNhatGiaTriHoaDon]
GO
USE [master]
GO
ALTER DATABASE [QLKS] SET  READ_WRITE 
GO
