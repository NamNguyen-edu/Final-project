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
    public partial class FormDanhSachLoaiPhong : Form
    {
        private Image LP = Properties.Resources.LoaiPhong;

        private Image edit = Properties.Resources.edit;

        private Image details = Properties.Resources.details;

        private List<LoaiPhong> loaiPhongs;

        private FormMain formMain;

        private TaiKhoan taiKhoan1;

        public FormDanhSachLoaiPhong(FormMain formMain, TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.formMain = formMain;
            this.taiKhoan1 = taiKhoan;
            HotelManagement.CTControls.ThemeManager.ApplyThemeToChild(this);
        }

        private void FormDanhSachLoaiPhong_Load(object sender, EventArgs e)
        {
            LoadAllDataGrid();
        }

        // Tải toàn bộ danh sách loại phòng từ tầng nghiệp vụ và đổ dữ liệu lên lưới
        public void LoadAllDataGrid()
        {
            try
            {
                this.loaiPhongs = LoaiPhongBUS.Instance.GetLoaiPhongs();
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Đổ danh sách loại phòng hiện tại (loaiPhongs) lên DataGridView
        private void LoadDataGrid()
        {
            try
            {
                grid.Rows.Clear();
                foreach (LoaiPhong loaiPhong in this.loaiPhongs)
                {
                    grid.Rows.Add(
                        LP,
                        loaiPhong.MaLPH,
                        loaiPhong.TenLPH,
                        loaiPhong.SoGiuong,
                        loaiPhong.SoNguoiToiDa,
                        loaiPhong.GiaNgay.ToString("#,#"),
                        loaiPhong.GiaGio.ToString("#,#"),
                        details,
                        edit
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Xuất danh sách loại phòng trên lưới ra Excel sử dụng Interop
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

                    // Lấy tiêu đề cột (bỏ cột icon đầu tiên và 2 cột cuối là nút)
                    for (int i = 1; i < col - 2 + 1; i++)
                    {
                        if (i == 1) continue;
                        XcelApp.Cells[1, i - 1] = grid.Columns[i - 1].HeaderText;
                    }

                    // Ghi dữ liệu từng ô xuống Excel
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
                    CTMessageBox.Show(mess, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý các thao tác click trên từng ô của DataGridView (xem chi tiết tiện nghi / sửa loại phòng)
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            if (y >= 0)
            {
                // Nếu click vào cột chi tiết tiện nghi (details)
                if (x == 7)
                {
                    FormBackground formBackground = new FormBackground(formMain);
                    try
                    {
                        string MaLP = grid.Rows[y].Cells[1].Value.ToString();
                        string TenLP = grid.Rows[y].Cells[2].Value.ToString();
                        using (FormDanhSachChiTietTienNghi formDanhSachChiTietTienNghi =
                               new FormDanhSachChiTietTienNghi(MaLP, TenLP, formMain, this.taiKhoan1))
                        {
                            formBackground.Owner = formMain;
                            formBackground.Show();
                            formDanhSachChiTietTienNghi.Owner = formBackground;
                            formDanhSachChiTietTienNghi.ShowDialog();
                            this.LoadAllDataGrid();
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

                // Nếu click vào cột chỉnh sửa loại phòng (edit)
                if (x == 8)
                {
                    // Kiểm tra quyền, nhân viên thường không được sửa loại phòng
                    if (taiKhoan1.CapDoQuyen == 1)
                    {
                        CTMessageBox.Show("Bạn không có quyền thực hiện thao tác này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    FormBackground formBackground = new FormBackground(formMain);
                    try
                    {
                        using (FormSuaLoaiPhong formSuaLoaiPhong =
                               new FormSuaLoaiPhong(LoaiPhongBUS.Instance.getLoaiPhong(grid.Rows[y].Cells[1].Value.ToString())))
                        {
                            formBackground.Owner = formMain;
                            formBackground.Show();
                            formSuaLoaiPhong.Owner = formBackground;
                            formSuaLoaiPhong.ShowDialog();
                            formBackground.Dispose();
                        }
                        LoadAllDataGrid();
                    }
                    catch (Exception)
                    {
                        CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        formBackground.Dispose();
                    }
                }
            }
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

        private void CTTextBoxTimPhongTheoMa__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxFindNameLP = sender as TextBox;
            textBoxFindNameLP.TextChanged += TextBoxFindNameLP_TextChanged;
        }

        // Xử lý tìm kiếm loại phòng theo tên, cập nhật danh sách hiển thị trên lưới
        private void TextBoxFindNameLP_TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxFindNameLP = sender as TextBox;

            // Nếu ô tìm kiếm không được focus (ví dụ đang hiển thị placeholder), tải lại toàn bộ dữ liệu
            if (textBoxFindNameLP.Focused == false)
            {
                LoadAllDataGrid();
                return;
            }

            // Lọc loại phòng theo tên nhập vào và đổ lại dữ liệu lên lưới
            this.loaiPhongs = LoaiPhongBUS.Instance.getLoaiPhongWithName(textBoxFindNameLP.Text);
            LoadDataGrid();
        }

        // Khi chuột rời khỏi ô, trả con trỏ về mặc định
        private void grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            grid.Cursor = Cursors.Default;
        }
    }
}
