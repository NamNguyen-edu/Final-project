using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    using System.Drawing;

namespace HotelManagement.CTControls
{
    // Class chứa màu
    public static class AppTheme
    {
        public static Color TextColorNormal = Color.Black;
        public static Color TextColorActive = Color.White;
        public static Color MainBackColor = Color.FromArgb(245, 245, 240); // Nền Off-White/Beige

        public static Color PrimaryColor = Color.FromArgb(96, 75, 50);    
        public static Color ActiveColor = Color.FromArgb(140, 95, 40);  
        public static Color PopupMainBackground = Color.White;
        public static Color PopupContentPanelColor = Color.FromArgb(250, 240, 220); 
        public static Color InnerBorderColor = Color.FromArgb(200, 200, 200);    

        public static Color ButtonSave = Color.FromArgb(80, 110, 60);      
        public static Color ButtonDanger = Color.FromArgb(165, 50, 50);  
        public static Color ButtonAction = Color.FromArgb(140, 95, 40);   
        public static Color ButtonCheckout = Color.FromArgb(70, 90, 100);  
        public static Color ButtonExit = Color.Gray;                       
        // Màu cho GridView
        public static Color GridHeaderDark = Color.FromArgb(182, 103, 36); //Màu header
        public static Color GridCellLight = Color.FromArgb(250, 250, 245);   // Màu Cell 
        public static Color GridSelectionColor = Color.FromArgb(254, 241, 214); //Màu từng GridRows
        public static Color PopupHighlightColor = Color.FromArgb(230, 210, 180); 
        public static Color GridContainerBackground = Color.FromArgb(182, 103, 36); // Màu của khung background thêm dịch vụ
        public static Color SidebarPrimary = Color.FromArgb(50, 75, 90);     
        public static Color SidebarHover = Color.FromArgb(70, 100, 120);    
        public static Color SidebarActive = Color.FromArgb(255, 145, 60);   
        public static Color SidebarTextNormal = Color.White;
        public static Color SidebarTextActive = Color.White;
        //Lựa chọn FormMain
        public static Color Select = Color.FromArgb(245, 220, 200);
    }

}