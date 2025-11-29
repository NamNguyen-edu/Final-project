using HotelManagement.BUS;
using HotelManagement.CTControls;
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

namespace HotelManagement.GUI
{
    public partial class FormSuaTaiKhoan : Form
    {
        // Khởi tạo các biến ban đầu
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.White;
        private TaiKhoan taiKhoan;
        // Hàm khởi tạo Form
        public FormSuaTaiKhoan(TaiKhoan taiKhoan)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.taiKhoan = taiKhoan;
            InitializeComponent();
            LoadForm();
        }
        #region  Hiển thị Form 
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

        // Hàm xử lý hiển thị 
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
        // Hàm xử lý sự kiện
        private void FormSuaTaiKhoan_Paint(object sender, PaintEventArgs e)
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
        private void FormSuaTaiKhoan_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormSuaTaiKhoan_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormSuaTaiKhoan_Activated(object sender, EventArgs e)
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

        private void FormSuaTaiKhoan_Load(object sender, EventArgs e)
        {
            this.ActiveControl = LabelSuaTaiKhoan;
            CTTextBoxNhapMatKhau.PasswordChar = true;
        }
        #endregion

        // Hiển thị thông tin chi tiết tài khoản 
        private void LoadForm()
        {
            ctTextBoxMaNV.RemovePlaceholder();
            CTTextBoxNhapTenTaiKhoan.RemovePlaceholder();
            CTTextBoxNhapMatKhau.RemovePlaceholder();
            ctTextBoxMaNV.Texts = taiKhoan.MaNV;
            CTTextBoxNhapTenTaiKhoan.Texts = taiKhoan.TenTK;
            CTTextBoxNhapMatKhau.Texts = taiKhoan.Password;
            if (taiKhoan.CapDoQuyen == 3)
            {
                comboBoxCapDoQuyen.Texts = "  Admin";
            }
            else if (taiKhoan.CapDoQuyen == 2)
            {
                comboBoxCapDoQuyen.Texts = "  Quản lý";
            }
            else
                comboBoxCapDoQuyen.Texts = "  Lễ tân";
        }
        // Xử lý việc sửa tài khoản
        private void CTButtonCapNhat_Click(object sender, EventArgs e)
        {
            string MaNV = ctTextBoxMaNV.Texts;
            string TenTK = CTTextBoxNhapTenTaiKhoan.Texts;
            string MK = CTTextBoxNhapMatKhau.Texts;
            string CapDoQuyen = comboBoxCapDoQuyen.Texts;
            if (MaNV == "" || TenTK == "" || MK == "" || CapDoQuyen == "  Cấp độ quyền")
            {
                CTMessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                taiKhoan.Password = MK;
                if (CapDoQuyen == "  Admin")
                    taiKhoan.CapDoQuyen = 3;
                else if (CapDoQuyen == "  Quản lý")
                    taiKhoan.CapDoQuyen = 2;
                else
                    taiKhoan.CapDoQuyen = 1;
                TaiKhoanBUS.Instance.AddOrUpdateTK(taiKhoan);

                CTMessageBox.Show("Cập nhật thông tin thành công.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                
            }
        }
        // Xử lý việc nhập mật khẩu
        private void CTTextBoxNhapMatKhau__TextChanged(object sender, EventArgs e)
        {
            if (CTTextBoxNhapMatKhau.Texts.Length > 0 && ctEyePassword1.IsShow == false)
            {
                CTTextBoxNhapMatKhau.PasswordChar = true;
            }
            /*TextBox textBoxPasswordConfirm = sender as TextBox;
            if (textBoxPasswordConfirm.Focused == false)
                textBoxPasswordConfirm.UseSystemPasswordChar = false;
            else
                textBoxPasswordConfirm.UseSystemPasswordChar = true;*/
        }
        // Hiển thị mật khẩu
        private void ctEyePassword1_Click(object sender, EventArgs e)
        {
            if (ctEyePassword1.IsShow == false)
            {
                ctEyePassword1.IsShow = true;
                CTTextBoxNhapMatKhau.PasswordChar = false;
                ctEyePassword1.BackgroundImage = Properties.Resources.hide;
            }
            else
            {
                ctEyePassword1.IsShow = false;
                if (CTTextBoxNhapMatKhau.Texts != "")
                {
                    CTTextBoxNhapMatKhau.PasswordChar = true;
                }
                ctEyePassword1.BackgroundImage = Properties.Resources.show;
            }
        }
    }
}
