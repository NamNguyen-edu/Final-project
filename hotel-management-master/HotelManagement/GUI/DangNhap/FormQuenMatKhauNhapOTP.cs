using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using HotelManagement.DTO;
using HotelManagement.CTControls;
// THÊM: Import lớp EmailHelper
using HotelManagement.Utils;

namespace HotelManagement.GUI
{
    public partial class FormQuenMatKhauNhapOTP : Form
    {
        private string OTP = "ABC";
        private string emailto;
        private Random random = new Random();
        private FormLogin formLoginParent;
        private TaiKhoan taiKhoan;
        int time = 60;

        // Constructor: chỉ nhận form cha (không có email)
        public FormQuenMatKhauNhapOTP(FormLogin formMain)
        {
            this.formLoginParent = formMain;
            InitializeComponent();
        }

        // Constructor: nhận form cha + email + tài khoản → gửi OTP ngay
        public FormQuenMatKhauNhapOTP(FormLogin formMain, string emailto = null, TaiKhoan taiKhoan = null)
        {
            InitializeComponent();
            this.formLoginParent = formMain;
            this.emailto = emailto;
            this.taiKhoan = taiKhoan;
            LoadOTP();
        }

        // Tạo OTP mới, gửi email OTP và bắt đầu đếm ngược resend
        void LoadOTP()
        {
            time = 60;
            this.ButtonResend.Enabled = false;
            timer1.Start();
            this.OTP = random.Next(10000, 99999).ToString();
            string subject = "Đặt lại mật khẩu tài khoản ứng dụng Quản lý khách sạn";

            string body = "<div style=\"font-family: Helvetica,Arial,sans-serif;min-width:1000px;overflow:auto;line-height:2\">\r\n  <div style=\"margin:50px auto;width:70%;padding:20px 0\">\r\n    <div style=\"border-bottom:1px solid #eee\">\r\n      <a href=\"\" style=\"font-size:1.4em;color: #00466a;text-decoration:none;font-weight:600\">Hotel Management</a>\r\n    </div>\r\n    <p style=\"font-size:1.1em\">Xin chào,</p>\r\n    <p>Đây là thư tự động gửi vào email. Vui lòng không trả lời thư này.<br> Dưới đây là mã OTP của bạn!</p>\r\n    <h2 style=\"background: #00466a;margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;\">" + OTP + "</h2>\r\n    <p style=\"font-size:0.9em;\">Xin cảm ơn,<br />Hotel Management</p>\r\n    <hr style=\"border:none;border-top:1px solid #eee\" />\r\n    <div style=\"float:right;padding:8px 0;color:#aaa;font-size:0.8em;line-height:1;font-weight:300\">\r\n    </div>\r\n  </div>\r\n</div>";
            try
            {
                // Thay thế logic gửi email cũ bằng hàm SendEmail của EmailHelper
                bool success = EmailHelper.SendEmail(emailto, subject, body);

                if (!success)
                {
                    // Nếu gửi email thất bại (do logic trong EmailHelper), có thể thông báo thêm ở đây
                    // Hoặc chỉ dựa vào thông báo lỗi đã được xử lý trong EmailHelper
                }
            }
            catch (Exception ex)
            {
                // Dù SendEmail đã có try/catch, việc bọc thêm catch ở đây giúp 
                // xử lý các lỗi có thể xảy ra trong quá trình chuẩn bị (ít khả năng hơn)
                CTMessageBox.Show("Không thể gửi OTP: " + ex.Message, "Lỗi Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kiểm tra OTP nhập vào có đúng không
        private bool checkOTPCorrect()
        {
            if (this.textBoxOTP.Texts == OTP)
            {
                return true;
            }
            return false;
        }

        // Khi nhấn "Continue": nếu OTP đúng → mở form đặt lại mật khẩu
        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkOTPCorrect())
                {
                    // Tắt Timer trước khi chuyển form
                    timer1.Stop();
                    formLoginParent.openChildForm(new FormDatLaiMatKhau(formLoginParent, this.taiKhoan));
                }
                else
                {
                    CTMessageBox.Show("Mã OTP bạn nhập chưa đúng. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Quay lại bước nhập email lấy OTP
        private void PictureBoxBack_Click(object sender, EventArgs e)
        {
            // Tắt Timer trước khi chuyển form
            timer1.Stop();
            formLoginParent.openChildForm(new FormQuenMatKhauLayOTP(formLoginParent));
        }

        // Nhấn resend OTP → gửi OTP mới
        private void ButtonResend_Click(object sender, EventArgs e)
        {
            LoadOTP();
        }

        // Timer đếm ngược 60s để cho phép resend OTP
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ButtonResend.Text = time.ToString();
            time--;
            if (this.time == 0)
            {
                timer1.Stop();
                this.ButtonResend.Enabled = true;
                this.ButtonResend.Text = "RESEND";
            }
        }
    }
}