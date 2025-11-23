using ApplicationSettings;
using HotelManagement.BUS;
using HotelManagement.CTControls;
using HotelManagement.DAO;
using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.BUS;
using HotelManagement.DTO;
using ApplicationSettings;
using HotelManagement.DAO;
using System.Runtime.CompilerServices;
using System.Net.Mail;
using System.Net;

namespace HotelManagement.GUI
{
    public partial class FormDatPhong : Form
    {
        //Fields
        private int borderRadius = 15;
        private int borderSize = 2;
        private Color borderColor = Color.White;
        private List<CTDP> listPhongDaDat = new List<CTDP>();
        private Image Add = Properties.Resources.Add; // Image for Button Thêm
        private Image Del = Properties.Resources.delete1; // Image for Button Hủy
        private KhachHang khachHang = new KhachHang();
        private int caseForm = 0;
        private int flagHoTen = 0;
        private TaiKhoan taiKhoan;
        private PhieuThue phieuThue;
        private DateTime CheckIn = DateTime.Now;  // flag = 1
        private DateTime CheckOut = DateTime.Now; // flag = 2

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
        //Control Box

        //Form Move

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
                cp.Style |= 0x20000; // <--- Minimize borderless form from taskbar
                return cp;
            }
        }

        //Private Methods
        //Private Methods
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
        private FormBoundsColors GetFormBoundsColors()
        {
            var fbColor = new FormBoundsColors();
            using (var bmp = new Bitmap(1, 1))
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle rectBmp = new Rectangle(0, 0, 1, 1);
                //Top Left
                rectBmp.X = this.Bounds.X - 1;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopLeftColor = bmp.GetPixel(0, 0);
                //Top Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopRightColor = bmp.GetPixel(0, 0);
                //Bottom Left
                rectBmp.X = this.Bounds.X;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0);
                //Bottom Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomRightColor = bmp.GetPixel(0, 0);
            }
            return fbColor;
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
        //Event Methods
        private void FormDatPhong_Paint(object sender, PaintEventArgs e)
        {
            //-> SMOOTH OUTER BORDER
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetSameDark();
            //fbColors = GetSame();
            //Top Left
            DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);
            //Top Right
            Rectangle rectTopRight = new Rectangle(mWidht, rectForm.Y, mWidht, mHeight);
            DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);
            //Bottom Left
            Rectangle rectBottomLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidht, mHeight);
            DrawPath(rectBottomLeft, e.Graphics, fbColors.BottomLeftColor);
            //Bottom Right
            Rectangle rectBottomRight = new Rectangle(mWidht, rectForm.Y + mHeight, mWidht, mHeight);
            DrawPath(rectBottomRight, e.Graphics, fbColors.BottomRightColor);
            //-> SET ROUNDED REGION AND BORDER
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

        private void FormDatPhong_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = label1;
                // Custom Dgv when loading Form
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
        private void LoadgridPhongTrong()
        {
            try
            {
                gridPhongTrong.Rows.Clear();
                //List<Phong> phongs = PhongBUS.Instance.FindPhongTrong(CTDatePickerNgayBD.Value, CTDatePickerNgayKT.Value, listPhongDaDat);
                List<Phong> phongs = PhongBUS.Instance.FindPhongTrong(this.CheckIn, this.CheckOut, listPhongDaDat);
                foreach (Phong phong in phongs)
                {
                    gridPhongTrong.Rows.Add(new object[] { phong.MaPH, phong.LoaiPhong.TenLPH, this.Add });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void gridPhongTrong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            if (y >= 0 && x == 2)
            {
                try
                {
                    //Set Date and Time for check in
                    setDate(CTDatePickerNgayBD.Value, 1);
                    setTime(cbBoxGioBatDau.Texts, cbBoxLetterBatDau.Texts, 1);

                    //Set Date and Time for check out
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
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #region Remove Room

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
        private void gridPhongDaChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.ColumnIndex, y = e.RowIndex;
            if (y >= 0 && x == 4)
            {
                // If click Remove new room
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

        #region UI Form
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

        #region Date and Time value changed
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

        private void CTButtonDatTruoc_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (listPhongDaDat.Count == 0)
            {
                CTMessageBox.Show("Chưa thêm thông tin đặt phòng", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.CTTextBoxNhapCCCD.Texts != "" && this.CTTextBoxNhapDiaChi.Texts != "" && this.CTTextBoxNhapHoTen.Texts != "" && this.ComboBoxGioiTinh.Texts != "  Giới tính")
            {
                if (CTTextBoxNhapCCCD.Texts.Length != 12 && CTTextBoxNhapCCCD.Texts.Length != 7)
                {
                    CTMessageBox.Show("Vui lòng nhập đầy đủ số CCCD/Passport.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (CTTextBoxNhapSDT.Texts.Length > 10)
                {
                    CTMessageBox.Show("Vui lòng nhập đầy đủ SĐT.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    CreateKH();
                    CreatePhieuThue();
                    CreateCTDP();
                    CreateHoaDon();
                    bool emailSent = SendBookingEmail(khachHang, phieuThue, listPhongDaDat);

                    if (!emailSent)
                    {
                        CTMessageBox.Show("Không thể gửi email xác nhận.\nVui lòng thử lại.",
                            "Lỗi gửi email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Email thành công → Thông báo
                    CTMessageBox.Show("Gửi email thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = 1;
                }
                catch (Exception ex)
                {
                    CTMessageBox.Show(ex.Message, "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (flag == 1)
                    {
                        SendBookingEmail(khachHang, phieuThue, listPhongDaDat); // Gọi hàm gửi mail

                        CTMessageBox.Show("Đặt phòng thành công\n Vui lòng kiểm tra email.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
            }
            else
            {
                CTMessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Thông báo",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateKH()
        {
            try
            {
                if (phieuThue == null)
                {
                    if (flagHoTen == 1)
                    {

                        khachHang.MaKH = this.khachHang.MaKH;
                        //CTMessageBox.Show("Thành cong");
                    }
                    else
                        khachHang.MaKH = KhachHangBUS.Instance.GetMaKHNext();
                    khachHang.SDT = CTTextBoxNhapSDT.Texts;
                    khachHang.QuocTich = CTTextBoxNhapDiaChi.Texts;
                    khachHang.TenKH = CTTextBoxNhapHoTen.Texts;
                    khachHang.CCCD_Passport = CTTextBoxNhapCCCD.Texts;
                    khachHang.GioiTinh = this.ComboBoxGioiTinh.Texts.Trim(' ');

                    KhachHangBUS.Instance.UpdateOrAdd(khachHang);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
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

        void CreateCTDP()
        {
            try
            {
                foreach (CTDP ctdp in listPhongDaDat)
                {
                    ctdp.MaPT = phieuThue.MaPT;
                    ctdp.TrangThai = "Đã đặt";
                    ctdp.DaXoa = false;
                    CTDP_BUS.Instance.UpdateOrAddCTDP(ctdp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateHoaDon()
        {
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
            TextBox textBox = sender as TextBox;
            textBox.MaxLength = 12;
            textBox.KeyPress += TextBoxOnlyNumber_KeyPress;
            if (caseForm == 0)
            {
                if (KhachHangBUS.Instance.FindKHWithCCCD(textBox.Text) != null)
                {
                    CTMessageBox.Show("Đã tồn tại số CCCD/Passport này trong danh sách.\r\nThông tin sẽ được tự động điền.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CTTextBoxNhapSDT.RemovePlaceholder();
                    CTTextBoxNhapDiaChi.RemovePlaceholder();
                    CTTextBoxNhapHoTen.RemovePlaceholder();
                    // CTTextBoxNhapCCCD.RemovePlaceholder();


                    khachHang = KhachHangBUS.Instance.FindKHWithCCCD(textBox.Text);
                    CTTextBoxNhapSDT.Texts = khachHang.SDT;
                    CTTextBoxNhapDiaChi.Texts = khachHang.QuocTich;
                    ComboBoxGioiTinh.Texts = khachHang.GioiTinh;
                    CTTextBoxNhapHoTen.Texts = khachHang.TenKH;
                    //khóa k cho đổi thông tin
                    CTTextBoxNhapCCCD.Enabled = false;
                    CTTextBoxNhapHoTen.Enabled = false;
                    CTTextBoxNhapSDT.Enabled = false;
                    CTTextBoxNhapDiaChi.Enabled = false;
                    ComboBoxGioiTinh.Enabled = false;

                    ComboBoxGioiTinh.Focus();
                    flagHoTen = 1;
                }
            }
        }

        private void CTTextBoxNhapSDT__TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxOnlyNumber = sender as TextBox;
            textBoxOnlyNumber.MaxLength = 9;
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
                string smtpHost = "smtp.gmail.com"; 
                int smtpPort = 587;
                string smtpUser = "ngynam05@gmail.com";
                string smtpPass = "pass"; // Sử dụng app password

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(smtpUser, "Hotel Management System");
                mail.To.Add(kh.Email);
                mail.Subject = "📌 Xác nhận đặt phòng khách sạn";
                mail.IsBodyHtml = true;
                StringBuilder sb = new StringBuilder();

                foreach (var ctdp in listPhong)
                {
                    Phong phong = null;
                    try
                    {
                        phong = PhongBUS.Instance.FindePhong(ctdp.MaPH);
                    }
                    catch { }

                    string tenLoaiPhong = phong?.LoaiPhong?.TenLPH ?? "(Không có thông tin)";

                    sb.Append($@"
                <tr style='border-bottom:1px solid #eee;'>
                    <td style='padding:10px;'>{ctdp.MaPH}</td>
                    <td style='padding:10px;'>{tenLoaiPhong}</td>
                    <td style='padding:10px;'>{ctdp.CheckIn:dd/MM/yyyy HH:mm}</td>
                    <td style='padding:10px;'>{ctdp.CheckOut:dd/MM/yyyy HH:mm}</td>
                </tr>
            ");
                }

                string bangPhong = sb.ToString();

                string htmlBody = $@"
                <!DOCTYPE html>
                <html lang='vi'>
                <head>
                    <meta charset='UTF-8'>
                    <title>Xác nhận đặt phòng</title>
                </head>

                <body style='font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f4f4f4;'>

                    <table width='100%' cellpadding='0' cellspacing='0'>
                        <tr>
                            <td style='padding: 20px 0;'>

                                <table width='600' cellpadding='0' cellspacing='0' 
                                    style='margin: 0 auto; background: #ffffff; 
                                    border: 1px solid #ddd; border-radius: 10px; overflow: hidden;'>

                                    <!-- Header -->
                                    <tr>
                                        <td style='background-color: #f9f4f0; padding: 25px; text-align: center; border-bottom: 1px solid #e0c9b6;'>
                                            <h1 style='margin: 0; color: #6b4f4f; font-size: 24px;'>Hotel Management</h1>
                                        </td>
                                    </tr>

                                    <!-- Content -->
                                    <tr>
                                        <td style='padding: 30px 40px; color: #333;'>

                                            <h2 style='color: #6b4f4f; font-size: 22px; margin-top: 0;'>Xác nhận đặt phòng thành công!</h2>

                                            <p>Chào <strong>{kh.TenKH}</strong>,</p>
                                            <p>Cảm ơn bạn đã đặt phòng tại hệ thống của chúng tôi. Vui lòng kiểm tra thông tin dưới đây:</p>

                                            <!-- Thông tin chung -->
                                            <table width='100%' style='border-collapse: collapse; margin-top: 20px;'>
                                                <tr style='border-bottom: 1px solid #eee;'>
                                                    <td style='padding: 12px 0; font-weight: bold;'>Mã phiếu thuê:</td>
                                                    <td style='padding: 12px 0; text-align: right;'>{phieuThue.MaPT}</td>
                                                </tr>
                                                <tr style='border-bottom: 1px solid #eee;'>
                                                    <td style='padding: 12px 0; font-weight: bold;'>Ngày đặt:</td>
                                                    <td style='padding: 12px 0; text-align: right;'>{phieuThue.NgPT:dd/MM/yyyy HH:mm}</td>
                                                </tr>
                                            </table>

                                            <!-- Thông tin phòng -->
                                            <h3 style='color: #6b4f4f; font-size: 18px; margin-top: 30px;'>Danh sách phòng đã đặt</h3>

                                            <table width='100%' cellpadding='0' cellspacing='0' 
                                                style='border-collapse: collapse; margin-top: 10px;'>
                                
                                                <tr style='background: #f0f0f0; border-bottom:1px solid #ddd;'>
                                                    <th style='padding:10px; text-align:left;'>Phòng</th>
                                                    <th style='padding:10px; text-align:left;'>Loại phòng</th>
                                                    <th style='padding:10px; text-align:left;'>Check-in</th>
                                                    <th style='padding:10px; text-align:left;'>Check-out</th>
                                                </tr>

                                                {bangPhong}
                                            </table>

                                            <!-- Thông tin khách hàng -->
                                            <h3 style='color: #6b4f4f; font-size: 18px; margin-top: 30px;'>Thông tin khách hàng</h3>

                                            <table width='100%' style='border-collapse: collapse;'>
                                                <tr style='border-bottom: 1px solid #eee;'>
                                                    <td style='padding: 12px 0; font-weight: bold;'>Họ và tên:</td>
                                                    <td style='padding: 12px 0; text-align: right;'>{kh.TenKH}</td>
                                                </tr>
                                                <tr style='border-bottom: 1px solid #eee;'>
                                                    <td style='padding: 12px 0; font-weight: bold;'>Email:</td>
                                                    <td style='padding: 12px 0; text-align: right;'>{kh.Email}</td>
                                                </tr>
                                                <tr style='border-bottom: 1px solid #eee;'>
                                                    <td style='padding: 12px 0; font-weight: bold;'>Số điện thoại:</td>
                                                    <td style='padding: 12px 0; text-align: right;'>{kh.SDT}</td>
                                                </tr>
                                                <tr style='border-bottom: 1px solid #eee;'>
                                                    <td style='padding: 12px 0; font-weight: bold;'>Giới tính:</td>
                                                    <td style='padding: 12px 0; text-align: right;'>{kh.GioiTinh}</td>
                                                </tr>
                                                <tr>
                                                    <td style='padding: 12px 0; font-weight: bold;'>Quốc tịch:</td>
                                                    <td style='padding: 12px 0; text-align: right;'>{kh.QuocTich}</td>
                                                </tr>
                                            </table>

                                            <p style='margin-top: 25px;'>Nếu bạn cần hỗ trợ, xin vui lòng phản hồi email này.</p>
                                            <p>Trân trọng,<br><b>Hotel Management</b></p>

                                        </td>
                                    </tr>

                                    <!-- Footer -->
                                    <tr>
                                        <td style='padding: 20px; text-align: center; background: #f9f9f9; color: #888; font-size: 12px;'>
                                            © 2025 Hotel Management – All rights reserved.
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                    </table>

                </body>
                </html>
                ";
                mail.Body = htmlBody;

                SmtpClient smtp = new SmtpClient(smtpHost, smtpPort);
                smtp.Credentials = new NetworkCredential(smtpUser, smtpPass);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể gửi email xác nhận:\n" + ex.Message,
                                "Lỗi gửi email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

