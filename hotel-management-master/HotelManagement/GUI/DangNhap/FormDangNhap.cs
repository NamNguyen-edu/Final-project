using HotelManagement.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.CTControls;
using HotelManagement.DTO;
using System.Security.Cryptography;

namespace HotelManagement.GUI
{
    public partial class FormDangNhap : Form
    {
        private FormLogin formLoginParent;
        public FormDangNhap(FormLogin formMain)
        {
            InitializeComponent();
            formLoginParent = formMain;
        }
        // Mở form quên mật khẩu (Lấy OTP)
        private void labelForgotPassword_Click(object sender, EventArgs e)
        {
            try
            {
                formLoginParent.openChildForm(new FormQuenMatKhauLayOTP(formLoginParent));
                formLoginParent.bringControlBoxAndTBTLabelToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Xử lý đăng nhập: kiểm tra tài khoản + mở form theo cấp độ quyền
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (TaiKhoanBUS.Instance.checkLogin(this.textBoxUsername.Texts, textBoxPassword.Texts))
            {
                string account = textBoxUsername.Texts;

                HotelDTO db = new HotelDTO();
                TaiKhoan taiKhoan = db.TaiKhoans.Find(account);

                int quyen = taiKhoan.CapDoQuyen;   

                Form formToOpen;

                switch (quyen)
                {
                    case 1:
                        formToOpen = new FormMain(taiKhoan);  
                        break;

                    case 2:
                        formToOpen = new FormMain(taiKhoan);  
                        break;

                    case 3:
                        formToOpen = new FormMain(taiKhoan); 
                        break;

                    case 4:
                        formToOpen = new FormMain(taiKhoan); 
                        break;

                    default:
                        CTMessageBox.Show("Tài khoản không có phân quyền hợp lệ!", "Lỗi",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                formLoginParent.Hide();
                formToOpen.ShowDialog();
                formLoginParent.Close();
            }
            else
            {
                CTMessageBox.Show("Sai thông tin đăng nhập! Vui lòng kiểm tra lại.",
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Khi text password thay đổi → bật chế độ PasswordChar nếu cần
        private void textBoxPassword__TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
            if (textBoxPassword.Texts.Length > 0 && ctEyePassword1.IsShow == false)
            {
                textBoxPassword.PasswordChar = true;
            }
        }
        // Ngăn tab khi password đang trống
        private void TextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab && textBoxPassword.Texts.Length == 0)
            {
                e.IsInputKey = false;
            }
        }
        // Nút mắt (Show/Hide password)
        private void ctEyePassword1_Click(object sender, EventArgs e)
        {
            if (ctEyePassword1.IsShow == false)
            {
                ctEyePassword1.IsShow = true;
                textBoxPassword.PasswordChar = false;
                ctEyePassword1.BackgroundImage = Properties.Resources.hide;
            }
            else
            {
                ctEyePassword1.IsShow = false;
                if (textBoxPassword.Texts != "")
                {
                    textBoxPassword.PasswordChar = true;
                }
                ctEyePassword1.BackgroundImage = Properties.Resources.show;
            }
        }
    }
}
