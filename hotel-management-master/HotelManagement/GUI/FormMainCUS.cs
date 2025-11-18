using HotelManagement.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationSettings;
using HotelManagement.GUI.ThongKe;
using HotelManagement.DTO;
using System.IO;
using HotelManagement.CTControls;
namespace HotelManagement
{
    public partial class FormMainCUS : Form
    {
        //Fields
        int LoaiTK;
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(72, 145, 153);
        private TaiKhoan taiKhoan;

        //Constructor
        public FormMainCUS(TaiKhoan taiKhoan)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.taiKhoan = taiKhoan;
            this.LoaiTK = taiKhoan.CapDoQuyen;
            InitializeComponent();
            //LoadFormForKhach();
            ApplyThemeForKhach();


        }
        private void ApplyThemeForKhach()
        {

            SetAllButtonNormalColor();
            openChildForm(new FormTrangChu_CUS(this));

            // Màu nhẹ hơn, tone pastel cho khách
            Color mainColor = Color.FromArgb(230, 245, 245);   // Toàn màn hình
            Color headerColor = Color.FromArgb(249, 165, 105); // Thanh tên KS
            Color sidebarColor = Color.FromArgb(249, 165, 105); // Sidebar
            Color infoColor = Color.FromArgb(249, 165, 105);   // Thanh thông tin dưới

            // Panel tổng
            this.PanelBackground.BackColor = mainColor;

            // Thanh top
            this.panelName.BackColor = headerColor;
            this.panelControlBox.BackColor = headerColor;

            // Sidebar
            this.Sidebar.BackColor = sidebarColor;
            this.PanelUser.BackColor = sidebarColor;

            // Panel hiển thị child
            this.panelMainChildForm.BackColor = mainColor;

            // Panel cuối
            this.panelInfomation.BackColor = infoColor;

            // Avatar nền khách
            this.PictureBoxUser.BackColor = Color.Transparent;

            // Đổi màu chữ
            this.labelTenKhachSan.ForeColor = Color.White;
            this.LabelTenNguoiDung.ForeColor = Color.Black;

            // Nếu bạn có button custom, có thể đổi màu luôn
        }



        //private void LoadFormForKhach()
        //{
        //    this.ButtonSoDoPhong.Hide();
        //    this.ButtonPhong.Hide();
        //    this.ButtonLoaiPhong.Hide();
        //    this.ButtonDanhSachDatPhong.Hide();
        //    this.ButtonDanhSachHoaDon.Hide();
        //    this.ButtonDanhSachDichVu.Hide();
        //    this.ButtonDanhSachKhachHang.Hide();
        //    this.ButtonDanhSachTienNghi.Hide();
        //    this.ButtonDanhSachTaiKhoan.Hide();
        //    this.ButtonDanhSachNhanVien.Hide();
        //    this.ButtonThongKe.Hide();
        //}

        //Control Box

        //Form Move

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- Minimize borderless form from taskbar
                return cp;
            }
        }

        //Private Methods
        //Private Methods
        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void ControlRegionAndBorder(Control control, float radius, Graphics graph, Color borderColor)
        {
            using (GraphicsPath roundPath = GetRoundedPath(control.ClientRectangle, radius))
            using (Pen penBorder = new Pen(borderColor, 1))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                control.Region = new Region(roundPath);
                graph.DrawPath(penBorder, roundPath);
            }
        }

        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);
                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);
                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }

        private void DrawPath(Rectangle rect, Graphics graph, Color color)
        {
            using (GraphicsPath roundPath = GetRoundedPath(rect, borderRadius))
            using (Pen penBorder = new Pen(color, 3))
            {
                graph.DrawPath(penBorder, roundPath);
            }
        }

        private struct FormBoundsColors
        {
            public Color TopLeftColor;
            public Color TopRightColor;
            public Color BottomLeftColor;
            public Color BottomRightColor;
        }
        private FormBoundsColors GetFormBoundsColors()
        {
            var fbColor = new FormBoundsColors();
            using (var bmp = new Bitmap(1, 1))
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle rectBmp = new Rectangle(0, 0, 1, 1);
                //Top Left
                rectBmp.X = this.Bounds.X - 1;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopLeftColor = bmp.GetPixel(0, 0);
                //Top Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopRightColor = bmp.GetPixel(0, 0);
                //Bottom Left
                rectBmp.X = this.Bounds.X;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0);
                //Bottom Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomRightColor = bmp.GetPixel(0, 0);
            }
            return fbColor;
        }

        private FormBoundsColors SameColor()
        {
            var fbColor = new FormBoundsColors();
            fbColor.TopLeftColor = Color.FromArgb(72, 145, 153);
            fbColor.TopRightColor = Color.FromArgb(72, 145, 153);
            fbColor.BottomLeftColor = Color.FromArgb(72, 145, 153);
            fbColor.BottomRightColor = Color.FromArgb(72, 145, 153);
            return fbColor;
        }

        //Event Methods
        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            //-> SMOOTH OUTER BORDER
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            //var fbColors = SameColor();
            var fbColors = GetFormBoundsColors();
            //Top Left
            DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);
            //Top Right
            Rectangle rectTopRight = new Rectangle(mWidht, rectForm.Y, mWidht, mHeight);
            DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);
            //Bottom Left
            Rectangle rectBottomLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidht, mHeight);
            DrawPath(rectBottomLeft, e.Graphics, fbColors.BottomLeftColor);
            //Bottom Right
            Rectangle rectBottomRight = new Rectangle(mWidht, rectForm.Y + mHeight, mWidht, mHeight);
            DrawPath(rectBottomRight, e.Graphics, fbColors.BottomRightColor);
            //-> SET ROUNDED REGION AND BORDER
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void FormMainCUS_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormMainCUS_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormMainCUS_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void PanelBackground_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(PanelBackground, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }
        private void FormMainCUS_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
            openChildForm(new FormTrangChu_CUS());
            int time = 300;
            WinAPI.AnimateWindow(this.Handle, time, WinAPI.CENTER);
            this.LabelTenNguoiDung.Text = taiKhoan.NhanVien.TenNV;
        }
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMainChildForm.Controls.Add(childForm);
            panelMainChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }



        private void ctMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ctMaximize1_Click(object sender, EventArgs e)
        {
            CTMessageBox.Show("Ứng dụng chưa hỗ trợ kích thước toàn màn hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void panelControlBox_MouseHover(object sender, EventArgs e)
        {
            ctClose1.turnOn();
            ctMinimize1.turnOn();
            ctMaximize1.turnOn();
        }

        private void panelControlBox_MouseLeave(object sender, EventArgs e)
        {
            ctClose1.turnOff();
            ctMinimize1.turnOff();
            ctMaximize1.turnOff();
        }

        private void panelControlBox_MouseMove(object sender, MouseEventArgs e)
        {
            ctClose1.turnOn();
            ctMinimize1.turnOn();
            ctMaximize1.turnOn();
        }

        private void panelName_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //Button color change
        private void SetAllButtonNormalColor()
        {
            SetColorButtonTrangChu();
            ButtonDatPhong.BackColor = Color.FromArgb(249, 165, 105);
            ButtonThanhToan.BackColor = Color.FromArgb(249, 165, 105);
            ButtonQLLD.BackColor = Color.FromArgb(249, 165, 105);
            ButtonCSKH.BackColor = Color.FromArgb(249, 165, 105);
            ButtonQLTK.BackColor = Color.FromArgb(249, 165, 105);



            ButtonDatPhong.ForeColor
            = ButtonThanhToan.ForeColor
            = ButtonQLLD.ForeColor
            = ButtonCSKH.ForeColor
            = ButtonQLTK.ForeColor = Color.Black;
        }

        //Khách hàng

        private void ButtonDatPhong_Click(object sender, EventArgs e)
        {
            //Change color button on side bar

            ButtonTrangChu.BackColor = Color.FromArgb(249, 165, 105);
            ButtonTrangChu.ForeColor = Color.Black;
            ButtonDatPhong.BackColor = Color.FromArgb(72, 145, 152);
            ButtonDatPhong.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachPhieuThue1(this, taiKhoan));
        }

        private void ButtonThanhToan_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonTrangChu.BackColor = Color.FromArgb(249, 165, 105);
            ButtonTrangChu.ForeColor = Color.Black;
            ButtonThanhToan.BackColor = Color.FromArgb(72, 145, 152);
            ButtonThanhToan.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachPhieuThue1(this, taiKhoan));
        }
        private void ButtonQLLD_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonTrangChu.BackColor = Color.FromArgb(249, 165, 105);
            ButtonTrangChu.ForeColor = Color.Black;
            ButtonQLLD.BackColor = Color.FromArgb(72, 145, 152);
            ButtonQLLD.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachPhieuThue1(this, taiKhoan));
        }
        private void ButtonCSKH_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonTrangChu.BackColor = Color.FromArgb(249, 165, 105);
            ButtonTrangChu.ForeColor = Color.Black;
            ButtonCSKH.BackColor = Color.FromArgb(72, 145, 152);
            ButtonCSKH.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachPhieuThue1(this, taiKhoan));
        }
        private void ButtonQLTK_Click(object sender, EventArgs e)
        {
            //Change color button on side bar
            SetAllButtonNormalColor();
            ButtonTrangChu.BackColor = Color.FromArgb(249, 165, 105);
            ButtonTrangChu.ForeColor = Color.Black;
            ButtonQLTK.BackColor = Color.FromArgb(72, 145, 152);
            ButtonQLTK.ForeColor = Color.White;
            //Open Child Form
            openChildForm(new FormDanhSachPhieuThue1(this, taiKhoan));
        }
        private void SetColorButtonTrangChu()
        {
            ButtonTrangChu.BackColor = Color.FromArgb(72, 145, 152);
            ButtonTrangChu.ForeColor = Color.White;
        }
        private void ButtonTrangChu_Click(object sender, EventArgs e)
        {
            //Change color button on side bar


            SetAllButtonNormalColor();
            ButtonTrangChu.BackColor = Color.FromArgb(72, 145, 152);
            ButtonTrangChu.ForeColor = Color.White;
            // form dành cho khách
            openChildForm(new FormTrangChu_CUS(this));


        }


        private void ctClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisplayTextMenu()
        {
            ButtonTrangChu.Text = "    Trang chủ";
            ButtonDatPhong.Text = "    Đặt phòng";
            ButtonThanhToan.Text = "    Thanh Toán";
            ButtonQLLD.Text = "    Quản lý lịch đặt";
            ButtonCSKH.Text = "    Chăm sóc khách hàng";
            ButtonQLTK.Text = "    Quản lý tài khoản";
            PanelUser.Visible = true;
        }
        private void NotDisplayTextMenu()
        {
            ButtonTrangChu.Text = "";
            ButtonDatPhong.Text = "";
            ButtonThanhToan.Text = "";
            ButtonQLLD.Text = "";
            ButtonCSKH.Text = "";
            ButtonQLTK.Text = "";

            PanelUser.Visible = false;
        }
        private bool isDisplayed = true;
        private void PictureBoxMenu_Click(object sender, EventArgs e)
        {
            if (isDisplayed == true)
            {
                isDisplayed = false;
                Size size = new Size(65, Sidebar.Height);
                NotDisplayTextMenu();
                Sidebar.Size = size;
            }
            else
            {
                isDisplayed = true;
                Size size = new Size(262, Sidebar.Height);
                DisplayTextMenu();
                Sidebar.Size = size;
            }
        }

        private void linkLabelDangXuat_Click(object sender, EventArgs e)
        {
            using (FormLogin formLogin = new FormLogin())
            {
                this.Hide();
                formLogin.ShowDialog();
                this.Close();
            }
        }

        private void PictureBoxMenu_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBoxMenu.BackColor = Color.FromArgb(58, 130, 137);
        }

        private void PictureBoxMenu_MouseLeave(object sender, EventArgs e)
        {
            PictureBoxMenu.BackColor = Color.Transparent;
        }

        private void FormMainCUS_Paint(object sender, PaintEventArgs e)
        {
            panelMainChildForm.BackColor = Color.FromArgb(255, 224, 192);
        }
    }
}
