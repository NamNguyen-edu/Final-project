using HotelManagement.BUS;
using HotelManagement.CTControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.DTO;

namespace HotelManagement.GUI
{
    public partial class FormDanhSachPhieuThue : Form
    {
        private Image PT = Properties.Resources.PhieuThueDgv;

        private Image details = Properties.Resources.details;

        private List<PhieuThue> phieuThues;

        private FormMain formMain;

        private TaiKhoan taiKhoan;

        public FormDanhSachPhieuThue(FormMain formMain, TaiKhoan taiKhoan)
        {
            this.taiKhoan = taiKhoan;
            InitializeComponent();
            this.formMain = formMain;
            HotelManagement.CTControls.ThemeManager.ApplyThemeToChild(this);
        }

        private void CTButtonDatPhong_Click(object sender, EventArgs e)
        {
            FormBackground formBackground = new FormBackground(formMain);
            try
            {
                using (FormDatPhong formDatPhong = new FormDatPhong(this.taiKhoan))
                {
                    formBackground.Owner = formMain;
                    formBackground.Show();
                    formDatPhong.Owner = formBackground;
                    formDatPhong.ShowDialog();
                    formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        private void FormDanhSachPhieuThue_Load(object sender, EventArgs e)
        {
            LoadFullDataGrid();
        }

        // Lấy toàn bộ phiếu thuê từ tầng BUS và gán vào lưới hiển thị
        public void LoadFullDataGrid()
        {
            try
            {
                phieuThues = PhieuThueBUS.Instance.GetPhieuThues();
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Đổ dữ liệu danh sách phiếu thuê vào DataGridView theo cấu trúc từng dòng
        public void LoadDataGrid()
        {
            try
            {
                this.grid.Rows.Clear();
                foreach (PhieuThue phieuThue in phieuThues)
                {
                    grid.Rows.Add(new object[]
                    {
                        PT,
                        phieuThue.MaPT,
                        phieuThue.KhachHang.TenKH,
                        phieuThue.NgPT.ToString("dd/MM/yyyy"),
                        phieuThue.NhanVien.TenNV,
                        details
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Xuất dữ liệu danh sách phiếu thuê ra file Excel với cấu trúc giống DataGridView
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

                    // Ghi tiêu đề cột (bỏ cột ảnh đầu tiên)
                    for (int i = 1; i < col - 1 + 1; i++)
                    {
                        if (i == 1) continue;
                        XcelApp.Cells[1, i - 1] = grid.Columns[i - 1].HeaderText;
                    }

                    // Ghi dữ liệu từng ô vào Excel
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

        // Xử lý click trên từng ô của DataGridView (mở chi tiết phiếu thuê khi bấm nút chi tiết)
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            if (y >= 0 && x == 5)
            {
                FormBackground formBackground = new FormBackground(formMain);
                try
                {
                    using (FormChiTietPhieuThue formChiTietPhieuThue =
                           new FormChiTietPhieuThue(
                               PhieuThueBUS.Instance.GetPhieuThue(
                                   grid.Rows[y].Cells[1].Value.ToString())))
                    {
                        formBackground.Owner = formMain;
                        formBackground.Show();
                        formChiTietPhieuThue.Owner = formBackground;
                        formChiTietPhieuThue.ShowDialog();
                        formBackground.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    formBackground.Dispose();
                }
            }
        }

        private void grid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            int y = e.RowIndex, x = e.ColumnIndex;
            int[] arrX = { 1, 3 };
            bool isExists = false;

            if (Array.IndexOf(arrX, x) != -1)
                isExists = true;

            if (y >= 0 && x == 5 || y == -1 && isExists)
                grid.Cursor = Cursors.Hand;
            else
                grid.Cursor = Cursors.Default;
        }

        // Lọc danh sách phiếu thuê theo tên khách hàng dựa trên nội dung textbox tìm kiếm
        private void ctTextBox1__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxPT = sender as TextBox;

            if (textBoxPT.Focused == false)
            {
                LoadFullDataGrid();
                return;
            }

            this.phieuThues = PhieuThueBUS.Instance.GetPhieuThuesWithNameCus(textBoxPT.Text);
            LoadDataGrid();
        }

        private void grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            grid.Cursor = Cursors.Default;
        }
    }
}
