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
        }
        private SoundPlayer player;
        public FormTrangChu(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }
        private void formTrangChu_load()
        {
            PlayMusic();
        }
        private bool isMusicPlaying = false;
        private bool isMuted = false; // Biến để theo dõi trạng thái mute
        private void PlayMusic()
        {
            if (Properties.Resources.audiotrangchu != null)
            {
                player = new SoundPlayer(Properties.Resources.audiotrangchu);
                player.PlayLooping(); // Phát nhạc liên tục
                isMusicPlaying = true; // Đánh dấu là nhạc đang phát
                picSound.Image = Properties.Resources.sound; // Thay đổi icon để hiển thị đang bật nhạc

            }
            else
            {
                MessageBox.Show("Không tìm thấy file âm thanh trong Resources!");
            }
        }
        private void picSound_Click(object sender, EventArgs e)
        {
            if (isMuted)
            {
                // Nếu đang tắt nhạc, bật lại nhạc
                PlayMusic();
                isMuted = false; // Đánh dấu nhạc đã bật
            }
            else
            {
                // Nếu đang phát nhạc, tắt nhạc
                StopMusic();
                isMuted = true; // Đánh dấu nhạc đã tắt (mute)
            }
        }

        private void StopMusic()
        {
            if (player != null)
            {
                player.Stop(); // Dừng nhạc
                isMusicPlaying = false; // Đánh dấu là nhạc đã dừng
                picSound.Image = Properties.Resources.mute; // Thay đổi icon để hiển thị đang tắt nhạc
            }
        }

        private void CTButtonTest_Click(object sender, EventArgs e)
        {
            CTMessageBox.Show("Sinh viên khoa công nghệ phần mềm - Đại học Công Nghệ Thông Tin - Đại học Quốc gia Thành Phố Hồ Chí Minh","Thông báo",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
        }
    }
}
