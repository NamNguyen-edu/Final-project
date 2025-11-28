using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    using System.Drawing;

namespace HotelManagement.CTControls
{
    public static class AppTheme
    {
        public static Color TextColorNormal = Color.Black;
        public static Color TextColorActive = Color.White;
        public static Color MainBackColor = Color.FromArgb(245, 245, 240); // Nền Off-White/Beige

            // --- 2. MÀU CHO MAIN FORM (Sidebar/Primary) ---
            public static Color PrimaryColor = Color.FromArgb(96, 75, 50);    // Nâu vừa, ấm áp (Sidebar nền, nút thường)
            public static Color ActiveColor = Color.FromArgb(140, 95, 40);   // Màu Đồng/Bronze (Nút Sidebar đang chọn, không phải Cam)

        public static Color PopupMainBackground = Color.White;
        public static Color PopupContentPanelColor = Color.FromArgb(250, 240, 220); 
        public static Color InnerBorderColor = Color.FromArgb(200, 200, 200);    

            // --- 4. MÀU CÁC NÚT CHỨC NĂNG (Muted Tones) ---
            public static Color ButtonSave = Color.FromArgb(80, 110, 60);       // Xanh rêu (Muted Forest Green)
            public static Color ButtonDanger = Color.FromArgb(165, 50, 50);   // Đỏ gạch/Maroon (Muted Red)
            public static Color ButtonAction = Color.FromArgb(140, 95, 40);    // Bronze (Dùng lại ActiveColor cho Thêm DV/Nhận)
            public static Color ButtonCheckout = Color.FromArgb(70, 90, 100);  // Xanh xám đậm (Muted Blue Contrast)
            public static Color ButtonExit = Color.Gray;                       // Xám (Giữ nguyên)

        // --- 5. MÀU CHO DATAGRIDVIEW & HIGHLIGHT ---
        public static Color GridHeaderDark = Color.FromArgb(182, 103, 36); //Màu header
        public static Color GridCellLight = Color.FromArgb(250, 250, 245);   // Màu Cell (Gần trắng)
        public static Color GridSelectionColor = Color.FromArgb(254, 241, 214); //Màu từng GridRows
        public static Color PopupHighlightColor = Color.FromArgb(230, 210, 180); // Màu của khung ghi chú
        public static Color GridContainerBackground = Color.FromArgb(182, 103, 36); // Màu của khung background thêm  dịch vụ trong thông tin phòng 
        public static Color SidebarPrimary = Color.FromArgb(50, 75, 90);      // normal
        public static Color SidebarHover = Color.FromArgb(70, 100, 120);    // hover
        public static Color SidebarActive = Color.FromArgb(255, 145, 60);    // active

        public static Color SidebarTextNormal = Color.White;
        public static Color SidebarTextActive = Color.White;
        //Lựa chọn FormMain
        public static Color Select = Color.FromArgb(245, 220, 200);
    }

}