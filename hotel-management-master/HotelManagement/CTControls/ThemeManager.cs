using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace HotelManagement.CTControls
{
    public static class ThemeManager
    {

        public static void ResetSidebarButtons(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = AppTheme.PrimaryColor;
                    btn.ForeColor = AppTheme.TextColorNormal;
                }
                if (c.HasChildren)
                    ResetSidebarButtons(c);
            }
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
                // Xử lý Panel chứa nội dung chính
                else if (c is Panel pnl && pnl.Name == "PanelChuaThongTin")
                {
                    pnl.BackColor = AppTheme.PopupContentPanelColor;
                }
                else if (c.GetType().Name == "CTTextBox")
                {
                    dynamic ctbb = c;
                    ctbb.BackColor = AppTheme.PopupMainBackground; // White
                    ctbb.ForeColor = AppTheme.TextColorNormal;
                }
                else if (c is Panel pnel && pnel.Name == "PanelBackground")
                {
                    pnel.BackColor = AppTheme.PopupMainBackground;
                }
                // Đệ quy dành cho trường hợp nhiều Panel chồng chéo
                if (c.HasChildren)
                    ApplyRecursive(c);
            }
        }

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
                btn.TextColor = AppTheme.TextColorActive;
            }
        }
        // Áp dụng màu cho CTPanel
        private static void ApplyCTPanelTheme(Control c)
        {
            dynamic ctp = c;

            if (c.Name == "ctPanel2")
            {
                ctp.GradientBottomColor = AppTheme.PopupMainBackground;
                ctp.GradientTopColor = AppTheme.PopupMainBackground;

            }
            else if (c.Name == "ctPanel1")
            {
                ctp.GradientBottomColor = AppTheme.GridContainerBackground;
                ctp.GradientTopColor = AppTheme.GridContainerBackground;

            }

        }
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.GridHeaderDark; 
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppTheme.GridHeaderDark;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.TextColorActive; 
            // Đổi cho Cell 
            dgv.BackgroundColor = AppTheme.PopupMainBackground;
            dgv.DefaultCellStyle.BackColor = AppTheme.GridCellLight;
            dgv.DefaultCellStyle.SelectionBackColor = AppTheme.GridSelectionColor;
            dgv.DefaultCellStyle.ForeColor = AppTheme.TextColorNormal;

        }
       
        public static void ApplySidebarBehavior(Control sidebar)
        {
            foreach (Control c in sidebar.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = AppTheme.SidebarPrimary;
                    btn.ForeColor = AppTheme.SidebarTextNormal;

                    // Gán sự kiện hover
                    btn.MouseEnter += (s, e) =>
                    {
                        if (btn.Tag?.ToString() != "active")
                            btn.BackColor = AppTheme.SidebarHover;
                    };

                    btn.MouseLeave += (s, e) =>
                    {
                        if (btn.Tag?.ToString() != "active")
                            btn.BackColor = AppTheme.SidebarPrimary;
                    };
                }

                // đệ quy cho panel con
                if (c.HasChildren)
                    ApplySidebarBehavior(c);
            }
        }
        
        private static void ClearActiveStatus(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is Button btn)
                {
                    btn.Tag = null;
                    btn.BackColor = AppTheme.SidebarPrimary;
                    btn.ForeColor = AppTheme.SidebarTextNormal;
                }

                if (c.HasChildren)
                    ClearActiveStatus(c);
            }
        }

    }
}
