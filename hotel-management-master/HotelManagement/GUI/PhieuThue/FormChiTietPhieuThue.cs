using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HotelManagement.DTO;
using HotelManagement.BUS;
using HotelManagement.CTControls;
using System.Globalization;

namespace HotelManagement.GUI
{
    public partial class FormChiTietPhieuThue : Form
    {
        // Các biến khởi tạo
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.White;
        private Image delete = Properties.Resources.delete;
        private PhieuThue phieuThue;
        // Hàm khởi tạo Form
        public FormChiTietPhieuThue(PhieuThue phieuThue)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.phieuThue = phieuThue;
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


        #region Hiển thị phòng 
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
        private void FormCTPhieuThue_Paint(object sender, PaintEventArgs e)
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
        private void FormCTPhieuThue_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormCTPhieuThue_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormCTPhieuThue_Activated(object sender, EventArgs e)
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
        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void CTButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        // Hiển thị chi tiết phiếu thuê 
        private void FormChiTietPhieuThue_Load(object sender, EventArgs e)
        {
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);

            this.LabelNhanVienLapPhieu.Text = this.phieuThue.NhanVien.TenNV;
            this.LabelChiTietPhieuThueTieuDe.Text = this.phieuThue.MaPT;
            this.LabelTen.Text = this.phieuThue.KhachHang.TenKH;
            this.LabelThoiGianLapPhieu.Text = this.phieuThue.NgPT.ToString("dd/MM/yyyy hh:mm:ss"); // chỉnh định dạng dd/MM/yyy là xóa đc lịch thuê
            LoadGrid();
        }
        // Hiển thị các trạng thái của từng phiếu thuê
        private void LoadGrid()
        {
            grid.Rows.Clear();
            List<CTDP> ctdps = CTDP_BUS.Instance.GetCTDPs().Where(p => p.MaPT == phieuThue.MaPT && p.DaXoa == false).ToList();

            foreach (CTDP cTDP in ctdps)
            {
                string TrangThai;
                if (cTDP.TrangThai == "Đang thuê")
                    TrangThai = cTDP.TrangThai;
                else if (cTDP.TrangThai == "Đã xong")
                    TrangThai = "Hoàn thành";
                else
                    TrangThai = cTDP.TrangThai;
                grid.Rows.Add(new object[] { cTDP.MaPH, cTDP.CheckIn.ToString("dd/MM/yyyy hh:mm:ss"), cTDP.CheckOut.ToString("dd/MM/yyyy hh:mm:ss"), TrangThai, this.delete });
            }
        }
        private void grid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            int y = e.RowIndex, x = e.ColumnIndex;
            if (y == -1 && x == 0 || y >= 0 && x == 4)
                grid.Cursor = Cursors.Hand;
            else
                grid.Cursor = Cursors.Default;
        }

        private void grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            grid.Cursor = Cursors.Default;
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int y = e.RowIndex, x = e.ColumnIndex;
            if (y >= 0 && x == 4)
            {
                // Khi nhấn nút xóa phiếu thuê
                DialogResult dialogresult = CTMessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)
                {
                    try
                    {
                        DateTime date = DateTime.ParseExact(grid.Rows[y].Cells[1].Value.ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture); //chỉnh định dạng dd/MM/yyyy HH:mm:ss
                        CTDP cTDP = CTDP_BUS.Instance.GetCTDPs().Where(p => p.MaPT == phieuThue.MaPT).ToList()[y];
                        if (cTDP.TrangThai == "Đã xong")
                        {
                            CTMessageBox.Show("Thông tin đặt phòng này không hủy được do đã hoàn thành!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (cTDP.TrangThai == "Đang thuê")
                        {
                            CTMessageBox.Show("Thông tin đặt phòng này không hủy được do đang thuê!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        cTDP.TrangThai = "Đã hủy";
                        cTDP.DaXoa = true;
                        CTDP_BUS.Instance.RemoveCTDP(cTDP);
                        this.LoadGrid();
                        CTMessageBox.Show("Xóa thông tin thành công.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        // Thêm phiếu thuê
        private void CTButtonThemPT_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormDatPhong formDatPhong = new FormDatPhong(null, this.phieuThue))
                {
                    formDatPhong.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CTButtonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
