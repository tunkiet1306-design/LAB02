using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB02
{
    public partial class Bai2_DocThongTin1File : Form
    {
        public Bai2_DocThongTin1File()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            // Khởi tạo công cụ hộp thoại chọn file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files|*.txt|All files|*.*"; // Chỉ lọc hiển thị các file .txt

            // Kiểm tra xem người dùng có bấm OK chọn file hay không
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lấy tên file theo đúng gợi ý của đề bài
                    txtFileName.Text = ofd.SafeFileName.ToString();

                    // Lấy thông tin kích thước file
                    FileInfo fi = new FileInfo(ofd.FileName);
                    txtSize.Text = fi.Length.ToString() + " bytes";

                    // Khởi tạo FileStream kết hợp StreamReader để vừa lấy đường dẫn, vừa đọc file
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        // Lấy đường dẫn URL theo gợi ý đề bài
                        txtURL.Text = fs.Name.ToString();

                        using (StreamReader sr = new StreamReader(fs))
                        {
                            // Đọc toàn bộ nội dung file
                            string content = sr.ReadToEnd();
                            rtbContent.Text = content;

                            // Tính tổng số ký tự
                            txtCharacterCount.Text = content.Length.ToString();

                            // Cắt chuỗi theo ký tự xuống dòng ('\n') để đếm số dòng
                            string[] lines = content.Split('\n');
                            txtLineCount.Text = lines.Length.ToString();

                            // Cắt chuỗi theo khoảng trắng và các ký tự ngắt đoạn để đếm số từ
                            char[] phanCachTu = new char[] { ' ', '\r', '\n', '\t' };
                            string[] words = content.Split(phanCachTu, StringSplitOptions.RemoveEmptyEntries);
                            txtWordsCount.Text = words.Length.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đọc file: " + ex.Message);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
