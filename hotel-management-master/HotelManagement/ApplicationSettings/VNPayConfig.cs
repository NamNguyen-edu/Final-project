using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Properties;

namespace HotelManagement.ApplicationSettings
{
    // Lấy dữ liệu các tham số bí mật từ Config của dự án 
    class VNPayConfig
    {
        public static string Vnp_Url => Settings.Default.Vnp_Url;// Đường link dẫn đến server thanh toán của VNPay
        public static string Vnp_TmnCode => Settings.Default.Vnp_TmnCode; // Mã định danh tài khoản đăng ký trên cổng giả lập của VNPay

        public static string Vnp_HashSecret => Settings.Default.Vnp_HashSecret; // Chìa khóa tạo và giải mã chuỗi bí mật để đưa thông tin lên cổng thanh toán

        public static string Vnp_ReturnUrl => Settings.Default.Vnp_ReturnUrl; // Đường link trang web mà VNPay sẽ trả kết quả về.
    }
}
