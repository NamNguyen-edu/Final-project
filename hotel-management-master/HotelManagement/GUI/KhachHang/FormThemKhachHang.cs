using HotelManagement.BUS;
using HotelManagement.DAO;
using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationSettings;
using HotelManagement.CTControls;

namespace HotelManagement.GUI
{
    public partial class FormThemKhachHang : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.White;

        // Tham chiếu đến form danh sách khách hàng để reload dữ liệu sau khi thêm
        FormDanhSachKhachHang formDanhSachKhachHang;

        // Hàm khởi tạo mặc định, dùng khi mở form độc lập
        public FormThemKhachHang()
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            InitializeComponent();
        }

        // Hàm khởi tạo nhận form danh sách khách hàng, phục vụ việc cập nhật lại grid sau khi thêm
        public FormThemKhachHang(FormDanhSachKhachHang formDanhSachKhachHang)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.formDanhSachKhachHang = formDanhSachKhachHang;
            InitializeComponent();
        }

        // Khai báo hàm WinAPI hỗ trợ kéo form không viền
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        // Khai báo hàm WinAPI gửi thông điệp đến Windows (dùng để di chuyển form)
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Ghi đè CreateParams để form không viền vẫn thu nhỏ được từ taskbar
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // Cho phép minimize form không viền từ taskbar
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
        private FormBoundsColors GetSameDark()
        {
            FormBoundsColors colors = new FormBoundsColors();
            colors.TopLeftColor = Color.FromArgb(67, 73, 73);
            colors.TopRightColor = Color.FromArgb(67, 73, 73);
            colors.BottomLeftColor = Color.FromArgb(67, 73, 73);
            colors.BottomRightColor = Color.FromArgb(67, 73, 73);
            return colors;
        }

        private void FormThemKhachHang_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;

            var fbColors = GetSameDark();


            DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);

            Rectangle rectTopRight = new Rectangle(mWidht, rectForm.Y, mWidht, mHeight);
            DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);

            Rectangle rectBottomLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidht, mHeight);
            DrawPath(rectBottomLeft, e.Graphics, fbColors.BottomLeftColor);

            Rectangle rectBottomRight = new Rectangle(mWidht, rectForm.Y + mHeight, mWidht, mHeight);
            DrawPath(rectBottomRight, e.Graphics, fbColors.BottomRightColor);


            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }

        // Sự kiện Resize của form, yêu cầu vẽ lại giao diện
        private void FormThemKhachHang_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        // Sự kiện thay đổi kích thước form, yêu cầu vẽ lại giao diện
        private void FormThemKhachHang_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        // Sự kiện form được kích hoạt, yêu cầu vẽ lại giao diện
        private void FormThemKhachHang_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }


        private void PanelBackground_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(PanelBackground, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }

        // Sự kiện nhấn chuột trên PanelBackground, cho phép kéo di chuyển form
        private void PanelBackground_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Sự kiện click nút Thoát, đóng form thêm khách hàng
        private void CTButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sự kiện click nút Cập nhật, kiểm tra dữ liệu và thêm khách hàng mới vào hệ thống
        private void CTButtonCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường bắt buộc đã nhập hay chưa
            if (this.ctTextBoxName.Texts != "" &&
                this.ctTextBoxQuocTich.Texts != "" &&
                this.ctTextBoxCMND.Texts != "" &&
                this.ctTextBoxEmail.Texts != "" &&
                this.comboBoxGioiTinh.Texts != "  Giới tính")
            {
                // Kiểm tra độ dài CCCD/Passport
                if (ctTextBoxCMND.Texts.Length != 12 && ctTextBoxCMND.Texts.Length != 7)
                {
                    CTMessageBox.Show("Vui lòng nhập đầy đủ số CCCD/Passport.", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra độ dài số điện thoại
                if (ctTextBoxSDT.Texts.Length != 10)
                {
                    CTMessageBox.Show("Vui lòng nhập đầy đủ SĐT.", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra định dạng email cơ bản
                if (!ctTextBoxEmail.Texts.Contains("@") || !ctTextBoxEmail.Texts.Contains("."))
                {
                    CTMessageBox.Show("Email không hợp lệ!", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Kiểm tra trùng CCCD/Passport và Email trong danh sách khách hàng
                List<KhachHang> khachHangs = KhachHangBUS.Instance.GetKhachHangs();
                foreach (KhachHang khachHang in khachHangs)
                {
                    if (khachHang.CCCD_Passport == this.ctTextBoxCMND.Texts)
                    {
                        CTMessageBox.Show("Đã tồn tại số CCCD/Passport này trong danh sách khách hàng! Vui lòng kiểm tra lại thông tin.", "Thông báo",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (khachHang.Email == this.ctTextBoxEmail.Texts)
                    {
                        CTMessageBox.Show("Email này đã tồn tại trong danh sách khách hàng!",
                                          "Lỗi",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                try
                {
                    // Khởi tạo và gán thông tin khách hàng mới
                    KhachHang khachHang1 = new KhachHang();
                    khachHang1.MaKH = KhachHangBUS.Instance.GetMaKHNext();
                    khachHang1.TenKH = this.ctTextBoxName.Texts;
                    khachHang1.QuocTich = this.ctTextBoxQuocTich.Texts;
                    khachHang1.CCCD_Passport = this.ctTextBoxCMND.Texts;
                    khachHang1.SDT = this.ctTextBoxSDT.Texts;
                    khachHang1.Email = this.ctTextBoxEmail.Texts;
                    khachHang1.GioiTinh = this.comboBoxGioiTinh.Texts.Trim(' ');

                    // Ghi dữ liệu khách hàng vào CSDL (thêm hoặc cập nhật)
                    KhachHangBUS.Instance.UpdateOrAdd(khachHang1);

                    // Reload lại danh sách khách hàng trên form danh sách
                    this.formDanhSachKhachHang.LoadAllGrid();

                    CTMessageBox.Show("Thêm thông tin thành công.", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                CTMessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện text changed của ô tên khách hàng, gắn sự kiện KeyPress để chặn ký tự số
        private void ctTextBoxName__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxName = sender as TextBox;
            textBoxName.KeyPress += TextBoxName_KeyPress;
        }

        // Xử lý KeyPress cho ô tên khách hàng, chỉ cho phép nhập chữ, không cho nhập số
        private void TextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxNotNumber(e);
        }

        // Sự kiện Load của form, đặt focus ban đầu vào label tiêu đề
        private void FormThemKhachHang_Load(object sender, EventArgs e)
        {
            this.ActiveControl = labelThemKhachHang;
        }

        // Sự kiện text changed của ô CCCD/Passport, giới hạn độ dài và gắn KeyPress chỉ cho nhập số
        private void ctTextBoxCMND__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxCCCD = sender as TextBox;
            textBoxCCCD.MaxLength = 12;
            textBoxCCCD.KeyPress += TextBoxCCCD_KeyPress;
        }

        // Xử lý KeyPress cho ô CCCD/Passport, chỉ cho phép nhập ký tự số
        private void TextBoxCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxOnlyNumber(e);
        }

        // Sự kiện text changed của ô số điện thoại, giới hạn độ dài và gắn KeyPress chỉ cho nhập số
        private void ctTextBoxSDT__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxSDT = sender as TextBox;
            textBoxSDT.MaxLength = 10;
            textBoxSDT.KeyPress += TextBoxSDT_KeyPress;
        }

        // Xử lý KeyPress cho ô số điện thoại, chỉ cho phép nhập ký tự số
        private void TextBoxSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxOnlyNumber(e);
        }

        // Sự kiện text changed của ô quốc tịch, gắn KeyPress để chặn ký tự số
        private void ctTextBoxQuocTich__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxQuocTich = sender as TextBox;
            textBoxQuocTich.KeyPress += TextBoxQuocTich_KeyPress;
        }

        // Xử lý KeyPress cho ô quốc tịch, chỉ cho phép nhập chữ, không cho phép nhập số
        private void TextBoxQuocTich_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxNotNumber(e);
        }
    }
}
