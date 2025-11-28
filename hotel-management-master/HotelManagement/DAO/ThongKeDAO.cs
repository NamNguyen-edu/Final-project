using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Policy;
using System.Data;

namespace HotelManagement.DAO
{
    internal class ThongKeDAO
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["HotelDTO"].ConnectionString;
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        public struct DoanhThuTheoNgay
        {
            public string Date { get; set; }
            public decimal TotalAmount { get; set; }
        }
        public struct SoPhongTheoNgay
        {
            public string Date { get; set; }
            public int TotalAmount { get; set; }
        }
        private DateTime ngayBD;
        private DateTime ngayKT;
        private int SoNgay;
        public List<KeyValuePair<string, decimal>> TopDichVuList { get; set; }
        public List<DoanhThuTheoNgay> DoanhThuThuongDonList { get; set; }
        public List<DoanhThuTheoNgay> DoanhThuThuongDoiList { get; set; }
        public List<DoanhThuTheoNgay> DoanhThuVipDonList { get; set; }
        public List<DoanhThuTheoNgay> DoanhThuVipDoiList { get; set; }
        public List<DoanhThuTheoNgay> DoanhThuDichVuList { get; set; }
        public List<DoanhThuDichVuTheoNgay> DoanhThuDichVuTheoNgayList { get; set; }
        public List<SoPhongTheoNgay> SoPhongDatList { get; set; }
        public List<DoanhThuTheoNgay> DoanhThuTongList { get; set; }
        public List<DatPhongTheoLoai> TyTrongDatPhongList { get; set; }
        public List<DoanhThuTheoLoaiPhong> DoanhThuLoaiPhongList { get; set; }
        public List<KeyValuePair<string, decimal>> TyTrongDoanhThuDVList { get; set; }
        public List<SoLuongTheoNgay> SoKhachTheoNgayList { get; set; }
        public List<KhachChiTieu> Top5KhachChiTieuList { get; set; }
        public List<KeyValuePair<string, int>> TopKhachDatList { get; set; }
        public decimal TongDoanhThuThuongDon { get; set; }
        public decimal TongDoanhThuThuongDoi { get; set; }
        public decimal TongDoanhThuVipDon { get; set; }
        public decimal TongDoanhThuVipDoi { get; set; }
        public decimal TongDoanhThuThue { get; set; }
        public decimal TongDoanhThuDichVu { get; set; }
        public decimal TongDoanhThuTong { get; set; }
        public int SoPhongDat { get; set; }

        public string TenLoaiPhongDoanhThuCaoNhat { get; set; }
        public decimal DoanhThuLoaiPhongCaoNhat { get; set; }
        public string TenLoaiPhongDuocDatNhieuNhat { get; set; }
        public int SoLanLoaiPhongDatNhieuNhat { get; set; }
        public string TenDichVuDoanhThuCaoNhat { get; set; }
        public decimal DoanhThuDichVuCaoNhat { get; set; }
        public string TenDichVuSuDungNhieuNhat { get; set; }
        public int SoLanDichVuSuDungNhieuNhat { get; set; }
        public int TongSoKhach { get; set; }
        public string TenKhachDatNhieuNhat { get; set; }
        public int SoLanKhachDatNhieuNhat { get; set; }
        public string TenKhachChiNhieuNhat { get; set; }
        public decimal TienKhachChiNhieuNhat { get; set; }
            
        public class DatPhongTheoLoai
        {
            public string TenLoaiPhong { get; set; }
            public int SoLan { get; set; }
        }
        public class DoanhThuTheoLoaiPhong
        {
            public string TenLoaiPhong { get; set; }
            public decimal TongTien { get; set; }
        }
        public class DoanhThuDichVuTheoNgay
        {
            public string Date { get; set; }
            public decimal TotalAmount { get; set; }
        }

        public class TyTrongDV
        {
            public string TenDV { get; set; }
            public decimal DoanhThu { get; set; }
        }
        public class SoLuongTheoNgay
        {
            public string Date { get; set; }
            public int TotalAmount { get; set; }
        }
        public class KhachChiTieu
        {
            public string TenKhach { get; set; }
            public decimal TongTien { get; set; }
        }
        public ThongKeDAO()
        {

        }

        public bool LoadData(DateTime ngayBD, DateTime ngayKT)
        {
            ngayBD = new DateTime(ngayBD.Year, ngayBD.Month, ngayBD.Day, 0, 0, 0);
            ngayKT = new DateTime(ngayKT.Year, ngayKT.Month, ngayKT.Day, 23, 59, 59);
            if (ngayBD != this.ngayBD || ngayKT != this.ngayKT)
            {
                this.ngayBD = ngayBD;
                this.ngayKT = ngayKT;
                this.SoNgay = (ngayKT - ngayBD).Days;
                //Các hàm GET data
                GetDoanhThuThuongDon();
                GetDoanhThuThuongDoi();
                GetDoanhThuVipDon();
                GetDoanhThuVipDoi();
                GetDoanhThuThue();
                GetDoanhThuTongHop();
                GetDoanhThuDichVu();
                GetDoanhThuDichVuTheoNgay();
                GetSoPhongDat();
                GetLoaiPhongDoanhThuCaoNhat();
                GetDichVuDoanhThuCaoNhat();
                GetDichVuSuDungNhieuNhat();
                GetLoaiPhongDatNhieuNhat();
                GetTyTrongDatPhong();
                GetDoanhThuTheoLoaiPhong();
                GetTop5DichVu();
                GetTyTrongDoanhThuDV();
                GetKhachChiTieuNhieuNhat();
                GetTongSoKhach();
                GetSoKhachTheoNgay();
                GetTop5KhachChiTieu();
                GetTopKhachDatNhieuNhat();

                //
                Console.WriteLine("Refresh data: {0} - {1}", ngayBD.ToString(), ngayKT.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Date not refresheed, same query: {0} - {1}", ngayBD.ToString(), ngayKT.ToString());
                return false;
            }
        }
        private void GetDoanhThuDichVu()
        {
            DoanhThuDichVuList = new List<DoanhThuTheoNgay>();
            TongDoanhThuDichVu = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;
                    command.CommandText = @"select DichVu.MaDV, ThanhTien
                                            from CTDV inner join HoaDon
                                            on CTDV.MaCTDP = HoaDon.MaCTDP
                                            inner join DichVu
                                            on DichVu.MaDV = CTDV.MaDV
                                            where HoaDon.DaXoa = 0 and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                            group by DichVu.MaDV, NgHD, ThanhTien, HoaDon.MaHD
                                            order by NgHD asc
                                            ";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TongDoanhThuDichVu += (decimal)reader[1];
                    }
                    reader.Close();
                }
            }
        }
        private void GetDoanhThuThuongDon()
        {
            DoanhThuThuongDonList = new List<DoanhThuTheoNgay>();
            TongDoanhThuThuongDon = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;
                    command.CommandText = @"  select NgHD, SUM(CTDP.DonGia)
                                              from HoaDon inner join CTDP
                                              on HoaDon.MaCTDP = CTDP.MaCTDP
                                              inner join Phong
                                              on Phong.MaPH = CTDP.MaPH
                                              inner join LoaiPhong
                                              on LoaiPhong.MaLPH = Phong.MaLPH
                                              where HoaDon.DaXoa = 0 and LoaiPhong.MaLPH = 'NOR01' and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                              group by NgHD
                                              order by NgHD asc
                                            ";
                    SqlDataReader reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1])
                            );
                        TongDoanhThuThuongDon += (decimal)reader[1];
                    }

                    reader.Close();
                    //Group by Hours
                    if (SoNgay <= 1)
                    {
                        DoanhThuThuongDonList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("hh tt")
                                            into order
                                            select new DoanhThuTheoNgay
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    //Group by Days
                    else if (SoNgay <= 30)
                    {
                        DoanhThuThuongDonList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("dd MMM")
                                           into order
                                            select new DoanhThuTheoNgay
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    //Group by Weeks
                    else if (SoNgay <= 92)
                    {
                        DoanhThuThuongDonList = (from orderList in resultTable
                                            group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                           into order
                                            select new DoanhThuTheoNgay
                                            {
                                                Date = "Week " + order.Key.ToString(),
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    //Group by Months
                    else if (SoNgay <= (365 * 2))
                    {
                        bool isYear = SoNgay <= 365 ? true : false;
                        DoanhThuThuongDonList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                            select new DoanhThuTheoNgay
                                            {
                                                Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    //Group by Years
                    else
                    {
                        DoanhThuThuongDonList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("yyyy")
                                           into order
                                            select new DoanhThuTheoNgay
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                }
            }
        }
        private void GetDoanhThuThuongDoi()
        {
            DoanhThuThuongDoiList = new List<DoanhThuTheoNgay>();
            TongDoanhThuThuongDoi = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;
                    command.CommandText = @"  select NgHD, SUM(CTDP.DonGia)
                                              from HoaDon inner join CTDP
                                              on HoaDon.MaCTDP = CTDP.MaCTDP
                                              inner join Phong
                                              on Phong.MaPH = CTDP.MaPH
                                              inner join LoaiPhong
                                              on LoaiPhong.MaLPH = Phong.MaLPH
                                              where HoaDon.DaXoa = 0 and LoaiPhong.MaLPH = 'NOR02' and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                              group by NgHD, CTDP.CheckIn, CTDP.CheckOut
                                              order by NgHD asc
                                            ";
                    SqlDataReader reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1])
                            );
                        TongDoanhThuThuongDoi += (decimal)reader[1];
                    }

                    reader.Close();
                    //Group by Hours
                    if (SoNgay <= 1)
                    {
                        DoanhThuThuongDoiList = (from orderList in resultTable
                                                 group orderList by orderList.Key.ToString("hh tt")
                                            into order
                                                 select new DoanhThuTheoNgay
                                                 {
                                                     Date = order.Key,
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }).ToList();
                    }
                    //Group by Days
                    else if (SoNgay <= 30)
                    {
                        DoanhThuThuongDoiList = (from orderList in resultTable
                                                 group orderList by orderList.Key.ToString("dd MMM")
                                           into order
                                                 select new DoanhThuTheoNgay
                                                 {
                                                     Date = order.Key,
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }).ToList();
                    }
                    //Group by Weeks
                    else if (SoNgay <= 92)
                    {
                        DoanhThuThuongDoiList = (from orderList in resultTable
                                                 group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                     orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                           into order
                                                 select new DoanhThuTheoNgay
                                                 {
                                                     Date = "Week " + order.Key.ToString(),
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }).ToList();
                    }
                    //Group by Months
                    else if (SoNgay <= (365 * 2))
                    {
                        bool isYear = SoNgay <= 365 ? true : false;
                        DoanhThuThuongDoiList = (from orderList in resultTable
                                                 group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                                 select new DoanhThuTheoNgay
                                                 {
                                                     Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }).ToList();
                    }
                    //Group by Years
                    else
                    {
                        DoanhThuThuongDoiList = (from orderList in resultTable
                                                 group orderList by orderList.Key.ToString("yyyy")
                                           into order
                                                 select new DoanhThuTheoNgay
                                                 {
                                                     Date = order.Key,
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }).ToList();
                    }
                }
            }
        }
        private void GetDoanhThuVipDon()
        {
            DoanhThuVipDonList = new List<DoanhThuTheoNgay>();
            TongDoanhThuVipDon = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;
                    command.CommandText = @"  select NgHD, SUM(CTDP.DonGia)
                                              from HoaDon inner join CTDP
                                              on HoaDon.MaCTDP = CTDP.MaCTDP
                                              inner join Phong
                                              on Phong.MaPH = CTDP.MaPH
                                              inner join LoaiPhong
                                              on LoaiPhong.MaLPH = Phong.MaLPH
                                              where HoaDon.DaXoa = 0 and LoaiPhong.MaLPH = 'VIP01' and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán' 
                                              group by NgHD, CTDP.CheckIn, CTDP.CheckOut
                                              order by NgHD asc
                                            ";
                    SqlDataReader reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1])
                            );
                        TongDoanhThuVipDon += (decimal)reader[1];
                    }

                    reader.Close();
                    //Group by Hours
                    if (SoNgay <= 1)
                    {
                        DoanhThuVipDonList = (from orderList in resultTable
                                                 group orderList by orderList.Key.ToString("hh tt")
                                            into order
                                                 select new DoanhThuTheoNgay
                                                 {
                                                     Date = order.Key,
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }).ToList();
                    }
                    //Group by Days
                    else if (SoNgay <= 30)
                    {
                        DoanhThuVipDonList = (from orderList in resultTable
                                                 group orderList by orderList.Key.ToString("dd MMM")
                                           into order
                                                 select new DoanhThuTheoNgay
                                                 {
                                                     Date = order.Key,
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }).ToList();
                    }
                    //Group by Weeks
                    else if (SoNgay <= 92)
                    {
                        DoanhThuVipDonList = (from orderList in resultTable
                                                 group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                     orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                           into order
                                                 select new DoanhThuTheoNgay
                                                 {
                                                     Date = "Week " + order.Key.ToString(),
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }).ToList();
                    }
                    //Group by Months
                    else if (SoNgay <= (365 * 2))
                    {
                        bool isYear = SoNgay <= 365 ? true : false;
                        DoanhThuVipDonList = (from orderList in resultTable
                                                 group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                                 select new DoanhThuTheoNgay
                                                 {
                                                     Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }).ToList();
                    }
                    //Group by Years
                    else
                    {
                        DoanhThuVipDonList = (from orderList in resultTable
                                                 group orderList by orderList.Key.ToString("yyyy")
                                           into order
                                                 select new DoanhThuTheoNgay
                                                 {
                                                     Date = order.Key,
                                                     TotalAmount = order.Sum(amount => amount.Value)
                                                 }).ToList();
                    }
                }
            }
        }
        private void GetDoanhThuVipDoi()
        {
            DoanhThuVipDoiList = new List<DoanhThuTheoNgay>();
            TongDoanhThuVipDoi = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;
                    command.CommandText = @"  select NgHD, SUM(CTDP.DonGia)
                                              from HoaDon inner join CTDP
                                              on HoaDon.MaCTDP = CTDP.MaCTDP
                                              inner join Phong
                                              on Phong.MaPH = CTDP.MaPH
                                              inner join LoaiPhong
                                              on LoaiPhong.MaLPH = Phong.MaLPH
                                              where HoaDon.DaXoa = 0 and LoaiPhong.MaLPH = 'VIP02' and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán' 
                                              group by NgHD, CTDP.CheckIn, CTDP.CheckOut
                                              order by NgHD asc
                                            ";
                    SqlDataReader reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], (decimal)reader[1])
                            );
                        TongDoanhThuVipDoi += (decimal)reader[1];
                    }

                    reader.Close();
                    //Group by Hours
                    if (SoNgay <= 1)
                    {
                        DoanhThuVipDoiList = (from orderList in resultTable
                                              group orderList by orderList.Key.ToString("hh tt")
                                            into order
                                              select new DoanhThuTheoNgay
                                              {
                                                  Date = order.Key,
                                                  TotalAmount = order.Sum(amount => amount.Value)
                                              }).ToList();
                    }
                    //Group by Days
                    else if (SoNgay <= 30)
                    {
                        DoanhThuVipDoiList = (from orderList in resultTable
                                              group orderList by orderList.Key.ToString("dd MMM")
                                           into order
                                              select new DoanhThuTheoNgay
                                              {
                                                  Date = order.Key,
                                                  TotalAmount = order.Sum(amount => amount.Value)
                                              }).ToList();
                    }
                    //Group by Weeks
                    else if (SoNgay <= 92)
                    {
                        DoanhThuVipDoiList = (from orderList in resultTable
                                              group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                  orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                           into order
                                              select new DoanhThuTheoNgay
                                              {
                                                  Date = "Week " + order.Key.ToString(),
                                                  TotalAmount = order.Sum(amount => amount.Value)
                                              }).ToList();
                    }
                    //Group by Months
                    else if (SoNgay <= (365 * 2))
                    {
                        bool isYear = SoNgay <= 365 ? true : false;
                        DoanhThuVipDoiList = (from orderList in resultTable
                                              group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                              select new DoanhThuTheoNgay
                                              {
                                                  Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                  TotalAmount = order.Sum(amount => amount.Value)
                                              }).ToList();
                    }
                    //Group by Years
                    else
                    {
                        DoanhThuVipDoiList = (from orderList in resultTable
                                              group orderList by orderList.Key.ToString("yyyy")
                                           into order
                                              select new DoanhThuTheoNgay
                                              {
                                                  Date = order.Key,
                                                  TotalAmount = order.Sum(amount => amount.Value)
                                              }).ToList();
                    }
                }
            }
        }
        private void GetDoanhThuThue()
        {
            TongDoanhThuThue = TongDoanhThuThuongDon + TongDoanhThuThuongDoi + TongDoanhThuVipDoi + TongDoanhThuVipDon;
        }
        private void GetDoanhThuDichVuTheoNgay()
        {
            DoanhThuDichVuTheoNgayList = new List<DoanhThuDichVuTheoNgay>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;

                    command.CommandText =
                        @"SELECT NgHD, SUM(CTDV.DonGia * CTDV.SL) AS DoanhThu
                  FROM HoaDon
                  INNER JOIN CTDV ON HoaDon.MaCTDP = CTDV.MaCTDP
                  WHERE HoaDon.DaXoa = 0
                    AND HoaDon.TrangThai = N'Đã thanh toán'
                    AND NgHD BETWEEN @fromDate AND @toDate
                  GROUP BY NgHD
                  ORDER BY NgHD ASC";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DoanhThuDichVuTheoNgayList.Add(new DoanhThuDichVuTheoNgay
                        {
                            Date = ((DateTime)reader[0]).ToString("dd/MM"),
                            TotalAmount = Convert.ToDecimal(reader[1])
                        });
                    }
                    reader.Close();
                }
            }
        }
        private void GetTop5DichVu()
        {
            TopDichVuList = new List<KeyValuePair<string, decimal>>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;

                    command.CommandText =
                        @"SELECT TOP 5 TenDV, SUM(CTDV.DonGia * CTDV.SL) AS DoanhThu
                  FROM CTDV
                  INNER JOIN DichVu ON CTDV.MaDV = DichVu.MaDV
                  INNER JOIN HoaDon ON CTDV.MaCTDP = HoaDon.MaCTDP
                  WHERE HoaDon.DaXoa = 0
                    AND HoaDon.TrangThai = N'Đã thanh toán'
                    AND NgHD BETWEEN @fromDate AND @toDate
                  GROUP BY TenDV
                  ORDER BY SUM(CTDV.DonGia * CTDV.SL) DESC";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TopDichVuList.Add(
                            new KeyValuePair<string, decimal>(
                                reader[0].ToString(),
                                Convert.ToDecimal(reader[1])
                            )
                        );
                    }
                    reader.Close();
                }
            }
        }
        private void GetTyTrongDoanhThuDV()
        {
            TyTrongDoanhThuDVList = new List<KeyValuePair<string, decimal>>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;

                    command.CommandText =
                        @"SELECT TenDV, SUM(CTDV.DonGia * CTDV.SL) AS DoanhThu
                  FROM CTDV
                  INNER JOIN DichVu ON CTDV.MaDV = DichVu.MaDV
                  INNER JOIN HoaDon ON CTDV.MaCTDP = HoaDon.MaCTDP
                  WHERE HoaDon.DaXoa = 0
                    AND HoaDon.TrangThai = N'Đã thanh toán'
                    AND NgHD BETWEEN @fromDate AND @toDate
                  GROUP BY TenDV";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TyTrongDoanhThuDVList.Add(new KeyValuePair<string, decimal>(
                            reader[0].ToString(),
                            Convert.ToDecimal(reader[1])
                        ));
                    }
                    reader.Close();
                }
            }
        }

        private void GetSoPhongDat()
        {
            SoPhongDat = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;
                    command.CommandText = @"  select NgPT, count(*) as SoPhongDat
                                              from PhieuThue inner join CTDP
                                              on CTDP.MaPT = PhieuThue.MaPT
                                              where PhieuThue.DaXoa = 0 and NgPT between @fromDate and @toDate
                                              group by NgPT, MaPH
                                              order by NgPT asc
                                            ";
                    SqlDataReader reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, int>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, int>((DateTime)reader[0], (int)reader[1])
                            );
                        SoPhongDat += (int)reader[1];
                    }

                    reader.Close();
                    //Group by Hours
                    if (SoNgay <= 1)
                    {
                        SoPhongDatList = (from orderList in resultTable
                                          group orderList by orderList.Key.ToString("hh tt")
                                            into order
                                          select new SoPhongTheoNgay
                                          {
                                              Date = order.Key,
                                              TotalAmount = order.Sum(amount => amount.Value)
                                          }).ToList();
                    }
                    //Group by Days
                    else if (SoNgay <= 30)
                    {
                        SoPhongDatList = (from orderList in resultTable
                                          group orderList by orderList.Key.ToString("dd MMM")
                                           into order
                                          select new SoPhongTheoNgay
                                          {
                                              Date = order.Key,
                                              TotalAmount = order.Sum(amount => amount.Value)
                                          }).ToList();
                    }
                    //Group by Weeks
                    else if (SoNgay <= 92)
                    {
                        SoPhongDatList = (from orderList in resultTable
                                          group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                              orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                           into order
                                          select new SoPhongTheoNgay
                                          {
                                              Date = "Week " + order.Key.ToString(),
                                              TotalAmount = order.Sum(amount => amount.Value)
                                          }).ToList();
                    }
                    //Group by Months
                    else if (SoNgay <= (365 * 2))
                    {
                        bool isYear = SoNgay <= 365 ? true : false;
                        SoPhongDatList = (from orderList in resultTable
                                          group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                          select new SoPhongTheoNgay
                                          {
                                              Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                              TotalAmount = order.Sum(amount => amount.Value)
                                          }).ToList();
                    }
                    //Group by Years
                    else
                    {
                        SoPhongDatList = (from orderList in resultTable
                                          group orderList by orderList.Key.ToString("yyyy")
                                           into order
                                          select new SoPhongTheoNgay
                                          {
                                              Date = order.Key,
                                              TotalAmount = order.Sum(amount => amount.Value)
                                          }).ToList();
                    }
                    reader.Close();
                }
            }
        }

        private void GetLoaiPhongDoanhThuCaoNhat()
        {
            TenLoaiPhongDoanhThuCaoNhat = "";
            DoanhThuLoaiPhongCaoNhat = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get Top 5 Dich Vu
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;
                    command.CommandText = @"  SELECT TOP 1 
       TenLPH,
       SUM(CTDP.DonGia) AS DoanhThu
FROM HoaDon 
INNER JOIN CTDP ON HoaDon.MaCTDP = CTDP.MaCTDP
INNER JOIN Phong ON Phong.MaPH = CTDP.MaPH
INNER JOIN LoaiPhong ON LoaiPhong.MaLPH = Phong.MaLPH
WHERE HoaDon.DaXoa = 0
  AND NgHD BETWEEN @fromDate AND @toDate
  AND HoaDon.TrangThai = N'Đã thanh toán'
GROUP BY TenLPH
ORDER BY DoanhThu DESC";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TenLoaiPhongDoanhThuCaoNhat = (string)reader[0];
                        DoanhThuLoaiPhongCaoNhat = (decimal)reader[1];
                    }
                    reader.Close();
                }
            }
        }
        private void GetDichVuDoanhThuCaoNhat()
        {
            TenDichVuDoanhThuCaoNhat = "";
            DoanhThuDichVuCaoNhat = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get Top 5 Dich Vu
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;
                    command.CommandText = @"  select top 1 TenDV, SUM(CTDV.DonGia)*SL as DoanhThu
                                              from DichVu inner join CTDV
                                              on DichVu.MaDV = CTDV.MaDV
                                              inner join HoaDon
                                              on CTDV.MaCTDP = HoaDon.MaCTDP
                                              where HoaDon.DaXoa = 0 and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                              group by TenDV, DichVu.MaDV, SL
                                              order by SUM(CTDV.DonGia)*SL desc";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TenDichVuDoanhThuCaoNhat = (string)reader[0];
                        DoanhThuDichVuCaoNhat = (decimal)reader[1];
                    }
                    reader.Close();
                }
            }
        }
        private void GetLoaiPhongDatNhieuNhat()
        {
            TenLoaiPhongDuocDatNhieuNhat = "";
            SoLanLoaiPhongDatNhieuNhat = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get Top 5 Dich Vu
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;
                    command.CommandText = @"  select top 1 TenLPH, COUNT(CTDP.MaCTDP) AS SoLanDat
                                              from HoaDon inner join CTDP
                                              on HoaDon.MaCTDP = CTDP.MaCTDP
                                              inner join Phong 
                                              on CTDP.MaPH = Phong.MaPH
                                              inner join LoaiPhong
                                              on LoaiPhong.MaLPH = Phong.MaLPH
                                              where HoaDon.DaXoa = 0 and NgHD between @fromDate and @toDate and HoaDon.TrangThai = N'Đã thanh toán'
                                              group by TenLPH, LoaiPhong.MaLPH
                                              order by COUNT(CTDP.MaCTDP) desc";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TenLoaiPhongDuocDatNhieuNhat = (string)reader[0];
                        SoLanLoaiPhongDatNhieuNhat = (int)reader[1];
                    }
                    reader.Close();
                }
            }
        }
        private void GetDoanhThuTongHop()
        {
            DoanhThuTongList = new List<DoanhThuTheoNgay>();
            TongDoanhThuTong = 0;

            // Gom toàn bộ ngày có trong phòng
            var all = new List<DoanhThuTheoNgay>();

            all.AddRange(DoanhThuThuongDonList);
            all.AddRange(DoanhThuThuongDoiList);
            all.AddRange(DoanhThuVipDonList);
            all.AddRange(DoanhThuVipDoiList);

            // GROUP THEO NGÀY (giống mấy hàm kia)
            var group = from x in all
                        group x by x.Date into g
                        select new DoanhThuTheoNgay
                        {
                            Date = g.Key,
                            TotalAmount = g.Sum(v => v.TotalAmount)
                        };

            DoanhThuTongList = group.ToList();

            // Tổng doanh thu = phòng + dịch vụ
            TongDoanhThuTong = TongDoanhThuThue + TongDoanhThuDichVu;
        }
        private void GetTyTrongDatPhong()
        {
            TyTrongDatPhongList = new List<DatPhongTheoLoai>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;

                    command.CommandText =
                        @" SELECT TenLPH, COUNT(*) AS SoLan
                   FROM CTDP 
                   INNER JOIN Phong ON CTDP.MaPH = Phong.MaPH
                   INNER JOIN LoaiPhong ON LoaiPhong.MaLPH = Phong.MaLPH
                   INNER JOIN HoaDon ON HoaDon.MaCTDP = CTDP.MaCTDP
                   WHERE HoaDon.DaXoa = 0 
                     AND NgHD BETWEEN @fromDate AND @toDate
                     AND HoaDon.TrangThai = N'Đã thanh toán'
                   GROUP BY TenLPH";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TyTrongDatPhongList.Add(new DatPhongTheoLoai
                        {
                            TenLoaiPhong = reader[0].ToString(),
                            SoLan = Convert.ToInt32(reader[1])
                        });
                    }

                    reader.Close();
                }
            }
        }
        private void GetDoanhThuTheoLoaiPhong()
        {
            DoanhThuLoaiPhongList = new List<DoanhThuTheoLoaiPhong>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;

                    command.CommandText =
                        @" SELECT TenLPH,
                         SUM(CTDP.DonGia) AS TongTien
                   FROM CTDP
                   INNER JOIN Phong ON CTDP.MaPH = Phong.MaPH
                   INNER JOIN LoaiPhong ON LoaiPhong.MaLPH = Phong.MaLPH
                   INNER JOIN HoaDon ON HoaDon.MaCTDP = CTDP.MaCTDP
                   WHERE HoaDon.DaXoa = 0
                     AND NgHD BETWEEN @fromDate AND @toDate
                     AND HoaDon.TrangThai = N'Đã thanh toán'
                   GROUP BY TenLPH";

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        DoanhThuLoaiPhongList.Add(new DoanhThuTheoLoaiPhong
                        {
                            TenLoaiPhong = reader[0].ToString(),
                            TongTien = Convert.ToDecimal(reader[1])
                        });
                    }

                    reader.Close();
                }
            }
        }
        private void GetDichVuSuDungNhieuNhat()
        {
            TenDichVuSuDungNhieuNhat = "";
            SoLanDichVuSuDungNhieuNhat = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;

                    command.CommandText =
                        @"SELECT TOP 1 TenDV,
                         SUM(CTDV.SL) AS SoLan
                  FROM CTDV
                  INNER JOIN DichVu ON DichVu.MaDV = CTDV.MaDV
                  INNER JOIN HoaDon ON HoaDon.MaCTDP = CTDV.MaCTDP
                  WHERE HoaDon.DaXoa = 0
                    AND NgHD BETWEEN @fromDate AND @toDate
                    AND HoaDon.TrangThai = N'Đã thanh toán'
                  GROUP BY TenDV
                  ORDER BY SoLan DESC";

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        TenDichVuSuDungNhieuNhat = reader[0].ToString();
                        SoLanDichVuSuDungNhieuNhat = Convert.ToInt32(reader[1]);
                    }

                    reader.Close();
                }
            }
        }
        private void GetTongSoKhach()
        {
            using (var con = GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"SELECT COUNT(*) FROM KhachHang WHERE DaXoa = 0";
                    TongSoKhach = (int)cmd.ExecuteScalar();
                }
            }
        }

        private void GetTop5KhachChiTieu()
        {
            Top5KhachChiTieuList = new List<KhachChiTieu>();

 using (var connection = GetConnection())
    {
        connection.Open();
        using (var command = new SqlCommand())
        {
            command.Connection = connection;
            command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
            command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;

            command.CommandText =
                @"SELECT TOP 5 
    KhachHang.TenKH, 
    SUM(HoaDon.TriGia) AS TongChi
FROM KhachHang
INNER JOIN PhieuThue ON PhieuThue.MaKH = KhachHang.MaKH
INNER JOIN CTDP ON CTDP.MaPT = PhieuThue.MaPT
INNER JOIN HoaDon ON HoaDon.MaCTDP = CTDP.MaCTDP
WHERE HoaDon.DaXoa = 0
  AND HoaDon.TrangThai = N'Đã thanh toán'
  AND HoaDon.NgHD BETWEEN @fromDate AND @toDate
GROUP BY KhachHang.TenKH
ORDER BY SUM(HoaDon.TriGia) DESC";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Top5KhachChiTieuList.Add(new KhachChiTieu
                        {
                            TenKhach = reader[0].ToString(),
                            TongTien = Convert.ToDecimal(reader[1])
                        });
                    }
                    reader.Close();
                }
            }
        }



        private void GetKhachChiTieuNhieuNhat()
        {
            using (var con = GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    cmd.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;

                    cmd.CommandText =
                        @"SELECT TOP 1 KhachHang.TenKH, SUM(TriGia) AS TongTien
                  FROM HoaDon
                  INNER JOIN CTDP ON CTDP.MaCTDP = HoaDon.MaCTDP
                  INNER JOIN PhieuThue ON PhieuThue.MaPT = CTDP.MaPT
                  INNER JOIN KhachHang ON KhachHang.MaKH = PhieuThue.MaKH
                  WHERE HoaDon.DaXoa = 0
                    AND NgHD BETWEEN @fromDate AND @toDate
                    AND HoaDon.TrangThai = N'Đã thanh toán'
                  GROUP BY TenKH
                  ORDER BY TongTien DESC";

                    var rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        TenKhachChiNhieuNhat = rd[0].ToString();
                        TienKhachChiNhieuNhat = Convert.ToDecimal(rd[1]);
                    }
                    rd.Close();
                }
            }
        }
        private void GetSoKhachTheoNgay()
        {
            SoKhachTheoNgayList = new List<SoLuongTheoNgay>();

            using (var con = GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = ngayBD;
                    cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = ngayKT;

                    cmd.CommandText =
                        @"SELECT NgPT,
                         SUM(CTDP.SoNguoi) AS SoKhach
                  FROM PhieuThue
                  INNER JOIN CTDP ON CTDP.MaPT = PhieuThue.MaPT
                  WHERE PhieuThue.DaXoa = 0
                    AND NgPT BETWEEN @fromDate AND @toDate
                  GROUP BY NgPT
                  ORDER BY NgPT ASC";

                    var rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        SoKhachTheoNgayList.Add(new SoLuongTheoNgay
                        {
                            Date = ((DateTime)rd[0]).ToString("dd/MM"),
                            TotalAmount = Convert.ToInt32(rd[1])
                        });
                    }
                    rd.Close();
                }
            }
        }

        private void GetTopKhachDatNhieuNhat()
        {
            TopKhachDatList = new List<KeyValuePair<string, int>>();

            using (var con = GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = ngayBD;
                    cmd.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = ngayKT;

                    cmd.CommandText =
                        @"SELECT TOP 10 KhachHang.TenKH, COUNT(*) AS SL
                  FROM PhieuThue
                  INNER JOIN KhachHang ON KhachHang.MaKH = PhieuThue.MaKH
                  WHERE PhieuThue.DaXoa = 0
                    AND NgPT BETWEEN @fromDate AND @toDate
                  GROUP BY TenKH
                  ORDER BY SL DESC";

                    var rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        TopKhachDatList.Add(
                            new KeyValuePair<string, int>(rd[0].ToString(), (int)rd[1])
                        );
                    }
                    rd.Close();
                }
            }

            // set KPI khách đặt nhiều nhất
            if (TopKhachDatList.Count > 0)
            {
                TenKhachDatNhieuNhat = TopKhachDatList[0].Key;
                SoLanKhachDatNhieuNhat = TopKhachDatList[0].Value;
            }
        }



    }
}
