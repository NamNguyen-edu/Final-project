using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement.GUI
{
    partial class FormTC
    {
        private IContainer components = null;

        private Panel panelTop;
        private Label lblDate;
        private Button btnDatPhong;

        private Panel panelOverview;
        private Label lblTongQuan;
        private Panel ovItem1;
        private Panel ovItem2;
        private Panel ovItem3;
        private Panel ovItem4;
        private Label lblOv1Title;
        private Label lblOv1Value;
        private Label lblOv2Title;
        private Label lblOv2Value;
        private Label lblOv3Title;
        private Label lblOv3Value;
        private Label lblOv4Title;
        private Label lblOv4Value;

        private Panel panelUser;
        private PictureBox picAvatar;
        private Label lblUserName;
        private Label lblUserRole;
        private Label lblUserPhone;
        private Label lblUserMail;

        private Panel panelNotify;
        private Label lblThongBao;
        private Panel notiItem1;
        private Panel notiItem2;
        private Label lblNoti1Title;
        private Label lblNoti1Sub;
        private Label lblNoti2Title;
        private Label lblNoti2Sub;

        private Timer timerDateTime;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.panelOverview = new System.Windows.Forms.Panel();
            this.lblTongQuan = new System.Windows.Forms.Label();
            this.ovItem1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblOv1Title = new System.Windows.Forms.Label();
            this.lblOv1Value = new System.Windows.Forms.Label();
            this.ovItem2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblOv2Title = new System.Windows.Forms.Label();
            this.lblOv2Value = new System.Windows.Forms.Label();
            this.ovItem3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblOv3Title = new System.Windows.Forms.Label();
            this.lblOv3Value = new System.Windows.Forms.Label();
            this.ovItem4 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblOv4Title = new System.Windows.Forms.Label();
            this.lblOv4Value = new System.Windows.Forms.Label();
            this.panelUser = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserPhone = new System.Windows.Forms.Label();
            this.lblUserMail = new System.Windows.Forms.Label();
            this.panelNotify = new System.Windows.Forms.Panel();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.notiItem1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblNoti1Title = new System.Windows.Forms.Label();
            this.lblNoti1Sub = new System.Windows.Forms.Label();
            this.notiItem2 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblNoti2Title = new System.Windows.Forms.Label();
            this.lblNoti2Sub = new System.Windows.Forms.Label();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.panelTop.SuspendLayout();
            this.panelOverview.SuspendLayout();
            this.ovItem1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ovItem2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.ovItem3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.ovItem4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panelNotify.SuspendLayout();
            this.notiItem1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.notiItem2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelTop.Controls.Add(this.lblDate);
            this.panelTop.Controls.Add(this.btnDatPhong);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 74);
            this.panelTop.TabIndex = 3;
            this.panelTop.SizeChanged += new System.EventHandler(this.panelTop_SizeChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.Location = new System.Drawing.Point(20, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 23);
            this.lblDate.TabIndex = 0;
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.AutoSize = true;
            this.btnDatPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(120)))), ((int)(((byte)(72)))));
            this.btnDatPhong.FlatAppearance.BorderSize = 0;
            this.btnDatPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatPhong.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnDatPhong.ForeColor = System.Drawing.Color.White;
            this.btnDatPhong.Location = new System.Drawing.Point(1024, 18);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Padding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.btnDatPhong.Size = new System.Drawing.Size(126, 41);
            this.btnDatPhong.TabIndex = 1;
            this.btnDatPhong.Text = "Đặt phòng";
            this.btnDatPhong.UseVisualStyleBackColor = false;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // panelOverview
            // 
            this.panelOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(241)))), ((int)(((byte)(214)))));
            this.panelOverview.Controls.Add(this.lblTongQuan);
            this.panelOverview.Controls.Add(this.ovItem1);
            this.panelOverview.Controls.Add(this.ovItem2);
            this.panelOverview.Controls.Add(this.ovItem3);
            this.panelOverview.Controls.Add(this.ovItem4);
            this.panelOverview.Location = new System.Drawing.Point(40, 80);
            this.panelOverview.Name = "panelOverview";
            this.panelOverview.Size = new System.Drawing.Size(336, 514);
            this.panelOverview.TabIndex = 2;
            // 
            // lblTongQuan
            // 
            this.lblTongQuan.AutoSize = true;
            this.lblTongQuan.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTongQuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(90)))), ((int)(((byte)(40)))));
            this.lblTongQuan.Location = new System.Drawing.Point(28, 29);
            this.lblTongQuan.Name = "lblTongQuan";
            this.lblTongQuan.Size = new System.Drawing.Size(167, 41);
            this.lblTongQuan.TabIndex = 0;
            this.lblTongQuan.Text = "Tổng quan";
            // 
            // ovItem1
            // 
            this.ovItem1.BackColor = System.Drawing.Color.White;
            this.ovItem1.Controls.Add(this.pictureBox1);
            this.ovItem1.Controls.Add(this.lblOv1Title);
            this.ovItem1.Controls.Add(this.lblOv1Value);
            this.ovItem1.Location = new System.Drawing.Point(25, 91);
            this.ovItem1.Name = "ovItem1";
            this.ovItem1.Size = new System.Drawing.Size(281, 84);
            this.ovItem1.TabIndex = 1;
            this.ovItem1.Click += new EventHandler(this.ovItem1_Click);
            this.lblOv1Title.Click += new EventHandler(this.ovItem1_Click);
            this.lblOv1Value.Click += new EventHandler(this.ovItem1_Click);

            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelManagement.Properties.Resources.DangThue__1_;
            this.pictureBox1.Location = new System.Drawing.Point(10, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 55);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblOv1Title
            // 
            this.lblOv1Title.AutoSize = true;
            this.lblOv1Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblOv1Title.Location = new System.Drawing.Point(74, 14);
            this.lblOv1Title.Name = "lblOv1Title";
            this.lblOv1Title.Size = new System.Drawing.Size(108, 28);
            this.lblOv1Title.TabIndex = 0;
            this.lblOv1Title.Text = "Đang thuê";
            // 
            // lblOv1Value
            // 
            this.lblOv1Value.AutoSize = true;
            this.lblOv1Value.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOv1Value.Location = new System.Drawing.Point(74, 44);
            this.lblOv1Value.Name = "lblOv1Value";
            this.lblOv1Value.Size = new System.Drawing.Size(82, 25);
            this.lblOv1Value.TabIndex = 1;
            this.lblOv1Value.Text = "3 phòng";
            // 
            // ovItem2
            // 
            this.ovItem2.BackColor = System.Drawing.Color.White;
            this.ovItem2.Controls.Add(this.pictureBox2);
            this.ovItem2.Controls.Add(this.lblOv2Title);
            this.ovItem2.Controls.Add(this.lblOv2Value);
            this.ovItem2.Location = new System.Drawing.Point(25, 195);
            this.ovItem2.Name = "ovItem2";
            this.ovItem2.Size = new System.Drawing.Size(281, 80);
            this.ovItem2.TabIndex = 2;
            this.ovItem2.Click += new EventHandler(this.ovItem2_Click);
            this.lblOv2Title.Click += new EventHandler(this.ovItem2_Click);
            this.lblOv2Value.Click += new EventHandler(this.ovItem2_Click);

            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HotelManagement.Properties.Resources.dadatphong;
            this.pictureBox2.Location = new System.Drawing.Point(10, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 55);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // lblOv2Title
            // 
            this.lblOv2Title.AutoSize = true;
            this.lblOv2Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblOv2Title.Location = new System.Drawing.Point(74, 12);
            this.lblOv2Title.Name = "lblOv2Title";
            this.lblOv2Title.Size = new System.Drawing.Size(71, 28);
            this.lblOv2Title.TabIndex = 0;
            this.lblOv2Title.Text = "Đã đặt";
            // 
            // lblOv2Value
            // 
            this.lblOv2Value.AutoSize = true;
            this.lblOv2Value.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOv2Value.Location = new System.Drawing.Point(74, 42);
            this.lblOv2Value.Name = "lblOv2Value";
            this.lblOv2Value.Size = new System.Drawing.Size(82, 25);
            this.lblOv2Value.TabIndex = 1;
            this.lblOv2Value.Text = "5 phòng";
            // 
            // ovItem3
            // 
            this.ovItem3.BackColor = System.Drawing.Color.White;
            this.ovItem3.Controls.Add(this.pictureBox3);
            this.ovItem3.Controls.Add(this.lblOv3Title);
            this.ovItem3.Controls.Add(this.lblOv3Value);
            this.ovItem3.Location = new System.Drawing.Point(25, 294);
            this.ovItem3.Name = "ovItem3";
            this.ovItem3.Size = new System.Drawing.Size(281, 81);
            this.ovItem3.TabIndex = 3;
            this.ovItem3.Click += new EventHandler(this.ovItem3_Click);
            this.lblOv3Title.Click += new EventHandler(this.ovItem3_Click);
            this.lblOv3Value.Click += new EventHandler(this.ovItem3_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HotelManagement.Properties.Resources.ChuaDon1;
            this.pictureBox3.Location = new System.Drawing.Point(11, 14);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(58, 55);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // lblOv3Title
            // 
            this.lblOv3Title.AutoSize = true;
            this.lblOv3Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblOv3Title.Location = new System.Drawing.Point(74, 14);
            this.lblOv3Title.Name = "lblOv3Title";
            this.lblOv3Title.Size = new System.Drawing.Size(100, 28);
            this.lblOv3Title.TabIndex = 0;
            this.lblOv3Title.Text = "Chưa dọn";
            // 
            // lblOv3Value
            // 
            this.lblOv3Value.AutoSize = true;
            this.lblOv3Value.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOv3Value.Location = new System.Drawing.Point(75, 44);
            this.lblOv3Value.Name = "lblOv3Value";
            this.lblOv3Value.Size = new System.Drawing.Size(82, 25);
            this.lblOv3Value.TabIndex = 1;
            this.lblOv3Value.Text = "5 phòng";
            // 
            // ovItem4
            // 
            this.ovItem4.BackColor = System.Drawing.Color.White;
            this.ovItem4.Controls.Add(this.pictureBox4);
            this.ovItem4.Controls.Add(this.lblOv4Title);
            this.ovItem4.Controls.Add(this.lblOv4Value);
            this.ovItem4.Location = new System.Drawing.Point(25, 393);
            this.ovItem4.Name = "ovItem4";
            this.ovItem4.Size = new System.Drawing.Size(281, 80);
            this.ovItem4.TabIndex = 4;
            this.ovItem4.Click += new EventHandler(this.ovItem4_Click);
            this.lblOv4Title.Click += new EventHandler(this.ovItem4_Click);
            this.lblOv4Value.Click += new EventHandler(this.ovItem4_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::HotelManagement.Properties.Resources.Dangsc1;
            this.pictureBox4.Location = new System.Drawing.Point(10, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(58, 55);
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // lblOv4Title
            // 
            this.lblOv4Title.AutoSize = true;
            this.lblOv4Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblOv4Title.Location = new System.Drawing.Point(74, 10);
            this.lblOv4Title.Name = "lblOv4Title";
            this.lblOv4Title.Size = new System.Drawing.Size(146, 28);
            this.lblOv4Title.TabIndex = 0;
            this.lblOv4Title.Text = "Đang sửa chữa";
            // 
            // lblOv4Value
            // 
            this.lblOv4Value.AutoSize = true;
            this.lblOv4Value.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOv4Value.Location = new System.Drawing.Point(74, 42);
            this.lblOv4Value.Name = "lblOv4Value";
            this.lblOv4Value.Size = new System.Drawing.Size(82, 25);
            this.lblOv4Value.TabIndex = 1;
            this.lblOv4Value.Text = "1 phòng";
            // 
            // panelUser
            // 
            this.panelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(241)))), ((int)(((byte)(214)))));
            this.panelUser.Controls.Add(this.picAvatar);
            this.panelUser.Controls.Add(this.lblUserName);
            this.panelUser.Controls.Add(this.lblUserRole);
            this.panelUser.Controls.Add(this.lblUserPhone);
            this.panelUser.Controls.Add(this.lblUserMail);
            this.panelUser.Location = new System.Drawing.Point(402, 80);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(748, 230);
            this.panelUser.TabIndex = 1;
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.LightGray;
            this.picAvatar.Location = new System.Drawing.Point(50, 50);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(130, 130);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(217, 29);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(305, 46);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Nguyễn Phúc Bình";
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUserRole.Location = new System.Drawing.Point(220, 90);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(100, 28);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "Nhân viên";
            // 
            // lblUserPhone
            // 
            this.lblUserPhone.AutoSize = true;
            this.lblUserPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUserPhone.Location = new System.Drawing.Point(220, 125);
            this.lblUserPhone.Name = "lblUserPhone";
            this.lblUserPhone.Size = new System.Drawing.Size(163, 28);
            this.lblUserPhone.TabIndex = 3;
            this.lblUserPhone.Text = "📞 0123 4567 89";
            // 
            // lblUserMail
            // 
            this.lblUserMail.AutoSize = true;
            this.lblUserMail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUserMail.Location = new System.Drawing.Point(220, 155);
            this.lblUserMail.Name = "lblUserMail";
            this.lblUserMail.Size = new System.Drawing.Size(216, 28);
            this.lblUserMail.TabIndex = 4;
            this.lblUserMail.Text = "✉️ npbinh@gmail.com";
            // 
            // panelNotify
            // 
            this.panelNotify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(241)))), ((int)(((byte)(214)))));
            this.panelNotify.Controls.Add(this.lblThongBao);
            this.panelNotify.Controls.Add(this.notiItem1);
            this.panelNotify.Controls.Add(this.notiItem2);
            this.panelNotify.Location = new System.Drawing.Point(402, 330);
            this.panelNotify.Name = "panelNotify";
            this.panelNotify.Size = new System.Drawing.Size(748, 264);
            this.panelNotify.TabIndex = 0;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(90)))), ((int)(((byte)(40)))));
            this.lblThongBao.Location = new System.Drawing.Point(40, 20);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(166, 41);
            this.lblThongBao.TabIndex = 0;
            this.lblThongBao.Text = "Thông báo";
            // 
            // notiItem1
            // 
            this.notiItem1.BackColor = System.Drawing.Color.White;
            this.notiItem1.Controls.Add(this.pictureBox5);
            this.notiItem1.Controls.Add(this.lblNoti1Title);
            this.notiItem1.Controls.Add(this.lblNoti1Sub);
            this.notiItem1.Location = new System.Drawing.Point(40, 70);
            this.notiItem1.Name = "notiItem1";
            this.notiItem1.Size = new System.Drawing.Size(690, 82);
            this.notiItem1.TabIndex = 1;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::HotelManagement.Properties.Resources.NhacLich1;
            this.pictureBox5.Location = new System.Drawing.Point(17, 13);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(58, 55);
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // lblNoti1Title
            // 
            this.lblNoti1Title.AutoSize = true;
            this.lblNoti1Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblNoti1Title.Location = new System.Drawing.Point(84, 9);
            this.lblNoti1Title.Name = "lblNoti1Title";
            this.lblNoti1Title.Size = new System.Drawing.Size(241, 28);
            this.lblNoti1Title.TabIndex = 0;
            this.lblNoti1Title.Text = "Thông báo giờ check - in";
            // 
            // lblNoti1Sub
            // 
            this.lblNoti1Sub.AutoSize = true;
            this.lblNoti1Sub.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNoti1Sub.Location = new System.Drawing.Point(84, 43);
            this.lblNoti1Sub.Name = "lblNoti1Sub";
            this.lblNoti1Sub.Size = new System.Drawing.Size(295, 25);
            this.lblNoti1Sub.TabIndex = 1;
            this.lblNoti1Sub.Text = "Phòng 101 sắp đến giờ Check - in";
            // 
            // notiItem2
            // 
            this.notiItem2.BackColor = System.Drawing.Color.White;
            this.notiItem2.Controls.Add(this.pictureBox6);
            this.notiItem2.Controls.Add(this.lblNoti2Title);
            this.notiItem2.Controls.Add(this.lblNoti2Sub);
            this.notiItem2.Location = new System.Drawing.Point(40, 158);
            this.notiItem2.Name = "notiItem2";
            this.notiItem2.Size = new System.Drawing.Size(690, 83);
            this.notiItem2.TabIndex = 2;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::HotelManagement.Properties.Resources.CSKH1;
            this.pictureBox6.Location = new System.Drawing.Point(17, 15);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(58, 55);
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            // 
            // lblNoti2Title
            // 
            this.lblNoti2Title.AutoSize = true;
            this.lblNoti2Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblNoti2Title.Location = new System.Drawing.Point(84, 11);
            this.lblNoti2Title.Name = "lblNoti2Title";
            this.lblNoti2Title.Size = new System.Drawing.Size(212, 28);
            this.lblNoti2Title.TabIndex = 0;
            this.lblNoti2Title.Text = "Chăm sóc khách hàng";
            // 
            // lblNoti2Sub
            // 
            this.lblNoti2Sub.AutoSize = true;
            this.lblNoti2Sub.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNoti2Sub.Location = new System.Drawing.Point(84, 48);
            this.lblNoti2Sub.Name = "lblNoti2Sub";
            this.lblNoti2Sub.Size = new System.Drawing.Size(408, 25);
            this.lblNoti2Sub.TabIndex = 1;
            this.lblNoti2Sub.Text = "Khách hàng phòng 102 yêu cầu thêm khăn tắm";
            // 
            // timerDateTime
            // 
            this.timerDateTime.Interval = 60000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // FormTC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.panelNotify);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.panelOverview);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(1200, 650);
            this.Name = "FormTC";
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.FormTC_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelOverview.ResumeLayout(false);
            this.panelOverview.PerformLayout();
            this.ovItem1.ResumeLayout(false);
            this.ovItem1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ovItem2.ResumeLayout(false);
            this.ovItem2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ovItem3.ResumeLayout(false);
            this.ovItem3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ovItem4.ResumeLayout(false);
            this.ovItem4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panelNotify.ResumeLayout(false);
            this.panelNotify.PerformLayout();
            this.notiItem1.ResumeLayout(false);
            this.notiItem1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.notiItem2.ResumeLayout(false);
            this.notiItem2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
    }
}
