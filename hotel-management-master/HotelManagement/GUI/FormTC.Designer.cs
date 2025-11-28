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
        private Label lblNoti2Title;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCSKH;


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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblNoti2Title = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblNoti1Title = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.gridCheckin = new System.Windows.Forms.DataGridView();
            this.ColPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colgio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheckin = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.flowLayoutPanelCSKH = new System.Windows.Forms.FlowLayoutPanel();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.ctPanel1 = new CTPanel.CTPanel();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckin)).BeginInit();
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
            this.panelTop.Size = new System.Drawing.Size(1226, 74);
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
            this.panelOverview.Size = new System.Drawing.Size(1157, 195);
            this.panelOverview.TabIndex = 2;
            // 
            // lblTongQuan
            // 
            this.lblTongQuan.AutoSize = true;
            this.lblTongQuan.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTongQuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(90)))), ((int)(((byte)(40)))));
            this.lblTongQuan.Location = new System.Drawing.Point(28, 18);
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
            this.ovItem1.Location = new System.Drawing.Point(39, 71);
            this.ovItem1.Name = "ovItem1";
            this.ovItem1.Size = new System.Drawing.Size(229, 84);
            this.ovItem1.TabIndex = 1;
            this.ovItem1.Click += new System.EventHandler(this.ovItem1_Click);
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
            this.lblOv1Title.Click += new System.EventHandler(this.ovItem1_Click);
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
            this.lblOv1Value.Click += new System.EventHandler(this.ovItem1_Click);
            // 
            // ovItem2
            // 
            this.ovItem2.BackColor = System.Drawing.Color.White;
            this.ovItem2.Controls.Add(this.pictureBox2);
            this.ovItem2.Controls.Add(this.lblOv2Title);
            this.ovItem2.Controls.Add(this.lblOv2Value);
            this.ovItem2.Location = new System.Drawing.Point(325, 71);
            this.ovItem2.Name = "ovItem2";
            this.ovItem2.Size = new System.Drawing.Size(229, 84);
            this.ovItem2.TabIndex = 2;
            this.ovItem2.Click += new System.EventHandler(this.ovItem2_Click);
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
            this.lblOv2Title.Click += new System.EventHandler(this.ovItem2_Click);
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
            this.lblOv2Value.Click += new System.EventHandler(this.ovItem2_Click);
            // 
            // ovItem3
            // 
            this.ovItem3.BackColor = System.Drawing.Color.White;
            this.ovItem3.Controls.Add(this.pictureBox3);
            this.ovItem3.Controls.Add(this.lblOv3Title);
            this.ovItem3.Controls.Add(this.lblOv3Value);
            this.ovItem3.Location = new System.Drawing.Point(612, 71);
            this.ovItem3.Name = "ovItem3";
            this.ovItem3.Size = new System.Drawing.Size(229, 84);
            this.ovItem3.TabIndex = 3;
            this.ovItem3.Click += new System.EventHandler(this.ovItem3_Click);
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
            this.lblOv3Title.Click += new System.EventHandler(this.ovItem3_Click);
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
            this.lblOv3Value.Click += new System.EventHandler(this.ovItem3_Click);
            // 
            // ovItem4
            // 
            this.ovItem4.BackColor = System.Drawing.Color.White;
            this.ovItem4.Controls.Add(this.pictureBox4);
            this.ovItem4.Controls.Add(this.lblOv4Title);
            this.ovItem4.Controls.Add(this.lblOv4Value);
            this.ovItem4.Location = new System.Drawing.Point(894, 71);
            this.ovItem4.Name = "ovItem4";
            this.ovItem4.Size = new System.Drawing.Size(229, 84);
            this.ovItem4.TabIndex = 4;
            this.ovItem4.Click += new System.EventHandler(this.ovItem4_Click);
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
            this.lblOv4Title.Click += new System.EventHandler(this.ovItem4_Click);
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
            this.lblOv4Value.Click += new System.EventHandler(this.ovItem4_Click);
            // 
            // panelUser
            // 
            this.panelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(241)))), ((int)(((byte)(214)))));
            this.panelUser.Controls.Add(this.picAvatar);
            this.panelUser.Controls.Add(this.lblUserName);
            this.panelUser.Controls.Add(this.lblUserRole);
            this.panelUser.Controls.Add(this.lblUserPhone);
            this.panelUser.Controls.Add(this.lblUserMail);
            this.panelUser.Location = new System.Drawing.Point(41, 302);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(387, 433);
            this.panelUser.TabIndex = 1;
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.LightGray;
            this.picAvatar.Location = new System.Drawing.Point(117, 37);
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
            this.lblUserName.Location = new System.Drawing.Point(40, 194);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(305, 46);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Nguyễn Phúc Bình";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUserRole.Location = new System.Drawing.Point(43, 259);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(100, 28);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "Nhân viên";
            // 
            // lblUserPhone
            // 
            this.lblUserPhone.AutoSize = true;
            this.lblUserPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUserPhone.Location = new System.Drawing.Point(43, 303);
            this.lblUserPhone.Name = "lblUserPhone";
            this.lblUserPhone.Size = new System.Drawing.Size(163, 28);
            this.lblUserPhone.TabIndex = 3;
            this.lblUserPhone.Text = "📞 0123 4567 89";
            // 
            // lblUserMail
            // 
            this.lblUserMail.AutoSize = true;
            this.lblUserMail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUserMail.Location = new System.Drawing.Point(43, 348);
            this.lblUserMail.Name = "lblUserMail";
            this.lblUserMail.Size = new System.Drawing.Size(216, 28);
            this.lblUserMail.TabIndex = 4;
            this.lblUserMail.Text = "✉️ npbinh@gmail.com";
            // 
            // panelNotify
            // 
            this.panelNotify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(241)))), ((int)(((byte)(214)))));
            this.panelNotify.Controls.Add(this.lblNoti2Title);
            this.panelNotify.Controls.Add(this.pictureBox6);
            this.panelNotify.Controls.Add(this.lblNoti1Title);
            this.panelNotify.Controls.Add(this.pictureBox5);
            this.panelNotify.Controls.Add(this.gridCheckin);
            this.panelNotify.Controls.Add(this.ctPanel1);
            this.panelNotify.Controls.Add(this.lblThongBao);
            this.panelNotify.Controls.Add(this.flowLayoutPanelCSKH);
            this.panelNotify.Location = new System.Drawing.Point(452, 302);
            this.panelNotify.Name = "panelNotify";
            this.panelNotify.Size = new System.Drawing.Size(748, 433);
            this.panelNotify.TabIndex = 0;
            // 
            // lblNoti2Title
            // 
            this.lblNoti2Title.AutoSize = true;
            this.lblNoti2Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblNoti2Title.Location = new System.Drawing.Point(490, 79);
            this.lblNoti2Title.Name = "lblNoti2Title";
            this.lblNoti2Title.Size = new System.Drawing.Size(212, 28);
            this.lblNoti2Title.TabIndex = 0;
            this.lblNoti2Title.Text = "Chăm sóc khách hàng";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::HotelManagement.Properties.Resources.CSKH1;
            this.pictureBox6.Location = new System.Drawing.Point(407, 64);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(58, 55);
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            // 
            // lblNoti1Title
            // 
            this.lblNoti1Title.AutoSize = true;
            this.lblNoti1Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblNoti1Title.Location = new System.Drawing.Point(111, 79);
            this.lblNoti1Title.Name = "lblNoti1Title";
            this.lblNoti1Title.Size = new System.Drawing.Size(241, 28);
            this.lblNoti1Title.TabIndex = 0;
            this.lblNoti1Title.Text = "Thông báo giờ check - in";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::HotelManagement.Properties.Resources.NhacLich1;
            this.pictureBox5.Location = new System.Drawing.Point(47, 64);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(58, 55);
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // gridCheckin
            // 
            this.gridCheckin.AllowUserToAddRows = false;
            this.gridCheckin.AllowUserToDeleteRows = false;
            this.gridCheckin.AllowUserToResizeColumns = false;
            this.gridCheckin.AllowUserToResizeRows = false;
            this.gridCheckin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gridCheckin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.gridCheckin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCheckin.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridCheckin.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(103)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(103)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCheckin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridCheckin.ColumnHeadersHeight = 50;
            this.gridCheckin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridCheckin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColPhong,
            this.Colgio,
            this.ColCheckin});
            this.gridCheckin.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCheckin.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridCheckin.EnableHeadersVisualStyles = false;
            this.gridCheckin.Location = new System.Drawing.Point(48, 149);
            this.gridCheckin.MultiSelect = false;
            this.gridCheckin.Name = "gridCheckin";
            this.gridCheckin.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCheckin.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridCheckin.RowHeadersVisible = false;
            this.gridCheckin.RowHeadersWidth = 40;
            this.gridCheckin.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCheckin.RowTemplate.Height = 40;
            this.gridCheckin.RowTemplate.ReadOnly = true;
            this.gridCheckin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCheckin.Size = new System.Drawing.Size(318, 252);
            this.gridCheckin.TabIndex = 12;
            // 
            // ColPhong
            // 
            this.ColPhong.FillWeight = 97.26121F;
            this.ColPhong.HeaderText = "Số phòng";
            this.ColPhong.MinimumWidth = 6;
            this.ColPhong.Name = "ColPhong";
            this.ColPhong.ReadOnly = true;
            this.ColPhong.Width = 113;
            // 
            // Colgio
            // 
            this.Colgio.FillWeight = 97.26121F;
            this.Colgio.HeaderText = "Giờ";
            this.Colgio.MinimumWidth = 6;
            this.Colgio.Name = "Colgio";
            this.Colgio.ReadOnly = true;
            this.Colgio.Width = 112;
            // 
            // ColCheckin
            // 
            this.ColCheckin.FillWeight = 80F;
            this.ColCheckin.HeaderText = "Check-in";
            this.ColCheckin.MinimumWidth = 6;
            this.ColCheckin.Name = "ColCheckin";
            this.ColCheckin.ReadOnly = true;
            this.ColCheckin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCheckin.Width = 93;
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
            // flowLayoutPanelCSKH
            // 
            this.flowLayoutPanelCSKH.Location = new System.Drawing.Point(407, 149);
            this.flowLayoutPanelCSKH.Name = "flowLayoutPanelCSKH";
            this.flowLayoutPanelCSKH.Size = new System.Drawing.Size(291, 265);
            this.flowLayoutPanelCSKH.TabIndex = 31;
            // 
            // timerDateTime
            // 
            this.timerDateTime.Interval = 60000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // ctPanel1
            // 
            this.ctPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ctPanel1.BackColor = System.Drawing.Color.White;
            this.ctPanel1.BorderRadius = 50;
            this.ctPanel1.ForeColor = System.Drawing.Color.Black;
            this.ctPanel1.GradientAngle = 90F;
            this.ctPanel1.GradientBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(103)))), ((int)(((byte)(36)))));
            this.ctPanel1.GradientTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(103)))), ((int)(((byte)(36)))));
            this.ctPanel1.Location = new System.Drawing.Point(40, 131);
            this.ctPanel1.Name = "ctPanel1";
            this.ctPanel1.Size = new System.Drawing.Size(334, 283);
            this.ctPanel1.TabIndex = 30;
            // 
            // FormTC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1226, 747);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox6;
        private DataGridView gridCheckin;
        private CTPanel.CTPanel ctPanel1;
        private Label lblNoti1Title;
        private PictureBox pictureBox5;
        private DataGridViewTextBoxColumn ColPhong;
        private DataGridViewTextBoxColumn Colgio;
        private DataGridViewImageColumn ColCheckin;
    }
}
