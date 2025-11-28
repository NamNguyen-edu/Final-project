using HotelManagement.CTControls;
using HotelManagement.DTO;
using System;
using System.Media;
using System.Windows.Forms;
using HotelManagement.DAO;   
using System.Linq;
using System.Drawing;

namespace HotelManagement.GUI

{
    public partial class FormTC : Form
    {
        private FormMain formMain;
        private SoundPlayer player;
        private bool isMusicPlaying = false;
        private PhieuThue phieuThue;


        public FormTC()
        {
            InitializeComponent();
        }

        public FormTC(FormMain formMain)
        {
            this.formMain = formMain;
            InitializeComponent();
        }

        private void FormTC_Load(object sender, EventArgs e)
        {

            UpdateDateTimeLabel();
            LoadThongKePhong();
            LoadThongTinNhanVien();
            LoadThongBaoCheckIn();

            SetupOverviewCardHover(ovItem1);
            SetupOverviewCardHover(ovItem2);
            SetupOverviewCardHover(ovItem3);
            SetupOverviewCardHover(ovItem4);

        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();
            LoadThongBaoCheckIn();
        }
        private void panelTop_SizeChanged(object sender, EventArgs e)
        {
            // canh giữa lblDate theo panelTop
            int x = (panelTop.Width - lblDate.Width) / 2;
            int y = (panelTop.Height - lblDate.Height) / 2;
            lblDate.Location = new System.Drawing.Point(x, y);
        }

        private void UpdateDateTimeLabel()
        {
            DateTime now = DateTime.Now;

            string[] thuVN =
            {
                "Chủ nhật",  // 0
                "Thứ hai",   // 1
                "Thứ ba",    // 2
                "Thứ tư",    // 3
                "Thứ năm",   // 4
                "Thứ sáu",   // 5
                "Thứ bảy"    // 6
            };

            string thuText = thuVN[(int)now.DayOfWeek];
            lblDate.Text = $"{thuText}, {now:dd/MM/yyyy - HH:mm tt}";
            // cập nhật lại vị trí cho đúng giữa
            panelTop_SizeChanged(null, EventArgs.Empty);
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormDatPhong formDatPhong = new FormDatPhong(null, this.phieuThue))
                {
                    formDatPhong.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(ex.Message, "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
            }
        }
        private void LoadThongKePhong()
        {
            DateTime today = DateTime.Today;

            // Cập nhật lại các CTDP quá hạn "Đã đặt" → "Đã xong"
            CTDP_DAO.Instance.UpdateTrangThaiQuaHan(today);

            // Lấy toàn bộ CTDP còn hiệu lực
            var listCTDP = CTDP_DAO.Instance.GetCTDPs()
                                .Where(p => p.DaXoa == false)
                                .ToList();

            // ==== 1. ĐANG THUÊ từ hôm nay trở đi ====
            int soDangThue = listCTDP
                .Where(p =>
                       !string.IsNullOrWhiteSpace(p.TrangThai)
                    && p.TrangThai.Trim().Equals("Đang thuê",
                                                 StringComparison.OrdinalIgnoreCase)
                    && p.CheckOut.Date >= today)
                .Select(p => p.MaPH)
                .Distinct()
                .Count();

            // ==== 2. ĐÃ ĐẶT trong hôm nay ====
            int soDaDat = listCTDP
                .Where(p =>
                       !string.IsNullOrWhiteSpace(p.TrangThai)
                    && p.TrangThai.Trim().Equals("Đã cọc",
                                                 StringComparison.OrdinalIgnoreCase)
                    && p.CheckIn.Date == today)
                .Select(p => p.MaPH)
                .Distinct()
                .Count();

            // ==== 3 + 4. CHƯA DỌN + ĐANG SỬA CHỮA (lấy từ Phòng) ====
            var phongs = PhongDAO.Instance.GetAllPhongs();

            int soChuaDon = phongs.Count(p => p.TTDD != null
                                           && p.TTDD.Trim() == "Chưa dọn dẹp");
            int soDangSua = phongs.Count(p => p.TTPH != null
                                           && p.TTPH.Trim() == "Đang sửa chữa");

            lblOv1Value.Text = $"{soDangThue} phòng";
            lblOv2Value.Text = $"{soDaDat} phòng";
            lblOv3Value.Text = $"{soChuaDon} phòng";
            lblOv4Value.Text = $"{soDangSua} phòng";
        }

        private void LoadThongTinNhanVien()
        {
            // chỉ NV (CapDoQuyen = 1) mới có panel này
            if (formMain == null || formMain.TaiKhoanDangNhap == null)
                return;

            TaiKhoan tk = formMain.TaiKhoanDangNhap;

            if (tk.CapDoQuyen != 1)   // 1 = Nhân viên
                return;

            // tk.NhanVien đã được EF map sẵn (bạn đã dùng ở FormMain)
            var nv = tk.NhanVien;
            if (nv == null) return;

            lblUserName.Text = nv.TenNV;          
            lblUserRole.Text = nv.ChucVu;         
            lblUserPhone.Text = "📞 " + nv.SDT;
            lblUserMail.Text = "✉️ " + nv.Email;
        }

        private void LoadThongBaoCheckIn()
        {
            DateTime now = DateTime.Now;

            // Cập nhật lại các CTDP quá hạn "Đã đặt"
            CTDP_DAO.Instance.UpdateTrangThaiQuaHan(now);

            // Lấy các CTDP còn hiệu lực, trạng thái "Đã đặt" và ở tương lai
            var list = CTDP_DAO.Instance.GetCTDPs()
                         .Where(p => p.DaXoa == false
                                  && p.TrangThai == "Đã đặt"
                                  && p.CheckIn > now)
                         .OrderBy(p => p.CheckIn)
                         .ToList();

            // Lấy phòng nào sắp check-in trong vòng 30 phút tới (có thể chỉnh số phút)
            const double canhBaoPhut = 30;
            var soon = list
                .FirstOrDefault(p => (p.CheckIn - now).TotalMinutes <= canhBaoPhut);

            lblNoti1Title.Text = "Thông báo giờ check - in";

            if (soon != null)
            {
                // dùng MaPH trực tiếp vì trong CTDP bạn có MaPH
                lblNoti1Sub.Text =
                    $"Phòng {soon.MaPH} sắp đến giờ Check - in ({soon.CheckIn:HH:mm})";
            }
            else
            {
                lblNoti1Sub.Text = "Hiện không có phòng nào sắp đến giờ Check - in";
            }
        }

        private void OpenSoDoPhongAndFilter(Action<FormSoDoPhong> applyFilter)
        {
            if (formMain == null || formMain.TaiKhoanDangNhap == null)
                return;

            // tạo form sơ đồ phòng
            var f = new FormSoDoPhong(formMain, formMain.TaiKhoanDangNhap);

            // mở trong FormMain
            formMain.openChildForm(f);

            // áp filter tương ứng
            applyFilter?.Invoke(f);
        }

        private void SetupOverviewCardHover(Panel card)
        {
            // lưu màu gốc vào Tag để lát còn trả lại
            card.Tag = card.BackColor;
            card.Cursor = Cursors.Hand;

            card.MouseEnter += OverviewCard_MouseEnter;
            card.MouseLeave += OverviewCard_MouseLeave;
            card.MouseDown += OverviewCard_MouseDown;
            card.MouseUp += OverviewCard_MouseUp;

            // đảm bảo khi rê vào label / picture bên trong vẫn đổi màu card
            foreach (Control c in card.Controls)
            {
                c.Cursor = Cursors.Hand;
                c.MouseEnter += (s, e) => OverviewCard_MouseEnter(card, e);
                c.MouseLeave += (s, e) => OverviewCard_MouseLeave(card, e);
                c.MouseDown += (s, e) => OverviewCard_MouseDown(card, e);
                c.MouseUp += (s, e) => OverviewCard_MouseUp(card, e);
            }
        }

        private void OverviewCard_MouseEnter(object sender, EventArgs e)
        {
            var p = sender as Panel;
            if (p == null) return;

            // màu hover sáng hơn xíu
            p.BackColor = Color.FromArgb(233, 117, 32);
            p.ForeColor = Color.White;
            //p.BorderStyle = BorderStyle.FixedSingle;
        }

        private void OverviewCard_MouseLeave(object sender, EventArgs e)
        {
            var p = sender as Panel;
            if (p == null) return;

            // trả lại màu gốc
            if (p.Tag is Color origin)
                p.BackColor = origin;
            p.ForeColor = Color.Black;

            p.BorderStyle = BorderStyle.None;
        }

        private void OverviewCard_MouseDown(object sender, MouseEventArgs e)
        {
            var p = sender as Panel;
            if (p == null) return;

            //// nhấn xuống thì tối lại chút
            //p.BackColor = Color.FromArgb(250, 230, 200);
        }

        private void OverviewCard_MouseUp(object sender, MouseEventArgs e)
        {
            var p = sender as Panel;
            if (p == null) return;

            // nhả ra thì về lại màu hover
            p.BackColor = Color.FromArgb(255, 244, 220);
        }


        // Đang thuê
        private void ovItem1_Click(object sender, EventArgs e)
        {
            OpenSoDoPhongAndFilter(f => f.ShowPhongDangThue());
        }

        // Đã đặt
        private void ovItem2_Click(object sender, EventArgs e)
        {
            OpenSoDoPhongAndFilter(f => f.ShowPhongDaDat());
        }

        // Chưa dọn
        private void ovItem3_Click(object sender, EventArgs e)
        {
            OpenSoDoPhongAndFilter(f => f.ShowPhongChuaDon());
        }

        // Đang sửa chữa
        private void ovItem4_Click(object sender, EventArgs e)
        {
            OpenSoDoPhongAndFilter(f => f.ShowPhongDangSuaChua());
        }


        // ====== nếu sau này muốn dùng âm thanh trên form này ======
        private void PlayMusic()
        {
            if (Properties.Resources.audiotrangchu != null)
            {
                player = new SoundPlayer(Properties.Resources.audiotrangchu);
                player.PlayLooping();
                isMusicPlaying = true;
            }
        }

        private void StopMusic()
        {
            if (player != null)
            {
                player.Stop();
                isMusicPlaying = false;
            }
        }

    }
}
