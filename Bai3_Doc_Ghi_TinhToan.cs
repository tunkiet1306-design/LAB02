using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB02
{
    public partial class Bai3_Doc_Ghi_TinhToan : Form
    {
        public Bai3_Doc_Ghi_TinhToan()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files|*.txt|All files|*.*"; // Lọc file txt

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Mở luồng đọc file và đẩy thẳng nội dung lên rtbInput
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        rtbInput.Text = sr.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đọc file: " + ex.Message);
                }
            }
        }

        private void btnThucThi_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy từng dòng dữ liệu trực tiếp từ ô rtbInput
                string[] lines = rtbInput.Lines;

                List<string> outputData = new List<string>();

                // 2. Duyệt qua từng dòng biểu thức để tính toán
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Gọi hàm xử lý tính toán bằng Stack
                    double ketQua = TinhGiaTriBieuThuc(line);

                    // Nối chuỗi kết quả
                    outputData.Add($"{line} = {ketQua}");
                }

                // 3. In toàn bộ danh sách kết quả ra màn hình rtbOutput
                rtbOutput.Text = string.Join("\r\n", outputData);

                // 4. (Tùy chọn) Vẫn giữ nguyên yêu cầu ghi kết quả xuống ổ cứng
                File.WriteAllLines("output3.txt", outputData);

                MessageBox.Show("Đã tính toán và lưu file output3.txt thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private double TinhGiaTriBieuThuc(string bieuThuc)
        {
            bieuThuc = bieuThuc.Replace(" ", "");
            Stack<double> cacConSo = new Stack<double>();
            Stack<char> phepTinh = new Stack<char>();

            for (int i = 0; i < bieuThuc.Length; i++)
            {
                char kyTu = bieuThuc[i];

                if (char.IsDigit(kyTu) || kyTu == '.')
                {
                    string chuoiSo = "";
                    while (i < bieuThuc.Length && (char.IsDigit(bieuThuc[i]) || bieuThuc[i] == '.'))
                    {
                        chuoiSo += bieuThuc[i++];
                    }
                    i--;
                    cacConSo.Push(double.Parse(chuoiSo));
                }
                else if (kyTu == '(')
                {
                    phepTinh.Push(kyTu);
                }
                else if (kyTu == ')')
                {
                    while (phepTinh.Count > 0 && phepTinh.Peek() != '(')
                    {
                        ThucThiPhepTinh(cacConSo, phepTinh.Pop());
                    }
                    phepTinh.Pop();
                }
                else if (kyTu == '+' || kyTu == '-' || kyTu == '*' || kyTu == '/')
                {
                    if (kyTu == '-' && (i == 0 || bieuThuc[i - 1] == '('))
                    {
                        cacConSo.Push(0);
                    }

                    while (phepTinh.Count > 0 && DoUuTien(kyTu) <= DoUuTien(phepTinh.Peek()))
                    {
                        ThucThiPhepTinh(cacConSo, phepTinh.Pop());
                    }
                    phepTinh.Push(kyTu);
                }
            }

            while (phepTinh.Count > 0)
            {
                ThucThiPhepTinh(cacConSo, phepTinh.Pop());
            }

            return cacConSo.Pop();
        }

        private int DoUuTien(char op)
        {
            if (op == '+' || op == '-') return 1;
            if (op == '*' || op == '/') return 2;
            return 0;
        }

        private void ThucThiPhepTinh(Stack<double> cacConSo, char op)
        {
            double b = cacConSo.Pop();
            double a = cacConSo.Pop();
            switch (op)
            {
                case '+': cacConSo.Push(a + b); break;
                case '-': cacConSo.Push(a - b); break;
                case '*': cacConSo.Push(a * b); break;
                case '/': cacConSo.Push(a / b); break;
            }
        }

    }
}
