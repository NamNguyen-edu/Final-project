using HotelManagement.CTControls;
using HotelManagement.DTO;
using System;
using System.Media;
using System.Windows.Forms;
using HotelManagement.DAO;   // thêm
using System.Linq;           // để dùng Count với điều kiện
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
            var now = DateTime.Now;

            // Cập nhật lại các CTDP quá hạn "Đã đặt" → "Đã xong"
            CTDP_DAO.Instance.UpdateTrangThaiQuaHan(now);

            // Lấy toàn bộ CTDP còn hiệu lực
            var listCTDP = CTDP_DAO.Instance.GetCTDPs()
                            .Where(p => p.DaXoa == false)
                            .ToList();

            // ==== 1. ĐANG THUÊ ====
            // CTDP có trạng thái "Đang thuê" và thời gian hiện tại nằm trong khoảng thuê
            int soDangThue = listCTDP
                .Where(p => p.TrangThai == "Đang thuê"
                         && p.CheckIn <= now
                         && now <= p.CheckOut)
                .Select(p => p.MaPH)         // đếm theo phòng
                .Distinct()
                .Count();

            // ==== 2. ĐÃ ĐẶT ====
            // CTDP "Đã đặt" và check-in ở tương lai
            int soDaDat = listCTDP
                .Where(p => p.TrangThai == "Đã đặt"
                         && now < p.CheckIn)
                .Select(p => p.MaPH)
                .Distinct()
                .Count();

            // ==== 3 + 4. CHƯA DỌN + ĐANG SỬA CHỮA (lấy từ Phòng) ====
            var phongs = PhongDAO.Instance.GetAllPhongs();

            int soChuaDon = phongs.Count(p => p.TTDD == "Chưa dọn dẹp");
            int soDangSua = phongs.Count(p => p.TTPH == "Đang sửa chữa");

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

            lblUserName.Text = nv.TenNV;          // Nguyễn Phúc Bình / Trần Thị B ...
            lblUserRole.Text = nv.ChucVu;         // Tiếp tân, Nhân viên vệ sinh...
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
