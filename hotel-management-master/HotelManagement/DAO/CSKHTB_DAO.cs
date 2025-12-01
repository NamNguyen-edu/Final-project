using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

public static class CSKH_ThongBao_DAO
{
    // Chuỗi kết nối tới CSDL, lấy từ file cấu hình với tên connection string "HotelDTO"
    private static string connectionString =
        ConfigurationManager.ConnectionStrings["HotelDTO"].ConnectionString;

    // Lấy danh sách thông báo chăm sóc khách hàng được gửi trong ngày hiện tại
    public static List<ThongBaoCSKH> LayThongBaoHomNay()
    {
        // Danh sách kết quả trả về
        List<ThongBaoCSKH> list = new List<ThongBaoCSKH>();

        // Mở kết nối tới SQL Server
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // Câu lệnh SQL lấy các thông báo có ngày gửi bằng ngày hiện tại (so sánh theo phần Date)
            string sql = @"
                SELECT TB.MaTB, TB.MaCTDP, TB.NoiDung, TB.NgayLap, CTDP.MaPH
                FROM CSKH_ThongBao TB
                INNER JOIN CTDP CTDP ON TB.MaCTDP = CTDP.MaCTDP
                WHERE CONVERT(date, TB.NgayLap) = CONVERT(date, GETDATE())
                ORDER BY TB.NgayLap DESC";

            // Thực thi câu lệnh SQL và đọc dữ liệu bằng SqlDataReader
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                // Duyệt từng dòng kết quả, ánh xạ sang đối tượng ThongBaoCSKH và thêm vào danh sách
                while (rd.Read())
                {
                    list.Add(new ThongBaoCSKH
                    {
                        MaTB = rd["MaTB"].ToString(),
                        MaCTDP = rd["MaCTDP"].ToString(),
                        MaPH = rd["MaPH"] != DBNull.Value ? rd["MaPH"].ToString() : string.Empty, // Kiểm tra giá trị null
                        NoiDung = rd["NoiDung"].ToString(),
                        NgayLap = (DateTime)rd["NgayLap"]
                    });
                }
            }
        }

        // Trả về danh sách thông báo của ngày hôm nay
        return list;
    }
}
