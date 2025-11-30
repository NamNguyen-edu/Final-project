using HotelManagement.CTControls;
using HotelManagement.DTO;
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

namespace HotelManagement.GUI
{
    public partial class FormDanhSachKhachHang : Form
    {
        List<KhachHang> khachHangs;

        private Image KH = Properties.Resources.KhachHang;
        private Image edit = Properties.Resources.edit;
        private Image delete = Properties.Resources.delete;

        private FormMain formMain;
        private TaiKhoan taiKhoan;

        public FormDanhSachKhachHang(FormMain formMain, TaiKhoan taiKhoan)
        {
            InitializeComponent();
            LoadAllGrid();
            this.formMain = formMain;
            this.taiKhoan = taiKhoan;
            HotelManagement.CTControls.ThemeManager.ApplyThemeToChild(this);
        }

        // Sự kiện click nút Thêm khách hàng, mở form thêm khách hàng trên nền FormBackground
        private void CTButtonThemKhachHang_Click(object sender, EventArgs e)
        {
            LoadGrid();
            FormBackground formBackground = new FormBackground(formMain);
            try
            {
                using (FormThemKhachHang formThemKhachHang = new FormThemKhachHang(this))
                {
                    formBackground.Owner = formMain;
                    formBackground.Show();
                    formThemKhachHang.Owner = formBackground;
                    formThemKhachHang.ShowDialog();
                    formBackground.Dispose();
                }
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { formBackground.Dispose(); }
        }



        // Tải toàn bộ danh sách khách hàng từ BUS và hiển thị lên grid
        public void LoadAllGrid()
        {
            try
            {
                this.khachHangs = KhachHangBUS.Instance.GetKhachHangs();
                LoadGrid();
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Đổ dữ liệu danh sách khách hàng hiện có trong khachHangs lên grid
        private void LoadGrid()
        {
            try
            {
                grid.Rows.Clear();
                foreach (KhachHang khachHang in khachHangs)
                {
                    grid.Rows.Add(this.KH, khachHang.MaKH, khachHang.TenKH, khachHang.CCCD_Passport,
                                  khachHang.SDT, khachHang.QuocTich, khachHang.GioiTinh, khachHang.Email,
                                  edit, delete);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Tìm kiếm khách hàng theo tên (hoặc tiêu chí được BUS xử lý) và load lại grid
        private void LoadGridWithCCCD()
        {
            try
            {
                khachHangs = KhachHangBUS.Instance.FindKhachHangWithName(this.CTTextBoxTimKhachHangTheoTen.Texts);
                LoadGrid();
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xuất danh sách khách hàng ra file Excel bằng Interop
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

                    // Ghi header cột (bỏ cột hình và 2 cột cuối là edit/delete)
                    for (int i = 1; i < col - 2 + 1; i++)
                    {
                        if (i == 1) continue;
                        XcelApp.Cells[1, i - 1] = grid.Columns[i - 1].HeaderText;
                    }

                    // Ghi dữ liệu từng ô
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 1; j < col - 2; j++)
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
                    CTMessageBox.Show(mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý click trên grid: mở form sửa hoặc xóa khách hàng tùy theo cột được click
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            if (y >= 0)
            {
                // Khi nhấn vào cột sửa (edit)
                if (x == 8)
                {
                    FormBackground formBackground = new FormBackground(formMain);
                    try
                    {
                        using (FormSuaKhachHang formSuaKhachHang =
                               new FormSuaKhachHang(KhachHangBUS.Instance.FindKhachHang(grid.Rows[y].Cells[1].Value.ToString()), this))
                        {
                            formBackground.Owner = formMain;
                            formBackground.Show();
                            formSuaKhachHang.Owner = formBackground;
                            formSuaKhachHang.ShowDialog();
                            formBackground.Dispose();
                        }
                    }
                    catch (Exception)
                    {
                        CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally { formBackground.Dispose(); }
                }

                // Khi nhấn vào cột xóa (delete)
                if (x == 9)
                {
                    // Kiểm tra quyền, nhân viên (CapDoQuyen = 1) không được phép xóa
                    if (taiKhoan.CapDoQuyen == 1)
                    {
                        CTMessageBox.Show("Bạn không có quyền thực hiện thao tác này.", "Thông báo",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Hỏi xác nhận xóa
                    DialogResult dialogresult = CTMessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
                                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogresult == DialogResult.Yes)
                    {
                        try
                        {
                            KhachHangBUS.Instance.RemoveKH(
                                KhachHangBUS.Instance.FindKhachHang(grid.Rows[y].Cells[1].Value.ToString()));
                            LoadAllGrid();
                            CTMessageBox.Show("Xóa thông tin thành công.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }
            }
        }

        private void CTTextBoxTimKhachHangTheoTen_Load(object sender, EventArgs e)
        {
        }

        private void CTTextBoxTimKhachHangTheoTen__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxFindName = sender as TextBox;
            if (textBoxFindName.Focused == false)
            {
                LoadAllGrid();
                return;
            }

            this.khachHangs = KhachHangBUS.Instance.FindKhachHangWithName(textBoxFindName.Text);
            LoadGrid();
        }

        private void grid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            int y = e.RowIndex, x = e.ColumnIndex;
            int[] arrX = { 1, 5, 6 };
            bool isExists = false;

            if (Array.IndexOf(arrX, x) != -1)
                isExists = true;

            if (y >= 0 && x == 7 || y >= 0 && x == 8 || y == -1 && isExists)
                grid.Cursor = Cursors.Hand;
            else
                grid.Cursor = Cursors.Default;
        }

        private void grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            grid.Cursor = Cursors.Default;
        }
    }
}
