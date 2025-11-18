//using HotelManagement.BUS;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using HotelManagement.CTControls;
//using HotelManagement.DTO;
//using System.Security.Cryptography;

//namespace HotelManagement.GUI
//{
//    public partial class FormDangNhap : Form
//    {
//        private FormLogin formLoginParent;
//        public FormDangNhap(FormLogin formMain)
//        {
//            InitializeComponent();
//            formLoginParent = formMain;
//        }

//        private void labelForgotPassword_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                formLoginParent.openChildForm(new FormQuenMatKhauLayOTP(formLoginParent));
//                formLoginParent.bringControlBoxAndTBTLabelToFront();
//            }
//            catch(Exception ex)
//            {
//                MessageBox.Show(ex.Message);    
//            }
//        }

//        private void buttonLogin_Click(object sender, EventArgs e)
//        {
//            if (TaiKhoanBUS.Instance.checkLogin(this.textBoxUsername.Texts, textBoxPassword.Texts))
//            {
//                string account = textBoxUsername.Texts;
//                HotelDTO db = new HotelDTO();
//                TaiKhoan taiKhoan = db.TaiKhoans.Find(account);
//                FormMain formMain = new FormMain(taiKhoan);
//                formLoginParent.Hide(); 
//                formMain.ShowDialog();
//                formLoginParent.Close();
//            }
//            else
//            {
//                CTMessageBox.Show("Sai thông tin đăng nhập! Vui lòng kiểm tra lại.", "Thông báo",
//                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }    
//        }

//        private void textBoxPassword__TextChanged(object sender, EventArgs e)
//        {
//            TextBox textBox = sender as TextBox;
//            textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
//            if(textBoxPassword.Texts.Length>0 && ctEyePassword1.IsShow == false)
//            {
//                textBoxPassword.PasswordChar = true;
//            }
//        }

//        private void TextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
//        {
//            if (e.KeyData == Keys.Tab && textBoxPassword.Texts.Length == 0)
//            {
//                e.IsInputKey = false;
//            }
//        }

//        private void ctEyePassword1_Click(object sender, EventArgs e)
//        {
//            if (ctEyePassword1.IsShow == false)
//            {
//                ctEyePassword1.IsShow = true;
//                textBoxPassword.PasswordChar = false;
//                ctEyePassword1.BackgroundImage = Properties.Resources.hide;
//            }
//            else
//            {
//                ctEyePassword1.IsShow = false;
//                if (textBoxPassword.Texts != "")
//                {
//                    textBoxPassword.PasswordChar = true;
//                }
//                ctEyePassword1.BackgroundImage = Properties.Resources.show;
//            }
//        }
//    }
//}



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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (TaiKhoanBUS.Instance.checkLogin(this.textBoxUsername.Texts, textBoxPassword.Texts))
            {
                string account = textBoxUsername.Texts;

                HotelDTO db = new HotelDTO();
                TaiKhoan taiKhoan = db.TaiKhoans.Find(account);

                // Lấy cấp độ quyền
                int quyen = taiKhoan.CapDoQuyen;   // 1=NV,2=QL,3=Admin,4=Khách

                Form formToOpen;

                switch (quyen)
                {
                    case 1:
                        formToOpen = new FormMain(taiKhoan);   // Nhân viên
                        break;

                    case 2:
                        formToOpen = new FormMain(taiKhoan);   // Quản lý
                        break;

                    case 3:
                        formToOpen = new FormMain(taiKhoan);   // Admin
                        break;

                    case 4:
                        formToOpen = new FormMain(taiKhoan);  // KHÁCH HÀNG
                        break;

                    default:
                        CTMessageBox.Show("Tài khoản không có phân quyền hợp lệ!", "Lỗi",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                // Ẩn form login & mở form phân quyền đúng
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


        private void textBoxPassword__TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
            if (textBoxPassword.Texts.Length > 0 && ctEyePassword1.IsShow == false)
            {
                textBoxPassword.PasswordChar = true;
            }
        }

        private void TextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab && textBoxPassword.Texts.Length == 0)
            {
                e.IsInputKey = false;
            }
        }

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
