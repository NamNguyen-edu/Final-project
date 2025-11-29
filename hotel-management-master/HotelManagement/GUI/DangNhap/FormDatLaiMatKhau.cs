using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.BUS;
using HotelManagement.CTControls; 

namespace HotelManagement.GUI
{
    public partial class FormDatLaiMatKhau : Form
    {
        private FormLogin formLoginParent;
        private TaiKhoan taiKhoan;
        public FormDatLaiMatKhau(FormLogin formMain)
        {
            InitializeComponent();
            this.formLoginParent = formMain;
        }
        // Constructor: mở form với tài khoản cần đổi mật khẩu
        public FormDatLaiMatKhau(FormLogin formMain,TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.formLoginParent = formMain;
            this.taiKhoan = taiKhoan;
        }
        // Quay lại bước nhập OTP
        private void PictureBoxBack_Click(object sender, EventArgs e)
        {
            formLoginParent.openChildForm(new FormQuenMatKhauNhapOTP(formLoginParent));
        }
        // Xác nhận đổi mật khẩu → kiểm tra input → lưu mật khẩu mới → quay về màn hình đăng nhập
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if(this.textBoxPassword.Texts == "" || this.textBoxPassConfirm.Texts=="")
            {
                CTMessageBox.Show("Vui lòng nhập password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }        
            if(this.textBoxPassword.Texts!=this.textBoxPassConfirm.Texts)
            {
                CTMessageBox.Show("Vui lòng kiểm tra lại password của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                taiKhoan.Password=this.textBoxPassword.Texts;
                try
                {
                    TaiKhoanBUS.Instance.AddOrUpdateTK(taiKhoan);
                    CTMessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    CTMessageBox.Show(ex.Message,"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                formLoginParent.openChildForm(new FormDangNhap(formLoginParent));

            }
        }
        // Nếu có ký tự trong password → bật chế độ ẩn mật khẩu
        private void textBoxPassword__TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Texts.Length > 0 && ctEyePassword1.IsShow == false)
            {
                textBoxPassword.PasswordChar = true;
            }
        }
        // Nếu có ký tự trong confirm password → bật chế độ ẩn mật khẩu
        private void textBoxPassConfirm__TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassConfirm.Texts.Length > 0 && ctEyePassword2.IsShow == false)
            {
                textBoxPassConfirm.PasswordChar = true;
            }
        }
        // Toggle hiện/ẩn mật khẩu của textboxPassword
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
        // Toggle hiện/ẩn mật khẩu của textboxConfirmPassword
        private void ctEyePassword2_Click(object sender, EventArgs e)
        {
            if (ctEyePassword2.IsShow == false)
            {
                ctEyePassword2.IsShow = true;
                textBoxPassConfirm.PasswordChar = false;
                ctEyePassword2.BackgroundImage = Properties.Resources.hide;
            }
            else
            {
                ctEyePassword2.IsShow = false;
                if (textBoxPassConfirm.Texts != "")
                {
                    textBoxPassConfirm.PasswordChar = true;
                }
                ctEyePassword2.BackgroundImage = Properties.Resources.show;
            }
        }
    }
}
