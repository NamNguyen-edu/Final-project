using HotelManagement.CTControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.GUI
{
    public partial class FormTrangChu_CUS : Form
    {
        private FormMainCUS formMainCUS;
        public FormTrangChu_CUS()
        {
            InitializeComponent();

        }
        public FormTrangChu_CUS(FormMainCUS formMainCUS)
        {
            InitializeComponent();
            this.formMainCUS = formMainCUS;
           
        }

        private void CTButtonTest_Click(object sender, EventArgs e)
        {
            CTMessageBox.Show("Sinh viên khoa công nghệ phần mềm - Đại học Công Nghệ Thông Tin - Đại học Quốc gia Thành Phố Hồ Chí Minh","Thông báo",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
        }

        private void FormTrangChu_CUS_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
        }
    }
}
