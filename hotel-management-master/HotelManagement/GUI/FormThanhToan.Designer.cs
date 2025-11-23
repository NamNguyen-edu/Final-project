namespace HotelManagement.GUI
{
    partial class FormThanhToan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThanhToan));
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.ctClose1 = new HotelManagement.CTControls.CTClose();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(12, 23);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(455, 652);
            this.webView21.TabIndex = 0;
            this.webView21.ZoomFactor = 1D;
            // 
            // ctClose1
            // 
            this.ctClose1.BackColor = System.Drawing.Color.Transparent;
            this.ctClose1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctClose1.BackgroundImage")));
            this.ctClose1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctClose1.Location = new System.Drawing.Point(474, 0);
            this.ctClose1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctClose1.Name = "ctClose1";
            this.ctClose1.Size = new System.Drawing.Size(20, 18);
            this.ctClose1.TabIndex = 1;
            this.ctClose1.Load += new System.EventHandler(this.ctClose1_Load);
            this.ctClose1.Click += CtClose1_Click;
            // 
            // FormThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 687);
            this.Controls.Add(this.ctClose1);
            this.Controls.Add(this.webView21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);
            
        }

        private void CtClose1_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private CTControls.CTClose ctClose1;
    }
}