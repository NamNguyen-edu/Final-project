using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DTO
{
    public class ThongBaoCSKH
    {
        // Mã thông báo CSKH (khóa chính hoặc định danh duy nhất)
        public string MaTB { get; set; }

        // Mã phòng liên quan đến thông báo
        public string MaPH { get; set; }

        // Nội dung chi tiết của thông báo (yêu cầu, góp ý, phản ánh, ...)
        public string NoiDung { get; set; }

        // Thời điểm gửi thông báo từ phía khách hoặc hệ thống
        public DateTime ThoiGianGui { get; set; }
    }
}
