using ApplicationSettings;
using HotelManagement.BUS;
using HotelManagement.CTControls;
using HotelManagement.DTO;
using HotelManagement.Utils;
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
    public partial class FormDatPhong : Form
    {
        // Khai báo các biến
        private int borderRadius = 15;
        private int borderSize = 2;
        private Color borderColor = Color.White;
        private List<CTDP> listPhongDaDat = new List<CTDP>();
        private Image Add = Properties.Resources.Add;
        private Image Del = Properties.Resources.delete1;
        private KhachHang khachHang = new KhachHang();
        private int caseForm = 0;
        private int flagHoTen = 0;     
        private TaiKhoan taiKhoan;
        private PhieuThue phieuThue;
        private DateTime CheckIn = DateTime.Now;  // flag = 1
        private DateTime CheckOut = DateTime.Now; // flag = 2
        private decimal TienCoc;
        //Constructor
        public FormDatPhong()
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            InitializeComponent();
            phieuThue.MaPT = PhieuThueBUS.Instance.GetMaPTNext();
        }
        public FormDatPhong(TaiKhoan taiKhoan, PhieuThue phieuThue = null)
        {
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.taiKhoan = taiKhoan;
            this.phieuThue = phieuThue;
            InitializeComponent();

        }
        //Drag Form
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
            colors.TopLeftColor = Color.FromArgb(67, 73, 73);
            colors.TopRightColor = Color.FromArgb(67, 73, 73);
            colors.BottomLeftColor = Color.FromArgb(67, 73, 73);
            colors.BottomRightColor = Color.FromArgb(67, 73, 73);
            return colors;
        }

        private void FormDatPhong_Paint(object sender, PaintEventArgs e)
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
        private void FormDatPhong_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormDatPhong_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void FormDatPhong_Activated(object sender, EventArgs e)
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

        private void CTButtonHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        // Hàm load thời gian mặc định cho 4 combo box (giờ + AM/PM)
        // Lấy giờ hệ thống, chuyển 24h sang 12h, format HH:mm và gán vào UI
        private void setLoadComboBox()
        {
            DateTime datetime = DateTime.Now;
            int iHour = datetime.Hour; string strHour = null;
            int iMinute = datetime.Minute; string strMinute = null;
            string letter = null;
            if (iHour > 12)
            {
                iHour -= 12;
                letter = "   PM";
            }
            else if (iHour == 12)
                letter = "   PM";
            else if (iHour < 12)
            {
                if (iHour == 0)
                    iHour = 12;
                letter = "   AM";
            }
            strHour = iHour.ToString();
            strMinute = iMinute.ToString();
            if (strMinute.Length == 1)
                strMinute = "0" + strMinute;
            if (strHour.Length == 1)
                strHour = "0" + strHour;
            cbBoxGioBatDau.Texts = strHour + ':' + strMinute;
            cbBoxLetterBatDau.Texts = letter;
            cbBoxGioKetThuc.Texts = strHour + ':' + strMinute;
            cbBoxLetterKetThuc.Texts = letter;
        }
        // Khởi tạo dữ liệu và giao diện khi form load
        private void FormDatPhong_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = label1;
                // Thiết kế Dgv khi bắt đầu tải form
                DataGridView grid1 = gridPhongTrong;
                DataGridView grid2 = gridPhongDaChon;
                grid1.ColumnHeadersDefaultCellStyle.Font = new Font(grid1.Font, FontStyle.Bold);
                LoadgridPhongTrong();
                LoadGridPhongDat();
                setLoadComboBox();
                LoadTenKH();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Tải thông tin khách hàng
        private void LoadTenKH()
        {
            try
            {
                if (this.phieuThue != null)
                {
                    caseForm = 1;
                    CTTextBoxNhapSDT.RemovePlaceholder();
                    CTTextBoxNhapDiaChi.RemovePlaceholder();
                    CTTextBoxNhapHoTen.RemovePlaceholder();
                    CTTextBoxNhapCCCD.RemovePlaceholder();
                    this.khachHang = KhachHangBUS.Instance.FindKhachHang(this.phieuThue.MaKH);
                    this.CTTextBoxNhapCCCD.Texts = khachHang.CCCD_Passport;
                    this.CTTextBoxNhapHoTen.Texts = khachHang.TenKH;
                    this.CTTextBoxNhapSDT.Texts = khachHang.SDT;
                    this.ComboBoxGioiTinh.Texts = "  " + khachHang.GioiTinh;
                    this.CTTextBoxNhapDiaChi.Texts = khachHang.QuocTich;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //  Tải form phòng trống
        private void LoadgridPhongTrong()
        {
            try
            {
                gridPhongTrong.Rows.Clear();
                List<Phong> phongs = PhongBUS.Instance.FindPhongTrong(this.CheckIn, this.CheckOut, listPhongDaDat);
                phongs = phongs.Where(p => p.TTPH == "Bình thường").ToList();
                foreach (Phong phong in phongs)
                {
                    gridPhongTrong.Rows.Add(new object[] { phong.MaPH, phong.LoaiPhong.TenLPH, this.Add });
                }
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(ex.Message);
            }
        }
        private void LoadGridPhongDat()
        {
            try
            {
                gridPhongDaChon.Rows.Clear();
                if (this.listPhongDaDat != null)
                {
                    foreach (CTDP room in listPhongDaDat)
                    {
                        gridPhongDaChon.Rows.Add(room.MaPH, room.SoNguoi, room.CheckIn.ToString("dd/MM/yyyy HH:mm:ss"), room.CheckOut.ToString("dd/MM/yyyy HH:mm:ss"), this.Del);
                    }
                }
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(ex.Message);
            }
        }
        // Chọn phòng trống để thêm vào danh sách phòng đã đặt
        private void gridPhongTrong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            if (y >= 0 && x == 2)
            {
                try
                {

                    setDate(CTDatePickerNgayBD.Value, 1);
                    setTime(cbBoxGioBatDau.Texts, cbBoxLetterBatDau.Texts, 1);

                    setDate(CTDatePickerNgayKT.Value, 2);
                    setTime(cbBoxGioKetThuc.Texts, cbBoxLetterKetThuc.Texts, 2);
                    if (this.CheckIn < DateTime.Now)
                    {
                        CTMessageBox.Show("Thời gian bắt đầu không hợp lệ.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.CheckIn < this.CheckOut)
                    {
                        CTDP cTDP = new CTDP();
                        cTDP.MaCTDP = CTDP_BUS.Instance.getNextCTDPwithList(this.listPhongDaDat);
                        cTDP.CheckIn = this.CheckIn;
                        cTDP.CheckOut = this.CheckOut;
                        cTDP.MaPH = gridPhongTrong.Rows[y].Cells[0].Value.ToString();
                        cTDP.Phong = PhongBUS.Instance.FindePhong(cTDP.MaPH);
                        cTDP.SoNguoi = cTDP.Phong.LoaiPhong.SoNguoiToiDa;
                        cTDP.DonGia = cTDP.Phong.LoaiPhong.GiaNgay;
                        cTDP.TrangThai = "Đã đặt";

                        listPhongDaDat.Add(cTDP);
                        LoadGridPhongDat();
                        LoadgridPhongTrong();
                    }
                    else
                    {
                        CTMessageBox.Show("Thời gian bắt đầu không được sau thời gian kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    CTMessageBox.Show(ex.Message);
                }
            }
        }

        #region Xóa phòng
        // Gán lại mã CTDP theo thứ tự mới sau khi thêm/xóa
        private void SetMaCTDP(List<CTDP> list)
        {
            try
            {
                int i = 1;
                int MaMax = CTDP_BUS.Instance.GetCTDPs().Count;
                int tong;
                foreach (CTDP cTDP in list)
                {
                    tong = MaMax + i;
                    if (tong < 10)
                    {
                        cTDP.MaCTDP = "CTDP00" + tong.ToString();
                    }
                    else if (tong < 100)
                    {
                        cTDP.MaCTDP = "CTDP0" + tong.ToString();
                    }
                    else
                        cTDP.MaCTDP = "CTDP" + tong.ToString();
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Xóa phòng đã chọn khỏi danh sách khi bấm nút xóa (cột 4)
        private void gridPhongDaChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            if (y >= 0 && x == 4)
            {
                DialogResult dialogresult = CTMessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult == DialogResult.Yes)
                {
                    try
                    {
                        foreach (CTDP ctdp in this.listPhongDaDat)
                        {
                            if (ctdp.CheckIn.ToString("dd/MM/yyyy HH:mm:ss") == gridPhongDaChon.Rows[y].Cells[2].Value.ToString() && ctdp.MaPH == gridPhongDaChon.Rows[y].Cells[0].Value.ToString())
                            {
                                this.listPhongDaDat.Remove(ctdp);
                                SetMaCTDP(listPhongDaDat);
                                LoadGridPhongDat();
                                LoadgridPhongTrong();
                                return;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        CTMessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally { }
                }
            }
        }
        #endregion

        #region Form giao diện
        private void gridPhongTrong_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = gridPhongTrong;
            int x = e.ColumnIndex, y = e.RowIndex;
            int[] arrX = { 0, 1 };
            bool isExists = false;

            if (Array.IndexOf(arrX, x) != -1)
                isExists = true;

            if (y >= 0 && x == 2 || y == -1 && isExists)
                grid.Cursor = Cursors.Hand;
            else
                grid.Cursor = Cursors.Default;
        }

        private void gridPhongTrong_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = gridPhongTrong;
            grid.Cursor = Cursors.Default;
        }

        private void gridPhongDaChon_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = gridPhongDaChon;
            int x = e.ColumnIndex, y = e.RowIndex;
            int[] arrX = { 0 };
            bool isExists = false;

            if (Array.IndexOf(arrX, x) != -1)
                isExists = true;

            if (y >= 0 && x == 4 || y == -1 && isExists)
                grid.Cursor = Cursors.Hand;
            else
                grid.Cursor = Cursors.Default;
        }

        private void gridPhongDaChon_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = gridPhongDaChon;
            grid.Cursor = Cursors.Default;
        }
        #endregion

        #region Thiết lập thời gian
        private void setDate(DateTime dateTime, int flag)
        {
            if (flag == 1)
                this.CheckIn = dateTime.Date;
            else
                this.CheckOut = dateTime.Date;
        }

        private void setTime(string Time, string Letter, int flag)
        {
            Letter = Letter.Trim(' ');
            string[] time = Time.Split(':');
            int hour = int.Parse(time[0]);
            int minute = int.Parse(time[1]);
            if (Letter == "AM" && hour == 12 || Letter == "PM" && hour != 12)
                hour += 12;

            TimeSpan ts = new TimeSpan(hour, minute, 0);
            if (flag == 1)
                this.CheckIn += ts;
            else
                this.CheckOut += ts;
        }

        private void CTDatePickerNgayBD_ValueChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayBD.Value, 1);
            setTime(cbBoxGioBatDau.Texts, cbBoxLetterBatDau.Texts, 1);
            LoadgridPhongTrong();
        }

        private void cbBoxGioBatDau_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayBD.Value, 1);
            setTime(cbBoxGioBatDau.Texts, cbBoxLetterBatDau.Texts, 1);
            LoadgridPhongTrong();
        }

        private void cbBoxLetterBatDau_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayBD.Value, 1);
            setTime(cbBoxGioBatDau.Texts, cbBoxLetterBatDau.Texts, 1);
            LoadgridPhongTrong();
        }

        private void CTDatePickerNgayKT_ValueChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayKT.Value, 2);
            setTime(cbBoxGioKetThuc.Texts, cbBoxLetterKetThuc.Texts, 2);
            LoadgridPhongTrong();
        }

        private void cbBoxGioKetThuc_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayKT.Value, 2);
            setTime(cbBoxGioKetThuc.Texts, cbBoxLetterKetThuc.Texts, 2);
            LoadgridPhongTrong();
        }

        private void cbBoxLetterKetThuc_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            setDate(CTDatePickerNgayKT.Value, 2);
            setTime(cbBoxGioKetThuc.Texts, cbBoxLetterKetThuc.Texts, 2);
            LoadgridPhongTrong();
        }
        #endregion

        // Xử lý khi bấm nút "Đặt trước phòng"
        private void CTButtonDatTruoc_Click(object sender, EventArgs e)
        {
            // Chưa chọn phòng nào
            if (listPhongDaDat.Count == 0)
            {
                CTMessageBox.Show("Chưa thêm thông tin đặt phòng", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Kiểm tra nhập liệu cơ bản
            if (this.CTTextBoxNhapCCCD.Texts != "" &&
                this.CTTextBoxNhapDiaChi.Texts != "" &&
                this.CTTextBoxNhapHoTen.Texts != "" &&
                this.ComboBoxGioiTinh.Texts != "  Giới tính")
            {
                // Kiểm tra độ dài CCCD/Passport
                if (CTTextBoxNhapCCCD.Texts.Length < 12 && CTTextBoxNhapCCCD.Texts.Length > 7)
                {
                    CTMessageBox.Show("Vui lòng nhập đầy đủ số CCCD/Passport.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Kiểm tra SĐT
                if (CTTextBoxNhapSDT.Texts.Length < 9)
                {
                    CTMessageBox.Show("Vui lòng nhập đầy đủ SĐT.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Kiểm tra email
                if (!CTTextBoxNhapEmail.Texts.Contains("@") ||
                    !CTTextBoxNhapEmail.Texts.Contains("."))
                {
                    CTMessageBox.Show("Email không hợp lệ!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Hỏi khách có muốn thanh toán cọc không
                DialogResult ask = CTMessageBox.Show(
                    "Bạn có muốn xác nhận đặt phòng?",
                    "Xác nhận đặt cọc",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (ask == DialogResult.No) return; 
                // Tính tổng tiền đặt cọc (30% giá phòng)
                foreach (CTDP ctdp in listPhongDaDat)
                {
                    decimal tiendatcoc =
                        (decimal)PhongBUS.Instance.FindePhong(ctdp.MaPH).LoaiPhong.GiaNgay * 0.3m;
                    TienCoc += tiendatcoc;
                }
                // Mở form thanh toán đặt cọc
                FormDatCoc f = new FormDatCoc(TienCoc, "Tien dat coc phong");
                var result = f.ShowDialog();
                    
                // Nếu thanh toán thất bại hoặc bị hủy
                if (result != DialogResult.OK)
                {
                    CTMessageBox.Show("Thanh toán thất bại hoặc bị hủy.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Thanh toán OK → tiến hành lưu dữ liệu
                try
                {
                    CreateKH();          
                    CreatePhieuThue();   
                    CreateCTDP();       
                    CreateHoaDon();      
                    // Gửi email xác nhận
                    bool EmailSent = SendBookingEmail(khachHang, phieuThue, listPhongDaDat);
                    if (EmailSent)
                    {
                        CTMessageBox.Show("Đặt phòng thành công!\nVui lòng kiểm tra email xác nhận.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        CTMessageBox.Show(
                            "Đặt phòng thành công!\n(Hệ thống không gửi được email xác nhận).",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    CTMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Close(); 
                }
            }
            else
            {
                // Thiếu thông tin khách hàng
                CTMessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Thông báo",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Tạo hoặc cập nhật thông tin khách hàng (KH cũ → update, KH mới → tạo mã mới)
        private void CreateKH()
        {
            try
            {
                // Nếu chưa có mã khách → khách mới → tạo mã mới
                if (string.IsNullOrEmpty(khachHang.MaKH))
                    khachHang.MaKH = KhachHangBUS.Instance.GetMaKHNext();
                // Gán thông tin khách từ form
                khachHang.TenKH = CTTextBoxNhapHoTen.Texts;
                khachHang.CCCD_Passport = CTTextBoxNhapCCCD.Texts;
                khachHang.SDT = CTTextBoxNhapSDT.Texts;
                khachHang.QuocTich = CTTextBoxNhapDiaChi.Texts;
                khachHang.GioiTinh = ComboBoxGioiTinh.Texts.Trim();
                khachHang.Email = CTTextBoxNhapEmail.Texts;
                // Lưu vào CSDL (thêm mới hoặc cập nhật)
                KhachHangBUS.Instance.UpdateOrAdd(khachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Tạo phiếu thuê nếu chưa có (khi đặt phòng mới)
        private void CreatePhieuThue()
        {
            if (phieuThue == null)
            {
                try
                {
                    phieuThue = new PhieuThue();
                    phieuThue.MaPT = PhieuThueBUS.Instance.GetMaPTNext(); 
                    phieuThue.MaNV = taiKhoan.MaNV;                     
                    phieuThue.DaXoa = false;
                    phieuThue.MaKH = khachHang.MaKH;                     
                    phieuThue.NgPT = DateTime.Now;                        

                    PhieuThueBUS.Instance.AddOrUpdatePhieuThue(phieuThue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // Tạo chi tiết đặt phòng (CTDP) cho từng phòng được chọn
        void CreateCTDP()
        {
            try
            {
                foreach (CTDP ctdp in listPhongDaDat)
                {
                    ctdp.MaPT = phieuThue.MaPT;      // Gắn vào phiếu thuê vừa tạo
                    ctdp.TrangThai = "Đã cọc";       // Trạng thái trước khi check-in
                    ctdp.DaXoa = false;
                    // Ghi số tiền đặt cọc (30% giá phòng)
                    ctdp.TienDatCoc =
                        (decimal)PhongBUS.Instance.FindePhong(ctdp.MaPH).LoaiPhong.GiaNgay * 0.3m;
                    // Lưu vào CSDL
                    CTDP_BUS.Instance.UpdateOrAddCTDP(ctdp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Tạo hóa đơn đặt cọc riêng cho từng phòng
        private void CreateHoaDon()
        {
            foreach (CTDP ctdp in listPhongDaDat)
            {
                try
                {
                    Phong phong = PhongBUS.Instance.FindePhong(ctdp.MaPH);
                    HoaDon hd = new HoaDon();
                    hd.MaHD = HoaDonBUS.Instance.getMaHDNext();   
                    hd.MaCTDP = ctdp.MaCTDP;                     
                    hd.MaNV = taiKhoan.MaNV;                     
                    hd.NgHD = DateTime.Now;                       
                    hd.TrangThai = "Đã đặt cọc";
                    HoaDonBUS.Instance.ThanhToanHD(hd);                   
                }
                catch (Exception ex)
                {
                    CTMessageBox.Show(
                        ex.InnerException?.Message ?? ex.Message,
                        "Lỗi khi tạo hóa đơn",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            // THông báo sau khi tạo xong tất cả hóa đơn
            CTMessageBox.Show(
                "Tạo hóa đơn đặt cọc thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        private void CTTextBoxNhapHoTen__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxNotNumber = sender as TextBox;
            textBoxNotNumber.KeyPress += TextBoxNotNumber_KeyPress;
        }
        private void TextBoxNotNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxNotNumber(e);
        }
        private void CTTextBoxNhapCCCD__TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.MaxLength = 12;
            txt.KeyPress += TextBoxOnlyNumber_KeyPress;
            string cccd = txt.Text.Trim(); 
            KhachHang khInDb = KhachHangBUS.Instance.FindKHWithCCCD(cccd);
            // Trường hợp 1: Khách hàng đã tồn tại
            if (khInDb != null)
            {
                // Gán vào biến toàn cục
                this.khachHang = khInDb;
                CTTextBoxNhapHoTen.RemovePlaceholder();
                CTTextBoxNhapSDT.RemovePlaceholder();
                CTTextBoxNhapDiaChi.RemovePlaceholder();
                CTTextBoxNhapEmail.RemovePlaceholder();
                // Tự động điền
                CTTextBoxNhapHoTen.Texts = khachHang.TenKH;
                CTTextBoxNhapSDT.Texts = khachHang.SDT;
                CTTextBoxNhapDiaChi.Texts = khachHang.QuocTich;
                ComboBoxGioiTinh.Texts = "  " + khachHang.GioiTinh;
                CTTextBoxNhapEmail.Texts = khachHang.Email;
                // Khóa không cho chỉnh sửa
                CTTextBoxNhapHoTen.Enabled = false;
                CTTextBoxNhapSDT.Enabled = false;
                CTTextBoxNhapDiaChi.Enabled = false;
                ComboBoxGioiTinh.Enabled = false;
                CTTextBoxNhapEmail.Enabled = false;
                flagHoTen = 1;   // đang dùng KH cũ
            }
            else
            {
                //  TRƯỜNG HỢP 2: KH MỚI
                // Mở khóa các trường
                CTTextBoxNhapHoTen.Enabled = true;
                CTTextBoxNhapSDT.Enabled = true;
                CTTextBoxNhapDiaChi.Enabled = true;
                ComboBoxGioiTinh.Enabled = true;
                CTTextBoxNhapEmail.Enabled = true;
                // Làm mới thông tin (nếu trước đó là KH cũ)
                if (flagHoTen == 1)
                {
                    CTTextBoxNhapHoTen.Texts = "";
                    CTTextBoxNhapSDT.Texts = "";
                    CTTextBoxNhapDiaChi.Texts = "";
                    ComboBoxGioiTinh.Texts = "  Giới tính";
                    CTTextBoxNhapEmail.Texts = "";
                }
                // KH mới
                this.khachHang = new KhachHang();
                flagHoTen = 0;
            }
        }
        private void CTTextBoxNhapSDT__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxOnlyNumber = sender as TextBox;
            textBoxOnlyNumber.MaxLength = 10;
            textBoxOnlyNumber.KeyPress += TextBoxOnlyNumber_KeyPress;
        }

        private void TextBoxOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxOnlyNumber(e);
        }
        private void CTTextBoxNhapDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxType.Instance.TextBoxNotNumber(e);
        }
        private bool SendBookingEmail(KhachHang kh, PhieuThue phieuThue, List<CTDP> listPhong)
        {
            try
            {
                string body = EmailHelper.GetBookingEmailBody(kh, phieuThue, listPhong);
                bool KQ = EmailHelper.SendEmail(kh.Email, "Xác nhận đặt phòng khách sạn", body);
                return KQ;
            }
            catch
            {
                return false;
            }
        }
    }
}

