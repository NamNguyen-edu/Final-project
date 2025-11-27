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
using System.Runtime.InteropServices;


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
            Button7Ngay.Select();
            Button7Ngay.BackColor = Color.FromArgb(30, 119, 148);
            Button7Ngay.ForeColor = Color.White;
            thongKe = new ThongKeDAO();
            LoadData();
        }

        private void setButtonNormal()
        {
            ButtonTuyChon.BackColor
                = ButtonHomNay.BackColor
                = Button7Ngay.BackColor
                = Button30Ngay.BackColor
                = Button6Thang.BackColor = Color.FromArgb(207, 236, 236);
            ButtonTuyChon.ForeColor
                = ButtonHomNay.ForeColor
                = Button7Ngay.ForeColor
                = Button30Ngay.ForeColor
                = Button6Thang.ForeColor = Color.Black;
        }
        private void ButtonTuyChon_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            ButtonOK.Enabled = true;
            ButtonTuyChon.BackColor = Color.FromArgb(30, 119, 148);
            ButtonTuyChon.ForeColor = Color.White;
            LoadData();
        }

        private void ButtonHomNay_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            ButtonHomNay.BackColor = Color.FromArgb(30, 119, 148);
            ButtonHomNay.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Now.Date;
            dtpNgayKT.Value = DateTime.Now.Date;
            LoadData();
        }

        private void Button7Ngay_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            Button7Ngay.BackColor = Color.FromArgb(30, 119, 148);
            Button7Ngay.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Today.AddDays(-7);
            dtpNgayKT.Value = DateTime.Now;
            LoadData();
        }

        private void Button30Ngay_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            Button30Ngay.BackColor = Color.FromArgb(30, 119, 148);
            Button30Ngay.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Today.AddDays(-30);
            dtpNgayKT.Value = DateTime.Now;
            LoadData();
        }

        private void Button6Thang_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            Button6Thang.BackColor = Color.FromArgb(30, 119, 148);
            Button6Thang.ForeColor = Color.White;
            ButtonOK.Enabled = false;
            dtpNgayBD.Value = DateTime.Today.AddDays(-180);
            dtpNgayKT.Value = DateTime.Now;
            LoadData();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            setButtonNormal();
            ButtonTuyChon.BackColor = Color.FromArgb(30, 119, 148);
            ButtonTuyChon.ForeColor = Color.White;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var refreshDate = thongKe.LoadData(dtpNgayBD.Value, dtpNgayKT.Value);
                if (refreshDate == true)
                {
                    chartDoanhThuThue.Series[0].Points.Clear();
                    chartDoanhThuThue.Series[1].Points.Clear();
                    chartDoanhThuThue.Series[2].Points.Clear();
                    chartDoanhThuThue.Series[3].Points.Clear();
                    foreach (var item in thongKe.DoanhThuThuongDonList)
                    {
                        chartDoanhThuThue.Series[0].Points.AddXY(item.Date, item.TotalAmount);
                    }
                    foreach (var item in thongKe.DoanhThuThuongDoiList)
                    {
                        chartDoanhThuThue.Series[1].Points.AddXY(item.Date, item.TotalAmount);
                    }
                    foreach (var item in thongKe.DoanhThuVipDonList)
                    {
                        chartDoanhThuThue.Series[2].Points.AddXY(item.Date, item.TotalAmount);
                    }
                    foreach (var item in thongKe.DoanhThuVipDoiList)
                    {
                        chartDoanhThuThue.Series[3].Points.AddXY(item.Date, item.TotalAmount);
                    }

                    chartSoPhongDat.DataSource = thongKe.SoPhongDatList;
                    chartSoPhongDat.Series[0].XValueMember = "Date";
                    chartSoPhongDat.Series[0].YValueMembers = "TotalAmount";
                    chartSoPhongDat.DataBind();

                    chartDichVu.DataSource = thongKe.TopDichVuList;
                    chartDichVu.Series[0].XValueMember = "Key";
                    chartDichVu.Series[0].YValueMembers = "Value";
                    chartDichVu.DataBind();

                    DoanhThuThue.Text = thongKe.TongDoanhThuThue.ToString("#,#");
                    DoanhThuDichVu.Text = thongKe.TongDoanhThuDichVu.ToString("#,#");
                    SoPhongDat.Text = thongKe.SoPhongDat.ToString();

                    TenLoaiPhongDoanhThuCaoNhat.Text = thongKe.TenLoaiPhongDoanhThuCaoNhat;
                    DoanhThuLoaiPhongCaoNhat.Text = thongKe.DoanhThuLoaiPhongCaoNhat.ToString("#,#");
                    TenLoaiPhongDatNhieuNhat.Text = thongKe.TenLoaiPhongDuocDatNhieuNhat;
                    SoLanDatLoaiPhongNhieuNhat.Text = thongKe.SoLanLoaiPhongDatNhieuNhat.ToString();
                    TenDichVuDoanhThuCaoNhat.Text = thongKe.TenDichVuDoanhThuCaoNhat;
                    DoanhThuDichVuCaoNhat.Text = thongKe.DoanhThuDichVuCaoNhat.ToString("#,#");

                }
                else
                {
                    Console.WriteLine("View not loaded, same query");
                }
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(_dashboardBitmap, e.MarginBounds);
            e.HasMorePages = false;
        }
    }
}