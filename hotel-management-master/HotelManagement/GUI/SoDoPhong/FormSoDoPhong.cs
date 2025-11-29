using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.DTO;
using HotelManagement.BUS;
using HotelManagement.CTControls;
using HotelManagement.DAO;
using System.Net.NetworkInformation;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagement.GUI
{
    public partial class FormSoDoPhong : Form
    {
        private FormMain formMain;
        private List<Phong> phongs;
        private TaiKhoan taiKhoan;
        private DateTime dateTime = DateTime.Now;

        public FormSoDoPhong()
        {
            InitializeComponent();
        }

        public FormSoDoPhong(FormMain formMain,TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.formMain = formMain;
            this.taiKhoan = taiKhoan;
            LoadLanDau();
        }


        #region Load sơ đồ phòng
        // Load toàn bộ phòng từ DB và hiển thị trên sơ đồ
        public void LoadAllPhong()
        {
            try
            {
                phongs = PhongBUS.Instance.GetAllPhong();
                LoadPhong(phongs);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Load lần đầu khi mở form: cập nhật trạng thái quá hạn + load toàn bộ phòng
        public void LoadLanDau()
        {
            try
            {
                CTDP_BUS.Instance.UpdateTrangThaiQuaHan(DateTime.Now);
                this.ctDatePicker1.Value = DateTime.Now;
                phongs = PhongBUS.Instance.GetAllPhong();
                LoadPhong(phongs);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Hàm chính để render từng phòng lên layout theo trạng thái
        private void LoadPhong(List<Phong> phongs)
        {
            try
            {
                List<CTRoom> DSPhong = new List<CTRoom>();


                foreach (Phong phong in phongs)
                {
                    CTDP ctdp = CTDP_DAO.Instance.FindCTDP(phong.MaPH, this.dateTime);
                    if (phong.TTPH == "Bình thường" && ctdp != null)
                    {
                        if (ctdp.TrangThai == "Đang thuê" && (this.CTRadioButtonPhongDangThue.Checked || this.CTRadioButtonTatCaPhong.Checked))
                        {
                            CTRoomDangThue room = new CTRoomDangThue(ctdp, this, this.formMain, this.taiKhoan);
                            room.Name = "PhongDangThue";
                            if (ctdp.TheoGio == false)
                                room.setThoiGian(CTDP_BUS.Instance.getKhoangTGTheoNgay(ctdp.MaCTDP).ToString() + " Ngày");
                            else
                                room.setThoiGian(CTDP_BUS.Instance.getKhoangTGTheoGio(ctdp.MaCTDP).ToString() + " Giờ");
                            if (phong.TTDD == "Đã dọn dẹp")
                                room.setDaDonDep();
                            else
                                room.setChuaDonDep();
                            room.setMaPhong(phong.MaPH);
                            room.setLoaiPhong(phong.LoaiPhong.TenLPH);
                            DSPhong.Add(room);
                        }
                    }
                    else if (phong.TTPH == "Đang sửa chữa" && (this.CTRadioButtonPhongDangSuaChua.Checked || this.CTRadioButtonTatCaPhong.Checked))
                    {
                        CTRoomDangSuaChua room = new CTRoomDangSuaChua(phong, this, this.formMain);
                        room.Name = "PhongSuaChua";
                        room.setMaPhong(phong.MaPH);
                        if (phong.TTDD == "Đã dọn dẹp")
                            room.setDaDonDep();
                        else
                            room.setChuaDonDep();
                        room.setGhiChu(phong.GhiChu);
                        room.setLoaiPhong(phong.LoaiPhong.TenLPH);
                        DSPhong.Add(room);

                    }

                    if (phong.TTPH == "Bình thường" && ctdp != null)
                    {
                        if (ctdp.TrangThai == "Đã cọc" && (this.CTRadioButtonPhongDaDat.Checked || this.CTRadioButtonTatCaPhong.Checked))
                        {
                            CTRoomDaDat room = new CTRoomDaDat(ctdp, this, this.formMain, taiKhoan);
                            if (ctdp.TheoGio == false)
                                room.setThoiGian(CTDP_BUS.Instance.getKhoangTGTheoNgay(ctdp.MaCTDP).ToString() + " Ngày");
                            else
                                room.setThoiGian(CTDP_BUS.Instance.getKhoangTGTheoGio(ctdp.MaCTDP).ToString() + " Giờ");
                            room.Name = "PhongDaDat";
                            if (phong.TTDD == "Đã dọn dẹp")
                                room.setDaDonDep();
                            else
                                room.setChuaDonDep();
                            room.setMaPhong(phong.MaPH);
                            room.setLoaiPhong(phong.LoaiPhong.TenLPH);
                            DSPhong.Add(room);
                        }

                    }
                    if (phong.TTPH == "Bình thường" && (ctdp == null || ctdp.TrangThai == "Đã xong") && (this.CTRadioButtonPhongTrong.Checked || this.CTRadioButtonTatCaPhong.Checked))
                    {
                        CTRoomTrong room = new CTRoomTrong(phong, this, this.formMain, taiKhoan);
                        room.Name = "PhongTrong";
                        if (phong.TTDD == "Đã dọn dẹp")
                            room.setDaDonDep();
                        else
                            room.setChuaDonDep();
                        room.setMaPhong(phong.MaPH);
                        room.setLoaiPhong(phong.LoaiPhong.TenLPH);
                        DSPhong.Add(room);
                    }
                }
                this.flowLayoutPanel1.Controls.Clear();
                this.flowLayoutPanel2.Controls.Clear();
                this.flowLayoutPanel3.Controls.Clear();
                this.flowLayoutPanel4.Controls.Clear();
                this.flowLayoutPanel5.Controls.Clear();
                foreach (CTRoom cTRoom in DSPhong)
                {

                    if (cTRoom.MaPhong.StartsWith("P1"))
                    {
                        flowLayoutPanel1.Controls.Add(cTRoom);
                    }
                    else if (cTRoom.MaPhong.StartsWith("P2"))
                    {
                        flowLayoutPanel2.Controls.Add(cTRoom);
                    }
                    else if (cTRoom.MaPhong.StartsWith("P3"))
                    {
                        flowLayoutPanel3.Controls.Add(cTRoom);
                    }
                    else if (cTRoom.MaPhong.StartsWith("P4"))
                    {
                        flowLayoutPanel4.Controls.Add(cTRoom);
                    }
                    else if (cTRoom.MaPhong.StartsWith("P5"))
                    {
                        flowLayoutPanel5.Controls.Add(cTRoom);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
        // Textbox tìm kiếm thay đổi → reset timer tìm kiếm
        private void ctTextBox1__TextChanged(object sender, EventArgs e)
        {
            if(this.ctTextBox1.Texts!=null)
                ResetTimer(this.timerSearch);
        }
        // Reset timer (dùng debounce tránh load quá nhiều)
        private void ResetTimer(Timer timer)
        {
            timer.Stop();
            timer.Start();         
        }
        #region Process event radio button
        // Khi chọn radio "Phòng trống" → reload danh sách theo trạng thái
        private void CTRadioButtonPhongTrong_CheckedChanged(object sender, EventArgs e)
        {
            // SetAppear();
            this.label1.Hide();
            this.panelSoDoPhong.Hide();
            LoadAddLoaiPhong();
            LoadCheckBoxLoaiPhong();
            LoadCheckBoxTTDD();
            this.label1.Show();
            this.panelSoDoPhong.Show();
            LoadPhong(phongs);
        }
        private void LoadCheckBoxPhong()
        {
        }
        #endregion              

        #region LoadLoaiPhong
        // Lọc phòng thường đơn
        private void LoadPhongThuongDon()
        {
            phongs = phongs.Where(p => p.MaLPH == "NOR01").ToList();            
        }
        // Lọc phòng thường đôi
        private void LoadPhongThuongDoi()
        {
            phongs = phongs.Where(p => p.MaLPH == "NOR02").ToList();

        }
        // Lọc phòng VIP đơn
        private void LoadPhongVipDon()
        {
            phongs = phongs.Where(p => p.MaLPH == "VIP01").ToList();

        }
        // Lọc phòng VIP đôi
        private void LoadPhongVipDoi()
        {
            phongs = phongs.Where(p => p.MaLPH == "VIP02").ToList();

        }
        // Lọc danh sách theo textbox (mã phòng)
        private void LoadAddLoaiPhong()
        {
            phongs = PhongBUS.Instance.FindPhongWithMaPH(ctTextBox1.Texts);
        }
        // Xử lý radio loại phòng → lọc đúng loại đã chọn
        private void LoadCheckBoxLoaiPhong()
        {
            try
            {
                foreach (Control control in this.PanelLoaiPhong.Controls)
                {
                    if (control.Name != "LabelLoaiPhong")
                    {
                        CTRadioButton item = control as CTRadioButton;
                        if(item.Checked && item.Name== "CTRadioButtonPhongThuongDon")
                        {
                            LoadPhongThuongDon();
                        }    
                        else if(item.Checked && item.Name == "CTRadioButtonPhongThuongDoi")
                        {
                            LoadPhongThuongDoi();
                        }    
                        else if(item.Checked && item.Name== "CTRadioButtonPhongVIPDon")
                        {
                            LoadPhongVipDon();
                        }
                        else if(item.Checked && item.Name == "CTRadioButtonPhongVIPDoi")
                        {
                            LoadPhongVipDoi();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region TTDD
        // Lọc phòng đã dọn dẹp
        private void LoadPhongDaDonDep()
        {
            phongs = phongs.Where(p => p.TTDD == "Đã dọn dẹp").ToList();
        }
        // Lọc phòng chưa dọn dẹp
        private void LoadPhongChuaDonDep()
        {
            phongs = phongs.Where(p => p.TTDD == "Chưa dọn dẹp").ToList();
        }
        // Xử lý radio dọn dẹp → lọc theo TTDD
        private void LoadCheckBoxTTDD()
        {
            try
            {
                foreach (Control control in this.PanelTinhTrangPhong.Controls)
                {

                    if (control.Name != "LabelTinhTrangDonDep")
                    {
                        CTRadioButton item = control as CTRadioButton;
                        if(item.Checked && item.Name== "CTRadioButtonDaDonDep")
                        {
                            LoadPhongDaDonDep();
                        }    
                        else if(item.Checked && item.Name == "CTRadioButtonChuaDonDep")
                        {
                            LoadPhongChuaDonDep();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetAppear()
        {
        }
        // Hiệu ứng xuất hiện bảng phòng
        private void timerAppear_Tick(object sender, EventArgs e)
        {
            panelSoDoPhong.Dock = DockStyle.Fill;
                timerAppear.Stop();
        }
        #endregion

        #region Date and time value changed
        // Gán ngày đang xem
        private void setDate(DateTime dateTime)
        {
            this.dateTime = dateTime.Date;
        }
        // Gán giờ đang xem (chuyển AM/PM → 24h)
        private void setTime(string Time, string Letter)
        {
            Letter = Letter.Trim(' ');
            string[] time = Time.Split(':');
            int hour = int.Parse(time[0]);
            int minute = int.Parse(time[1]);
            if (Letter == "AM" && hour == 12 || Letter == "PM" && hour != 12)
                hour += 12;

            TimeSpan ts = new TimeSpan(hour, minute, 0);
            this.dateTime += ts;
        }
        // Khi chọn giờ → cập nhật danh sách phòng
        private void cbBoxGio_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            setDate(ctDatePicker1.Value);
            setTime(cbBoxGio.Texts, cbBoxLetter.Texts);
            phongs = PhongBUS.Instance.GetAllPhong();
            phongs = PhongBUS.Instance.FindPhongWithMaPH(ctTextBox1.Texts);
            LoadCheckBoxLoaiPhong();
            LoadPhong(phongs);
            LoadCheckBoxPhong();
        }
        // Khi chọn AM/PM → cập nhật danh sách phòng
        private void cbBoxLetter_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            setDate(ctDatePicker1.Value);
            setTime(cbBoxGio.Texts, cbBoxLetter.Texts);
            phongs = PhongBUS.Instance.GetAllPhong();
            phongs = PhongBUS.Instance.FindPhongWithMaPH(ctTextBox1.Texts);
            LoadCheckBoxLoaiPhong();
            LoadPhong(phongs);
            LoadCheckBoxPhong();
        }
        // Khi đổi ngày trên DatePicker
        private void ctDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            setDate(ctDatePicker1.Value);
            setTime(cbBoxGio.Texts, cbBoxLetter.Texts);
            phongs = PhongBUS.Instance.GetAllPhong();
            phongs = PhongBUS.Instance.FindPhongWithMaPH(ctTextBox1.Texts);
            LoadCheckBoxLoaiPhong();
            LoadPhong(phongs);
            LoadCheckBoxPhong();
        }
        #endregion
        // Set mặc định cho combo giờ/phút theo DateTime hiện tại
        private void setLoadComboBox(DateTime datetime)
        {
            datetime = this.dateTime;
            int iHour  = datetime.Hour; string strHour = null;
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
            cbBoxGio.Texts = strHour + ':' + strMinute;
            cbBoxLetter.Texts = letter;
        }
        // Khi form load → set vị trí focus + load giờ
        private void FormSoDoPhong_Load(object sender, EventArgs e)
        {
            this.ActiveControl = pictureBox1;
            setLoadComboBox(dateTime);
        }
        // Timer thực thi tìm kiếm sau khi user dừng gõ
        private void timerSearch_Tick(object sender, EventArgs e)
        {
            this.timerSearch.Stop();
            this.label1.Hide();
            this.panelSoDoPhong.Hide();
            LoadAddLoaiPhong();
            LoadCheckBoxLoaiPhong();
            LoadCheckBoxTTDD();
            this.label1.Show();
            this.panelSoDoPhong.Show();
            LoadPhong(phongs);
        }
        // Hiển thị chỉ phòng đang thuê
        public void ShowPhongDangThue()
        {
            CTRadioButtonPhongDangThue.Checked = true;
            CTRadioButtonPhongDaDat.Checked = false;
            CTRadioButtonPhongTrong.Checked = false;
            CTRadioButtonPhongDangSuaChua.Checked = false;
            CTRadioButtonTatCaPhong.Checked = false;

            this.label1.Hide();
            this.panelSoDoPhong.Hide();

            phongs = PhongBUS.Instance.GetAllPhong();
            LoadAddLoaiPhong();
            LoadCheckBoxLoaiPhong();
            LoadCheckBoxTTDD();
            this.label1.Show();
            this.panelSoDoPhong.Show();
            LoadPhong(phongs);
        }
        // Hiển thị chỉ phòng đã đặt (booking)
        public void ShowPhongDaDat()
        {
            CTRadioButtonPhongDangThue.Checked = false;
            CTRadioButtonPhongDaDat.Checked = true;
            CTRadioButtonPhongTrong.Checked = false;
            CTRadioButtonPhongDangSuaChua.Checked = false;
            CTRadioButtonTatCaPhong.Checked = false;

            this.label1.Hide();
            this.panelSoDoPhong.Hide();

            phongs = PhongBUS.Instance.GetAllPhong();
            LoadAddLoaiPhong();
            LoadCheckBoxLoaiPhong();
            LoadCheckBoxTTDD();
            this.label1.Show();
            this.panelSoDoPhong.Show();
            LoadPhong(phongs);
        }
        // Hiển thị chỉ phòng chưa dọn vệ sinh
        public void ShowPhongChuaDon()
        {
            CTRadioButtonTatCaPhong.Checked = true;
            CTRadioButtonPhongDangThue.Checked = false;
            CTRadioButtonPhongDaDat.Checked = false;
            CTRadioButtonPhongTrong.Checked = false;
            CTRadioButtonPhongDangSuaChua.Checked = false;

            CTRadioButtonDaDonDep.Checked = false;
            CTRadioButtonChuaDonDep.Checked = true;

            this.label1.Hide();
            this.panelSoDoPhong.Hide();

            phongs = PhongBUS.Instance.GetAllPhong();
            LoadAddLoaiPhong();
            LoadCheckBoxLoaiPhong();
            LoadCheckBoxTTDD();
            this.label1.Show();
            this.panelSoDoPhong.Show();
            LoadPhong(phongs);
        }
        // Hiển thị chỉ phòng đang sửa chữa
        public void ShowPhongDangSuaChua()
        {
            CTRadioButtonPhongDangThue.Checked = false;
            CTRadioButtonPhongDaDat.Checked = false;
            CTRadioButtonPhongTrong.Checked = false;
            CTRadioButtonPhongDangSuaChua.Checked = true;
            CTRadioButtonTatCaPhong.Checked = false;

            this.label1.Hide();
            this.panelSoDoPhong.Hide();

            phongs = PhongBUS.Instance.GetAllPhong();
            LoadAddLoaiPhong();
            LoadCheckBoxLoaiPhong();
            LoadCheckBoxTTDD();
            this.label1.Show();
            this.panelSoDoPhong.Show();
            LoadPhong(phongs);
        }
        // Mở nhanh giao diện của phòng đã đặt theo mã
        public void OpenPhongDaDatNhanh(string maPhong)
        {
            if (string.IsNullOrWhiteSpace(maPhong))
                return;

            CTRoomDaDat target = null;
            FlowLayoutPanel[] flows =
            {
        flowLayoutPanel1,
        flowLayoutPanel2,
        flowLayoutPanel3,
        flowLayoutPanel4,
        flowLayoutPanel5
    };

            foreach (var fl in flows)
            {
                target = fl.Controls
                           .OfType<CTRoomDaDat>()
                           .FirstOrDefault(r => r.MaPhong == maPhong);

                if (target != null)
                    break;
            }

            if (target != null)
            {
                target.OpenDetail();
            }
            else
            {
                CTMessageBox.Show(
                    $"Không tìm thấy phòng đã đặt với mã {maPhong} trên sơ đồ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

    }
}
