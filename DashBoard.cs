using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB02
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void MoFormBaiTap(Form formBaiTap)
        {
            try
            {
                this.Hide(); // 1. Ẩn màn hình Dashboard đi
                using (formBaiTap)
                {
                    formBaiTap.ShowDialog(); // 2. Mở Form bài tập và chờ người dùng thao tác xong
                }
            }
            finally
            {
                this.Show();     // 3. Khi tắt Form bài tập -> Tự động hiện lại Dashboard
                this.Activate(); // Đưa cửa sổ Dashboard lên trên cùng
            }
        }

        private void btnBai1_Click(object sender, EventArgs e)
        {
            MoFormBaiTap(new Bai1_GhivaDocFile());
        }

        private void btnBai2_Click(object sender, EventArgs e)
        {
            MoFormBaiTap(new Bai2_DocThongTin1File());
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            MoFormBaiTap(new Bai3_Doc_Ghi_TinhToan());
        }

        private void btnBai4_Click(object sender, EventArgs e)
        {
            MoFormBaiTap(new Bai4_BinaryFormatter());
        }

        private void btnBai5_Click(object sender, EventArgs e)
        {
            MoFormBaiTap(new Bai5_QuanLyPhongVe());
        }
        private void btnBai6_Click(object sender, EventArgs e)
        {
            MoFormBaiTap(new Bai6_HomNayAnGi());
        }

        private void btnBai7_Click(object sender, EventArgs e)
        {
            MoFormBaiTap(new Bai7_DuyetThuMuc());
        }
    }
}
