using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace LAB02
{
    public partial class Bai5_QuanLyPhongVe : Form
    {

        private List<Phim> danhSachPhim = new List<Phim>();

        // 2. Dictionary lưu trạng thái các ghế đã bán theo từng suất chiếu
        // Key: "TênPhim_Phòng X" (VD: "Mai_Phòng 2") -> Value: Danh sách ghế đã mua (VD: {"B2", "B3"})
        private Dictionary<string, List<string>> gheDaBan = new Dictionary<string, List<string>>();

        // Đường dẫn tên file theo đúng yêu cầu đề bài Lab 02
        private const string FILE_INPUT = "input5.txt";
        private const string FILE_OUTPUT = "output5.txt";
        public Bai5_QuanLyPhongVe()
        {
            InitializeComponent();
        }
        private void Bai5_QuanLyPhongVe_Load(object sender, EventArgs e)
        {
            // Bước 1: Khởi tạo sơ đồ 15 ghế ngồi (A1-A5, B1-B5, C1-C5) lên CheckedListBox
            clbChoNgoi.Items.Clear();
            string[] cacHangGhe = { "A", "B", "C" };
            foreach (string hang in cacHangGhe)
            {
                for (int i = 1; i <= 5; i++)
                {
                    clbChoNgoi.Items.Add(hang + i);
                }
            }

            // Bước 2: Nếu chưa có file input5.txt thì tạo sẵn 4 bộ phim chuẩn từ Lab 01 để tiện chạy thử
            if (!File.Exists(FILE_INPUT))
            {
                TaoFileInputMacDinh();
            }

            // Bước 3: Tự động đọc file input5.txt ngay khi mở Form để nạp danh sách phim
            DocDuLieuTuFileInput(hienThongBao: false);
        }

        private void TaoFileInputMacDinh()
        {
            string duLieuMau =
                "Đào, phở và piano\r\n45000\r\n1, 2, 3\r\n" +
                "Mai\r\n100000\r\n2, 3\r\n" +
                "Gặp lại chị bầu\r\n70000\r\n1\r\n" +
                "Tarot\r\n90000\r\n3";

            File.WriteAllText(FILE_INPUT, duLieuMau, Encoding.UTF8);
        }
        private void btnGhiInput_Click(object sender, EventArgs e)
        {
            string tenPhim = txtTenPhimMoi.Text.Trim();
            string giaVeText = txtGiaVeMoi.Text.Trim();
            string phongChieuText = txtPhongChieuMoi.Text.Trim();

            // 1. Kiểm tra tính hợp lệ khi nhập thông tin phim mới
            if (string.IsNullOrEmpty(tenPhim))
            {
                MessageBox.Show("Vui lòng nhập tên phim!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhimMoi.Focus();
                return;
            }

            if (!double.TryParse(giaVeText, out double giaVe) || giaVe <= 0)
            {
                MessageBox.Show("Giá vé chuẩn phải là một số dương hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaVeMoi.Focus();
                return;
            }
            // Cắt chuỗi phòng chiếu theo dấu phẩy hoặc khoảng trắng
            string[] mangPhongStr = phongChieuText.Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> dsPhong = new List<int>();

            foreach (string p in mangPhongStr)
            {
                if (int.TryParse(p.Trim(), out int soPhong) && soPhong > 0)
                {
                    if (!dsPhong.Contains(soPhong))
                        dsPhong.Add(soPhong);
                }
                else
                {
                    MessageBox.Show($"Số phòng chiếu '{p}' không hợp lệ! Vui lòng nhập các số nguyên dương cách nhau bởi dấu phẩy (VD: 1, 2, 3).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhongChieuMoi.Focus();
                    return;
                }
            }

            if (dsPhong.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập ít nhất 1 phòng chiếu!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhongChieuMoi.Focus();
                return;
            }

            try
            {
                // 2. Ghi nối tiếp (Append) bộ phim mới xuống cuối file input5.txt theo đúng cấu trúc 3 dòng:
                // Dòng 1: <Tên phim>
                // Dòng 2: <Giá vé chuẩn>
                // Dòng 3: <Danh sách phòng chiếu>
                string chuoiPhong = string.Join(", ", dsPhong);
                string noiDungGhiThem = $"\r\n{tenPhim}\r\n{giaVe}\r\n{chuoiPhong}";

                // Nếu file chưa tồn tại hoặc đang rỗng thì không cần xuống dòng ở đầu
                if (!File.Exists(FILE_INPUT) || string.IsNullOrWhiteSpace(File.ReadAllText(FILE_INPUT)))
                {
                    noiDungGhiThem = $"{tenPhim}\r\n{giaVe}\r\n{chuoiPhong}";
                }

                File.AppendAllText(FILE_INPUT, noiDungGhiThem, Encoding.UTF8);

                // Xóa trắng các ô nhập sau khi ghi xong
                txtTenPhimMoi.Clear();
                txtGiaVeMoi.Clear();
                txtPhongChieuMoi.Clear();
                txtTenPhimMoi.Focus();

                // Tự động đọc lại file để cập nhật giao diện
                DocDuLieuTuFileInput(hienThongBao: false);
                MessageBox.Show($"Đã thêm phim '{tenPhim}' vào file '{FILE_INPUT}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDocInput_Click(object sender, EventArgs e)
        {
            DocDuLieuTuFileInput(hienThongBao: true);
        }

        private void DocDuLieuTuFileInput(bool hienThongBao)
        {
            try
            {
                if (!File.Exists(FILE_INPUT))
                {
                    MessageBox.Show($"Không tìm thấy file '{FILE_INPUT}'!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị nguyên văn nội dung file input5.txt lên RichTextBox bên trái
                string rawContent = File.ReadAllText(FILE_INPUT, Encoding.UTF8);
                rtbInput5.Text = rawContent;

                // Đọc từng dòng (bỏ qua các dòng trống) để bóc tách thành các đối tượng Phim
                string[] lines = File.ReadAllLines(FILE_INPUT, Encoding.UTF8)
                                     .Select(l => l.Trim())
                                     .Where(l => !string.IsNullOrEmpty(l))
                                     .ToArray();

                danhSachPhim.Clear();
                gheDaBan.Clear(); // Reset lại trạng thái ghế khi nạp lại dữ liệu gốc

                // Cứ mỗi cụm 3 dòng liên tiếp tương ứng với 1 bộ phim:
                // lines[i]   : Tên phim
                // lines[i+1] : Giá vé chuẩn
                // lines[i+2] : Danh sách phòng chiếu
                for (int i = 0; i + 2 < lines.Length; i += 3)
                {
                    string tenPhim = lines[i];
                    double.TryParse(lines[i + 1], out double giaChuan);

                    string[] cacPhongStr = lines[i + 2].Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    List<int> dsPhong = new List<int>();
                    foreach (string p in cacPhongStr)
                    {
                        if (int.TryParse(p.Trim(), out int soPhong))
                        {
                            dsPhong.Add(soPhong);
                        }
                    }

                    Phim phimMoi = new Phim
                    {
                        TenPhim = tenPhim,
                        GiaVeChuan = giaChuan,
                        DanhSachPhong = dsPhong,
                        SoVeBanRa = 0,
                        DoanhThu = 0
                    };

                    danhSachPhim.Add(phimMoi);
                }

                // Đổ danh sách tên phim lên ComboBox chọn phim
                cbbChonPhim.Items.Clear();
                foreach (Phim p in danhSachPhim)
                {
                    cbbChonPhim.Items.Add(p.TenPhim);
                }

                // Chọn sẵn bộ phim đầu tiên để tự động load phòng chiếu
                if (cbbChonPhim.Items.Count > 0)
                {
                    cbbChonPhim.SelectedIndex = 0;
                }

                if (hienThongBao)
                {
                    MessageBox.Show($"Đã đọc thành công {danhSachPhim.Count} bộ phim từ file '{FILE_INPUT}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbbChonPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbChonPhim.SelectedIndex == -1) return;

            // Xóa danh sách phòng chiếu cũ và bỏ tick các ghế đang chọn
            cbbChonPhongChieu.Items.Clear();
            for (int i = 0; i < clbChoNgoi.Items.Count; i++)
            {
                clbChoNgoi.SetItemChecked(i, false);
            }

            string tenPhimChon = cbbChonPhim.SelectedItem?.ToString() ?? "";

            // Tìm đối tượng Phim tương ứng trong danhSachPhim
            Phim? phim = danhSachPhim.FirstOrDefault(p => p.TenPhim == tenPhimChon);
            if (phim != null)
            {
                foreach (int soPhong in phim.DanhSachPhong)
                {
                    cbbChonPhongChieu.Items.Add("Phòng " + soPhong);
                }

                if (cbbChonPhongChieu.Items.Count > 0)
                {
                    cbbChonPhongChieu.SelectedIndex = 0;
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTenKhach.Text.Trim();

            // 1. Kiểm tra ràng buộc nhập liệu
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTenKhach.Focus();
                return;
            }
            if (cbbChonPhim.SelectedIndex == -1 || cbbChonPhongChieu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (clbChoNgoi.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 ghế ngồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenPhim = cbbChonPhim.SelectedItem?.ToString() ?? "";
            string tenPhong = cbbChonPhongChieu.SelectedItem?.ToString() ?? "";

            // Tìm đối tượng Phim để lấy giá vé chuẩn và cộng dồn thống kê
            Phim? phimHienTai = danhSachPhim.FirstOrDefault(p => p.TenPhim == tenPhim);
            if (phimHienTai == null) return;

            // Tạo khóa phân biệt từng suất chiếu (Phim + Phòng)[cite: 1]
            string keySuatChieu = $"{tenPhim}_{tenPhong}";
            if (!gheDaBan.ContainsKey(keySuatChieu))
            {
                gheDaBan[keySuatChieu] = new List<string>();
            }

            // 2. Kiểm tra xem có ghế nào khách đang chọn đã bị mua trước đó chưa[cite: 1]
            List<string> dsGheDangChon = new List<string>();
            foreach (var item in clbChoNgoi.CheckedItems)
            {
                string maGhe = item.ToString()!;
                if (gheDaBan[keySuatChieu].Contains(maGhe))
                {
                    MessageBox.Show($"Ghế [{maGhe}] tại {tenPhong} của phim '{tenPhim}' đã có người mua!\nVui lòng bỏ chọn ghế này.", "Trùng ghế", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dsGheDangChon.Add(maGhe);
            }

            // 3. Tính tiền theo từng hạng ghế (Vớt: 1/4, Thường: 1, VIP: 2)[cite: 1]
            double giaChuan = phimHienTai.GiaVeChuan;
            double tongTienHoaDon = 0;

            foreach (string ghe in dsGheDangChon)
            {
                double giaGhe = giaChuan;

                if (ghe == "A1" || ghe == "A5" || ghe == "C1" || ghe == "C5")
                {
                    giaGhe = giaChuan * 0.25; // Vé vớt: 1/4 giá chuẩn[cite: 1]
                }
                else if (ghe == "B2" || ghe == "B3" || ghe == "B4")
                {
                    giaGhe = giaChuan * 2.0;  // Vé VIP: 2 lần giá chuẩn[cite: 1]
                }
                else
                {
                    giaGhe = giaChuan * 1.0;  // Vé thường: 1 lần giá chuẩn[cite: 1]
                }

                tongTienHoaDon += giaGhe;

                // Lưu ghế vào danh sách ghế đã bán của suất chiếu này[cite: 1]
                gheDaBan[keySuatChieu].Add(ghe);
            }

            // 4. Cập nhật số lượng vé bán ra và doanh thu trực tiếp vào đối tượng Phim
            phimHienTai.SoVeBanRa += dsGheDangChon.Count;
            phimHienTai.DoanhThu += tongTienHoaDon;

            // 5. Xuất biên lai ra màn hình RichTextBox[cite: 1]
            string chuoiGhe = string.Join(", ", dsGheDangChon);
            StringBuilder sbBienLai = new StringBuilder();
            sbBienLai.AppendLine("========== BIÊN LAI THANH TOÁN ==========");
            sbBienLai.AppendLine($"Khách hàng : {hoTen}");
            sbBienLai.AppendLine($"Phim       : {tenPhim}");
            sbBienLai.AppendLine($"Phòng chiếu: {tenPhong}");
            sbBienLai.AppendLine($"Ghế đã mua : {chuoiGhe} ({dsGheDangChon.Count} vé)");
            sbBienLai.AppendLine($"TỔNG TIỀN  : {tongTienHoaDon:N0} VNĐ");

            rtbBienLai.Text = sbBienLai.ToString();

            // 6. Bỏ chọn các ghế trên giao diện sau khi thanh toán thành công[cite: 1]
            for (int i = 0; i < clbChoNgoi.Items.Count; i++)
            {
                clbChoNgoi.SetItemChecked(i, false);
            }

            MessageBox.Show("Đặt vé và thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnXuatThongKe_Click(object sender, EventArgs e)
        {
            if (danhSachPhim.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu phim để thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnXuatThongKe.Enabled = false;
                rtbThongKe.Clear();

                // 1. Sắp xếp danh sách phim theo Doanh thu giảm dần (Từ cao xuống thấp) bằng LINQ
                List<Phim> dsXepHang = danhSachPhim.OrderByDescending(p => p.DoanhThu).ToList();

                // 2. Cấu hình thanh ProgressBar
                prgTienTrinh.Minimum = 0;
                prgTienTrinh.Maximum = dsXepHang.Count;
                prgTienTrinh.Value = 0;

                StringBuilder sbOutput = new StringBuilder();
                sbOutput.AppendLine("==========================================================================================");
                sbOutput.AppendLine(string.Format("{0,-6} | {1,-22} | {2,-8} | {3,-8} | {4,-14} | {5,16}",
                    "Hạng", "Tên phim", "Vé bán", "Vé tồn", "Tỉ lệ bán (%)", "Doanh thu (VNĐ)"));
                sbOutput.AppendLine("==========================================================================================");

                // 3. Duyệt qua từng bộ phim, tính toán thống kê và tăng dần ProgressBar
                for (int i = 0; i < dsXepHang.Count; i++)
                {
                    Phim p = dsXepHang[i];
                    int xepHang = i + 1;

                    // Mỗi dòng dữ liệu được xử lý sẽ dừng 250ms để mắt thường nhìn thấy thanh ProgressBar chạy mượt mà
                    await Task.Delay(250);

                    string dongThongKe = string.Format("{0,-6} | {1,-22} | {2,-8} | {3,-8} | {4,12:F2}% | {5,16:N0}",
                        xepHang,
                        p.TenPhim,
                        p.SoVeBanRa,
                        p.SoVeTon,
                        p.TiLeVeBanRa,
                        p.DoanhThu);

                    sbOutput.AppendLine(dongThongKe);

                    // Cập nhật giá trị ProgressBar
                    prgTienTrinh.Value = i + 1;
                }

                sbOutput.AppendLine("==========================================================================================");

                // 4. Hiển thị bảng thống kê lên màn hình và ghi xuống file output5.txt
                rtbThongKe.Text = sbOutput.ToString();
                File.WriteAllText(FILE_OUTPUT, sbOutput.ToString(), Encoding.UTF8);

                MessageBox.Show($"Đã xuất thống kê phòng vé ra file '{FILE_OUTPUT}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnXuatThongKe.Enabled = true;
            }
        }
        public class Phim
        {
            public string TenPhim { get; set; } = string.Empty;
            public double GiaVeChuan { get; set; }
            public List<int> DanhSachPhong { get; set; } = new List<int>();

            // Thuộc tính lưu trữ số liệu bán vé thực tế
            public int SoVeBanRa { get; set; }
            public double DoanhThu { get; set; }

            // Mỗi phòng chiếu có 15 ghế (A1->A5, B1->B5, C1->C5)[cite: 1]
            // => Tổng số vé phát hành của bộ phim = Số lượng phòng chiếu phim đó * 15
            public int TongSoVe => DanhSachPhong.Count * 15;

            // Số lượng vé tồn = Tổng số vé của phim - Số vé đã bán ra
            public int SoVeTon => TongSoVe - SoVeBanRa;

            // Tỉ lệ vé bán ra (%) = (Số vé bán ra / Tổng số vé) * 100
            public double TiLeVeBanRa => TongSoVe > 0 ? (SoVeBanRa * 100.0) / TongSoVe : 0;
        }

    }
}
