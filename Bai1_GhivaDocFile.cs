using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Forms;


namespace LAB02
{
    public partial class Bai1_GhivaDocFile : Form
    {
        public Bai1_GhivaDocFile()
        {
            InitializeComponent();
        }

        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu trên màn hình và chuyển sang in hoa
                string noiDungInHoa = rtbDocFile.Text.ToUpper();

                // Khởi tạo luồng ghi file
                using (StreamWriter sw = new StreamWriter("output1.txt", false, Encoding.UTF8))
                {
                    // Ghi chuỗi văn bản xuống ổ cứng
                    sw.Write(noiDungInHoa);
                }
                rtbDocFile.Clear();
                MessageBox.Show("Ghi file thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi ghi file: " + ex.Message);
            }
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file cần đọc";
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (ofd.ShowDialog() != DialogResult.OK)
                    return; // Người dùng bấm Cancel

                try
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName, Encoding.UTF8))
                    {
                        rtbDocFile.Text = sr.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi đọc file: " + ex.Message);
                }
            }
        }
    }
}
