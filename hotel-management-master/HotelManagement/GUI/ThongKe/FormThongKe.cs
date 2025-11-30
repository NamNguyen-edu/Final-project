using HotelManagement.DAO;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.BUS;
using HotelManagement.CTControls;
using System.Globalization;
using System.Runtime.InteropServices;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Printing;

namespace HotelManagement.GUI.ThongKe
{
    public partial class FormThongKe : Form
    {
        private FormMain formMain;
        private ThongKeDAO thongKe;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);
        private Bitmap _dashboardBitmap;
        private PrintDocument _printDocument;
        public FormThongKe()
        {
            InitializeComponent();
            HotelManagement.CTControls.ThemeManager.ApplyThemeToChild(this);
        }
        public FormThongKe(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
            _printDocument = new PrintDocument();
            _printDocument.DefaultPageSettings.Landscape = true; // A4 ngang cho giống màn hình
            _printDocument.PrintPage += PrintDocument_PrintPage;
            dtpNgayBD.Value = DateTime.Today.AddDays(-7);
            dtpNgayKT.Value = DateTime.Now;
            setButtonNormal();
            Button7Ngay.Select();
            Button7Ngay.BackColor = Color.FromArgb(128, 61, 8);
            Button7Ngay.ForeColor = Color.White;
            thongKe = new ThongKeDAO();
            LoadData();
            ChonTab(btnTongQuan, pnlTongQuan);
        }
        // Reset màu và trạng thái tất cả nút lọc thời gian về mặc định
        private void setButtonNormal()
        {
            ButtonTuyChon.BackColor
                = ButtonHomNay.BackColor
                = Button7Ngay.BackColor
                = Button30Ngay.BackColor
                = Button6Thang.BackColor
                = ButtonOK.BackColor = Color.FromArgb(245, 210, 165);
            ButtonTuyChon.ForeColor
                = ButtonHomNay.ForeColor
                = Button7Ngay.ForeColor
                = Button30Ngay.ForeColor
                = Button6Thang.ForeColor = Color.Black;
        }
        // Chọn chế độ Tùy chọn (cho phép chỉnh ngày), highlight nút, load dữ liệu
        private void ButtonTuyChon_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            ButtonOK.Enabled = true;
            ButtonTuyChon.BackColor = Color.FromArgb(128, 61, 8);
            ButtonTuyChon.ForeColor = Color.White;
            LoadData();
        }
        // Lọc dữ liệu theo ngày hôm nay
        private void ButtonHomNay_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            ButtonHomNay.BackColor = Color.FromArgb(128, 61, 8);
            ButtonHomNay.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Now.Date;
            dtpNgayKT.Value = DateTime.Now.Date;
            LoadData();
        }
        // Lọc dữ liệu 7 ngày gần nhất
        private void Button7Ngay_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            Button7Ngay.BackColor = Color.FromArgb(128, 61, 8);
            Button7Ngay.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Today.AddDays(-7);
            dtpNgayKT.Value = DateTime.Now;
            LoadData();
        }
        // Lọc dữ liệu 30 ngày gần nhất
        private void Button30Ngay_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            Button30Ngay.BackColor = Color.FromArgb(128, 61, 8);
            Button30Ngay.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Today.AddDays(-30);
            dtpNgayKT.Value = DateTime.Now;
            LoadData();
        }
        // Lọc dữ liệu 6 tháng gần nhất
        private void Button6Thang_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            Button6Thang.BackColor = Color.FromArgb(128, 61, 8);
            Button6Thang.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Today.AddDays(-180);
            dtpNgayKT.Value = DateTime.Now;
            LoadData();
        }
        // Xác nhận lọc bằng ngày tùy chọn
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            ButtonTuyChon.BackColor = Color.FromArgb(128, 61, 8);
            ButtonTuyChon.ForeColor = Color.White;
            LoadData();
        }
        // Gọi DAO để tải dữ liệu theo khoảng ngày → cập nhật UI 4 tab
        private void LoadData()
        {
            try
            {
                bool refreshed = thongKe.LoadData(dtpNgayBD.Value, dtpNgayKT.Value);
                if (!refreshed) return;

                UpdateUI_TongQuan();
                UpdateUI_Phong();
                UpdateUI_DichVu();
                UpdateUI_Khach();
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Cập nhật KPI + biểu đồ tổng quan (doanh thu, phòng đặt)
        private void UpdateUI_TongQuan()
        {
            TongDoanhThuTong.Text = thongKe.TongDoanhThuTong.ToString("#,#");
            DoanhThuThue.Text = thongKe.TongDoanhThuThue.ToString("#,#");
            DoanhThuDichVu.Text = thongKe.TongDoanhThuDichVu.ToString("#,#");
            SoPhongDat.Text = thongKe.SoPhongDat.ToString();

            chartDoanhThuTong.Series["Tổng Doanh Thu"].Points.Clear();
            foreach (var item in thongKe.DoanhThuTongList)
                chartDoanhThuTong.Series["Tổng Doanh Thu"].Points.AddXY(item.Date, item.TotalAmount);

            chartSoPhongDat.DataSource = thongKe.SoPhongDatList;
            chartSoPhongDat.Series[0].XValueMember = "Date";
            chartSoPhongDat.Series[0].YValueMembers = "TotalAmount";
            chartSoPhongDat.DataBind();
        }
        // Cập nhật KPI + biểu đồ liên quan đến loại phòng
        private void UpdateUI_Phong()
        {
            lblPhong_TopDoanhThu_Ten.Text = thongKe.TenLoaiPhongDoanhThuCaoNhat;
            lblPhong_TopDoanhThu_GiaTri.Text = thongKe.DoanhThuLoaiPhongCaoNhat.ToString("#,#");
            lblPhong_TopDat_Ten.Text = thongKe.TenLoaiPhongDuocDatNhieuNhat;
            lblPhong_TopDat_SoLan.Text = thongKe.SoLanLoaiPhongDatNhieuNhat.ToString();

            chartPhong_Line.Series["Thường đơn"].Points.Clear();
            chartPhong_Line.Series["Thường đôi"].Points.Clear();
            chartPhong_Line.Series["VIP đơn"].Points.Clear();
            chartPhong_Line.Series["VIP đôi"].Points.Clear();

            foreach (var x in thongKe.DoanhThuThuongDonList)
                chartPhong_Line.Series["Thường đơn"].Points.AddXY(x.Date, x.TotalAmount);

            foreach (var x in thongKe.DoanhThuThuongDoiList)
                chartPhong_Line.Series["Thường đôi"].Points.AddXY(x.Date, x.TotalAmount);

            foreach (var x in thongKe.DoanhThuVipDonList)
                chartPhong_Line.Series["VIP đơn"].Points.AddXY(x.Date, x.TotalAmount);

            foreach (var x in thongKe.DoanhThuVipDoiList)
                chartPhong_Line.Series["VIP đôi"].Points.AddXY(x.Date, x.TotalAmount);

            chartPhong_TyTrong.Series["TyTrong"].Points.Clear();

            foreach (var item in thongKe.TyTrongDatPhongList)
            {
                chartPhong_TyTrong.Series["TyTrong"].Points.AddXY(item.TenLoaiPhong, item.SoLan);
            }

            chartPhong_Horizontal.Series["DoanhThu"].Points.Clear();

            foreach (var item in thongKe.DoanhThuLoaiPhongList)
            {
                chartPhong_Horizontal.Series["DoanhThu"]
                    .Points.AddXY(item.TenLoaiPhong, item.TongTien);
            }
        }
        // Cập nhật KPI + biểu đồ liên quan đến dịch vụ
        private void UpdateUI_DichVu()
        {
            lblDV_TopDT_Ten.Text = thongKe.TenDichVuDoanhThuCaoNhat;
            lblDV_TopDT_GiaTri.Text = thongKe.DoanhThuDichVuCaoNhat.ToString("#,#");

            lblDV_TopSL_Ten.Text = thongKe.TenDichVuSuDungNhieuNhat;
            lblDV_TopSL_SoLan.Text = thongKe.SoLanDichVuSuDungNhieuNhat.ToString();

            chartDV_Line.Series["Doanh Thu Dịch Vụ"].Points.Clear();
            foreach (var item in thongKe.DoanhThuDichVuTheoNgayList)
            {
                chartDV_Line.Series["Doanh Thu Dịch Vụ"]
                    .Points.AddXY(item.Date, item.TotalAmount);
            }
            chartDV_Top5.Series["DoanhThu"].Points.Clear();

            foreach (var dv in thongKe.TopDichVuList)
            {
                chartDV_Top5.Series["DoanhThu"].Points.AddXY(dv.Key, dv.Value);
            }
            chartDV_Pie.Series["TyTrong"].Points.Clear();

            foreach (var dv in thongKe.TyTrongDoanhThuDVList)
            {
                chartDV_Pie.Series["TyTrong"]
                    .Points.AddXY(dv.Key, dv.Value);
            }
        }
        // Cập nhật KPI + biểu đồ liên quan đến khách hàng
        private void UpdateUI_Khach()
        {
            lblKH_TongKhach_GiaTri.Text = thongKe.TongSoKhach.ToString();
            lblKH_TopDat_Ten.Text = thongKe.TenKhachDatNhieuNhat;
            lblKH_TopDat_SoLan.Text = thongKe.SoLanKhachDatNhieuNhat.ToString();
            lblKH_TopChiTieu_Ten.Text = thongKe.TenKhachChiNhieuNhat;
            lblKH_TopChiTieu_GiaTri.Text = thongKe.TienKhachChiNhieuNhat.ToString("#,#");

            chartKH_TopChiTieu.Series["Dong"].Points.Clear();
            foreach (var kh in thongKe.Top5KhachChiTieuList)
            {
                chartKH_TopChiTieu.Series["Dong"].Points.AddXY(kh.TenKhach, kh.TongTien);
            }

            chartKH_SoKhach.Series["KhachHang"].Points.Clear();
            foreach (var item in thongKe.SoKhachTheoNgayList)
            {
                chartKH_SoKhach.Series["KhachHang"].Points.AddXY(item.Date, item.TotalAmount);
            }
        }
        // Chụp toàn bộ form và mở Print Preview để xem trước khi in
        private void Printer_ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                this.Refresh();
                _dashboardBitmap = CaptureFormWithPrintWindow(this);

                using (PrintPreviewDialog preview = new PrintPreviewDialog())
                {
                    preview.Document = _printDocument;
                    preview.WindowState = FormWindowState.Maximized;
                    preview.ShowIcon = false;
                    preview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(ex.Message, "Lỗi in thống kê",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Dùng WinAPI để chụp ảnh toàn bộ form (kể cả ngoài màn hình)
        private Bitmap CaptureFormWithPrintWindow(Control form)
        {
            {
                Bitmap bmp = new Bitmap(form.Width, form.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    IntPtr hdc = g.GetHdc();
                    PrintWindow(form.Handle, hdc, 0);
                    g.ReleaseHdc(hdc);
                }
                return bmp;
            }
        }
        // Vẽ hình dashboard vào trang in
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(_dashboardBitmap, e.MarginBounds);
            e.HasMorePages = false;
        }
        // Mở tab Tổng quan
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            ChonTab(btnTongQuan, pnlTongQuan);
        }
        // Mở tab Phòng
        private void btnPhong_Click(object sender, EventArgs e)
        {
            ChonTab(btnPhong, pnlPhong);
        }
        // Mở tab Dịch vụ
        private void btnDichVu_Click(object sender, EventArgs e)
        {
            ChonTab(btnDichVu, pnlDichVu);
        }
        // Mở tab Khách hàng
        private void btnKhach_Click(object sender, EventArgs e)
        {
            ChonTab(btnKhach, pnlKhach);
        }
        // Đổi màu nút tab + ẩn các panel khác + hiện panel được chọn
        private void ChonTab(System.Windows.Forms.Button btnDangChon, Control pnlDangChon)
        {
            var allButtons = new System.Windows.Forms.Button[] { btnTongQuan, btnPhong, btnDichVu, btnKhach };

            foreach (var b in allButtons)
            {
                b.BackColor = Color.FromArgb(245, 210, 165);
                b.ForeColor = Color.Black;
            }

            btnDangChon.BackColor = Color.FromArgb(128, 61, 8);
            btnDangChon.ForeColor = Color.White;

            pnlTongQuan.Visible = false;
            pnlPhong.Visible = false;
            pnlDichVu.Visible = false;
            pnlKhach.Visible = false;

            pnlDangChon.Visible = true;
            pnlDangChon.BringToFront();
        }
    }
}