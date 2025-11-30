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
        public string MaTB { get; set; }
        public string MaPH { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGianGui { get; set; }
    }
}
