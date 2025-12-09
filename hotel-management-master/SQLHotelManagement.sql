USE [master]
GO
/****** Object:  Database [QLKS]    Script Date: 12/9/2025 12:07:42 PM ******/
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
ALTER DATABASE [QLKS] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [QLKS] SET RECOVERY FULL 
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
EXEC sys.sp_db_vardecimal_storage_format N'QLKS', N'ON'
GO
ALTER DATABASE [QLKS] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLKS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLKS]
GO
/****** Object:  Table [dbo].[CSKH_ThongBao]    Script Date: 12/9/2025 12:07:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CSKH_ThongBao](
	[MaTB] [nvarchar](5) NOT NULL,
	[MaPH] [nvarchar](5) NOT NULL,
	[NoiDung] [nvarchar](255) NOT NULL,
	[NgayLap] [smalldatetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTDP]    Script Date: 12/9/2025 12:07:42 PM ******/
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
/****** Object:  Table [dbo].[CTDV]    Script Date: 12/9/2025 12:07:42 PM ******/
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
	[MaDV] ASC,
	[DonGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTTN]    Script Date: 12/9/2025 12:07:42 PM ******/
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
/****** Object:  Table [dbo].[DichVu]    Script Date: 12/9/2025 12:07:42 PM ******/
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
/****** Object:  Table [dbo].[HoaDon]    Script Date: 12/9/2025 12:07:42 PM ******/
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
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/9/2025 12:07:42 PM ******/
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
	[DaXoa] [bit] NULL,
	[Email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 12/9/2025 12:07:42 PM ******/
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
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/9/2025 12:07:42 PM ******/
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
/****** Object:  Table [dbo].[PhieuThue]    Script Date: 12/9/2025 12:07:42 PM ******/
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
/****** Object:  Table [dbo].[Phong]    Script Date: 12/9/2025 12:07:42 PM ******/
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
	[DaXoa] [bit] NULL,
	[Tang] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/9/2025 12:07:42 PM ******/
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
/****** Object:  Table [dbo].[TienNghi]    Script Date: 12/9/2025 12:07:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TienNghi](
	[MaTN] [nvarchar](5) NOT NULL,
	[TenTN] [nvarchar](50) NOT NULL,
	[DaXoa] [bit] NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CSKH_ThongBao] ([MaTB], [MaPH], [NoiDung], [NgayLap]) VALUES (N'TB001', N'P101', N'Khách phòng yêu cầu thêm 2 chai nước suối.', CAST(N'2025-11-29T09:15:00' AS SmallDateTime))
INSERT [dbo].[CSKH_ThongBao] ([MaTB], [MaPH], [NoiDung], [NgayLap]) VALUES (N'TB002', N'P102', N'Khách phòng cần thêm khăn tắm.', CAST(N'2025-11-29T09:30:00' AS SmallDateTime))
GO
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP001', 2, N'PT001', N'P101', CAST(N'2022-05-11T00:00:00' AS SmallDateTime), CAST(N'2022-05-15T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP002', 2, N'PT001', N'P103', CAST(N'2022-06-11T00:00:00' AS SmallDateTime), CAST(N'2022-06-15T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1600000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP003', 2, N'PT002', N'P201', CAST(N'2022-07-15T00:00:00' AS SmallDateTime), CAST(N'2022-07-18T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP004', 2, N'PT003', N'P104', CAST(N'2022-09-16T00:00:00' AS SmallDateTime), CAST(N'2022-09-20T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP005', 2, N'PT003', N'P204', CAST(N'2022-12-01T00:00:00' AS SmallDateTime), CAST(N'2022-12-06T00:00:00' AS SmallDateTime), N'Đã xong', 700000.0000, 3500000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP006', 2, N'PT004', N'P105', CAST(N'2022-11-08T00:00:00' AS SmallDateTime), CAST(N'2022-12-10T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 12800000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP007', 2, N'PT023', N'P101', CAST(N'2022-12-10T00:00:00' AS SmallDateTime), CAST(N'2022-12-20T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 3000000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP008', 2, N'PT022', N'P301', CAST(N'2022-12-17T00:00:00' AS SmallDateTime), CAST(N'2022-12-20T00:00:00' AS SmallDateTime), N'Đã xong', 500000.0000, 1500000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP009', 2, N'PT005', N'P201', CAST(N'2022-09-30T00:00:00' AS SmallDateTime), CAST(N'2022-10-05T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 2000000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP010', 2, N'PT006', N'P101', CAST(N'2022-12-03T00:00:00' AS SmallDateTime), CAST(N'2022-12-20T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 5100000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP011', 2, N'PT007', N'P301', CAST(N'2022-12-20T00:00:00' AS SmallDateTime), CAST(N'2022-12-25T00:00:00' AS SmallDateTime), N'Đã xong', 500000.0000, 2500000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP012', 2, N'PT008', N'P401', CAST(N'2022-08-08T00:00:00' AS SmallDateTime), CAST(N'2022-08-15T00:00:00' AS SmallDateTime), N'Đã xong', 700000.0000, 4900000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP013', 2, N'PT008', N'P501', CAST(N'2022-10-09T00:00:00' AS SmallDateTime), CAST(N'2022-10-11T00:00:00' AS SmallDateTime), N'Đã xong', 700000.0000, 1400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP014', 2, N'PT009', N'P202', CAST(N'2022-07-18T00:00:00' AS SmallDateTime), CAST(N'2022-07-20T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 600000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP015', 2, N'PT010', N'P203', CAST(N'2022-11-11T00:00:00' AS SmallDateTime), CAST(N'2022-11-20T00:00:00' AS SmallDateTime), N'Đã xong', 700000.0000, 6300000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP017', 2, N'PT012', N'P105', CAST(N'2022-09-17T00:00:00' AS SmallDateTime), CAST(N'2022-09-21T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 1600000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP018', 2, N'PT013', N'P302', CAST(N'2023-01-01T00:00:00' AS SmallDateTime), CAST(N'2023-01-03T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 600000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP019', 2, N'PT014', N'P303', CAST(N'2022-12-15T00:00:00' AS SmallDateTime), CAST(N'2022-12-20T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 2000000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP020', 2, N'PT015', N'P102', CAST(N'2023-02-04T00:00:00' AS SmallDateTime), CAST(N'2023-02-07T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 900000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP021', 2, N'PT016', N'P101', CAST(N'2023-02-03T00:00:00' AS SmallDateTime), CAST(N'2023-02-07T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP022', 2, N'PT017', N'P105', CAST(N'2023-02-02T00:00:00' AS SmallDateTime), CAST(N'2023-02-08T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 2400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP023', 2, N'PT018', N'P202', CAST(N'2023-02-03T00:00:00' AS SmallDateTime), CAST(N'2023-02-09T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 1800000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP024', 2, N'PT019', N'P303', CAST(N'2023-01-15T00:00:00' AS SmallDateTime), CAST(N'2023-01-17T00:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 800000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP025', 2, N'PT020', N'P401', CAST(N'2023-01-17T00:00:00' AS SmallDateTime), CAST(N'2023-01-19T00:00:00' AS SmallDateTime), N'Đã xong', 700000.0000, 1400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP026', 2, N'PT021', N'P302', CAST(N'2023-01-20T00:00:00' AS SmallDateTime), CAST(N'2023-01-25T00:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 1500000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP027', 2, N'PT024', N'P101', CAST(N'2025-11-07T15:38:00' AS SmallDateTime), CAST(N'2025-11-08T15:38:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP028', 2, N'PT025', N'P101', CAST(N'2025-11-10T18:52:00' AS SmallDateTime), CAST(N'2025-11-13T18:52:00' AS SmallDateTime), N'Đang thuê', 400000.0000, 1200000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP029', 2, N'PT026', N'P104', CAST(N'2025-11-10T18:53:00' AS SmallDateTime), CAST(N'2025-11-11T18:53:00' AS SmallDateTime), N'Đã xong', 300000.0000, 300000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP030', 4, N'PT027', N'P105', CAST(N'2025-11-10T14:30:00' AS SmallDateTime), CAST(N'2025-11-12T20:11:00' AS SmallDateTime), N'Đã xong', 400000.0000, 800000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP031', 2, N'PT028', N'P102', CAST(N'2025-11-13T11:30:00' AS SmallDateTime), CAST(N'2025-11-15T10:29:00' AS SmallDateTime), N'Đã xong', 400000.0000, 800000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP032', 2, N'PT029', N'P102', CAST(N'2025-11-17T12:05:00' AS SmallDateTime), CAST(N'2025-11-20T12:05:00' AS SmallDateTime), N'Đã xong', 300000.0000, 900000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP033', 4, N'PT030', N'P103', CAST(N'2025-11-18T18:26:00' AS SmallDateTime), CAST(N'2025-11-19T18:26:00' AS SmallDateTime), N'Đã xong', 300000.0000, 300000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP034', 2, N'PT031', N'P104', CAST(N'2025-11-18T12:00:00' AS SmallDateTime), CAST(N'2025-11-18T20:00:00' AS SmallDateTime), N'Đã xong', 300000.0000, 300000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP035', 4, N'PT032', N'P101', CAST(N'2025-11-18T15:00:00' AS SmallDateTime), CAST(N'2025-11-18T23:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP036', 4, N'PT033', N'P101', CAST(N'2025-11-18T15:30:00' AS SmallDateTime), CAST(N'2025-11-18T17:00:00' AS SmallDateTime), N'Đã xong', 120000.0000, 240000.0000, 0, 1, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP037', 4, N'PT034', N'P101', CAST(N'2025-11-20T16:03:00' AS SmallDateTime), CAST(N'2025-11-21T16:03:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP038', 4, N'PT035', N'P102', CAST(N'2025-11-20T16:06:00' AS SmallDateTime), CAST(N'2025-11-21T16:06:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP039', 4, N'PT036', N'P101', CAST(N'2025-11-24T00:00:00' AS SmallDateTime), CAST(N'2025-11-24T11:37:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP040', 4, N'PT037', N'P101', CAST(N'2025-11-23T13:00:00' AS SmallDateTime), CAST(N'2025-11-23T20:00:00' AS SmallDateTime), N'Đang thuê', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP041', 4, N'PT038', N'P102', CAST(N'2025-11-23T13:00:00' AS SmallDateTime), CAST(N'2025-11-23T23:53:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP042', 4, N'PT039', N'P103', CAST(N'2025-11-23T13:00:00' AS SmallDateTime), CAST(N'2025-11-24T12:22:00' AS SmallDateTime), N'Đã xong', 300000.0000, 300000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP043', 2, N'PT040', N'P103', CAST(N'2025-11-23T23:00:00' AS SmallDateTime), CAST(N'2025-11-24T22:28:00' AS SmallDateTime), N'Đã xong', 300000.0000, 300000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP044', 4, N'PT041', N'P102', CAST(N'2025-11-24T10:30:00' AS SmallDateTime), CAST(N'2025-11-24T22:00:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP045', 4, N'PT042', N'P101', CAST(N'2025-11-24T11:00:00' AS SmallDateTime), CAST(N'2025-11-24T21:48:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP046', 4, N'PT043', N'P102', CAST(N'2025-11-24T11:30:00' AS SmallDateTime), CAST(N'2025-11-24T23:25:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP047', 4, N'PT044', N'P102', CAST(N'2025-11-24T23:00:00' AS SmallDateTime), CAST(N'2025-11-25T21:41:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP048', 4, N'PT045', N'P102', CAST(N'2025-11-25T11:30:00' AS SmallDateTime), CAST(N'2025-11-25T23:12:00' AS SmallDateTime), N'Đã xong', 400000.0000, 400000.0000, 0, 0, 0.0000)
INSERT [dbo].[CTDP] ([MaCTDP], [SoNguoi], [MaPT], [MaPH], [CheckIn], [CheckOut], [TrangThai], [DonGia], [ThanhTien], [DaXoa], [TheoGio], [TienDatCoc]) VALUES (N'CTDP049', 2, N'PT046', N'P106', CAST(N'2025-11-28T19:30:00' AS SmallDateTime), CAST(N'2025-11-29T18:27:00' AS SmallDateTime), N'Đã xong', 500000.0000, 350000.0000, 0, 0, 150000.0000)
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
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP028', N'DV01', 10000.0000, 1, 0, 10000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP049', N'DV01', 10000.0000, 7, 0, 70000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP049', N'DV02', 15000.0000, 4, 0, 60000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP049', N'DV03', 15000.0000, 4, 0, 60000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP049', N'DV04', 20000.0000, 4, 0, 80000.0000)
INSERT [dbo].[CTDV] ([MaCTDP], [MaDV], [DonGia], [SL], [DaXoa], [ThanhTien]) VALUES (N'CTDP049', N'DV05', 15000.0000, 6, 0, 90000.0000)
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
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV01', N'Nước suối', 10000.0000, 89, N'Thức uống', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV02', N'Coca cola', 15000.0000, 96, N'Thức uống', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV03', N'Pepsi', 15000.0000, 96, N'Thức uống', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV04', N'Bia Sài Gòn', 20000.0000, 96, N'Thức uống', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV05', N'Mì ăn liền', 15000.0000, 94, N'Đồ ăn', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV06', N'Đưa đón', 100000.0000, -1, N'Dịch vụ', 0)
INSERT [dbo].[DichVu] ([MaDV], [TenDV], [DonGia], [SLConLai], [LoaiDV], [DaXoa]) VALUES (N'DV07', N'Giặt ủi', 25000.0000, -1, N'Dịch vụ', 0)
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD001', CAST(N'2022-05-15T00:00:00' AS SmallDateTime), 1350000.0000, N'NV001', N'Đã thanh toán', N'CTDP001', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD002', CAST(N'2022-06-15T00:00:00' AS SmallDateTime), 1730000.0000, N'NV001', N'Đã thanh toán', N'CTDP002', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD003', CAST(N'2022-07-18T00:00:00' AS SmallDateTime), 1220000.0000, N'NV001', N'Đã thanh toán', N'CTDP003', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD004', CAST(N'2022-09-20T00:00:00' AS SmallDateTime), 1225000.0000, N'NV001', N'Đã thanh toán', N'CTDP004', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD005', CAST(N'2022-12-06T00:00:00' AS SmallDateTime), 3540000.0000, N'NV001', N'Đã thanh toán', N'CTDP005', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD006', CAST(N'2022-12-10T00:00:00' AS SmallDateTime), 12800000.0000, N'NV001', N'Đã thanh toán', N'CTDP006', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD007', CAST(N'2022-12-20T00:00:00' AS SmallDateTime), 3020000.0000, N'NV001', N'Đã thanh toán', N'CTDP007', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD008', CAST(N'2022-12-20T00:00:00' AS SmallDateTime), 1560000.0000, N'NV001', N'Đã thanh toán', N'CTDP008', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD009', CAST(N'2022-10-05T00:00:00' AS SmallDateTime), 2020000.0000, N'NV001', N'Đã thanh toán', N'CTDP009', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD010', CAST(N'2022-12-20T00:00:00' AS SmallDateTime), 5130000.0000, N'NV001', N'Đã thanh toán', N'CTDP010', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD011', CAST(N'2022-12-25T00:00:00' AS SmallDateTime), 2540000.0000, N'NV001', N'Đã thanh toán', N'CTDP011', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD012', CAST(N'2022-12-18T00:00:00' AS SmallDateTime), 4930000.0000, N'NV001', N'Đã thanh toán', N'CTDP012', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD013', CAST(N'2022-08-15T00:00:00' AS SmallDateTime), 1450000.0000, N'NV001', N'Đã thanh toán', N'CTDP013', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD014', CAST(N'2022-07-20T00:00:00' AS SmallDateTime), 630000.0000, N'NV001', N'Đã thanh toán', N'CTDP014', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD015', CAST(N'2022-11-20T00:00:00' AS SmallDateTime), 6520000.0000, N'NV001', N'Đã thanh toán', N'CTDP015', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD018', CAST(N'2023-01-03T00:00:00' AS SmallDateTime), 630000.0000, N'NV001', N'Đã thanh toán', N'CTDP018', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD019', CAST(N'2022-12-20T00:00:00' AS SmallDateTime), 2200000.0000, N'NV001', N'Đã thanh toán', N'CTDP019', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD020', CAST(N'2023-02-07T00:00:00' AS SmallDateTime), 930000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD021', CAST(N'2023-02-07T00:00:00' AS SmallDateTime), 930000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD022', CAST(N'2023-02-08T00:00:00' AS SmallDateTime), 930000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD023', CAST(N'2023-02-09T00:00:00' AS SmallDateTime), 930000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD024', CAST(N'2023-01-17T00:00:00' AS SmallDateTime), 930000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD025', CAST(N'2023-01-19T00:00:00' AS SmallDateTime), 930000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD026', CAST(N'2023-01-25T00:00:00' AS SmallDateTime), 930000.0000, N'NV001', N'Đã thanh toán', N'CTDP020', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD027', CAST(N'2025-11-18T13:43:00' AS SmallDateTime), 900000.0000, N'AD001', N'Đã thanh toán', N'CTDP032', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD028', CAST(N'2025-11-18T13:52:00' AS SmallDateTime), 400000.0000, N'AD001', N'Đã thanh toán', N'CTDP035', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD029', CAST(N'2025-11-23T21:58:00' AS SmallDateTime), 400000.0000, N'AD001', N'Đã thanh toán', N'CTDP041', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD030', CAST(N'2025-11-23T21:58:00' AS SmallDateTime), 300000.0000, N'AD001', N'Đã thanh toán', N'CTDP042', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD031', CAST(N'2025-11-24T09:46:00' AS SmallDateTime), 400000.0000, N'AD001', N'Đã thanh toán', N'CTDP039', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD032', CAST(N'2025-11-24T09:46:00' AS SmallDateTime), 300000.0000, N'AD001', N'Đã thanh toán', N'CTDP043', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD033', CAST(N'2025-11-24T21:46:00' AS SmallDateTime), 400000.0000, N'AD001', N'Đã thanh toán', N'CTDP047', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD034', CAST(N'2025-11-28T18:30:00' AS SmallDateTime), 350000.0000, N'AD001', N'Đã Đặt Cọc', N'CTDP049', 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgHD], [TriGia], [MaNV], [TrangThai], [MaCTDP], [DaXoa]) VALUES (N'HD035', CAST(N'2025-11-28T18:32:00' AS SmallDateTime), 710000.0000, N'AD001', N'Đã thanh toán', N'CTDP049', 0)
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH001', N'Nguyễn Văn A', N'092391233', N'072001056912', N'Việt Nam', N'Nam', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH002', N'Nguyễn Văn B', N'092391234', N'072001056913', N'Việt Nam', N'Nam', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH003', N'Nguyễn Văn C', N'092391235', N'072001056914', N'Việt Nam', N'Nam', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH004', N'Phạm Thi P', N'092361213', N'072001546231', N'Việt Nam', N'Nữ', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH005', N'Phạm Thi G', N'082361233', N'072001012231', N'Việt Nam', N'Nữ', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH006', N'Nguyễn Văn D', N'0923232343', N'072001056952', N'Việt Nam', N'Nam', 0, N'nádfndfn@hotmail.con')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH007', N'Nguyễn Văn E', N'092391237', N'072001056911', N'Việt Nam', N'Nam', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH008', N'Phạm Thi H', N'096361233', N'072001078231', N'Việt Nam', N'Nữ', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH009', N'Nguyễn Văn F', N'092391238', N'072001056976', N'Việt Nam', N'Nam', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH010', N'Nguyễn Văn G', N'092391229', N'072001056919', N'Việt Nam', N'Nam', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH011', N'Phạm Thi U', N'071236123', N'072071756231', N'Việt Nam', N'Nữ', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH012', N'Phạm Thi T', N'022361233', N'072041056231', N'Việt Nam', N'Nữ', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH013', N'Lê Doãn Phú', N'0814338029', N'083249222839', N'Việt Nam', N'Nam', 0, N'phule2005@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH014', N'Lê Doãn Bảo', N'1234222342', N'083205000963', N'aa', N'Nam', 0, N'nguyenbao2006at@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH015', N'Nguyễn Duy Phú', N'2312442312', N'243243555644', N'aa', N'Nam', 0, N'nguyenb9205@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH016', N'dfsdfsd', N'2222222222', N'222222222222', N'ff', N'Nữ', 0, NULL)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH017', N'NNam', N'0938904763', N'079205016997', N'Việt Nam', N'Nam', 0, N'nhatnam17092005@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH018', N'đâsđá', N'3333333333', N'122222222222', N'ee', N'Nam', 0, N'baongr@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH019', N'lee hoan gviet', N'2131231231', N'432433253234', N'Viejet', N'Nam', 0, N'nguyenbao2005at@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH020', N'gggg', N'4445454356', N'453453453453', N'ngngngn', N'Nam', 0, N'nguyenbao2005at@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH021', N'ndfnnnfn', N'9134292394', N'123124923949', N'nrnjrjrj', N'Nam', 0, N'nguyenbao2005at@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [SDT], [CCCD/Passport], [QuocTich], [GioiTinh], [DaXoa], [Email]) VALUES (N'KH022', N'ewrưẻ', N'3423432432', N'324234234324', N'dsds', N'Nam', 0, N'phudoan1703@gmail.com')
GO
INSERT [dbo].[LoaiPhong] ([MaLPH], [TenLPH], [SoGiuong], [SoNguoiToiDa], [GiaNgay], [GiaGio]) VALUES (N'NOR01', N'Thường đơn', 1, 2, 300000.0000, 80000.0000)
INSERT [dbo].[LoaiPhong] ([MaLPH], [TenLPH], [SoGiuong], [SoNguoiToiDa], [GiaNgay], [GiaGio]) VALUES (N'NOR02', N'Thường đôi', 2, 4, 400000.0000, 120000.0000)
INSERT [dbo].[LoaiPhong] ([MaLPH], [TenLPH], [SoGiuong], [SoNguoiToiDa], [GiaNgay], [GiaGio]) VALUES (N'VIP01', N'VIP đơn', 1, 2, 500000.0000, 150000.0000)
INSERT [dbo].[LoaiPhong] ([MaLPH], [TenLPH], [SoGiuong], [SoNguoiToiDa], [GiaNgay], [GiaGio]) VALUES (N'VIP02', N'VIP đôi', 2, 4, 700000.0000, 200000.0000)
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'AD001', N'Nguyễn Duy Bảo', N'Quản lý', 40000000.0000, N'0907219273', N'072000001212', CAST(N'2005-07-09' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'21520638@gm.uit.edu.vn', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'AD002', N'Phan Tuấn Thành', N'Quản lý', 45000000.0000, N'0712234312', N'072000001234', CAST(N'2003-10-11' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'21520455@gm.uit.edu.vn', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'AD003', N'Lê Thanh Tuấn', N'Quản lý', 50000000.0000, N'010311231', N'072000001214', CAST(N'1989-06-10' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'21520519@gm.uit.edu.vn', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV001', N'Trần Thị B', N'Tiếp tân', 5500000.0000, N'091311231', N'072000001217', CAST(N'1993-01-23' AS Date), N'Nữ', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV545205119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV002', N'Nguyễn Phuc Du', N'Tiếp tân', 5500000.0000, N'092311231', N'072000001230', CAST(N'1986-11-21' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV6152051@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV003', N'Lê Văn D', N'Tiếp tân', 5500000.0000, N'090317231', N'072000001221', CAST(N'1990-07-05' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV2152119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV004', N'Hồ Văn E', N'Bảo vệ', 5500000.0000, N'090312231', N'072000001282', CAST(N'2000-10-27' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV715205119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV005', N'Nguyễn Văn F', N'Nhân viên vệ sinh', 5500000.0000, N'090111231', N'072000009012', CAST(N'1998-02-24' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV52015119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV006', N'Phạm Thị P', N'Nhân viên vệ sinh', 5500000.0000, N'090311232', N'072000002135', CAST(N'2001-08-02' AS Date), N'Nữ', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV15205119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV007', N'Nguyễn Văn G', N'Bảo vệ', 5500000.0000, N'090311233', N'072000028912', CAST(N'2002-09-12' AS Date), N'Nam', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV215595119@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV008', N'Lê Doãn Phú', N'Bảo vệ', 100000000.0000, N'0814338920', N'083205000985', CAST(N'2005-03-17' AS Date), N'Nam', N'Cam Lộ', N'phule2005at@gmail.com', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV009', N'ssss', N'sss', 2223333.0000, N'3432433235', N'434343444343', CAST(N'1999-06-30' AS Date), N'Nam', N'eê', N'as@gmail.com', 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV010', N'NDB', N'Nhân viên', 10000000.0000, N'0823448920', N'083205000983', CAST(N'2000-02-01' AS Date), N'Nam', N'aaa', N'ngbao20025at@gmail.com', 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'NV011', N'dưewew', N'ưẻwểwr', 322332231213.0000, N'1322131321', N'213132123213', CAST(N'2025-11-13' AS Date), N'Nữ', N'ewrưẻwẻ', N'123123123', 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [ChucVu], [Luong], [SDT], [CCCD], [NgaySinh], [GioiTinh], [DiaChi], [Email], [DaXoa]) VALUES (N'QL001', N'Phạm Thị A', N'Nhân viên', 5500000.0000, N'095411231', N'072000001215', CAST(N'1995-03-09' AS Date), N'Nữ', N'Đường Hàn Thuyên, khu phố 6, Thủ Đức, Thành phố Hồ Chí Minh', N'NV215235119@gmail.com', 0)
GO
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT001', CAST(N'2022-05-10T00:00:00' AS SmallDateTime), N'KH002', N'NV002', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT002', CAST(N'2022-06-12T00:00:00' AS SmallDateTime), N'KH004', N'QL001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT003', CAST(N'2022-07-15T00:00:00' AS SmallDateTime), N'KH003', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT004', CAST(N'2022-11-28T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT005', CAST(N'2022-08-28T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT006', CAST(N'2022-05-28T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT007', CAST(N'2022-03-28T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT008', CAST(N'2023-01-05T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT009', CAST(N'2023-02-03T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT010', CAST(N'2023-02-04T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT011', CAST(N'2023-01-06T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT012', CAST(N'2023-02-08T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT013', CAST(N'2023-02-09T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT014', CAST(N'2022-02-10T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT015', CAST(N'2022-12-28T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT016', CAST(N'2022-11-11T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT017', CAST(N'2022-10-15T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT018', CAST(N'2022-09-18T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT019', CAST(N'2022-08-30T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT020', CAST(N'2023-01-26T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT021', CAST(N'2022-11-27T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT022', CAST(N'2022-06-11T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT023', CAST(N'2022-11-11T00:00:00' AS SmallDateTime), N'KH001', N'NV001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT024', CAST(N'2025-11-06T15:40:00' AS SmallDateTime), N'KH013', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT025', CAST(N'2025-11-09T18:53:00' AS SmallDateTime), N'KH014', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT026', CAST(N'2025-11-09T18:54:00' AS SmallDateTime), N'KH015', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT027', CAST(N'2025-11-09T20:12:00' AS SmallDateTime), N'KH016', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT028', CAST(N'2025-11-13T10:30:00' AS SmallDateTime), N'KH014', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT029', CAST(N'2025-11-13T12:05:00' AS SmallDateTime), N'KH014', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT030', CAST(N'2025-11-13T18:27:00' AS SmallDateTime), N'KH014', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT031', CAST(N'2025-11-18T11:31:00' AS SmallDateTime), N'KH017', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT032', CAST(N'2025-11-18T13:51:00' AS SmallDateTime), N'KH017', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT033', CAST(N'2025-11-18T15:25:00' AS SmallDateTime), N'KH017', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT034', CAST(N'2025-11-18T16:04:00' AS SmallDateTime), N'KH014', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT035', CAST(N'2025-11-18T16:08:00' AS SmallDateTime), N'KH017', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT036', CAST(N'2025-11-23T11:39:00' AS SmallDateTime), N'KH013', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT037', CAST(N'2025-11-23T11:46:00' AS SmallDateTime), N'KH013', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT038', CAST(N'2025-11-23T11:54:00' AS SmallDateTime), N'KH013', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT039', CAST(N'2025-11-23T12:23:00' AS SmallDateTime), N'KH013', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT040', CAST(N'2025-11-23T22:31:00' AS SmallDateTime), N'KH018', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT041', CAST(N'2025-11-24T09:41:00' AS SmallDateTime), N'KH019', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT042', CAST(N'2025-11-24T09:49:00' AS SmallDateTime), N'KH020', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT043', CAST(N'2025-11-24T11:26:00' AS SmallDateTime), N'KH021', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT044', CAST(N'2025-11-24T21:43:00' AS SmallDateTime), N'KH022', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT045', CAST(N'2025-11-25T11:13:00' AS SmallDateTime), N'KH017', N'AD001', 0)
INSERT [dbo].[PhieuThue] ([MaPT], [NgPT], [MaKH], [MaNV], [DaXoa]) VALUES (N'PT046', CAST(N'2025-11-28T18:30:00' AS SmallDateTime), N'KH013', N'AD001', 0)
GO
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P101', N'Đang sửa chữa', N'Chưa dọn dẹp', N'aaa', N'NOR02', 0, 1)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P102', N'Bình thường', N'Chưa dọn dẹp', N'mm', N'NOR02', 0, 1)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P103', N'Bình thường', N'Chưa dọn dẹp', N'owwww', N'NOR01', 0, 1)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P104', N'Bình thường', N'Đang dọn dẹp', N'Hư điều hòa', N'NOR01', 0, 1)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P105', N'Bình thường', N'Đã dọn dẹp', N'', N'NOR02', 0, 1)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P106', N'Bình thường', N'Chưa dọn dẹp', NULL, N'VIP01', 0, 1)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P107', N'Bình thường', N'Đã dọn dẹp', N'', N'NOR02', 0, 1)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P201', N'Bình thường', N'Chưa dọn dẹp', NULL, N'NOR02', 0, 2)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P202', N'Bình thường', N'Chưa dọn dẹp', N'aaa', N'NOR01', 0, 2)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P203', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 0, 2)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P204', N'Bình thường', N'Chưa dọn dẹp', NULL, N'VIP02', 0, 2)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P301', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP01', 0, 3)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P302', N'Bình thường', N'Chưa dọn dẹp', NULL, N'NOR01', 0, 3)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P303', N'Bình thường', N'Đã dọn dẹp', NULL, N'NOR02', 0, 3)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P304', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 0, 3)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P305', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP01', 0, 3)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P401', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 0, 4)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P402', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 0, 4)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P403', N'Bình thường', N'Chưa dọn dẹp', NULL, N'VIP01', 0, 4)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P404', N'Bình thường', N'Chưa dọn dẹp', NULL, N'VIP01', 0, 4)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P501', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 0, 5)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P502', N'Bình thường', N'Đã dọn dẹp', NULL, N'VIP02', 0, 5)
INSERT [dbo].[Phong] ([MaPH], [TTPH], [TTDD], [GhiChu], [MaLPH], [DaXoa], [Tang]) VALUES (N'P503', N'Bình thường', N'Chưa dọn dẹp', N'', N'VIP01', 0, 5)
GO
INSERT [dbo].[TaiKhoan] ([TenTK], [Password], [CapDoQuyen], [MaNV], [DaXoa]) VALUES (N'admin', N'1234', 3, N'AD001', 0)
INSERT [dbo].[TaiKhoan] ([TenTK], [Password], [CapDoQuyen], [MaNV], [DaXoa]) VALUES (N'admin1', N'1234', 3, N'AD002', 0)
INSERT [dbo].[TaiKhoan] ([TenTK], [Password], [CapDoQuyen], [MaNV], [DaXoa]) VALUES (N'admin2', N'1234', 3, N'AD003', 0)
INSERT [dbo].[TaiKhoan] ([TenTK], [Password], [CapDoQuyen], [MaNV], [DaXoa]) VALUES (N'NhanVien', N'1234', 1, N'NV001', 0)
INSERT [dbo].[TaiKhoan] ([TenTK], [Password], [CapDoQuyen], [MaNV], [DaXoa]) VALUES (N'Quanly', N'1234', 2, N'QL001', 0)
GO
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN001', N'Máy lạnh', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN002', N'Máy quạt', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN003', N'Tủ lạnh', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN004', N'Tivi', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN005', N'Đèn ngủ', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN006', N'Bàn', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN007', N'Ghế', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN008', N'Bàn trang điểm', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN009', N'Bồn tắm', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN010', N'Vòi sen', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN011', N'Máy sấy tóc', 0, 0)
INSERT [dbo].[TienNghi] ([MaTN], [TenTN], [DaXoa], [SoLuong]) VALUES (N'TN012', N'Máy nước nóng', 0, 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__F7905DCD126A236B]    Script Date: 12/9/2025 12:07:42 PM ******/
ALTER TABLE [dbo].[KhachHang] ADD UNIQUE NONCLUSTERED 
(
	[CCCD/Passport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__A955A0AAF1FD0BD5]    Script Date: 12/9/2025 12:07:42 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[CCCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__A9D1053455381E33]    Script Date: 12/9/2025 12:07:42 PM ******/
ALTER TABLE [dbo].[NhanVien] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NhanVien__CA1930A52497A8BC]    Script Date: 12/9/2025 12:07:42 PM ******/
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
/****** Object:  Trigger [dbo].[CapNhatGiaCTDP]    Script Date: 12/9/2025 12:07:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Trigger Update Giá phòng
CREATE TRIGGER [dbo].[CapNhatGiaCTDP] ON [dbo].[CTDP] FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @MaPhong NVARCHAR(5)
	SET @MaPhong = (SELECT MaPH FROM inserted)
	DECLARE @MaCTDP NVARCHAR(7)
	SET @MaCTDP = (SELECT MaCTDP FROM inserted)
	DECLARE @GiaNgay MONEY
	SET @GiaNgay = (SELECT  LoaiPhong.GiaNgay
					FROM Phong JOIN LoaiPhong ON Phong.MaLPH=LoaiPhong.MaLPH
					WHERE Phong.MaPH=@MaPhong
					)
	DECLARE @GiaGio MONEY
	SET @GiaGio = (SELECT  LoaiPhong.GiaGio
					FROM Phong JOIN LoaiPhong ON Phong.MaLPH=LoaiPhong.MaLPH
					WHERE Phong.MaPH=@MaPhong
					)
	DECLARE @CheckIn SMALLDATETIME, @CheckOut SMALLDATETIME,@KhoangTGNgay INT, @KhoangTGGio INT, @TienDatCoc money
	SET @CheckIn = (SELECT CheckIn FROM inserted)
	SET @CheckOut = (SELECT CheckOut FROM inserted)
	SET @KhoangTGNgay=  (SELECT DATEDIFF(DAY, @CheckIn, @CheckOut))
	SET @TienDatCoc = (SELECT TienDatCoc FROM inserted where MaCTDP = @MaCTDP)
	IF @KhoangTGNgay < 1
	BEGIN
	SET @KhoangTGGio=  (SELECT DATEDIFF(HOUR, @CheckIn, @CheckOut))		
		IF @KhoangTGGio < 4
			BEGIN
				DECLARE @DonGia MONEY
				SET @DonGia = (SELECT GiaGio FROM LoaiPhong JOIN Phong ON LoaiPhong.MaLPH = Phong.MaLPH JOIN CTDP ON CTDP.MaPH=Phong.MaPH WHERE CTDP.MaCTDP=@MaCTDP) 
				UPDATE CTDP
				SET "ThanhTien"= (@KhoangTGGio * @GiaGio) - @TienDatCoc
				WHERE @MaCTDP = MaCTDP
				UPDATE CTDP
				SET "TheoGio"= 1
				WHERE @MaCTDP = MaCTDP
				UPDATE CTDP
				SET "DonGia"= @DonGia
				WHERE @MaCTDP = MaCTDP
			END
		ELSE
			BEGIN
				UPDATE CTDP
				SET "ThanhTien"= @GiaNgay - @TienDatCoc
				WHERE @MaCTDP = MaCTDP
			END
	END
	ELSE
	BEGIN
		UPDATE CTDP
		SET "DonGia"= @GiaNgay
		WHERE @MaCTDP = MaCTDP
		UPDATE CTDP
		SET "ThanhTien"= @KhoangTGNgay * @GiaNgay -@TienDatCoc
		WHERE @MaCTDP = MaCTDP
	END
END
-- Trigger update Gia CTDV
GO
ALTER TABLE [dbo].[CTDP] ENABLE TRIGGER [CapNhatGiaCTDP]
GO
/****** Object:  Trigger [dbo].[CapNhatGiaDV]    Script Date: 12/9/2025 12:07:42 PM ******/
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
	WHERE "MaDV" = @MaDV AND MaCTDP = @MaCTDP
	UPDATE CTDV
	SET ThanhTien= @SL * @GiaTien
	WHERE "MaDV" = @MaDV AND MaCTDP = @MaCTDP
END
-- TRIGGER udpate giá trị hóa đơn

GO
ALTER TABLE [dbo].[CTDV] ENABLE TRIGGER [CapNhatGiaDV]
GO
/****** Object:  Trigger [dbo].[CapNhatGiaTriHoaDon]    Script Date: 12/9/2025 12:07:42 PM ******/
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
