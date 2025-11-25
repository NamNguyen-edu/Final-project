using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Properties;

namespace HotelManagement.ApplicationSettings
{
    class VNPayConfig
    {
        public static string Vnp_Url => Settings.Default.Vnp_Url;
        public static string Vnp_TmnCode => Settings.Default.Vnp_TmnCode;
        public static string Vnp_HashSecret => Settings.Default.Vnp_HashSecret;
        public static string Vnp_ReturnUrl => Settings.Default.Vnp_ReturnUrl;
    }
}
