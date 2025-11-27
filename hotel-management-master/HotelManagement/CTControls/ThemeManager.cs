using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.Linq; // Cần thiết cho các hàm LINQ

namespace HotelManagement.CTControls
{
    public static class ThemeManager
    {

        public static void ResetSidebarButtons(Panel sidebar)
        {
            foreach (Control c in sidebar.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = AppTheme.PrimaryColor;
                    btn.ForeColor = AppTheme.TextColorNormal;
                }
            }
        }

        public static void HighlightButton(Button btn)
        {
            if (btn == null) return;
            btn.BackColor = AppTheme.ActiveColor;
            btn.ForeColor = AppTheme.TextColorActive;
        }


        public static void ApplyThemeToChild(Form childForm)
        {
            childForm.BackColor = AppTheme.MainBackColor;
            ApplyRecursive(childForm);
        }

        public static void ApplyThemeToRoomPopup(Form form)
        {
            form.BackColor = AppTheme.PopupMainBackground;
            ApplyRecursive(form);
        }

        // ===============================================
        // C. CORE RECURSIVE APPLICATION (ÁP DỤNG MÀU)
        // ===============================================
        private static void ApplyRecursive(Control container)
        {
            foreach (Control c in container.Controls)
            {
                // Xử lý Custom Button (Dùng Tag để gán màu)
                if (c.GetType().Name == "CTButton" && c is CTControls.CTButton ctb)
                {
                    ApplyCustomButtonTheme(ctb);
                }
                // Xử lý Custom Panel (CTPanel)
                else if (c.GetType().Name == "CTPanel" && c is CTPanel.CTPanel ctp)
                {
                    ApplyCTPanelTheme(ctp);
                }
                // Xử lý DataGridView
                else if (c is DataGridView dgv)
                {
                    StyleDataGridView(dgv);
                }
                // Xử lý TextBox Ghi Chú (Áp dụng màu highlight nếu cần)
                else if (c is TextBox txt && txt.Name == "TextBoxGhiChu")
                {
                    //txt.BackColor = AppTheme.PopupHighlightColor;
                    //txt.ForeColor = AppTheme.TextColorNormal;
                }
                // Xử lý Panel chứa nội dung chính
                else if (c is Panel pnl && pnl.Name == "PanelChuaThongTin")
                {
                    pnl.BackColor = AppTheme.PopupContentPanelColor;
                }

                // Đệ quy
                if (c.HasChildren)
                    ApplyRecursive(c);
            }
        }

        // ===============================================
        // D. HÀM HELPER ĐỂ ĐỊNH DẠNG RIÊNG
        // ===============================================

        private static void ApplyCustomButtonTheme(CTButton btn)
        {
            if (btn.Tag == null) return;

            // Dùng switch expression để gán màu dựa trên Tag
            Color color = btn.Tag.ToString().ToLower() switch
            {
                "save" => AppTheme.ButtonSave,
                "checkout" => AppTheme.ButtonCheckout,
                "action" => AppTheme.ButtonAction,
                "danger" => AppTheme.ButtonDanger,
                "exit" => AppTheme.ButtonExit,
                _ => Color.Empty
            };

            if (color != Color.Empty)
            {
                btn.BackColor = color;
                btn.BackgroundColor = color;
                btn.BorderColor = color;
                btn.TextColor = AppTheme.TextColorActive; // White
            }
        }


        private static void ApplyCTPanelTheme(Control c)
        {
            dynamic ctp = c;

            // QUAN TRỌNG: Cần đảm bảo CTPanel của bạn có các thuộc tính công khai (public) 

            if (c.Name == "ctPanel2")
            {
                // Yêu cầu: ctPanel2 (Status Update) phải có màu Trắng để nổi bật
                ctp.GradientBottomColor = AppTheme.PopupMainBackground;
                ctp.GradientTopColor = AppTheme.PopupMainBackground;

            }
            else if (c.Name == "ctPanel1")
            {
                // Yêu cầu: ctPanel1 (Grid Container) về màu Nâu nhạt hơn (Linen)
                ctp.GradientBottomColor = AppTheme.GridContainerBackground;
                ctp.GradientTopColor = AppTheme.GridContainerBackground;

            }
            //else if (c.Name == "ctPanel3")
            //{
            //    Ghi Chú: giữ nguyên màu Highlight nhạt mới(230, 210, 180)
            //    ctp.GradientBottomColor = AppTheme.PopupHighlightColor;
            //    ctp.GradientTopColor = AppTheme.PopupHighlightColor;
            //}
        }
        private static void StyleDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            // Đổi cho Header (Column Header)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.GridHeaderDark; // Nâu đậm
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppTheme.GridHeaderDark;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.TextColorActive; // Chữ trắng

            // Đổi cho Cell (Ô dữ liệu)
            dgv.BackgroundColor = AppTheme.PopupMainBackground; // Đảm bảo nền Form được nhìn thấy
            dgv.DefaultCellStyle.BackColor = AppTheme.GridContainerBackground;
            dgv.DefaultCellStyle.SelectionBackColor = AppTheme.GridSelectionColor; // Màu Cam nổi bật
            dgv.DefaultCellStyle.ForeColor = AppTheme.TextColorNormal; // Chữ đen

        }
    }
}
