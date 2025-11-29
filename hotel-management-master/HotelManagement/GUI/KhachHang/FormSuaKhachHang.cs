using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ApplicationSettings;
using HotelManagement.BUS;
using HotelManagement.CTControls;
using HotelManagement.DTO;

namespace HotelManagement.GUI
{
    public partial class FormSuaKhachHang : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.White;

        // Đối tượng khách hàng cần chỉnh sửa
        KhachHang khachHang;

        // Tham chiếu đến form danh sách khách hàng để reload dữ liệu sau khi cập nhật
        FormDanhSachKhachHang formDanhSachKhachHang;

        // Hàm khởi tạo mặc định, dùng khi mở form độc lập
        public FormSuaKhachHang()
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            InitializeComponent();
        }

        // Hàm khởi tạo nhận khách hàng và form danh sách, dùng để hiển thị thông tin cũ và cập nhật lại danh sách
        public FormSuaKhachHang(KhachHang khachHang, FormDanhSachKhachHang formDanhSachKhachHang)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.khachHang = khachHang;
            this.formDanhSachKhachHang = formDanhSachKhachHang;
            InitializeComponent();
            LoadForm();
        }

        // Nạp dữ liệu khách hàng lên các ô nhập liệu (hiển thị thông tin cũ để chỉnh sửa)
        private void LoadForm()
        {
            this.ctTextBoxName.RemovePlaceholder();
            this.ctTextBoxQuocTich.RemovePlaceholder();
            this.ctTextBoxCCCD.RemovePlaceholder();
            this.ctTextBoxSDT.RemovePlaceholder();
            this.ctTextBoxEmail.RemovePlaceholder();

            this.ctTextBoxName.Texts = this.khachHang.TenKH;
            this.ctTextBoxQuocTich.Texts = this.khachHang.QuocTich;
            this.ctTextBoxCCCD.Texts = this.khachHang.CCCD_Passport;
            this.comboBoxGioiTinh.Texts = "  " + this.khachHang.GioiTinh;
            this.ctTextBoxSDT.Texts = this.khachHang.SDT;
            this.ctTextBoxEmail.Texts = this.khachHang.Email;
        }

        // Khai báo hàm WinAPI hỗ trợ kéo form không viền
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        // Khai báo hàm WinAPI gửi thông điệp để di chuyển form
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Ghi đè CreateParams để form không viền vẫn có thể thu nhỏ từ taskbar
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

        private void FormSuaKhachHang_Paint(object sender, PaintEventArgs e)
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
        private void FormSuaKhachHang_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        // Sự kiện thay đổi kích thước form, yêu cầu vẽ lại giao diện
        private void FormSuaKhachHang_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        // Sự kiện form được kích hoạt, yêu cầu vẽ lại giao diện
        private void FormSuaKhachHang_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        // Sự kiện Paint của panel nền, áp dụng bo góc và viền cho PanelBackground
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

        // Sự kiện nhấn chuột trên PanelTop, cho phép kéo di chuyển form
        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Sự kiện click nút Thoát, đóng form sửa khách hàng
        private void CTButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sự kiện text changed của ô tên (ctTextBox1), gắn KeyPress để chặn nhập số
        private void ctTextBox1__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxName = sender as TextBox;
            textBoxName.KeyPress += TextBoxName_KeyPress;
        }

        // Xử lý KeyPress cho ô tên khách hàng, chỉ cho phép nhập chữ, không cho nhập số
        private void TextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxNotNumber(e);
        }

        // Sự kiện text changed của ô CCCD/Passport (ctTextBox2), giới hạn độ dài và gắn KeyPress chỉ cho nhập số
        private void ctTextBox2__TextChanged(object sender, EventArgs e)
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

        // Sự kiện click nút Cập nhật, kiểm tra dữ liệu và ghi lại thông tin khách hàng đã chỉnh sửa
        private void CTButtonCapNhat_Click(object sender, EventArgs e)
        {
            if (this.ctTextBoxName.Texts != "" &&
                this.ctTextBoxQuocTich.Texts != "" &&
                this.ctTextBoxCCCD.Texts != "" &&
                this.comboBoxGioiTinh.Texts != "  Giới tính" &&
                this.ctTextBoxEmail.Texts != "")
            {
                // Kiểm tra độ dài CCCD/Passport
                if (ctTextBoxCCCD.Texts.Length != 12 && ctTextBoxCCCD.Texts.Length != 7)
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

                // Kiểm tra định dạng email hợp lệ
                if (!IsValidEmail(ctTextBoxEmail.Texts))
                {
                    CTMessageBox.Show("Email không hợp lệ! Vui lòng nhập đúng định dạng (ví dụ: abc@gmail.com).",
                                      "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra trùng CCCD/Passport và Email với các khách hàng khác
                List<KhachHang> khachHangs = KhachHangBUS.Instance.GetKhachHangs();
                foreach (KhachHang khachHang in khachHangs)
                {
                    if (khachHang.CCCD_Passport == this.ctTextBoxCCCD.Texts &&
                        this.khachHang.CCCD_Passport != this.ctTextBoxCCCD.Texts)
                    {
                        CTMessageBox.Show("Đã tồn tại số CCCD/Passport này trong danh sách khách hàng! Vui lòng kiểm tra lại thông tin.",
                                          "Thông báo",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (khachHang.Email == this.ctTextBoxEmail.Texts &&
                        this.khachHang.Email != this.ctTextBoxEmail.Texts)
                    {
                        CTMessageBox.Show("Email này đã tồn tại trong danh sách khách hàng!",
                                          "Lỗi",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                try
                {
                    // Gán lại dữ liệu mới cho đối tượng kháchHang
                    khachHang.TenKH = this.ctTextBoxName.Texts;
                    khachHang.QuocTich = this.ctTextBoxQuocTich.Texts;
                    khachHang.CCCD_Passport = this.ctTextBoxCCCD.Texts;
                    khachHang.SDT = this.ctTextBoxSDT.Texts;
                    khachHang.GioiTinh = this.comboBoxGioiTinh.Texts.Trim(' ');
                    khachHang.Email = this.ctTextBoxEmail.Texts;

                    // Cập nhật thông tin khách hàng vào CSDL
                    KhachHangBUS.Instance.UpdateOrAdd(khachHang);

                    CTMessageBox.Show("Cập nhật thông tin thành công.", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload lại danh sách khách hàng và đóng form
                    this.formDanhSachKhachHang.LoadAllGrid();
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

        // Sự kiện text changed của ô quốc tịch, gắn KeyPress để chặn nhập số
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

        // Sự kiện Load của form, đặt focus ban đầu vào label tiêu đề sửa khách hàng
        private void FormSuaKhachHang_Load(object sender, EventArgs e)
        {
            this.ActiveControl = labelSuaKhachHang;
        }

        // Kiểm tra định dạng email hợp lệ bằng System.Net.Mail
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
