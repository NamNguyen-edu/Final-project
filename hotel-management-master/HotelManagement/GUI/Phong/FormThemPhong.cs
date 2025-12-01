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
    public partial class FormThemPhong : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.White;
        public FormThemPhong()
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            InitializeComponent();
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
            colors.TopLeftColor = Color.FromArgb(67, 73, 73);
            colors.TopRightColor = Color.FromArgb(67, 73, 73);
            colors.BottomLeftColor = Color.FromArgb(67, 73, 73);
            colors.BottomRightColor = Color.FromArgb(67, 73, 73);
            return colors;
        }
        private void FormThemPhong_Paint(object sender, PaintEventArgs e)
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
        private void FormThemPhong_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void FormThemPhong_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void FormThemPhong_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void PanelBackground_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void PanelBackground_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ControlRegionAndBorder(PanelBackground, borderRadius - (borderSize / 2), g, borderColor);
        }
        private void CTButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormThemPhong_Load(object sender, EventArgs e)
        {
            this.ActiveControl = LabelThemPhong;
            comboBoxTang.Items.Clear();
            comboBoxTang.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
        }
        // Lưu thông tin phòng và thêm mới phòng vào CSDL
        private void CTButtonCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(comboBoxTang.SelectedItem?.ToString(), out int tang))
                {
                    CTMessageBox.Show("Vui lòng chọn tầng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string MaPH = PhongBUS.Instance.GenerateNextRoomCode(tang);
                string TinhTrang = comboBoxTinhTrangPhong.Texts;
                string DonDep = comboBoxDonDep.Texts;
                string LoaiPhong = comboBoxLoaiPhong.Texts;
                string GhiChu = ctTextBoxGhiChu.Texts;

                if (TinhTrang == "Tình trạng phòng" || DonDep == "Tình trạng dọn dẹp" || LoaiPhong == "Loại phòng" || MaPH == "")
                {
                    CTMessageBox.Show("Vui lòng nhập đầy đủ thông tin phòng.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Phong phong1 = new Phong();
                phong1.MaPH = MaPH;
                phong1.Tang = tang;
                phong1.DaXoa = false;
                phong1.GhiChu = GhiChu;
                if (DonDep == "Đã dọn dẹp")
                    phong1.TTDD = "Đã dọn dẹp";
                else
                    phong1.TTDD = "Chưa dọn dẹp";
                if (TinhTrang == "Bình thường")
                    phong1.TTPH = "Bình thường";
                else
                    phong1.TTPH = "Đang sửa chữa";
                if (LoaiPhong == "Thường đơn")
                    phong1.MaLPH = "NOR01";
                else if (LoaiPhong == "Thường đôi")
                    phong1.MaLPH = "NOR02";
                else if (LoaiPhong == "VIP đơn")
                    phong1.MaLPH = "VIP01";
                else
                    phong1.MaLPH = "VIP02";
                PhongBUS.Instance.UpdateOrAdd(phong1);

                CTMessageBox.Show($"Thêm phòng {MaPH} (tầng {tang}) thành công.", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                CTMessageBox.Show("Đã xảy ra lỗi khi thêm phòng:\n" + ex.Message,
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
