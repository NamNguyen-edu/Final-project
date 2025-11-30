using HotelManagement.BUS;
using HotelManagement.CTControls;
using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HotelManagement.GUI
{
    public partial class FormThemDichVuVaoPhong : Form
    {
        private Image Del = Properties.Resources.delete1; 
        private Image Add = Properties.Resources.Add;     
        private List<DichVu> dichVus = new List<DichVu>();
        private List<CTDV> dichVusDaDat = new List<CTDV>();
        private List<int?> SLDVConLai = new List<int?>();
        private List<int> SLDVDaDat = new List<int>();

        
        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = AppTheme.PopupMainBackground;
        private DichVu dichVu;
        FormDanhSachDichVu formDanhSachDichVu;
        private CTDP ctdp;

        private decimal ParseMoney(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0;

            // Lấy hết ký tự số, bỏ hết dấu . , khoảng trắng
            string digits = new string(value.Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(digits))
                return 0;

            return decimal.Parse(digits);
        }

        public FormThemDichVuVaoPhong(CTDP cTDP)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.ctdp = cTDP;
            HotelManagement.CTControls.ThemeManager.ApplyThemeToRoomPopup(this);
            InitializeComponent();
            LoadGridDaChonLanDau();
            LoadGridDichVuLanDau();
        }


        #region Load Grid Checked
        private void LoadGridDaChonLanDau()
        {
            try
            {
                // Lấy danh sách dịch vụ mà phòng này đã đặt trước đó từ DB
                List<CTDV> cTDVs = CTDV_BUS.Instance.FindCTDV(this.ctdp.MaCTDP);
                if (cTDVs != null)
                {
                    foreach (CTDV cTDV in cTDVs)
                    {
                        // Tạo bản sao (copy) để không ảnh hưởng dữ liệu gốc trong DB khi thao tác tạm
                        CTDV cTDV1 = new CTDV(cTDV);
                        this.dichVusDaDat.Add(cTDV1);     
                        this.SLDVDaDat.Add(cTDV.SL);
                    }
                }
                LoadGridDaChon();
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(ex.Message); // Hiển thị lỗi nếu có
            }
        }

        private void LoadGridDaChon()
        {
            try
            {
                dgvDVDaChon.Rows.Clear();  // Xóa hết để load lại từ đầu
                foreach (CTDV v in dichVusDaDat)
                {
                    if (v.SL != 0) // Chỉ hiển thị dịch vụ còn SL > 0
                    {

                        DichVu dichVu = DichVuBUS.Instance.FindDichVu(v.MaDV);

                        dgvDVDaChon.Rows.Add(dichVu.TenDV, v.SL, v.ThanhTien.ToString("#,#"), Del);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region LoadGridDV
        private void LoadGridDichVuLanDau()
        {
            try
            {
                List<DichVu> dichVusDb = DichVuBUS.Instance.GetDichVus();
                foreach (DichVu dv in dichVusDb)
                {
                    // Tạo bản copy để hiển thị và thao tác tạm trên form
                    this.dichVus.Add(new DichVu(dv));
                    // Lưu tồn kho ban đầu cho mỗi dịch vụ
                    this.SLDVConLai.Add(dv.SLConLai);
                }
                LoadGridDichVu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadGridDichVu()
        {
            gridDichVu.Rows.Clear();
            foreach (DichVu v in dichVus)
            {
                if (v.SLConLai == -1) // -1 nghĩa là dịch vụ không giới hạn số lượng
                {
                    gridDichVu.Rows.Add(v.TenDV, v.DonGia.ToString("#,#"), "", Add);
                }
                else
                    gridDichVu.Rows.Add(v.TenDV, v.DonGia.ToString("#,#"), v.SLConLai, Add);
            }
        }
        #endregion

        #region Draw Form + Border
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

        private void FormThemDichVuVaoPhong_Paint(object sender, PaintEventArgs e)
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

        private void FormThemDichVuVaoPhong_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormThemDichVuVaoPhong_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormThemDichVuVaoPhong_Activated(object sender, EventArgs e)
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
            ControlRegionAndBorder(PanelBackground, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }
        #endregion

        private void CTButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Chọn thêm dịch vụ từ Grid Dịch vụ
        private void gridDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;

            if (y >= 0 && x == 3)
            {
                #region Thêm dịch vụ
                try
                {
                    // Lấy đơn giá từ ô cột 1 của dòng (dạng chuỗi có dấu . ,)
                    decimal dongia = ParseMoney(gridDichVu.Rows[y].Cells[1].Value.ToString());

                    // Tìm đúng dịch vụ trong danh sách "dichVus" theo Tên DV + Đơn Giá
                    string tenDV = gridDichVu.Rows[y].Cells[0].Value.ToString();
                    DichVu dichVu = dichVus
                        .Where(p => p.TenDV == tenDV && p.DonGia == dongia)
                        .SingleOrDefault();

                    if (dichVu == null)
                    {
                        MessageBox.Show("Không tìm thấy dịch vụ tương ứng.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xử lý tồn kho dịch vụ (nếu có giới hạn)
                    if (dichVu.SLConLai >= 1)
                    {
                        dichVu.SLConLai--; // Giảm tồn kho khi thêm
                        gridDichVu.Rows[y].Cells[2].Value = dichVu.SLConLai;
                    }
                    else if (dichVu.SLConLai == 0)
                    {
                        CTMessageBox.Show("Số lượng hàng trong kho đã hết!!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    // Kiểm tra dịch vụ đã có trong danh sách đã chọn hay chưa
                    foreach (DataGridViewRow dataRow in dgvDVDaChon.Rows)
                    {
                        if (dataRow.Cells[0].Value == null) continue;

                        // Tên + đơn giá phải trùng
                        string tenDaChon = dataRow.Cells[0].Value.ToString();
                        int slDaChon = int.Parse(dataRow.Cells[1].Value.ToString());
                        decimal thanhTienRow = ParseMoney(dataRow.Cells[2].Value.ToString());
                        decimal donGiaRow = (slDaChon == 0) ? 0 : thanhTienRow / slDaChon;

                        if (tenDaChon == dichVu.TenDV && donGiaRow == dichVu.DonGia)
                        {
                            // Lấy đúng CTDV đã lưu trong danh sách tạm
                            CTDV cTDV = dichVusDaDat
                                .Where(p => p.MaDV == dichVu.MaDV)
                                .FirstOrDefault();

                            if (cTDV != null)
                            {
                                cTDV.SL++;
                                cTDV.ThanhTien = cTDV.DonGia * cTDV.SL;

                                dataRow.Cells[1].Value = cTDV.SL;
                                dataRow.Cells[2].Value = cTDV.ThanhTien.ToString("#,#");
                            }

                            return; // Đã xử lý xong, không thêm dòng mới
                        }
                    }
                    // Dịch vụ lần đầu thêm vào danh sách đã chọn
                    CTDV cTDV1 = new CTDV();
                    cTDV1.DonGia = dichVu.DonGia;
                    cTDV1.DaXoa = false;
                    cTDV1.ThanhTien = dichVu.DonGia;
                    cTDV1.MaDV = dichVu.MaDV;
                    cTDV1.MaCTDP = ctdp.MaCTDP;
                    cTDV1.SL = 1;
                    dichVusDaDat.Add(cTDV1);
                    this.LoadGridDaChon();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
        }

        // Lưu dịch vụ vào CSDL
        private void CTButtonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                DichVuBUS.Instance.UpdateDV(dichVus);
                CTDV_BUS.Instance.InsertOrUpdateList(dichVusDaDat);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Chọn xóa dịch vụ ở Grid đã chọn 
        private void dgvDVDaChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            if (y >= 0 && x == 3)
            {
                #region Xóa dịch vụ
                try
                {
                    // Đọc dữ liệu hiện tại trên lưới
                    int currentSL = int.Parse(dgvDVDaChon.Rows[y].Cells[1].Value.ToString());
                    decimal thanhTien = ParseMoney(dgvDVDaChon.Rows[y].Cells[2].Value.ToString());
                    decimal donGia = (currentSL == 0) ? 0 : thanhTien / currentSL;
                    string tenDV = dgvDVDaChon.Rows[y].Cells[0].Value.ToString();

                    // Tìm DichVu tương ứng trong list dichVus để cộng lại tồn kho
                    DichVu dv = dichVus
                        .Where(p => p.TenDV == tenDV && p.DonGia == donGia)
                        .SingleOrDefault();

                    // Tìm CTDV tương ứng trong danh sách dichVusDaDat
                    CTDV cTDV = null;
                    if (dv != null)
                    {
                        cTDV = dichVusDaDat
                            .Where(p => p.MaDV == dv.MaDV && p.DonGia == dv.DonGia)
                            .FirstOrDefault();
                    }

                    if (dv == null || cTDV == null)
                    {
                        // Trường hợp dữ liệu không khớp, tránh crash
                        MessageBox.Show("Không tìm thấy dịch vụ tương ứng để cập nhật.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // 1. CỘNG LẠI TỒN KHO (nếu không phải dịch vụ không giới hạn)
                    if (dv.SLConLai != -1)
                    {
                        dv.SLConLai++; // hoàn trả 1 đơn vị về kho
                    }
                    // 2. XỬ LÝ GIẢM HOẶC XÓA HẲN DỊCH VỤ ĐÃ ĐẶT
                    if (currentSL > 1)
                    {
                        // Giảm số lượng
                        cTDV.SL--;
                        cTDV.ThanhTien = cTDV.SL * cTDV.DonGia;

                        // Cập nhật lại lên lưới
                        dgvDVDaChon.Rows[y].Cells[1].Value = cTDV.SL;
                        dgvDVDaChon.Rows[y].Cells[2].Value = cTDV.ThanhTien.ToString("#,#");
                    }
                    else // currentSL == 1 -> xóa hẳn dịch vụ khỏi danh sách đã chọn
                    {
                        // Đánh dấu CTDV này là đã xóa + set SL = 0 
                        cTDV.SL = 0;
                        cTDV.ThanhTien = 0;
                        cTDV.DaXoa = true;
                        // Xóa dòng trên DataGridView
                        dgvDVDaChon.Rows.RemoveAt(y);
                    }
                    // 3. Cập nhật lại lưới dịch vụ để hiển thị tồn kho mới
                    LoadGridDichVu();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion
            }
        }
        // Form thêm dịch vụ vào phòng
        private void FormThemDichVuVaoPhong_Load(object sender, EventArgs e)
        {
            HotelManagement.CTControls.ThemeManager.StyleDataGridView(this.gridDichVu);
            HotelManagement.CTControls.ThemeManager.StyleDataGridView(this.dgvDVDaChon);
        }

        private void gridDichVu_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            int y = e.RowIndex, x = e.ColumnIndex;
            if (y >= 0 && x == 3)
                gridDichVu.Cursor = Cursors.Hand;
            else
                gridDichVu.Cursor = Cursors.Default;
        }

        private void gridDichVu_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridDichVu.Cursor = Cursors.Default;
        }

        private void dgvDVDaChon_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            int y = e.RowIndex, x = e.ColumnIndex;
            if (y >= 0 && x == 3)
                dgvDVDaChon.Cursor = Cursors.Hand;
            else
                dgvDVDaChon.Cursor = Cursors.Default;
        }

        private void dgvDVDaChon_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvDVDaChon.Cursor = Cursors.Default;
        }

        // Tìm dịch vụ theo tên 
        private void CTTextBoxTimTheoTenDV__TextChanged(object sender, EventArgs e)
        {
            CTTextBox txt = sender as CTTextBox;
            if (txt == null)
            {
                LoadGridDichVu();
                return;
            }
            string keyword = txt.Texts.Trim().ToLower();
            // Lọc trên danh sách dịch vụ hiện tại (so sánh không phân biệt hoa thường)
            var filtered = dichVus
                .Where(x => x.TenDV != null && x.TenDV.ToLower().Contains(keyword))
                .ToList();

            gridDichVu.Rows.Clear();
            foreach (DichVu v in filtered)
            {
                if (v.SLConLai == -1)
                    gridDichVu.Rows.Add(v.TenDV, v.DonGia.ToString("#,#"), "", Add);
                else
                    gridDichVu.Rows.Add(v.TenDV, v.DonGia.ToString("#,#"), v.SLConLai, Add);
            }
        }
    }
}
