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
using HotelManagement.DTO;
using HotelManagement.BUS;
using HotelManagement.CTControls;
using ApplicationSettings;
using HotelManagement.DAO;

namespace HotelManagement.GUI
{
    public partial class FormThemNhanVien : Form
    {
        private int borderRadius = 20;

        private int borderSize = 2;

        private Color borderColor = Color.White;

        public FormThemNhanVien()
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

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

        private void FormThemNhanVien_Paint(object sender, PaintEventArgs e)
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

        private void FormThemNhanVien_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormThemNhanVien_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormThemNhanVien_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void PanelBackground_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(PanelBackground, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }

        private void PanelBackground_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void CTButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThemNhanVien_Load(object sender, EventArgs e)
        {
            this.ActiveControl = LabelThemNhanVien;
        }

        private void CTTextBoxNhapHoTen__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxOnlyChu = sender as TextBox;
            textBoxOnlyChu.KeyPress += TextBoxOnlyChu_KeyPress;
        }

        private void TextBoxOnlyChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxNotNumber(e);
        }


        private void CTTextBoxLuong__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxMoney = sender as TextBox;
            textBoxMoney.KeyPress += TextBoxMoney_KeyPress;
            TextBoxType.Instance.CurrencyType(sender, e);
        }

        private void TextBoxMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxOnlyNumber(e);
        }


        private void ctTextBoxSDT__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxOnlyNum = sender as TextBox;
            textBoxOnlyNum.MaxLength = 10;
            textBoxOnlyNum.KeyPress += TextBoxOnlyNum_KeyPress;
        }

      
        private void ctTextBoxCCCD__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxOnlyNum = sender as TextBox;
            textBoxOnlyNum.MaxLength = 12;
            textBoxOnlyNum.KeyPress += TextBoxOnlyNum_KeyPress;
        }

  
        private void TextBoxOnlyNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxOnlyNumber(e);
        }

        // Xử lý thêm mới nhân viên: kiểm tra dữ liệu, validate trùng và gọi BUS để lưu
        private void CTButtonCapNhat_Click(object sender, EventArgs e)
        {
            string HoTen = CTTextBoxNhapHoTen.Texts;
            string ChucVu = cbChucVu.SelectedItem?.ToString() ?? "";
            string Luong = CTTextBoxLuong.Texts;
            string SDT = ctTextBoxSDT.Texts;
            string CCCD = CTTextBoxNhapCCCD.Texts;
            string DiaChi = CTTextBoxDiaChi.Texts;
            string email = ctTextBoxEmail.Texts;
            string GioiTinh = ComboBoxGioiTinh.SelectedItem?.ToString() ?? "";

            // Kiểm tra các trường bắt buộc không được để trống
            if (HoTen == "" || ChucVu == "" || Luong == "" || SDT == "" || CCCD == "" ||
                DiaChi == "" || email == "" || GioiTinh == "")
            {
                CTMessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên.", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Chuẩn hóa chuỗi lương và chuyển sang kiểu decimal
                string luongText = Luong.Replace(",", "").Replace(".", "").Trim();
                decimal luongValue = decimal.Parse(luongText);

                // Khởi tạo đối tượng nhân viên từ dữ liệu người dùng nhập
                NhanVien nhanVien = new NhanVien();
                nhanVien.MaNV = NhanVienBUS.Instance.GetMaNVNext();
                nhanVien.TenNV = HoTen;
                nhanVien.ChucVu = ChucVu;
                nhanVien.Luong = luongValue;
                nhanVien.SDT = SDT;
                nhanVien.CCCD = CCCD;
                nhanVien.DiaChi = DiaChi;
                nhanVien.Email = email;
                nhanVien.GioiTinh = GioiTinh.Trim();
                nhanVien.NgaySinh = ctDatePicker1.Value;

                // Lấy danh sách nhân viên hiện tại để kiểm tra trùng CCCD và SĐT
                List<NhanVien> nhanViens = NhanVienDAO.Instance.GetNhanViens();

                if (nhanViens.Any(p => p.CCCD == CCCD))
                {
                    CTMessageBox.Show("CCCD đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (nhanViens.Any(p => p.SDT == SDT))
                {
                    CTMessageBox.Show("SĐT đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gọi tầng nghiệp vụ để thêm mới nhân viên (bao gồm kiểm tra điều kiện nghiệp vụ)
                NhanVienBUS.Instance.UpdateOrInsert(nhanVien);

                CTMessageBox.Show("Thêm nhân viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi chi tiết nếu có vấn đề trong quá trình thêm nhân viên
                CTMessageBox.Show(ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
