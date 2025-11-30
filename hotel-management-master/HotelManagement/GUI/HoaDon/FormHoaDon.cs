using HotelManagement.BUS;
using HotelManagement.CTControls;
using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HotelManagement.DTO.HoaDon;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Button = System.Windows.Forms.Button;

namespace HotelManagement.GUI
{
    public partial class FormHoaDon : Form
    {
        HoaDon HD;

        private int borderRadius = 10;
        private int borderSize = 2;
        private Color borderColor = Color.White;

        private string money = null;

        public FormHoaDon()
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            InitializeComponent();
        }

        // Hàm khởi tạo nhận đối tượng hóa đơn, dùng để hiển thị chi tiết hóa đơn tương ứng
        public FormHoaDon(HoaDon HD)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.HD = HD;
            InitializeComponent();
            LoadHD();
        }

        // Nạp dữ liệu chi tiết hóa đơn (khách hàng, phòng, dịch vụ, số ngày/giờ, tổng tiền) lên giao diện
        void LoadHD()
        {
            try
            {
                DichVu dichvu;
                CTDP cTDP = CTDP_BUS.Instance.GetCTDPs().Where(p => p.MaCTDP == HD.MaCTDP).Single();

                // Gán thông tin cơ bản của hóa đơn
                this.TextBoxSoHD.Text = HD.MaHD;
                this.TextBoxTenKH.Text = CTDP_BUS.Instance.GetCTDPs()
                                            .Where(p => p.MaCTDP == HD.MaCTDP)
                                            .Single()
                                            .PhieuThue
                                            .KhachHang
                                            .TenKH;
                this.TextBoxMaPhong.Text = CTDP_BUS.Instance.GetCTDPs()
                                              .Where(p => p.MaCTDP == HD.MaCTDP)
                                              .Single()
                                              .MaPH;
                this.TextBoxTenNV.Text = NhanVienBUS.Instance.GetNhanVien(HD.MaNV).TenNV;
                this.TextBoxNgayHD.Text = HD.NgHD.ToString();

                // Lấy thông tin phòng và loại phòng
                Phong phong = PhongBUS.Instance.FindePhong(TextBoxMaPhong.Text);
                LoaiPhong loaiphong = LoaiPhongBUS.Instance.getLoaiPhong(phong.MaLPH);
                this.TextBoxLoaiPhong.Text = loaiphong.TenLPH;

                // Đổ danh sách dịch vụ đã sử dụng vào DataGridView
                List<CTDV> ctdvs = CTDV_BUS.Instance.FindCTDV(HD.MaCTDP);
                foreach (CTDV ctdv in ctdvs)
                {
                    dichvu = DichVuBUS.Instance.FindDichVu(ctdv.MaDV);
                    DataGridViewDichVu.Rows.Add(
                        dichvu.TenDV,
                        ctdv.DonGia.ToString("#,#"),
                        ctdv.SL,
                        ctdv.ThanhTien.ToString("#,#")
                    );
                }

                // Tính thông tin tiền phòng và thời gian thuê
                decimal Tongtienphong = cTDP.ThanhTien;
                string time = null;

                // Trường hợp tính theo ngày
                if (cTDP.TheoGio == false)
                {
                    time = CTDP_BUS.Instance.getKhoangTGTheoNgay(HD.MaCTDP).ToString();
                    if (int.Parse(time) == 0)
                        time = "1";
                    this.TextBoxSoNgay.Text = time + " ngày";
                }
                // Trường hợp tính theo giờ
                else
                {
                    time = CTDP_BUS.Instance.getKhoangTGTheoGio(HD.MaCTDP).ToString();
                    this.TextBoxSoNgay.Text = CTDP_BUS.Instance.getKhoangTGTheoGio(HD.MaCTDP).ToString() + " giờ";
                }

                // Thêm dòng thể hiện tiền phòng vào cuối DataGridView
                DataGridViewDichVu.Rows.Add(
                    loaiphong.TenLPH,
                    cTDP.DonGia.ToString("#,#"),
                    int.Parse(time),
                    Tongtienphong.ToString("#,#")
                );

                // Lưu lại tổng trị giá hóa đơn để hiển thị ở Label tổng tiền
                money = HD.TriGia.ToString("#,#");
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
            colors.TopLeftColor = Color.FromArgb(77, 77, 77);
            colors.TopRightColor = Color.FromArgb(77, 77, 77);
            colors.BottomLeftColor = Color.FromArgb(77, 77, 77);
            colors.BottomRightColor = Color.FromArgb(77, 77, 77);
            return colors;
        }

      
        private void FormHoaDon_Paint(object sender, PaintEventArgs e)
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


        private void FormHoaDon_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }


        private void FormHoaDon_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormHoaDon_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void PanelBackground_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ControlRegionAndBorder(PanelBackground, borderRadius - (borderSize / 2), g, borderColor);
        }

        private void PanelBackground_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ctClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sự kiện Load của form, định dạng header lưới dịch vụ và căn chỉnh vị trí label tổng tiền
        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            DataGridView grid = DataGridViewDichVu;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);

            int row, offset, x, y, len;
            row = grid.Rows.Count;
            offset = 25 * row;
            x = 350;
            y = 0;
            len = money.Length;

            // Căn vị trí Label tổng tiền theo số lượng dòng dịch vụ
            if (row < 6)
                y = 400 + offset;
            else
                y = 370 + offset;

            LabelTongTien.Text += money;
            LabelTongTien.Location = new Point(x - 10 * len, y);
        }

        private void DataGridViewDichVu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            Graphics g = e.Graphics;
            DataGridView grid = DataGridViewDichVu;

            int topX_left = 0, topY_left = 35, topX_right = 515, topY_right = 35;
            int row = grid.Rows.Count;
            int offset = 25 * row + 10;
            int botX_left = 0, botY_left = 35 + offset, botX_right = 515, botY_right = 35 + offset;

            using (var pen = new Pen(Color.FromArgb(198, 197, 195), 2))
            {
                g.DrawLine(pen, topX_left, topY_left, topX_right, topY_right);
                g.DrawLine(pen, botX_left, botY_left, botX_right, botY_right);
            }
        }

        #region In Hóa đơn

        private Bitmap memoryImage;

        private Size s;

        // Chụp lại nội dung PanelBackground thành một bitmap để phục vụ in/preview
        private void CaptureScreen()
        {
            s = PanelBackground.Size;

            memoryImage = new Bitmap(s.Width, s.Height);
            PanelBackground.DrawToBitmap(
                memoryImage,
                new Rectangle(0, 0, s.Width, s.Height)
            );
        }

        // Sự kiện PrintPage của printDocument, vẽ ảnh hóa đơn đã chụp lên trang giấy với tỉ lệ phù hợp
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Tính tỉ lệ để scale ảnh hóa đơn cho vừa vùng in của trang giấy
            Rectangle m = e.MarginBounds;

            int w = memoryImage.Width;
            int h = memoryImage.Height;

            float ratio = Math.Min(
                (float)m.Width / w,
                (float)m.Height / h
            );

            w = (int)(w * ratio);
            h = (int)(h * ratio);

            e.Graphics.DrawImage(memoryImage, m.Left, m.Top, w, h);
        }

        // Ẩn các nút điều khiển khi chụp màn hình/in để tránh xuất hiện trên hóa đơn
        private void HideButton()
        {
            Printer.Visible = false;
            ctMaximize1.Visible = false;
            ctMinimize1.Visible = false;
            ctClose1.Visible = false;
        }

        // Hiện lại các nút điều khiển sau khi in xong
        private void ShowButton()
        {
            Printer.Visible = true;
            ctMaximize1.Visible = true;
            ctMinimize1.Visible = true;
            ctClose1.Visible = true;
        }

        // Sự kiện click nút in (Printer), xử lý quy trình xem trước và in hóa đơn
        private void Printer_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    HideButton();
                    this.Refresh();

                    // Chụp lại nội dung panel
                    CaptureScreen();

                    // Gán document cho preview (nếu chưa gán)
                    printPreviewDialog1.Document = printDocument;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;
                    printPreviewDialog1.ShowIcon = false;

                    // Hiển thị màn hình xem trước
                    printPreviewDialog1.ShowDialog();

                    // Tiến hành in
                    printDocument.Print();
                    ShowButton();
                    printDialog.Dispose();
                }
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                ShowButton();
                printDialog.Dispose();
            }
        }

        #endregion
    }
}
