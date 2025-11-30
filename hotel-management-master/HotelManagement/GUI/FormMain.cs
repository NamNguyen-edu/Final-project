using ApplicationSettings;
using HotelManagement.CTControls;
using HotelManagement.DTO;
using HotelManagement.GUI;
using HotelManagement.GUI.ThongKe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class FormMain : Form
    {
        private bool _isKhachMode = false;

        int LoaiTK;
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(72, 145, 153);
        private TaiKhoan taiKhoan;
        private bool isMusicPlaying = false; 
        private SoundPlayer player;          

       
        public FormMain(TaiKhoan taiKhoan)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.taiKhoan = taiKhoan;
            this.LoaiTK = taiKhoan.CapDoQuyen;
            InitializeComponent();
            if (this.LoaiTK == 1)
                LoadFormForNhanVien();
            else if (this.LoaiTK == 2)
                LoadFormQuanLy();
            else if (this.LoaiTK == 3)
                LoadFormForAdmin();
        }

        public TaiKhoan TaiKhoanDangNhap
        {
            get { return taiKhoan; }
        }

        private void LoadFormForAdmin()
        {
            _isKhachMode = false;
            this.ButtonTrangChu.Hide();
        }

        // Cấu hình giao diện và menu dành cho tài khoản Nhân viên
        private void LoadFormForNhanVien()
        {
            _isKhachMode = false;
            this.ButtonDanhSachTienNghi.Hide();
            this.ButtonDanhSachTaiKhoan.Hide();
            this.ButtonDanhSachNhanVien.Hide();
            this.ButtonThongKe.Hide();
            this.ButtonLoaiPhong.Hide();
        }

        private void LoadFormQuanLy()
        {
            _isKhachMode = false;
            this.ButtonDanhSachTaiKhoan.Hide();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; 
                return cp;
            }
        }

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
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(form.ClientRectangle);
                    if (borderSize >= 1)
                    {
                        graph.DrawRectangle(penBorder, form.ClientRectangle);
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

                rectBmp.X = this.Bounds.X - 1;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopLeftColor = bmp.GetPixel(0, 0);

                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopRightColor = bmp.GetPixel(0, 0);

                rectBmp.X = this.Bounds.X;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0);

                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomRightColor = bmp.GetPixel(0, 0);
            }
            return fbColor;
        }


        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;


            var fbColors = GetFormBoundsColors();



            DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);

            Rectangle rectTopRight = new Rectangle(mWidht, rectForm.Y, mWidht, mHeight);
            DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);

            Rectangle rectBottomLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidht, mHeight);
            DrawPath(rectBottomLeft, e.Graphics, fbColors.BottomLeftColor);

            Rectangle rectBottomRight = new Rectangle(mWidht, rectForm.Y + mHeight, mWidht, mHeight);
            DrawPath(rectBottomRight, e.Graphics, fbColors.BottomRightColor);


            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.Padding = new Padding(0);
            else
                this.Padding = new Padding(borderSize);

            this.Invalidate();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void PanelBackground_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(PanelBackground, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }

        // Sự kiện Load của form, thiết lập giao diện ban đầu và mở form con tương ứng với quyền
        private void FormMain_Load(object sender, EventArgs e)
        {
            int time = 300;
            WinAPI.AnimateWindow(this.Handle, time, WinAPI.CENTER);

            this.LabelTenNguoiDung.Text = taiKhoan.NhanVien.TenNV;

            if (LoaiTK == 1) // Nhân viên
            {
                ButtonTrangChu.Show();
                SetColorButtonTrangChu();
                openChildForm(new FormTC(this));
            }
            else
            {
                ButtonTrangChu.Hide();

                if (LoaiTK == 2) // Quản lý
                {
                    openChildForm(new FormSoDoPhong(this, taiKhoan));
                }
                else if (LoaiTK == 3) // Admin
                {
                    openChildForm(new FormSoDoPhong(this, taiKhoan));
                }
            }

            PlayMusic();
        }

        private void PlayMusic()
        {
            if (Properties.Resources.audiotrangchu != null)
            {
                player = new SoundPlayer(Properties.Resources.audiotrangchu);
                player.PlayLooping();
                isMusicPlaying = true;
            }
            else
            {
                MessageBox.Show("Không tìm thấy file âm thanh trong Resources!");
            }
        }

        private Form activeForm = null;

        // Mở form con trong panelMainChildForm, đảm bảo chỉ có một form con hiển thị
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

        private void ctMaximize1_Click(object sender, EventArgs e) =>
            this.WindowState = (this.WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;

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

         private void SetColorButtonTrangChu()
        {
            ButtonTrangChu.BackColor = Color.FromArgb(182, 103, 36);
            ButtonTrangChu.ForeColor = Color.White;
        }

         private void SetAllButtonNormalColor()
        {
            Color normalColor = Color.FromArgb(182, 103, 36);
            ButtonSoDoPhong.BackColor = normalColor;
            ButtonDanhSachDatPhong.BackColor = normalColor;
            ButtonDanhSachHoaDon.BackColor = normalColor;
            ButtonDanhSachKhachHang.BackColor = normalColor;
            ButtonPhong.BackColor = normalColor;
            ButtonLoaiPhong.BackColor = normalColor;
            ButtonDanhSachDichVu.BackColor = normalColor;
            ButtonDanhSachTienNghi.BackColor = normalColor;
            ButtonDanhSachTaiKhoan.BackColor = normalColor;
            ButtonDanhSachNhanVien.BackColor = normalColor;
            ButtonThongKe.BackColor = normalColor;
        }

        public static Color Select = Color.FromArgb(221, 173, 127);

         private void ButtonDanhSachDatPhong_Click(object sender, EventArgs e)
        {
             SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonDanhSachDatPhong.BackColor = Select;
            ButtonDanhSachDatPhong.ForeColor = Color.White;

             openChildForm(new FormDanhSachPhieuThue(this, taiKhoan));
        }


        private void ButtonSoDoPhong_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonSoDoPhong.BackColor = Color.FromArgb(233, 117, 32);
            ButtonSoDoPhong.ForeColor = Color.White;

            openChildForm(new FormSoDoPhong(this, taiKhoan));
        }


        private void ButtonDanhSachHoaDon_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonDanhSachHoaDon.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachHoaDon.ForeColor = Color.White;

            openChildForm(new FormDanhSachHoaDon(this));
        }


        private void ButtonTrangChu_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonTrangChu.BackColor = Color.FromArgb(233, 117, 32);
            ButtonTrangChu.ForeColor = Color.White;

            openChildForm(new FormTC(this));
        }


        private void ButtonDanhSachKhachHang_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonDanhSachKhachHang.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachKhachHang.ForeColor = Color.White;

            openChildForm(new FormDanhSachKhachHang(this, this.taiKhoan));
        }

        private void ButtonPhong_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonPhong.BackColor = Color.FromArgb(233, 117, 32);
            ButtonPhong.ForeColor = Color.White;

            openChildForm(new FormDanhSachPhong(this, this.taiKhoan));
        }


        private void ButtonLoaiPhong_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonLoaiPhong.BackColor = Color.FromArgb(233, 117, 32);
            ButtonLoaiPhong.ForeColor = Color.White;

            openChildForm(new FormDanhSachLoaiPhong(this, this.taiKhoan));
        }


        private void ButtonDanhSachDichVu_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonDanhSachDichVu.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachDichVu.ForeColor = Color.White;

            openChildForm(new FormDanhSachDichVu(this, this.taiKhoan));
        }


        private void ButtonDanhSachTienNghi_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonDanhSachTienNghi.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachTienNghi.ForeColor = Color.White;

            openChildForm(new FormDanhSachTienNghi(this, this.taiKhoan));
        }


        private void ButtonDanhSachTaiKhoan_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonDanhSachTaiKhoan.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachTaiKhoan.ForeColor = Color.White;

            openChildForm(new FormDanhSachTaiKhoan(this));
        }


        private void ButtonDanhSachNhanVien_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonDanhSachNhanVien.BackColor = Color.FromArgb(233, 117, 32);
            ButtonDanhSachNhanVien.ForeColor = Color.White;

            openChildForm(new FormDanhSachNhanVien(this, this.taiKhoan));
        }

        // Sự kiện click nút đóng, đóng form chính của ứng dụng
        private void ctClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ButtonThongKe_Click(object sender, EventArgs e)
        {

            SetAllButtonNormalColor();
            SetColorButtonTrangChu();
            ButtonThongKe.BackColor = Color.FromArgb(233, 117, 32);


            openChildForm(new HotelManagement.GUI.ThongKe.FormThongKe(this));
        }

        // Hiển thị chữ cho menu bên trái, kích hoạt panel thông tin người dùng
        private void DisplayTextMenu()
        {
            ButtonTrangChu.Text = "    Trang chủ";
            ButtonSoDoPhong.Text = "    Sơ đồ phòng";
            ButtonDanhSachDatPhong.Text = "    Danh sách đặt phòng";
            ButtonDanhSachHoaDon.Text = "    Danh sách hóa đơn";
            ButtonDanhSachKhachHang.Text = "    Danh sách khách hàng";
            ButtonPhong.Text = "    Phòng";
            ButtonLoaiPhong.Text = "    Loại phòng";
            ButtonDanhSachDichVu.Text = "    Danh sách dịch vụ";
            ButtonDanhSachTienNghi.Text = "    Danh sách tiện nghi";
            ButtonDanhSachTaiKhoan.Text = "    Danh sách tài khoản";
            ButtonDanhSachNhanVien.Text = "    Danh sách nhân viên";
            ButtonThongKe.Text = "    Thống kê";
            PanelUser.Visible = true;
        }

        // Ẩn chữ trên menu bên trái, ẩn panel thông tin người dùng
        private void NotDisplayTextMenu()
        {
            ButtonTrangChu.Text = "";
            ButtonSoDoPhong.Text = "";
            ButtonDanhSachDatPhong.Text = "";
            ButtonDanhSachHoaDon.Text = "";
            ButtonDanhSachKhachHang.Text = "";
            ButtonPhong.Text = "";
            ButtonLoaiPhong.Text = "";
            ButtonDanhSachDichVu.Text = "";
            ButtonDanhSachTienNghi.Text = "";
            ButtonDanhSachTaiKhoan.Text = "";
            ButtonDanhSachNhanVien.Text = "";
            ButtonThongKe.Text = "";
            PanelUser.Visible = false;
        }

        private bool isDisplayed = true;

        // Sự kiện click icon menu, thu gọn hoặc mở rộng thanh Sidebar
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

        // Sự kiện click link Đăng xuất, quay lại form đăng nhập và đóng form chính
        private void linkLabelDangXuat_Click(object sender, EventArgs e)
        {
            using (FormLogin formLogin = new FormLogin())
            {
                this.Hide();
                formLogin.ShowDialog();
                this.Close();
            }
        }

        // Sự kiện di chuyển chuột qua icon menu, đổi màu nền để tạo hiệu ứng hover
        private void PictureBoxMenu_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBoxMenu.BackColor = Color.FromArgb(58, 130, 137);
        }

        // Sự kiện rời chuột khỏi icon menu, trả về màu nền trong suốt
        private void PictureBoxMenu_MouseLeave(object sender, EventArgs e)
        {
            PictureBoxMenu.BackColor = Color.Transparent;
        }
    }
}