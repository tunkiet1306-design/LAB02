using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace LAB02
{
    public partial class Bai4_BinaryFormatter : Form
    {
        private List<SinhVien> danhSachSV = new List<SinhVien>();
        private int currentIndex = -1;
        public Bai4_BinaryFormatter()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (danhSachSV.Count > 0 && currentIndex > 0)
            {
                currentIndex--;
                HienThiSinhVienTaiViTri(currentIndex);
            }
        }

        private void Bai4_BinaryFormatter_Load(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (danhSachSV.Count == 0)
            {
                MessageBox.Show("Danh sách sinh viên đang trống! Vui lòng bấm Add để thêm ít nhất 1 sinh viên trước khi ghi file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Cấu hình WriteIndented = true giúp chuỗi JSON trong file được xuống dòng đẹp mắt, dễ đọc
                JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

                // Tuần tự hóa (Serialize) toàn bộ List<SinhVien> thành chuỗi JSON
                string jsonInput = JsonSerializer.Serialize(danhSachSV, options);

                // Ghi chuỗi JSON xuống file "input4.txt" với bảng mã UTF-8 (hỗ trợ tiếng Việt có dấu)
                File.WriteAllText("input4.txt", jsonInput, Encoding.UTF8);

                MessageBox.Show("Đã ghi danh sách sinh viên xuống file 'input4.txt' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string hoTen = txtAddName.Text.Trim();
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ và tên sinh viên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddName.Focus();
                return;
            }

            string mssvText = txtAddID.Text.Trim();
            if (mssvText.Length != 8 || !int.TryParse(mssvText, out int mssv))
            {
                MessageBox.Show("Mã số sinh viên (ID) phải là một dãy gồm đúng 8 chữ số!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddID.Focus();
                return;
            }

            string dienThoai = txtAddPhone.Text.Trim();
            if (dienThoai.Length != 10 || !dienThoai.StartsWith("0") || !dienThoai.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số và bắt đầu bằng chữ số 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddPhone.Focus();
                return;
            }

            if (!float.TryParse(txtAddCourse1.Text.Trim(), out float diem1) || diem1 < 0 || diem1 > 10)
            {
                MessageBox.Show("Điểm môn 1 (Course 1) phải là số thực từ 0 đến 10!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddCourse1.Focus();
                return;
            }

            if (!float.TryParse(txtAddCourse2.Text.Trim(), out float diem2) || diem2 < 0 || diem2 > 10)
            {
                MessageBox.Show("Điểm môn 2 (Course 2) phải là số thực từ 0 đến 10!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddCourse2.Focus();
                return;
            }

            if (!float.TryParse(txtAddCourse3.Text.Trim(), out float diem3) || diem3 < 0 || diem3 > 10)
            {
                MessageBox.Show("Điểm môn 3 (Course 3) phải là số thực từ 0 đến 10!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddCourse3.Focus();
                return;
            }

            SinhVien svMoi = new SinhVien
            {
                HoTen = hoTen,
                MSSV = mssv,
                DienThoai = dienThoai,
                Diem1 = diem1,
                Diem2 = diem2,
                Diem3 = diem3,
                DiemTrungBinh = 0f // Đề bài yêu cầu không nhập ĐTB ở bước này
            };

            danhSachSV.Add(svMoi);
            CapNhatRichTextBox(hienThiDTB: false);

            XoaTrangOThem();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem file input4.txt đã tồn tại hay chưa
                if (!File.Exists("input4.txt"))
                {
                    MessageBox.Show("Không tìm thấy file 'input4.txt'! Vui lòng ghi file trước khi đọc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Bước 1: Đọc toàn bộ chuỗi JSON từ file input4.txt lên
                string jsonInput = File.ReadAllText("input4.txt", Encoding.UTF8);

                // Bước 2: Giải tuần tự hóa (Deserialize) chuỗi JSON ngược lại thành List<SinhVien>
                List<SinhVien>? dsDocTuFile = JsonSerializer.Deserialize<List<SinhVien>>(jsonInput);

                if (dsDocTuFile == null || dsDocTuFile.Count == 0)
                {
                    MessageBox.Show("File 'input4.txt' không có dữ liệu sinh viên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                danhSachSV = dsDocTuFile;

                // Bước 3: Duyệt qua từng sinh viên để tính Điểm Trung Bình
                foreach (SinhVien sv in danhSachSV)
                {
                    // Chia cho 3.0f để thực hiện phép chia số thực chính xác
                    sv.DiemTrungBinh = (sv.Diem1 + sv.Diem2 + sv.Diem3) / 3.0f;
                }

                // Bước 4: Ghi danh sách sinh viên (đã có Điểm Trung Bình) xuống file output4.txt
                JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
                string jsonOutput = JsonSerializer.Serialize(danhSachSV, options);
                File.WriteAllText("output4.txt", jsonOutput, Encoding.UTF8);

                // Bước 5: Cập nhật lại RichTextBox ở giữa (hiển thị kèm ĐTB) và hiển thị sinh viên đầu tiên ở khung bên phải
                CapNhatRichTextBox(hienThiDTB: true);
                currentIndex = 0;
                HienThiSinhVienTaiViTri(currentIndex);

                MessageBox.Show("Đã đọc dữ liệu từ 'input4.txt', tính Điểm trung bình và lưu vào 'output4.txt' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Nếu đang ở vị trí lớn hơn 0 thì mới lùi lại được
            if (danhSachSV.Count > 0 && currentIndex > 0)
            {
                currentIndex--;
                HienThiSinhVienTaiViTri(currentIndex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (danhSachSV.Count > 0 && currentIndex < danhSachSV.Count - 1)
            {
                currentIndex++;
                HienThiSinhVienTaiViTri(currentIndex);
            }
        }

        private void HienThiSinhVienTaiViTri(int index)
        {
            if (index >= 0 && index < danhSachSV.Count)
            {
                SinhVien sv = danhSachSV[index];

                txtReadName.Text = sv.HoTen;
                txtReadID.Text = sv.MSSV.ToString();
                txtReadPhone.Text = sv.DienThoai;
                txtReadCourse1.Text = sv.Diem1.ToString();
                txtReadCourse2.Text = sv.Diem2.ToString();
                txtReadCourse3.Text = sv.Diem3.ToString();

                // Làm tròn ĐTB đến 2 chữ số thập phân khi hiển thị
                txtReadAverage.Text = Math.Round(sv.DiemTrungBinh, 2).ToString();

                // Cập nhật số trang (Vì index bắt đầu từ 0 nên số trang hiển thị cho người dùng là index + 1)
                lblPage.Text = (index + 1).ToString();

                // Bật/tắt nút Back và Next hợp lý khi ở trang đầu hoặc trang cuối
                btnBack.Enabled = (index > 0);
                btnNext.Enabled = (index < danhSachSV.Count - 1);
            }
        }

        private void CapNhatRichTextBox(bool hienThiDTB)
        {
            rtbHienThi.Clear();
            foreach (SinhVien sv in danhSachSV)
            {
                rtbHienThi.AppendText($"{sv.HoTen}\n");
                rtbHienThi.AppendText($"{sv.MSSV}\n");
                rtbHienThi.AppendText($"{sv.DienThoai}\n");
                rtbHienThi.AppendText($"{sv.Diem1}\n");
                rtbHienThi.AppendText($"{sv.Diem2}\n");
                rtbHienThi.AppendText($"{sv.Diem3}\n");

                if (hienThiDTB)
                {
                    rtbHienThi.AppendText($"{Math.Round(sv.DiemTrungBinh, 2)}\n");
                }

                rtbHienThi.AppendText("\n"); // Dòng trống ngăn cách giữa các sinh viên
            }
        }

        private void XoaTrangOThem()
        {
            txtAddName.Clear();
            txtAddID.Clear();
            txtAddPhone.Clear();
            txtAddCourse1.Clear();
            txtAddCourse2.Clear();
            txtAddCourse3.Clear();
            txtAddAverage.Clear();
            txtAddName.Focus(); // Đưa con trỏ chuột về lại ô Họ tên
        }

        [Serializable]
        public class SinhVien
        {
            public string HoTen { get; set; } = string.Empty;
            public int MSSV { get; set; }
            public string DienThoai { get; set; } = string.Empty;
            public float Diem1 { get; set; }
            public float Diem2 { get; set; }
            public float Diem3 { get; set; }
            public float DiemTrungBinh { get; set; }
        }

        private void rtbHienThi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReadName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPage_Click(object sender, EventArgs e)
        {

        }
    }
}
