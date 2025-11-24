using HotelManagement.DTO;
using HotelManagement.BUS;
using HotelManagement.CTControls;
using HotelManagement.Properties;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace HotelManagement.Utils
{
    public static class EmailHelper
    {
        private static readonly string SmtpHost = "smtp.gmail.com";
        private static readonly int SmtpPort = 587;
        private static readonly string SmtpUser = "ngynam05@gmail.com";
        private static readonly string SmtpPass = "lmyarytfnihtcqps";

        public static bool SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(SmtpUser, "Hotel Management System");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;

                SmtpClient smtp = new SmtpClient(SmtpHost, SmtpPort);
                smtp.Credentials = new NetworkCredential(SmtpUser, SmtpPass);
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                CTMessageBox.Show("Không gửi được email: " + ex.Message, "Lỗi Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string GetBookingEmailBody(KhachHang kh, PhieuThue phieuThue, List<CTDP> listPhong)
        {
            StringBuilder sbRows = new StringBuilder();
            foreach (var ctdp in listPhong)
            {
                Phong phong = null;
                try { phong = PhongBUS.Instance.FindePhong(ctdp.MaPH); } catch { }
                string tenLoaiPhong = phong?.LoaiPhong?.TenLPH ?? "(Không có)";

                sbRows.Append($@"
        <tr>
            <td>{ctdp.MaPH}</td>
            <td>{tenLoaiPhong}</td>
            <td>{ctdp.CheckIn:dd/MM/yyyy HH:mm}</td>
            <td>{ctdp.CheckOut:dd/MM/yyyy HH:mm}</td>
        </tr>");
            }

            string template = Properties.Resources.EmailTemplate;

            template = template.Replace("{{TEN_KHACH}}", kh.TenKH);
            template = template.Replace("{{MA_PHIEU}}", phieuThue.MaPT);
            template = template.Replace("{{NGAY_DAT}}", phieuThue.NgPT.ToString("dd/MM/yyyy HH:mm"));
            template = template.Replace("{{EMAIL_KHACH}}", kh.Email);
            template = template.Replace("{{SDT_KHACH}}", kh.SDT);
            template = template.Replace("{{DANH_SACH_PHONG}}", sbRows.ToString());

            return template;
        }
    }
}