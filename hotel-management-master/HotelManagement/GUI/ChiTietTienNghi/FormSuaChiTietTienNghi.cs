using ApplicationSettings;
using HotelManagement.CTControls;
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

namespace HotelManagement.GUI
{
    public partial class FormSuaChiTietTienNghi : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.White;

        CTTN cTTN;



        // Hàm khởi tạo nhận chi tiết tiện nghi, dùng để hiển thị dữ liệu cũ lên form
        public FormSuaChiTietTienNghi(CTTN cTTN)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.cTTN = cTTN;
            InitializeComponent();
            LoadcTTN();
        }

        // Nạp dữ liệu chi tiết tiện nghi từ đối tượng cTTN lên các ô nhập liệu
        void LoadcTTN()
        {
            try
            {
                this.ctTextBoxTenTienNghi.RemovePlaceholder();
                this.CTTextBoxSoLuong.RemovePlaceholder();
                this.ctTextBoxTenTienNghi.Texts = cTTN.TienNghi.TenTN;
                this.CTTextBoxSoLuong.Texts = cTTN.SL.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            colors.TopLeftColor = Color.FromArgb(128, 128, 128);
            colors.TopRightColor = Color.FromArgb(128, 128, 128);
            colors.BottomLeftColor = Color.FromArgb(128, 128, 128);
            colors.BottomRightColor = Color.FromArgb(128, 128, 128);
            return colors;
        }

        private void FormSuaChiTietTienNghi_Paint(object sender, PaintEventArgs e)
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

        private void FormSuaChiTietTienNghi_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormSuaChiTietTienNghi_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormSuaChiTietTienNghi_Activated(object sender, EventArgs e)
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

   
        private void FormSuaChiTietTienNghi_Load(object sender, EventArgs e)
        {
            this.ActiveControl = LabelSuaChiTietTienNghi;
        }

        // Sự kiện click nút Cập nhật, kiểm tra dữ liệu và lưu số lượng mới cho chi tiết tiện nghi
        private void CTButtonCapNhat_Click(object sender, EventArgs e)
        {
            string TenTN = ctTextBoxTenTienNghi.Texts;
            string SL = CTTextBoxSoLuong.Texts;
            string GhiChu = ctTextBoxGhiChu.Texts;

            // Kiểm tra nhập đầy đủ các thông tin bắt buộc
            if (TenTN == "" || SL == "")
            {
                CTMessageBox.Show("Vui lòng nhập đầy đủ thông tin tiện nghi.", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Cập nhật lại số lượng cho chi tiết tiện nghi
                this.cTTN.SL = int.Parse(this.CTTextBoxSoLuong.Texts);
                CTTN_DAO.Instance.UpdateOrInsert(cTTN);

                CTMessageBox.Show("Cập nhật thông tin thành công.", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CTTextBoxSoLuong__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxOnlyNum = sender as TextBox;
            textBoxOnlyNum.KeyPress += TextBoxOnlyNum_KeyPress;
        }

        private void TextBoxOnlyNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxOnlyNumber(e);
        }
    }
}
