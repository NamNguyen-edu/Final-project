using HotelManagement.CTControls;
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
using HotelManagement.DTO;
using HotelManagement.DAO;

namespace HotelManagement.GUI
{
    public partial class FormDanhSachHoaDon : Form
    {
        private Image HD = Properties.Resources.HoaDon;
        private Image details = Properties.Resources.details;

        private FormMain formMain;

        private List<HoaDon> hoaDons;

        private bool reset = true;

        private DateTime dateTime = DateTime.Now;

        private string cccd = null;

        public FormDanhSachHoaDon(FormMain formMain)
        {
            InitializeComponent();
            LoadAllDataGrid();
            this.formMain = formMain;
            HotelManagement.CTControls.ThemeManager.ApplyThemeToChild(this);
        }

        public void LoadAllDataGrid()
        {
            try
            {
                hoaDons = HoaDonBUS.Instance.GetHoaDons();
                LoadDataGrid(hoaDons);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Đổ dữ liệu danh sách hóa đơn lên DataGridView, chỉ hiển thị hóa đơn đã thanh toán
        public void LoadDataGrid(List<HoaDon> hoaDons)
        {
            DichVu dichvu;
            grid.Rows.Clear();
            try
            {
                foreach (HoaDon hoadon in hoaDons)
                {
                    // Lấy chi tiết đặt phòng tương ứng với hóa đơn
                    CTDP ctdp = CTDP_BUS.Instance.GetCTDPs().Where(p => p.MaCTDP == hoadon.MaCTDP).Single();
                    Phong phong = PhongBUS.Instance.FindePhong(ctdp.MaPH);
                    LoaiPhong loaiphong = LoaiPhongBUS.Instance.getLoaiPhong(phong.MaLPH);
                    string tennv = null;

                    // Lấy danh sách chi tiết dịch vụ của hóa đơn (nếu cần sử dụng)
                    List<CTDV> ctdvs = CTDV_BUS.Instance.FindCTDV(hoadon.MaHD);
                    foreach (CTDV ctdv in ctdvs)
                    {
                        dichvu = DichVuBUS.Instance.FindDichVu(ctdv.MaDV);
                    }

                    // Lấy tên nhân viên lập hóa đơn (nếu có)
                    if (hoadon.MaNV != null)
                        tennv = hoadon.NhanVien.TenNV;

                    // Chỉ hiển thị hóa đơn đã thanh toán
                    if (hoadon.TrangThai == "Đã thanh toán" || hoadon.TrangThai == "Đã đặt cọc")
                    {
                        PhieuThue phieuThue = PhieuThueBUS.Instance.GetPhieuThue(ctdp.MaPT);
                        KhachHang khachHang = KhachHangBUS.Instance.GetKhachHangs()
                                                                  .Where(p => p.MaKH == phieuThue.MaKH)
                                                                  .Single();

                        grid.Rows.Add(
                            HD,
                            hoadon.MaHD,
                            hoadon.NgHD,
                            tennv,
                            khachHang.TenKH,
                            hoadon.TriGia.ToString("#,#"),
                            hoadon.TrangThai,
                            details
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                CTMessageBox.Show($"Đã xảy ra lỗi: {ex}! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lọc danh sách hóa đơn theo CCCD khách hàng và hiển thị lên lưới
        void LoadGridWith_CCCD()
        {
            try
            {
                cccd = this.CTTextBoxTimTheoCCCD.Texts;
                hoaDons = HoaDonBUS.Instance.FindHoaDonWith_CCCD(cccd);
                LoadDataGrid(hoaDons);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Xuất dữ liệu hóa đơn trên lưới ra file Excel bằng Interop
        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
                    XcelApp.Application.Workbooks.Add(Type.Missing);

                    int row = grid.Rows.Count;
                    int col = grid.Columns.Count;

                    // Lấy tiêu đề cột (bỏ cột icon đầu tiên)
                    for (int i = 1; i < col - 1 + 1; i++)
                    {
                        if (i == 1) continue;
                        XcelApp.Cells[1, i - 1] = grid.Columns[i - 1].HeaderText;
                    }

                    // Đổ dữ liệu từng ô vào Excel
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 1; j < col - 1; j++)
                        {
                            XcelApp.Cells[i + 2, j] = grid.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    XcelApp.Columns.AutoFit();
                    XcelApp.Visible = true;
                }
                else
                {
                    string mess = "Chưa có dữ liệu trong bảng!";
                    CTMessageBox.Show(mess, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Xử lý khi click vào một ô trên lưới, mở form chi tiết hóa đơn khi click nút "chi tiết"
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            // Nếu click vào cột chi tiết (cột 7) và dòng hợp lệ
            if (x == 7 && y >= 0)
            {
                try
                {
                    string MaHD = grid.Rows[y].Cells[1].Value.ToString();
                    HoaDon HD = HoaDonBUS.Instance.FindHD(MaHD);

                    FormBackground formBackground = new FormBackground(formMain);
                    try
                    {
                        using (FormHoaDon formHoaDon = new FormHoaDon(HD))
                        {
                            formBackground.Owner = formMain;
                            formBackground.Show();
                            formHoaDon.Owner = formBackground;
                            formHoaDon.ShowDialog();
                            formBackground.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { formBackground.Dispose(); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Thay đổi hình dạng con trỏ chuột khi rê vào một số cột đặc biệt (tiêu đề có thể sort / cột nút chi tiết)
        private void grid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            int y = e.RowIndex, x = e.ColumnIndex;
            int[] arrX = { 1, 2, 5, 6 };
            bool isExists = false;

            // Kiểm tra cột có nằm trong danh sách cột đặc biệt không
            if (Array.IndexOf(arrX, x) != -1)
                isExists = true;

            // Đổi con trỏ chuột thành dạng "Hand" khi rê vào cột chi tiết hoặc một số tiêu đề cột
            if (y >= 0 && x == 7 || y == -1 && isExists)
                grid.Cursor = Cursors.Hand;
            else
                grid.Cursor = Cursors.Default;
        }

        // Khi chuột rời khỏi ô, trả con trỏ về mặc định
        private void grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            grid.Cursor = Cursors.Default;
        }

        // Xử lý tìm kiếm hóa đơn theo CCCD, kết hợp với trạng thái bộ lọc (theo ngày hoặc không)
        private void CTTextBoxTimTheoCCCD__TextChanged(object sender, EventArgs e)
        {
            cccd = this.CTTextBoxTimTheoCCCD.Texts;
            dateTime = this.ctDatePicker1.Value;

            // reset = true: chỉ lọc theo CCCD
            if (reset)
            {
                if (cccd != String.Empty)
                {
                    hoaDons = HoaDonBUS.Instance.FindHoaDonWith_CCCD(cccd);
                    LoadDataGrid(hoaDons);
                }
            }
            // reset = false: lọc theo ngày và CCCD (nếu có)
            else
            {
                if (cccd == String.Empty)
                {
                    dateTime = this.ctDatePicker1.Value;
                    hoaDons = HoaDonBUS.Instance.FindHoaDonWith_Date(dateTime);
                    LoadDataGrid(hoaDons);
                }
                else
                {
                    hoaDons = HoaDonBUS.Instance.FindHoaDonWith_DateAndCCCD(dateTime, cccd);
                    LoadDataGrid(hoaDons);
                }
            }
        }

        // Xử lý khi người dùng đổi giá trị DatePicker: kích hoạt chế độ lọc theo ngày (reset = false)
        private void ctDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            reset = false;
            dateTime = this.ctDatePicker1.Value;
            cccd = this.CTTextBoxTimTheoCCCD.Texts;

            // Nếu không nhập CCCD thì chỉ lọc theo ngày
            if (this.CTTextBoxTimTheoCCCD.Texts == string.Empty)
            {
                hoaDons = HoaDonBUS.Instance.FindHoaDonWith_Date(dateTime);
                LoadDataGrid(hoaDons);
            }
            // Nếu có CCCD thì lọc kết hợp ngày + CCCD
            else
            {
                hoaDons = HoaDonBUS.Instance.FindHoaDonWith_DateAndCCCD(dateTime, cccd);
                LoadDataGrid(hoaDons);
            }
        }

        // Nút Reset bộ lọc: đưa DatePicker về ngày hiện tại, xóa CCCD, trả về danh sách đầy đủ
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ctDatePicker1.Value = DateTime.Now;
            reset = true;
            LoadAllDataGrid();
            CTTextBoxTimTheoCCCD.Texts = string.Empty;
        }
    }
}
