namespace HotelManagement
{
    partial class FormMainCUS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainCUS));
            this.PanelBackground = new System.Windows.Forms.Panel();
            this.panelMainChildForm = new System.Windows.Forms.Panel();
            this.panelInfomation = new System.Windows.Forms.Panel();
            this.labelPhienBan = new System.Windows.Forms.Label();
            this.labelBanQuyen = new System.Windows.Forms.Label();
            this.Sidebar = new System.Windows.Forms.Panel();
            this.ButtonQLTK = new System.Windows.Forms.Button();
            this.ButtonCSKH = new System.Windows.Forms.Button();
            this.ButtonQLLD = new System.Windows.Forms.Button();
            this.ButtonThanhToan = new System.Windows.Forms.Button();
            this.ButtonDatPhong = new System.Windows.Forms.Button();
            this.ButtonTrangChu = new System.Windows.Forms.Button();
            this.PanelUser = new System.Windows.Forms.Panel();
            this.linkLabelDangXuat = new System.Windows.Forms.LinkLabel();
            this.LabelTenNguoiDung = new System.Windows.Forms.Label();
            this.PictureBoxUser = new System.Windows.Forms.PictureBox();
            this.panelName = new System.Windows.Forms.Panel();
            this.PictureBoxMenu = new System.Windows.Forms.PictureBox();
            this.panelControlBox = new System.Windows.Forms.Panel();
            this.ctMaximize1 = new HotelManagement.CTControls.CTMaximize();
            this.ctMinimize1 = new HotelManagement.CTControls.CTMinimize();
            this.ctClose1 = new HotelManagement.CTControls.CTClose();
            this.labelTenKhachSan = new System.Windows.Forms.Label();
            this.PanelBackground.SuspendLayout();
            this.panelInfomation.SuspendLayout();
            this.Sidebar.SuspendLayout();
            this.PanelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUser)).BeginInit();
            this.panelName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMenu)).BeginInit();
            this.panelControlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelBackground
            // 
            this.PanelBackground.Controls.Add(this.panelMainChildForm);
            this.PanelBackground.Controls.Add(this.panelInfomation);
            this.PanelBackground.Controls.Add(this.Sidebar);
            this.PanelBackground.Controls.Add(this.panelName);
            this.PanelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBackground.Location = new System.Drawing.Point(0, 0);
            this.PanelBackground.Name = "PanelBackground";
            this.PanelBackground.Size = new System.Drawing.Size(1522, 934);
            this.PanelBackground.TabIndex = 0;
            this.PanelBackground.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBackground_Paint);
            // 
            // panelMainChildForm
            // 
            this.panelMainChildForm.AutoScroll = true;
            this.panelMainChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelMainChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainChildForm.Location = new System.Drawing.Point(262, 60);
            this.panelMainChildForm.Name = "panelMainChildForm";
            this.panelMainChildForm.Size = new System.Drawing.Size(1260, 833);
            this.panelMainChildForm.TabIndex = 7;
            this.panelMainChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMainCUS_Paint);
            // 
            // panelInfomation
            // 
            this.panelInfomation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(145)))), ((int)(((byte)(153)))));
            this.panelInfomation.Controls.Add(this.labelPhienBan);
            this.panelInfomation.Controls.Add(this.labelBanQuyen);
            this.panelInfomation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInfomation.Location = new System.Drawing.Point(262, 893);
            this.panelInfomation.Name = "panelInfomation";
            this.panelInfomation.Size = new System.Drawing.Size(1260, 41);
            this.panelInfomation.TabIndex = 6;
            // 
            // labelPhienBan
            // 
            this.labelPhienBan.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPhienBan.AutoSize = true;
            this.labelPhienBan.Location = new System.Drawing.Point(1156, 11);
            this.labelPhienBan.Name = "labelPhienBan";
            this.labelPhienBan.Size = new System.Drawing.Size(106, 20);
            this.labelPhienBan.TabIndex = 1;
            this.labelPhienBan.Text = "Version 1.0.0";
            // 
            // labelBanQuyen
            // 
            this.labelBanQuyen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBanQuyen.AutoSize = true;
            this.labelBanQuyen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBanQuyen.Location = new System.Drawing.Point(6, 11);
            this.labelBanQuyen.Name = "labelBanQuyen";
            this.labelBanQuyen.Size = new System.Drawing.Size(501, 28);
            this.labelBanQuyen.TabIndex = 0;
            this.labelBanQuyen.Text = "Copyright © 2022 TBT Coorporation. All rights reserved.";
            // 
            // Sidebar
            // 
            this.Sidebar.AutoScroll = true;
            this.Sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(145)))), ((int)(((byte)(153)))));
            this.Sidebar.Controls.Add(this.ButtonQLTK);
            this.Sidebar.Controls.Add(this.ButtonCSKH);
            this.Sidebar.Controls.Add(this.ButtonQLLD);
            this.Sidebar.Controls.Add(this.ButtonThanhToan);
            this.Sidebar.Controls.Add(this.ButtonDatPhong);
            this.Sidebar.Controls.Add(this.ButtonTrangChu);
            this.Sidebar.Controls.Add(this.PanelUser);
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Sidebar.Location = new System.Drawing.Point(0, 60);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Size = new System.Drawing.Size(262, 874);
            this.Sidebar.TabIndex = 5;
            // 
            // ButtonQLTK
            // 
            this.ButtonQLTK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonQLTK.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonQLTK.FlatAppearance.BorderSize = 0;
            this.ButtonQLTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonQLTK.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonQLTK.ForeColor = System.Drawing.Color.Black;
            this.ButtonQLTK.Image = global::HotelManagement.Properties.Resources.MenuQuanLyTaiKhoan;
            this.ButtonQLTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonQLTK.Location = new System.Drawing.Point(0, 374);
            this.ButtonQLTK.Name = "ButtonQLTK";
            this.ButtonQLTK.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonQLTK.Size = new System.Drawing.Size(262, 48);
            this.ButtonQLTK.TabIndex = 41;
            this.ButtonQLTK.TabStop = false;
            this.ButtonQLTK.Text = "    Quản lý tài khoản";
            this.ButtonQLTK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonQLTK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonQLTK.UseVisualStyleBackColor = true;
            this.ButtonQLTK.Click += new System.EventHandler(this.ButtonQLTK_Click);
            // 
            // ButtonCSKH
            // 
            this.ButtonCSKH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCSKH.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonCSKH.FlatAppearance.BorderSize = 0;
            this.ButtonCSKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCSKH.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCSKH.ForeColor = System.Drawing.Color.Black;
            this.ButtonCSKH.Image = ((System.Drawing.Image)(resources.GetObject("ButtonCSKH.Image")));
            this.ButtonCSKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonCSKH.Location = new System.Drawing.Point(0, 326);
            this.ButtonCSKH.Name = "ButtonCSKH";
            this.ButtonCSKH.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonCSKH.Size = new System.Drawing.Size(262, 48);
            this.ButtonCSKH.TabIndex = 40;
            this.ButtonCSKH.TabStop = false;
            this.ButtonCSKH.Text = "    CS Khách hàng";
            this.ButtonCSKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonCSKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonCSKH.UseVisualStyleBackColor = true;
            this.ButtonCSKH.Click += new System.EventHandler(this.ButtonCSKH_Click);
            // 
            // ButtonQLLD
            // 
            this.ButtonQLLD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonQLLD.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonQLLD.FlatAppearance.BorderSize = 0;
            this.ButtonQLLD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonQLLD.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonQLLD.ForeColor = System.Drawing.Color.Black;
            this.ButtonQLLD.Image = ((System.Drawing.Image)(resources.GetObject("ButtonQLLD.Image")));
            this.ButtonQLLD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonQLLD.Location = new System.Drawing.Point(0, 278);
            this.ButtonQLLD.Name = "ButtonQLLD";
            this.ButtonQLLD.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonQLLD.Size = new System.Drawing.Size(262, 48);
            this.ButtonQLLD.TabIndex = 39;
            this.ButtonQLLD.TabStop = false;
            this.ButtonQLLD.Text = "    Quản lý lịch đặt";
            this.ButtonQLLD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonQLLD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonQLLD.UseVisualStyleBackColor = true;
            this.ButtonQLLD.Click += new System.EventHandler(this.ButtonQLLD_Click);
            // 
            // ButtonThanhToan
            // 
            this.ButtonThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonThanhToan.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonThanhToan.FlatAppearance.BorderSize = 0;
            this.ButtonThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonThanhToan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonThanhToan.ForeColor = System.Drawing.Color.Black;
            this.ButtonThanhToan.Image = ((System.Drawing.Image)(resources.GetObject("ButtonThanhToan.Image")));
            this.ButtonThanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonThanhToan.Location = new System.Drawing.Point(0, 230);
            this.ButtonThanhToan.Name = "ButtonThanhToan";
            this.ButtonThanhToan.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonThanhToan.Size = new System.Drawing.Size(262, 48);
            this.ButtonThanhToan.TabIndex = 38;
            this.ButtonThanhToan.TabStop = false;
            this.ButtonThanhToan.Text = "    Thanh toán";
            this.ButtonThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonThanhToan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonThanhToan.UseVisualStyleBackColor = true;
            this.ButtonThanhToan.Click += new System.EventHandler(this.ButtonThanhToan_Click);
            // 
            // ButtonDatPhong
            // 
            this.ButtonDatPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDatPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonDatPhong.FlatAppearance.BorderSize = 0;
            this.ButtonDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDatPhong.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDatPhong.ForeColor = System.Drawing.Color.Black;
            this.ButtonDatPhong.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDatPhong.Image")));
            this.ButtonDatPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDatPhong.Location = new System.Drawing.Point(0, 182);
            this.ButtonDatPhong.Name = "ButtonDatPhong";
            this.ButtonDatPhong.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonDatPhong.Size = new System.Drawing.Size(262, 48);
            this.ButtonDatPhong.TabIndex = 37;
            this.ButtonDatPhong.TabStop = false;
            this.ButtonDatPhong.Text = "    Đặt phòng";
            this.ButtonDatPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDatPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonDatPhong.UseVisualStyleBackColor = true;
            this.ButtonDatPhong.Click += new System.EventHandler(this.ButtonDatPhong_Click);
            // 
            // ButtonTrangChu
            // 
            this.ButtonTrangChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(119)))), ((int)(((byte)(34)))));
            this.ButtonTrangChu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ButtonTrangChu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonTrangChu.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonTrangChu.FlatAppearance.BorderSize = 0;
            this.ButtonTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTrangChu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTrangChu.ForeColor = System.Drawing.Color.White;
            this.ButtonTrangChu.Image = global::HotelManagement.Properties.Resources.MenuTrangChu;
            this.ButtonTrangChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonTrangChu.Location = new System.Drawing.Point(0, 134);
            this.ButtonTrangChu.Name = "ButtonTrangChu";
            this.ButtonTrangChu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ButtonTrangChu.Size = new System.Drawing.Size(262, 48);
            this.ButtonTrangChu.TabIndex = 25;
            this.ButtonTrangChu.TabStop = false;
            this.ButtonTrangChu.Text = "    Trang chủ";
            this.ButtonTrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonTrangChu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonTrangChu.UseVisualStyleBackColor = false;
            this.ButtonTrangChu.Click += new System.EventHandler(this.ButtonTrangChu_Click);
            // 
            // PanelUser
            // 
            this.PanelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.PanelUser.Controls.Add(this.linkLabelDangXuat);
            this.PanelUser.Controls.Add(this.LabelTenNguoiDung);
            this.PanelUser.Controls.Add(this.PictureBoxUser);
            this.PanelUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelUser.Location = new System.Drawing.Point(0, 0);
            this.PanelUser.Name = "PanelUser";
            this.PanelUser.Size = new System.Drawing.Size(262, 134);
            this.PanelUser.TabIndex = 0;
            // 
            // linkLabelDangXuat
            // 
            this.linkLabelDangXuat.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(119)))), ((int)(((byte)(34)))));
            this.linkLabelDangXuat.AutoSize = true;
            this.linkLabelDangXuat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDangXuat.LinkColor = System.Drawing.Color.Black;
            this.linkLabelDangXuat.Location = new System.Drawing.Point(3, 10);
            this.linkLabelDangXuat.Name = "linkLabelDangXuat";
            this.linkLabelDangXuat.Size = new System.Drawing.Size(101, 28);
            this.linkLabelDangXuat.TabIndex = 2;
            this.linkLabelDangXuat.TabStop = true;
            this.linkLabelDangXuat.Text = "Đăng xuất";
            this.linkLabelDangXuat.Click += new System.EventHandler(this.linkLabelDangXuat_Click);
            // 
            // LabelTenNguoiDung
            // 
            this.LabelTenNguoiDung.AutoSize = true;
            this.LabelTenNguoiDung.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTenNguoiDung.Location = new System.Drawing.Point(46, 99);
            this.LabelTenNguoiDung.Name = "LabelTenNguoiDung";
            this.LabelTenNguoiDung.Size = new System.Drawing.Size(0, 32);
            this.LabelTenNguoiDung.TabIndex = 1;
            // 
            // PictureBoxUser
            // 
            this.PictureBoxUser.Image = global::HotelManagement.Properties.Resources.user;
            this.PictureBoxUser.Location = new System.Drawing.Point(87, 10);
            this.PictureBoxUser.Name = "PictureBoxUser";
            this.PictureBoxUser.Size = new System.Drawing.Size(80, 80);
            this.PictureBoxUser.TabIndex = 0;
            this.PictureBoxUser.TabStop = false;
            // 
            // panelName
            // 
            this.panelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(145)))), ((int)(((byte)(153)))));
            this.panelName.Controls.Add(this.PictureBoxMenu);
            this.panelName.Controls.Add(this.panelControlBox);
            this.panelName.Controls.Add(this.labelTenKhachSan);
            this.panelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelName.Location = new System.Drawing.Point(0, 0);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(1522, 60);
            this.panelName.TabIndex = 4;
            this.panelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelName_MouseDown);
            // 
            // PictureBoxMenu
            // 
            this.PictureBoxMenu.BackColor = System.Drawing.Color.Transparent;
            this.PictureBoxMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxMenu.Image = global::HotelManagement.Properties.Resources.Menu;
            this.PictureBoxMenu.Location = new System.Drawing.Point(12, 4);
            this.PictureBoxMenu.Name = "PictureBoxMenu";
            this.PictureBoxMenu.Size = new System.Drawing.Size(50, 50);
            this.PictureBoxMenu.TabIndex = 21;
            this.PictureBoxMenu.TabStop = false;
            this.PictureBoxMenu.Click += new System.EventHandler(this.PictureBoxMenu_Click);
            this.PictureBoxMenu.MouseLeave += new System.EventHandler(this.PictureBoxMenu_MouseLeave);
            this.PictureBoxMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMenu_MouseMove);
            // 
            // panelControlBox
            // 
            this.panelControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(145)))), ((int)(((byte)(153)))));
            this.panelControlBox.Controls.Add(this.ctMaximize1);
            this.panelControlBox.Controls.Add(this.ctMinimize1);
            this.panelControlBox.Controls.Add(this.ctClose1);
            this.panelControlBox.Location = new System.Drawing.Point(1424, 3);
            this.panelControlBox.Name = "panelControlBox";
            this.panelControlBox.Size = new System.Drawing.Size(95, 30);
            this.panelControlBox.TabIndex = 6;
            this.panelControlBox.MouseLeave += new System.EventHandler(this.panelControlBox_MouseLeave);
            this.panelControlBox.MouseHover += new System.EventHandler(this.panelControlBox_MouseHover);
            this.panelControlBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelControlBox_MouseMove);
            // 
            // ctMaximize1
            // 
            this.ctMaximize1.BackColor = System.Drawing.Color.Transparent;
            this.ctMaximize1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctMaximize1.BackgroundImage")));
            this.ctMaximize1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctMaximize1.Location = new System.Drawing.Point(10, 6);
            this.ctMaximize1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctMaximize1.Name = "ctMaximize1";
            this.ctMaximize1.Size = new System.Drawing.Size(15, 15);
            this.ctMaximize1.TabIndex = 2;
            this.ctMaximize1.Click += new System.EventHandler(this.ctMaximize1_Click);
            // 
            // ctMinimize1
            // 
            this.ctMinimize1.BackColor = System.Drawing.Color.Transparent;
            this.ctMinimize1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctMinimize1.BackgroundImage")));
            this.ctMinimize1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctMinimize1.Location = new System.Drawing.Point(40, 6);
            this.ctMinimize1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctMinimize1.Name = "ctMinimize1";
            this.ctMinimize1.Size = new System.Drawing.Size(15, 15);
            this.ctMinimize1.TabIndex = 1;
            this.ctMinimize1.Click += new System.EventHandler(this.ctMinimize1_Click);
            // 
            // ctClose1
            // 
            this.ctClose1.BackColor = System.Drawing.Color.Transparent;
            this.ctClose1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctClose1.BackgroundImage")));
            this.ctClose1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ctClose1.Location = new System.Drawing.Point(71, 6);
            this.ctClose1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctClose1.Name = "ctClose1";
            this.ctClose1.Size = new System.Drawing.Size(15, 15);
            this.ctClose1.TabIndex = 0;
            this.ctClose1.Click += new System.EventHandler(this.ctClose1_Click);
            // 
            // labelTenKhachSan
            // 
            this.labelTenKhachSan.AutoSize = true;
            this.labelTenKhachSan.BackColor = System.Drawing.Color.Transparent;
            this.labelTenKhachSan.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenKhachSan.ForeColor = System.Drawing.Color.LightSalmon;
            this.labelTenKhachSan.Location = new System.Drawing.Point(68, 14);
            this.labelTenKhachSan.Name = "labelTenKhachSan";
            this.labelTenKhachSan.Size = new System.Drawing.Size(285, 41);
            this.labelTenKhachSan.TabIndex = 2;
            this.labelTenKhachSan.Text = "Hotel Management";
            // 
            // FormMainCUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1522, 934);
            this.Controls.Add(this.PanelBackground);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1522, 934);
            this.Name = "FormMainCUS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách sạn";
            this.Activated += new System.EventHandler(this.FormMainCUS_Activated);
            this.Load += new System.EventHandler(this.FormMainCUS_Load);
            this.SizeChanged += new System.EventHandler(this.FormMainCUS_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.Resize += new System.EventHandler(this.FormMainCUS_Resize);
            this.PanelBackground.ResumeLayout(false);
            this.panelInfomation.ResumeLayout(false);
            this.panelInfomation.PerformLayout();
            this.Sidebar.ResumeLayout(false);
            this.PanelUser.ResumeLayout(false);
            this.PanelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUser)).EndInit();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxMenu)).EndInit();
            this.panelControlBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelBackground;
        private System.Windows.Forms.Panel panelMainChildForm;
        private System.Windows.Forms.Panel panelInfomation;
        private System.Windows.Forms.Label labelPhienBan;
        private System.Windows.Forms.Label labelBanQuyen;
        private System.Windows.Forms.Panel Sidebar;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Panel panelControlBox;
        private CTControls.CTMaximize ctMaximize1;
        private CTControls.CTMinimize ctMinimize1;
        private CTControls.CTClose ctClose1;
        private System.Windows.Forms.Label labelTenKhachSan;
        private System.Windows.Forms.PictureBox PictureBoxMenu;
        private System.Windows.Forms.Panel PanelUser;
        private System.Windows.Forms.PictureBox PictureBoxUser;
        private System.Windows.Forms.Label LabelTenNguoiDung;
        private System.Windows.Forms.Button ButtonTrangChu;
        private System.Windows.Forms.LinkLabel linkLabelDangXuat;
        private System.Windows.Forms.Button ButtonQLTK;
        private System.Windows.Forms.Button ButtonCSKH;
        private System.Windows.Forms.Button ButtonQLLD;
        private System.Windows.Forms.Button ButtonThanhToan;
        private System.Windows.Forms.Button ButtonDatPhong;
    }
}