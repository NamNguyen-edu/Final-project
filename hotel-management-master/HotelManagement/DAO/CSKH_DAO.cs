using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

public static class CSKH_ThongBao_DAO
{
    private static string connectionString =
        ConfigurationManager.ConnectionStrings["HotelDTO"].ConnectionString;
    // Đổi tên chuỗi kết nối theo app.config của m

    public static List<ThongBaoCSKH> LayThongBaoHomNay()
    {
        List<ThongBaoCSKH> list = new List<ThongBaoCSKH>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = @"
                SELECT MaTB, MaPH, NoiDung, ThoiGianGui
                FROM CSKH_ThongBao
                WHERE CONVERT(date, ThoiGianGui) = CONVERT(date, GETDATE())
                ORDER BY ThoiGianGui DESC";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    list.Add(new ThongBaoCSKH
                    {
                        MaTB = rd["MaTB"].ToString(),
                        MaPH = rd["MaPH"].ToString(),
                        NoiDung = rd["NoiDung"].ToString(),
                        ThoiGianGui = (DateTime)rd["ThoiGianGui"]
                    });
                }
            }
        }

        return list;
    }
}