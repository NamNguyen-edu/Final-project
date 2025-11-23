using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace HotelManagement.GUI
{
    public partial class FormThanhToan: Form
    {
        public class PaymentResult
        {
            public bool success { get; set; }
            public string transactionId { get; set; }
            public double amount { get; set; }
            public string message { get; set; }

            // Các trường phục vụ gửi mail
            public string emailTo { get; set; }
            public string emailSubject { get; set; }
            public string emailBody { get; set; }
        }
        public FormThanhToan()
        {
            InitializeComponent();
            InitializeWebView();
        }
        private async void InitializeWebView()
        {
            await webView21.EnsureCoreWebView2Async(null);

            // Trỏ tới Web React đang chạy (bước 1)
            webView21.Source = new Uri("http://localhost:3000");

            // Đăng ký sự kiện nhận tin nhắn
            webView21.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
        }

        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            try
            {
                string jsonResult = e.TryGetWebMessageAsString();
                PaymentResult result = JsonConvert.DeserializeObject<PaymentResult>(jsonResult);

                if (result.success)
                {
                    // 1. Gửi Email (nếu có địa chỉ nhận)
                    if (!string.IsNullOrEmpty(result.emailTo))
                    {
                        bool mailSent = SendEmail(result.emailTo, result.emailSubject, result.emailBody);
                        if (mailSent) MessageBox.Show("Đã gửi hóa đơn qua email!");
                    }

                    // 2. Thông báo kết quả
                    MessageBox.Show($"Thanh toán thành công!\nMã GD: {result.transactionId}\nSố tiền: {result.amount:N0} VNĐ",
                                    "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Thất bại: {result.message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý dữ liệu: " + ex.Message);
            }
        }

        private bool SendEmail(string toEmail, string subject, string htmlBody)
        {
            try
            {
                // CẤU HÌNH SMTP CỦA BẠN
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                string smtpUser = "ngynam05@gmail.com";
                string smtpPass = "lmyarytfnihtcqps"; // Mật khẩu ứng dụng (App Password)

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(smtpUser, "Hotel Management System");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = htmlBody;
                mail.IsBodyHtml = true; // QUAN TRỌNG: Để hiển thị HTML đẹp
                mail.BodyEncoding = Encoding.UTF8;

                SmtpClient smtp = new SmtpClient(smtpHost, smtpPort);
                smtp.Credentials = new NetworkCredential(smtpUser, smtpPass);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không gửi được mail: " + ex.Message);
                return false;
            }
        }
        private void FormThanhToan_Load(object sender, EventArgs e)
        {
          
        }
    }
}
