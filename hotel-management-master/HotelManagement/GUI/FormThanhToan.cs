using HotelManagement.UTILS;
using HotelManagement.CTControls;
using Microsoft.Web.WebView2.Core;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;


namespace HotelManagement.GUI
{
    public partial class FormThanhToan : Form
    {
        /// <summary>
        /// Cấu hình VNPay
        /// </summary>
        private string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html"; 
        private string vnp_TmnCode = "GTTWTT88"; 
        private string vnp_HashSecret = "GYJ4U78H3H1EJ9ED7Z1U9K0S6ENAZC8E"; 
        private string vnp_ReturnUrl = "http://localhost:8080/vnpay_return"; 

        private double PayAmount;
        private string Description;

        public FormThanhToan(double amount, string description)
        {
            InitializeComponent();
            this.PayAmount = amount;
            this.Description = description;
        }

        private async void FormThanhToan_Load(object sender, EventArgs e)
        {
            await InitializeWebView();
        }

        private async System.Threading.Tasks.Task InitializeWebView()
        {
            try
            {
                if (webView21.CoreWebView2 == null)
                {
                    await webView21.EnsureCoreWebView2Async(null);
                }

                webView21.CoreWebView2.NavigationStarting -= CoreWebView2_NavigationStarting;
                webView21.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;

                string paymentUrl = BuildVnPayUrl(PayAmount, Description);

                webView21.CoreWebView2.Navigate(paymentUrl);
            }
            catch (Exception ex)
            {
                CTMessageBox.Show("Lỗi khởi tạo cổng thanh toán: " + ex.Message);
            }
        }

        private string BuildVnPayUrl(double amount, string description)
        {
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", "2.1.0");
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode); 

            long vnp_Amount = (long)(amount * 100);
            vnpay.AddRequestData("vnp_Amount", vnp_Amount.ToString());

            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", "127.0.0.1");
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", description);
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_ReturnUrl);
            vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString());
            return vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
        }

        private void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {

            if (e.Uri.StartsWith(vnp_ReturnUrl))
            {
                e.Cancel = true; 

                try
                {
                    Uri myUri = new Uri(e.Uri);

                    string queryString = myUri.Query;

                    if (!string.IsNullOrEmpty(queryString))
                    {
                        queryString = queryString.TrimStart('?');

                        string[] listParams = queryString.Split('&');

                        string vnp_ResponseCode = "";
                        string vnp_TransactionNo = "";

                        foreach (string param in listParams)
                        {
                            string[] parts = param.Split('=');
                            if (parts.Length == 2)
                            {
                                string key = parts[0];
                                string value = WebUtility.UrlDecode(parts[1]);

                                if (key == "vnp_ResponseCode") vnp_ResponseCode = value;
                                if (key == "vnp_TransactionNo") vnp_TransactionNo = value;
                            }
                        }

                        if (vnp_ResponseCode == "00")
                        {
                            CTMessageBox.Show($"Thanh toán thành công!\nMã GD: {vnp_TransactionNo}",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            CTMessageBox.Show("Giao dịch không thành công. Mã lỗi: " + vnp_ResponseCode,
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.DialogResult = DialogResult.Cancel;
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    CTMessageBox.Show("Lỗi xử lý: " + ex.Message);
                }
            }
        }
        private void ctClose1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}