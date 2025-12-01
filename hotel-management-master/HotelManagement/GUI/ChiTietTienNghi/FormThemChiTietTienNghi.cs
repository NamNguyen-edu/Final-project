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
using HotelManagement.BUS;
using HotelManagement.DAO;
using ApplicationSettings;

namespace HotelManagement.GUI
{
    public partial class FormThemChiTietTienNghi : Form
    {
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.White;

        LoaiPhong loaiPhong;

        public FormThemChiTietTienNghi()
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            InitializeComponent();
        }

        // Hàm khởi tạo nhận mã loại phòng, dùng để tải thông tin loại phòng và danh sách tiện nghi phù hợp
        public FormThemChiTietTienNghi(string MaLPH)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.loaiPhong = LoaiPhongBUS.Instance.getLoaiPhong(MaLPH);
            InitializeComponent();
            LoadForm();
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

        #region Draw Form

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

        private void FormThemChiTietTienNghi_Paint(object sender, PaintEventArgs e)
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

        private void FormThemChiTietTienNghi_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormThemChiTietTienNghi_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormThemChiTietTienNghi_Activated(object sender, EventArgs e)
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

        private void FormThemChiTietTienNghi_Load(object sender, EventArgs e)
        {
            this.ActiveControl = LabelThemChiTietTienNghi;
        }

        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        // Nạp danh sách tiện nghi có thể thêm cho loại phòng (lọc bỏ các tiện nghi đã tồn tại)
        private void LoadForm()
        {
            try
            {
                this.ComboBoxTenTienNghi.Items.Clear();

                List<TienNghi> tienNghis = TienNghiBUS.Instance.GetTienNghis();

                List<CTTN> cTTNs = CTTN_BUS.Instance.GetCTTNs()
                    .Where(p => p.MaLPH == loaiPhong.MaLPH)
                    .ToList();

                // Chỉ thêm vào combobox các tiện nghi chưa tồn tại trong loại phòng
                foreach (TienNghi tienNghi in tienNghis)
                {
                    if (cTTNs.Where(p => p.MaTN == tienNghi.MaTN).Any())
                    {
                        continue;
                    }
                    this.ComboBoxTenTienNghi.Items.Add(tienNghi.TenTN);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sự kiện click nút Thêm, kiểm tra dữ liệu và lưu chi tiết tiện nghi mới cho loại phòng
        private void ButtonThem_Click(object sender, EventArgs e)
        {
            string TenTN = ComboBoxTenTienNghi.Texts;
            string SL = CTTextBoxSoLuong.Texts;
            string GhiChu = ctTextBoxGhiChu.Texts;

            // Kiểm tra nhập đầy đủ thông tin bắt buộc
            if (TenTN == "  Tên tiện nghi" || SL == "" || GhiChu == "")
            {
                CTMessageBox.Show("Vui lòng nhập đầy đủ thông tin tiện nghi.", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Khởi tạo chi tiết tiện nghi mới cho loại phòng
                CTTN cTTN = new CTTN();
                cTTN.MaTN = TienNghiBUS.Instance.GetTienNghis()
                                .Where(p => p.TenTN == this.ComboBoxTenTienNghi.Texts)
                                .Single()
                                .MaTN;
                cTTN.MaLPH = loaiPhong.MaLPH;
                cTTN.SL = int.Parse(CTTextBoxSoLuong.Texts);

                CTTN_BUS.Instance.UpdateOrInsert(cTTN);

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
