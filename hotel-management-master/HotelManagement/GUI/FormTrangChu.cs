using HotelManagement.CTControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HotelManagement.GUI
{
    public partial class FormTrangChu : Form
    {
        private FormMain formMain;
        public FormTrangChu()
        {
            InitializeComponent();
            BuildUI();
        }
        private SoundPlayer player;
        public FormTrangChu(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }
        private void formTrangChu_load()
        {
            //PlayMusic();
        }
        //private bool isMusicPlaying = false;
        //private bool isMuted = false; // Biến để theo dõi trạng thái mute
        //private void PlayMusic()
        //{
        //    if (Properties.Resources.audiotrangchu != null)
        //    {
        //        player = new SoundPlayer(Properties.Resources.audiotrangchu);
        //        player.PlayLooping(); // Phát nhạc liên tục
        //        isMusicPlaying = true; // Đánh dấu là nhạc đang phát
        //        picSound.Image = Properties.Resources.sound; // Thay đổi icon để hiển thị đang bật nhạc

        //    }
        //    else
        //    {
        //        MessageBox.Show("Không tìm thấy file âm thanh trong Resources!");
        //    }
        //}
        //private void picSound_Click(object sender, EventArgs e)
        //{
        //    if (isMuted)
        //    {
        //        // Nếu đang tắt nhạc, bật lại nhạc
        //        PlayMusic();
        //        isMuted = false; // Đánh dấu nhạc đã bật
        //    }
        //    else
        //    {
        //        // Nếu đang phát nhạc, tắt nhạc
        //        StopMusic();
        //        isMuted = true; // Đánh dấu nhạc đã tắt (mute)
        //    }
        //}

        //private void StopMusic()
        //{
        //    if (player != null)
        //    {
        //        player.Stop(); // Dừng nhạc
        //        isMusicPlaying = false; // Đánh dấu là nhạc đã dừng
        //        picSound.Image = Properties.Resources.mute; // Thay đổi icon để hiển thị đang tắt nhạc
        //    }
        //}

        //private void CTButtonTest_Click(object sender, EventArgs e)
        //{
        //    CTMessageBox.Show("Sinh viên khoa công nghệ phần mềm - Đại học Công Nghệ Thông Tin - Đại học Quốc gia Thành Phố Hồ Chí Minh","Thông báo",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
        //}

        private void BuildUI()
        {
            this.BackColor = Color.FromArgb(250, 245, 235);
            this.Padding = new Padding(20);

            // MAIN LAYOUT
            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.ColumnCount = 3;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            this.Controls.Add(mainLayout);

            // ===========================
            // 1. PANEL TỔNG QUAN
            // ===========================
            Panel pnOverview = CreateCardPanel();
            pnOverview.Padding = new Padding(20);

            Label lbOverview = CreateTitle("Tổng quan");

            FlowLayoutPanel listOverview = new FlowLayoutPanel();
            listOverview.FlowDirection = FlowDirection.TopDown;
            listOverview.Dock = DockStyle.Top;
            listOverview.AutoSize = true;

            listOverview.Controls.Add(CreateOverviewItem("Đang thuê", "3 phòng"));
            listOverview.Controls.Add(CreateOverviewItem("Đã đặt", "5 phòng"));
            listOverview.Controls.Add(CreateOverviewItem("Chưa dọn", "5 phòng"));
            listOverview.Controls.Add(CreateOverviewItem("Đang sửa chữa", "1 phòng"));

            pnOverview.Controls.Add(listOverview);
            pnOverview.Controls.Add(lbOverview);
            lbOverview.Dock = DockStyle.Top;

            mainLayout.Controls.Add(pnOverview, 0, 0);

            // ===========================
            // 2. PANEL NHÂN VIÊN
            // ===========================
            Panel pnUser = CreateCardPanel();
            pnUser.Padding = new Padding(20);

            TableLayoutPanel userLayout = new TableLayoutPanel();
            userLayout.Dock = DockStyle.Top;
            userLayout.ColumnCount = 2;
            userLayout.RowCount = 4;
            userLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            userLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));

            PictureBox avatar = new PictureBox();
            avatar.Size = new Size(100, 100);
            avatar.BackColor = Color.LightGray;
            avatar.SizeMode = PictureBoxSizeMode.Zoom;
            avatar.Margin = new Padding(10);

            Label lbName = new Label()
            {
                Text = "Nguyễn Phúc Bình",
                Font = new Font("Segoe UI Semibold", 16, FontStyle.Bold),
                AutoSize = true
            };
            Label lbRole = new Label()
            {
                Text = "Nhân viên",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                AutoSize = true
            };

            Label phone = new Label()
            {
                Text = "📞 0123 4567 89",
                Font = new Font("Segoe UI", 12),
                AutoSize = true
            };
            Label mail = new Label()
            {
                Text = "✉️ npbinh@gmail.com",
                Font = new Font("Segoe UI", 12),
                AutoSize = true
            };

            userLayout.Controls.Add(avatar, 0, 0);
            userLayout.SetRowSpan(avatar, 4);

            userLayout.Controls.Add(lbName, 1, 0);
            userLayout.Controls.Add(lbRole, 1, 1);
            userLayout.Controls.Add(phone, 1, 2);
            userLayout.Controls.Add(mail, 1, 3);

            pnUser.Controls.Add(userLayout);

            mainLayout.Controls.Add(pnUser, 1, 0);

            // ===========================
            // 3. PANEL THÔNG BÁO
            // ===========================
            Panel pnNotify = CreateCardPanel();
            pnNotify.Padding = new Padding(20);

            Label lbNotify = CreateTitle("Thông báo");
            lbNotify.Dock = DockStyle.Top;

            FlowLayoutPanel notifyList = new FlowLayoutPanel();
            notifyList.Dock = DockStyle.Top;
            notifyList.FlowDirection = FlowDirection.TopDown;
            notifyList.AutoSize = true;

            notifyList.Controls.Add(CreateNotifyItem("Thông báo giờ check - in",
                "Phòng 101 sắp đến giờ Check-in"));

            notifyList.Controls.Add(CreateNotifyItem("Chăm sóc khách hàng",
                "Khách hàng phòng 102 yêu cầu thêm khăn tắm"));

            pnNotify.Controls.Add(notifyList);
            pnNotify.Controls.Add(lbNotify);

            mainLayout.Controls.Add(pnNotify, 2, 0);
        }

        // ================================
        // ===== REUSABLE UI COMPONENTS ====
        // ================================

        private Panel CreateCardPanel()
        {
            Panel p = new Panel();
            p.BackColor = Color.FromArgb(255, 250, 240);
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Margin = new Padding(10);
            return p;
        }

        private Label CreateTitle(string txt)
        {
            return new Label()
            {
                Text = txt,
                Font = new Font("Segoe UI Semibold", 15, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 15)
            };
        }

        private Panel CreateOverviewItem(string title, string subtitle)
        {
            Panel item = new Panel();
            item.Size = new Size(250, 60);
            item.BackColor = Color.White;
            item.Margin = new Padding(0, 10, 0, 0);
            item.Padding = new Padding(10);

            Label lb1 = new Label()
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true
            };
            Label lb2 = new Label()
            {
                Text = subtitle,
                Font = new Font("Segoe UI", 11),
                AutoSize = true
            };

            item.Controls.Add(lb1);
            item.Controls.Add(lb2);

            lb2.Location = new Point(0, 25);

            return item;
        }

        private Panel CreateNotifyItem(string title, string subtitle)
        {
            Panel item = new Panel();
            item.BackColor = Color.White;
            item.Size = new Size(300, 65);
            item.Padding = new Padding(10);
            item.Margin = new Padding(0, 10, 0, 0);

            Label lb1 = new Label()
            {
                Text = title,
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                AutoSize = true
            };
            Label lb2 = new Label()
            {
                Text = subtitle,
                Font = new Font("Segoe UI", 11),
                AutoSize = true
            };

            item.Controls.Add(lb1);
            item.Controls.Add(lb2);
            lb2.Location = new Point(0, 28);

            return item;
        }
    }
}
