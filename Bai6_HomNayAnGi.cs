using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LAB02
{
    public partial class Bai6_HomNayAnGi : Form
    {
        // Danh sách tên SQL Server phổ biến để tự động dò tìm
        private static readonly string[] DanhSachServer = new[]
        {
            @"localhost",
            @"localhost\SQLEXPRESS",
            @".\SQLEXPRESS",
            @"(localdb)\MSSQLLocalDB"
        };

        private string? _chuoiKetNoiHienTai = null;
        private bool _suDungSqlServer = false;
        private const string TEN_DATABASE = "HomNayAnGiDB";

        // Đường dẫn thư mục Data_Bai6 nằm ngay trong thư mục gốc của Project (đi theo file .zip khi nộp bài)
        private string _thuMucData = string.Empty;
        private string _thuMucImages = string.Empty;
        private string _fileDongBoJson = string.Empty;

        // Bộ nhớ đệm đồng bộ giữa SQL Server và File đính kèm trong Project
        private DuLieuDongBoBai6 _duLieuDongBo = new DuLieuDongBoBai6();

        public Bai6_HomNayAnGi()
        {
            InitializeComponent();
        }

        // ================= SỰ KIỆN 1: KHỞI ĐỘNG FORM (TỰ ĐỘNG NẠP & HIỂN THỊ KẾT QUẢ NGAY) =================
        private void Bai6_HomNayAnGi_Load(object sender, EventArgs e)
        {
            // [ĐÃ SỬA] Ảnh thật thường lớn hơn khung -> co giãn vừa khung PictureBox, không bị cắt mất
            picMonAn.SizeMode = PictureBoxSizeMode.Zoom;

            // 1. Khởi tạo thư mục Data_Bai6 và Images ngay trong thư mục gốc của Project
            KhoiTaoThuMucDongGoiProject();

            // 2. Nạp danh sách Quyền hạn mặc định
            cbbQuyenHan.Items.Clear();
            cbbQuyenHan.Items.AddRange(new string[] { "Admin", "Đầu bếp", "Thành viên", "Khách" });
            cbbQuyenHan.SelectedIndex = 0;

            // 3. Đọc dữ liệu bạn đã tạo được lưu trong file đồng bộ của Project (nếu chưa có thì tạo bộ mẫu kèm file ảnh thật)
            NapHoacTaoDuLieuDongGoi();

            // 4. Kết nối SQL Server (nếu máy có SQL Server) và tự động đẩy dữ liệu đã tạo vào SQL Server của máy hiện tại
            KetNoiVaDongBoSQLServer();

            // 5. Hiển thị danh sách Người dùng lên ComboBox và Món ăn lên ListView
            TaiDanhSachNguoiDungLenComboBox();
            TaiDanhSachMonAnLenListView();

            // 6. TỰ ĐỘNG CHỌN NGAY 1 MÓN ĂN KHI MỞ FORM ĐỂ GIÁO VIÊN THẤY KẾT QUẢ NGAY MÀ KHÔNG CẦN BẤM NÚT
            if (lvwMonAn.Items.Count > 0)
            {
                ChonNgauNhienMotMonAn();
            }
        }

        // ================= CƠ CHẾ ĐÓNG GÓI HÌNH ẢNH & DỮ LIỆU ĐI KÈM PROJECT =================

        // Tìm đúng thư mục gốc chứa file .csproj để lưu ảnh và dữ liệu (không sợ bị mất khi Clean/Rebuild hoặc gửi sang máy khác)
        private void KhoiTaoThuMucDongGoiProject()
        {
            DirectoryInfo? dir = new DirectoryInfo(Application.StartupPath);
            while (dir != null && dir.GetFiles("*.csproj").Length == 0)
            {
                dir = dir.Parent;
            }

            string thuMucGocProject = dir != null ? dir.FullName : Application.StartupPath;
            _thuMucData = Path.Combine(thuMucGocProject, "Data_Bai6");
            _thuMucImages = Path.Combine(_thuMucData, "Images");
            _fileDongBoJson = Path.Combine(_thuMucData, "csdl_dong_bo.json");

            Directory.CreateDirectory(_thuMucData);
            Directory.CreateDirectory(_thuMucImages);
        }

        // Đọc dữ liệu từ file đính kèm trong Project, nếu chạy lần đầu tiên thì tạo sẵn 5 món ăn kèm 5 file ảnh .png thật
        private void NapHoacTaoDuLieuDongGoi()
        {
            if (File.Exists(_fileDongBoJson))
            {
                try
                {
                    string json = File.ReadAllText(_fileDongBoJson, Encoding.UTF8);
                    var data = JsonSerializer.Deserialize<DuLieuDongBoBai6>(json);
                    if (data != null && data.DanhSachNguoiDung.Count > 0)
                    {
                        _duLieuDongBo = data;
                        return;
                    }
                }
                catch
                {
                    // Nếu file JSON lỗi thì tạo lại dữ liệu mặc định bên dưới
                }
            }

            // Tạo dữ liệu mẫu ban đầu kèm file ảnh .png thật lưu trong Data_Bai6\Images
            _duLieuDongBo = new DuLieuDongBoBai6
            {
                DanhSachNguoiDung = new List<NguoiDungItem>
                {
                    new NguoiDungItem { IDNCC = 1, HoVaTen = "Vũ Tuấn Kiệt", QuyenHan = "Admin" },
                    new NguoiDungItem { IDNCC = 2, HoVaTen = "Nguyễn Thị Mai", QuyenHan = "Đầu bếp" },
                    new NguoiDungItem { IDNCC = 3, HoVaTen = "Trần Văn Hùng", QuyenHan = "Thành viên" }
                },
                DanhSachMonAn = new List<MonAnRecord>
                {
                    new MonAnRecord { IDMA = 1, TenMonAn = "Phở bò tái lăn", HinhAnh = TaoFileAnhMau("pho_bo.png", "Phở bò tái lăn", Color.FromArgb(254, 215, 170)), IDNCC = 1 },
                    new MonAnRecord { IDMA = 2, TenMonAn = "Cơm tấm sườn bì chả", HinhAnh = TaoFileAnhMau("com_tam.png", "Cơm tấm sườn bì chả", Color.FromArgb(254, 240, 138)), IDNCC = 2 },
                    new MonAnRecord { IDMA = 3, TenMonAn = "Bún bò Huế đặc biệt", HinhAnh = TaoFileAnhMau("bun_bo.png", "Bún bò Huế đặc biệt", Color.FromArgb(254, 202, 202)), IDNCC = 2 },
                    new MonAnRecord { IDMA = 4, TenMonAn = "Bánh mì thịt nướng", HinhAnh = TaoFileAnhMau("banh_mi.png", "Bánh mì thịt nướng", Color.FromArgb(217, 249, 157)), IDNCC = 3 },
                    new MonAnRecord { IDMA = 5, TenMonAn = "Gỏi cuốn tôm thịt", HinhAnh = TaoFileAnhMau("goi_cuon.png", "Gỏi cuốn tôm thịt", Color.FromArgb(186, 230, 253)), IDNCC = 1 }
                }
            };

            LuuFileDongBoJson();
        }

        // Lưu toàn bộ trạng thái CSDL xuống file JSON nằm trong thư mục Project
        private void LuuFileDongBoJson()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_duLieuDongBo, options);
            File.WriteAllText(_fileDongBoJson, json, Encoding.UTF8);
        }

        // Hàm tạo sẵn file ảnh .png thật trong thư mục Data_Bai6\Images cho các món mặc định
        private string TaoFileAnhMau(string tenFile, string tenMon, Color mauNen)
        {
            string duongDanDayDu = Path.Combine(_thuMucImages, tenFile);
            if (!File.Exists(duongDanDayDu))
            {
                using (Bitmap bmp = VeTheHinhAnhMonAn(tenMon, tenFile, mauNen))
                {
                    bmp.Save(duongDanDayDu, ImageFormat.Png);
                }
            }
            // Trả về đường dẫn tương đối để máy nào mở lên cũng đọc được
            return Path.Combine("Images", tenFile);
        }

        // [ĐÃ SỬA] Copy ảnh vào thư mục Data_Bai6\Images của Project.
        // Hàm này nhận được CẢ đường dẫn tuyệt đối (C:\...\anh.jpg) LẪN đường dẫn tương đối ("Images\anh.jpg").
        // Lỗi cũ: sau khi bấm "Chọn ảnh", ô txtHinhAnh chứa đường dẫn tương đối "Images\anh.jpg".
        // Khi bấm "Thêm Món Ăn", hàm cũ gọi File.Exists("Images\anh.jpg") -> tìm theo thư mục bin\Debug
        // -> không thấy -> trả về chuỗi rỗng -> món ăn bị lưu với HinhAnh = "" (cột Hình Ảnh trống).
        private string CopyAnhVaoThuMucProject(string duongDanNhap)
        {
            if (string.IsNullOrWhiteSpace(duongDanNhap))
                return string.Empty;

            // Đổi mọi kiểu đường dẫn về đường dẫn thật đang tồn tại trên máy
            string duongDanGoc = LayDuongDanAnhThucTe(duongDanNhap.Trim());
            if (string.IsNullOrEmpty(duongDanGoc))
                return string.Empty;

            try
            {
                string fullGoc = Path.GetFullPath(duongDanGoc);
                string fullThuMucImages = Path.GetFullPath(_thuMucImages);

                // Ảnh đã nằm sẵn trong Data_Bai6\Images thì không cần copy nữa
                if (string.Equals(Path.GetDirectoryName(fullGoc), fullThuMucImages, StringComparison.OrdinalIgnoreCase))
                {
                    return Path.Combine("Images", Path.GetFileName(fullGoc));
                }

                // Thêm mốc thời gian vào tên file để 2 ảnh trùng tên (vd: image.png) không ghi đè lên nhau
                string tenFileMoi = $"{DateTime.Now:yyyyMMdd_HHmmssfff}_{Path.GetFileName(fullGoc)}";
                File.Copy(fullGoc, Path.Combine(_thuMucImages, tenFileMoi), overwrite: true);

                // Lưu đường dẫn tương đối "Images\ten_anh.jpg"
                return Path.Combine("Images", tenFileMoi);
            }
            catch
            {
                // Copy lỗi thì vẫn dùng đường dẫn gốc để ít nhất máy này còn xem được ảnh
                return duongDanGoc;
            }
        }

        // Chuyển đường dẫn tương đối ("Images\...") thành đường dẫn thực tế trên máy đang chạy
        private string LayDuongDanAnhThucTe(string duongDanLuuTrongDB)
        {
            if (string.IsNullOrWhiteSpace(duongDanLuuTrongDB))
                return string.Empty;

            // 1. Nếu là đường dẫn tương đối trong Data_Bai6 (VD: "Images\pho_bo.png")
            string duongDanTrongData = Path.Combine(_thuMucData, duongDanLuuTrongDB);
            if (File.Exists(duongDanTrongData))
                return duongDanTrongData;

            // 2. Nếu chỉ lưu tên file (VD: "pho_bo.png")
            string duongDanTheoTenFile = Path.Combine(_thuMucImages, Path.GetFileName(duongDanLuuTrongDB));
            if (File.Exists(duongDanTheoTenFile))
                return duongDanTheoTenFile;

            // 3. Nếu là đường dẫn tuyệt đối có sẵn trên máy
            if (File.Exists(duongDanLuuTrongDB))
                return duongDanLuuTrongDB;

            return string.Empty;
        }

        // ================= KẾT NỐI & ĐỒNG BỘ HAI CHIỀU VỚI SQL SERVER =================
        private void KetNoiVaDongBoSQLServer()
        {
            _suDungSqlServer = false;

            foreach (string sv in DanhSachServer)
            {
                try
                {
                    string connMaster = $@"Server={sv};Database=master;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=2;";
                    using (SqlConnection conn = new SqlConnection(connMaster))
                    {
                        conn.Open();
                        string sqlCreateDB = $@"
                            IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{TEN_DATABASE}')
                            BEGIN
                                CREATE DATABASE {TEN_DATABASE};
                            END";
                        using (SqlCommand cmd = new SqlCommand(sqlCreateDB, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    _chuoiKetNoiHienTai = $@"Server={sv};Database={TEN_DATABASE};Trusted_Connection=True;TrustServerCertificate=True;";
                    _suDungSqlServer = true;
                    break;
                }
                catch
                {
                    // Thử tiếp tên Server tiếp theo
                }
            }

            // Nếu máy giáo viên không bật SQL Server -> Tự động chạy bằng dữ liệu đóng gói trong Data_Bai6 mà không báo lỗi
            if (!_suDungSqlServer || string.IsNullOrEmpty(_chuoiKetNoiHienTai))
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(_chuoiKetNoiHienTai))
                {
                    conn.Open();

                    // Tạo 2 bảng NguoiDung và MonAn nếu chưa có
                    string sqlCreateTables = @"
                        IF OBJECT_ID('NguoiDung', 'U') IS NULL
                        BEGIN
                            CREATE TABLE NguoiDung (
                                IDNCC INT IDENTITY(1,1) PRIMARY KEY,
                                HoVaTen NVARCHAR(100) NOT NULL,
                                QuyenHan NVARCHAR(50) NOT NULL
                            );
                        END

                        IF OBJECT_ID('MonAn', 'U') IS NULL
                        BEGIN
                            CREATE TABLE MonAn (
                                IDMA INT IDENTITY(1,1) PRIMARY KEY,
                                TenMonAn NVARCHAR(100) NOT NULL,
                                HinhAnh NVARCHAR(500) NULL,
                                IDNCC INT NOT NULL,
                                CONSTRAINT FK_MonAn_NguoiDung FOREIGN KEY (IDNCC) REFERENCES NguoiDung(IDNCC) ON DELETE CASCADE
                            );
                        END";

                    using (SqlCommand cmd = new SqlCommand(sqlCreateTables, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Nạp toàn bộ dữ liệu từ file csdl_dong_bo.json (mà bạn đã tạo ở nhà) vào SQL Server của máy hiện tại
                    DongBoTuFileJsonVaoSQLServer(conn);
                }
            }
            catch
            {
                _suDungSqlServer = false;
            }
        }

        // Đảm bảo máy giáo viên có đầy đủ 100% món ăn & người dùng như trong file csdl_dong_bo.json của bạn
        private void DongBoTuFileJsonVaoSQLServer(SqlConnection conn)
        {
            string sqlClearAndInsert = @"
                DELETE FROM MonAn;
                DELETE FROM NguoiDung;";
            using (SqlCommand cmdClear = new SqlCommand(sqlClearAndInsert, conn))
            {
                cmdClear.ExecuteNonQuery();
            }

            // Bật IDENTITY_INSERT để giữ nguyên mã IDNCC đúng như bạn đã tạo
            using (SqlCommand cmdIdentityOn = new SqlCommand("SET IDENTITY_INSERT NguoiDung ON;", conn))
            {
                cmdIdentityOn.ExecuteNonQuery();
            }

            foreach (var nd in _duLieuDongBo.DanhSachNguoiDung)
            {
                string sqlInsND = "INSERT INTO NguoiDung (IDNCC, HoVaTen, QuyenHan) VALUES (@id, @ten, @quyen)";
                using (SqlCommand cmd = new SqlCommand(sqlInsND, conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = nd.IDNCC;
                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = nd.HoVaTen;
                    cmd.Parameters.Add("@quyen", SqlDbType.NVarChar, 50).Value = nd.QuyenHan;
                    cmd.ExecuteNonQuery();
                }
            }

            using (SqlCommand cmdIdentityOff = new SqlCommand("SET IDENTITY_INSERT NguoiDung OFF;", conn))
            {
                cmdIdentityOff.ExecuteNonQuery();
            }

            // Bật IDENTITY_INSERT cho bảng MonAn để giữ nguyên mã IDMA
            using (SqlCommand cmdIdentityMAOn = new SqlCommand("SET IDENTITY_INSERT MonAn ON;", conn))
            {
                cmdIdentityMAOn.ExecuteNonQuery();
            }

            foreach (var ma in _duLieuDongBo.DanhSachMonAn)
            {
                string sqlInsMA = "INSERT INTO MonAn (IDMA, TenMonAn, HinhAnh, IDNCC) VALUES (@idma, @ten, @hinh, @idncc)";
                using (SqlCommand cmd = new SqlCommand(sqlInsMA, conn))
                {
                    cmd.Parameters.Add("@idma", SqlDbType.Int).Value = ma.IDMA;
                    cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = ma.TenMonAn;
                    cmd.Parameters.Add("@hinh", SqlDbType.NVarChar, 500).Value = ma.HinhAnh ?? string.Empty;
                    cmd.Parameters.Add("@idncc", SqlDbType.Int).Value = ma.IDNCC;
                    cmd.ExecuteNonQuery();
                }
            }

            using (SqlCommand cmdIdentityMAOff = new SqlCommand("SET IDENTITY_INSERT MonAn OFF;", conn))
            {
                cmdIdentityMAOff.ExecuteNonQuery();
            }
        }

        // Đọc ngược từ SQL Server lưu ra file JSON mỗi khi bạn thêm/xóa dữ liệu
        private void CapNhatFileJsonTuSQLServer()
        {
            if (!_suDungSqlServer || string.IsNullOrEmpty(_chuoiKetNoiHienTai))
            {
                LuuFileDongBoJson();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(_chuoiKetNoiHienTai))
                {
                    conn.Open();
                    _duLieuDongBo.DanhSachNguoiDung.Clear();
                    using (SqlCommand cmd = new SqlCommand("SELECT IDNCC, HoVaTen, QuyenHan FROM NguoiDung ORDER BY IDNCC", conn))
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            _duLieuDongBo.DanhSachNguoiDung.Add(new NguoiDungItem
                            {
                                IDNCC = r.GetInt32(0),
                                HoVaTen = r.GetString(1),
                                QuyenHan = r.GetString(2)
                            });
                        }
                    }

                    _duLieuDongBo.DanhSachMonAn.Clear();
                    using (SqlCommand cmd = new SqlCommand("SELECT IDMA, TenMonAn, HinhAnh, IDNCC FROM MonAn ORDER BY IDMA", conn))
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            _duLieuDongBo.DanhSachMonAn.Add(new MonAnRecord
                            {
                                IDMA = r.GetInt32(0),
                                TenMonAn = r.GetString(1),
                                HinhAnh = r.IsDBNull(2) ? "" : r.GetString(2),
                                IDNCC = r.GetInt32(3)
                            });
                        }
                    }
                }
                LuuFileDongBoJson();
            }
            catch
            {
                LuuFileDongBoJson();
            }
        }

        // ================= SỰ KIỆN 2: THÊM NGƯỜI DÙNG ĐÓNG GÓP =================
        private void btnThemNguoiDung_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoVaTen.Text.Trim();
            string quyenHan = cbbQuyenHan.SelectedItem?.ToString() ?? "Thành viên";

            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ và tên người đóng góp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }

            try
            {
                if (_suDungSqlServer && !string.IsNullOrEmpty(_chuoiKetNoiHienTai))
                {
                    using (SqlConnection conn = new SqlConnection(_chuoiKetNoiHienTai))
                    {
                        conn.Open();
                        string sqlInsert = "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES (@hoTen, @quyen)";
                        using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                        {
                            cmd.Parameters.Add("@hoTen", SqlDbType.NVarChar, 100).Value = hoTen;
                            cmd.Parameters.Add("@quyen", SqlDbType.NVarChar, 50).Value = quyenHan;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    CapNhatFileJsonTuSQLServer();
                }
                else
                {
                    int newId = _duLieuDongBo.DanhSachNguoiDung.Count > 0
                        ? _duLieuDongBo.DanhSachNguoiDung.Max(x => x.IDNCC) + 1 : 1;
                    _duLieuDongBo.DanhSachNguoiDung.Add(new NguoiDungItem { IDNCC = newId, HoVaTen = hoTen, QuyenHan = quyenHan });
                    LuuFileDongBoJson();
                }

                txtHoVaTen.Clear();
                TaiDanhSachNguoiDungLenComboBox();
                if (cbbNguoiDongGop.Items.Count > 0)
                {
                    cbbNguoiDongGop.SelectedIndex = cbbNguoiDongGop.Items.Count - 1;
                }

                MessageBox.Show($"Đã thêm người đóng góp '{hoTen}' ({quyenHan}) và lưu đồng bộ vào Project!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= SỰ KIỆN 3: CHỌN ẢNH & TỰ ĐỘNG COPY VÀO PROJECT =================
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn hình ảnh cho món ăn";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Tự động copy file ảnh vào thư mục Data_Bai6\Images của Project và lấy đường dẫn tương đối
                    string duongDanTuongDoi = CopyAnhVaoThuMucProject(ofd.FileName);
                    txtHinhAnh.Text = duongDanTuongDoi;
                    HienThiHinhAnhMonAn(duongDanTuongDoi, txtTenMonAn.Text.Trim());
                }
            }
        }

        // ================= SỰ KIỆN 4: THÊM MÓN ĂN MỚI =================
        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            string tenMon = txtTenMonAn.Text.Trim();
            string hinhAnhNhap = txtHinhAnh.Text.Trim();

            if (string.IsNullOrEmpty(tenMon))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMonAn.Focus();
                return;
            }

            if (cbbNguoiDongGop.SelectedItem is not NguoiDungItem nccChon)
            {
                MessageBox.Show("Vui lòng chọn người đóng góp món ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [ĐÃ SỬA] Nếu có nhập ảnh mà không tìm thấy file thì báo lỗi, KHÔNG âm thầm lưu chuỗi rỗng như trước
            string duongDanAnhLuu;
            if (string.IsNullOrEmpty(hinhAnhNhap))
            {
                duongDanAnhLuu = TaoFileAnhMau($"mon_{DateTime.Now:yyyyMMdd_HHmmssfff}.png", tenMon, Color.FromArgb(254, 215, 170));
            }
            else
            {
                duongDanAnhLuu = CopyAnhVaoThuMucProject(hinhAnhNhap);
                if (string.IsNullOrEmpty(duongDanAnhLuu))
                {
                    MessageBox.Show("Không tìm thấy file ảnh theo đường dẫn đã nhập!\nHãy bấm nút 'Chọn ảnh...' để chọn lại.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHinhAnh.Focus();
                    return;
                }
            }

            try
            {
                if (_suDungSqlServer && !string.IsNullOrEmpty(_chuoiKetNoiHienTai))
                {
                    using (SqlConnection conn = new SqlConnection(_chuoiKetNoiHienTai))
                    {
                        conn.Open();
                        string sqlInsert = "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES (@tenMon, @hinh, @idncc)";
                        using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                        {
                            cmd.Parameters.Add("@tenMon", SqlDbType.NVarChar, 100).Value = tenMon;
                            cmd.Parameters.Add("@hinh", SqlDbType.NVarChar, 500).Value = duongDanAnhLuu;
                            cmd.Parameters.Add("@idncc", SqlDbType.Int).Value = nccChon.IDNCC;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    CapNhatFileJsonTuSQLServer();
                }
                else
                {
                    int newId = _duLieuDongBo.DanhSachMonAn.Count > 0
                        ? _duLieuDongBo.DanhSachMonAn.Max(x => x.IDMA) + 1 : 1;
                    _duLieuDongBo.DanhSachMonAn.Add(new MonAnRecord
                    {
                        IDMA = newId,
                        TenMonAn = tenMon,
                        HinhAnh = duongDanAnhLuu,
                        IDNCC = nccChon.IDNCC
                    });
                    LuuFileDongBoJson();
                }

                txtTenMonAn.Clear();
                txtHinhAnh.Clear();
                txtTenMonAn.Focus();

                TaiDanhSachMonAnLenListView();

                // Chọn luôn món vừa thêm -> khung bên phải hiện đúng tên, người đóng góp và hình ảnh của món đó
                if (lvwMonAn.Items.Count > 0)
                {
                    ListViewItem itemMoi = lvwMonAn.Items[lvwMonAn.Items.Count - 1];
                    lvwMonAn.SelectedItems.Clear();
                    itemMoi.Selected = true;
                    itemMoi.EnsureVisible();
                    HienThiChiTietTuListViewItem(itemMoi);
                }

                MessageBox.Show($"Đã thêm món '{tenMon}' kèm hình ảnh vào CSDL và đóng gói vào thư mục Project!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= SỰ KIỆN 5: NẠP LẠI / KHÔI PHỤC DỮ LIỆU MẪU =================
        private void btnTaoDuLieuMau_Click(object sender, EventArgs e)
        {
            TaiDanhSachNguoiDungLenComboBox();
            TaiDanhSachMonAnLenListView();
            if (lvwMonAn.Items.Count > 0)
            {
                ChonNgauNhienMotMonAn();
            }
            MessageBox.Show("Đã làm mới danh sách món ăn và người đóng góp trên ListView!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= SỰ KIỆN 6: XÓA MÓN ĂN ĐÃ CHỌN =================
        private void btnXoaMonAn_Click(object sender, EventArgs e)
        {
            if (lvwMonAn.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 món ăn trong bảng ListView để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem itemChon = lvwMonAn.SelectedItems[0];
            int idma = int.Parse(itemChon.SubItems[0].Text);
            string tenMon = itemChon.SubItems[1].Text;

            try
            {
                if (_suDungSqlServer && !string.IsNullOrEmpty(_chuoiKetNoiHienTai))
                {
                    using (SqlConnection conn = new SqlConnection(_chuoiKetNoiHienTai))
                    {
                        conn.Open();
                        string sqlDelete = "DELETE FROM MonAn WHERE IDMA = @idma";
                        using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                        {
                            cmd.Parameters.Add("@idma", SqlDbType.Int).Value = idma;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    CapNhatFileJsonTuSQLServer();
                }
                else
                {
                    _duLieuDongBo.DanhSachMonAn.RemoveAll(x => x.IDMA == idma);
                    LuuFileDongBoJson();
                }

                TaiDanhSachMonAnLenListView();
                if (lvwMonAn.Items.Count > 0)
                {
                    HienThiChiTietTuListViewItem(lvwMonAn.Items[0]);
                }
                MessageBox.Show($"Đã xóa món '{tenMon}' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= SỰ KIỆN 7: NÚT QUAY NGẪU NHIÊN ("HÔM NAY ĂN GÌ?") =================
        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            if (lvwMonAn.Items.Count == 0)
            {
                MessageBox.Show("Danh sách món ăn đang trống! Hãy thêm món ăn trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChonNgauNhienMotMonAn();
        }

        private void ChonNgauNhienMotMonAn()
        {
            if (lvwMonAn.Items.Count == 0) return;

            Random rand = new Random();
            int viTriNgauNhien = rand.Next(0, lvwMonAn.Items.Count);

            lvwMonAn.SelectedItems.Clear();
            lvwMonAn.Items[viTriNgauNhien].Selected = true;
            lvwMonAn.Items[viTriNgauNhien].EnsureVisible();

            HienThiChiTietTuListViewItem(lvwMonAn.Items[viTriNgauNhien]);
        }

        private void lvwMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwMonAn.SelectedItems.Count > 0)
            {
                HienThiChiTietTuListViewItem(lvwMonAn.SelectedItems[0]);
            }
        }

        // ================= CÁC HÀM TRUY VẤN & HIỂN THỊ LÊN GIAO DIỆN =================
        private void TaiDanhSachNguoiDungLenComboBox()
        {
            cbbNguoiDongGop.Items.Clear();

            if (_suDungSqlServer && !string.IsNullOrEmpty(_chuoiKetNoiHienTai))
            {
                using (SqlConnection conn = new SqlConnection(_chuoiKetNoiHienTai))
                {
                    conn.Open();
                    string sql = "SELECT IDNCC, HoVaTen, QuyenHan FROM NguoiDung ORDER BY IDNCC";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbbNguoiDongGop.Items.Add(new NguoiDungItem
                            {
                                IDNCC = reader.GetInt32(0),
                                HoVaTen = reader.GetString(1),
                                QuyenHan = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            else
            {
                foreach (var nd in _duLieuDongBo.DanhSachNguoiDung)
                {
                    cbbNguoiDongGop.Items.Add(nd);
                }
            }

            if (cbbNguoiDongGop.Items.Count > 0)
            {
                cbbNguoiDongGop.SelectedIndex = 0;
            }
        }

        private void TaiDanhSachMonAnLenListView()
        {
            lvwMonAn.Items.Clear();

            if (_suDungSqlServer && !string.IsNullOrEmpty(_chuoiKetNoiHienTai))
            {
                using (SqlConnection conn = new SqlConnection(_chuoiKetNoiHienTai))
                {
                    conn.Open();
                    string sqlJoin = @"
                        SELECT m.IDMA, m.TenMonAn, n.HoVaTen, n.QuyenHan, m.HinhAnh
                        FROM MonAn m
                        INNER JOIN NguoiDung n ON m.IDNCC = n.IDNCC
                        ORDER BY m.IDMA";

                    using (SqlCommand cmd = new SqlCommand(sqlJoin, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem lvi = new ListViewItem(reader.GetInt32(0).ToString());
                            lvi.SubItems.Add(reader.GetString(1));
                            lvi.SubItems.Add(reader.GetString(2));
                            lvi.SubItems.Add(reader.GetString(3));
                            lvi.SubItems.Add(reader.IsDBNull(4) ? "" : reader.GetString(4));
                            lvwMonAn.Items.Add(lvi);
                        }
                    }
                }
            }
            else
            {
                foreach (var m in _duLieuDongBo.DanhSachMonAn)
                {
                    var ncc = _duLieuDongBo.DanhSachNguoiDung.FirstOrDefault(x => x.IDNCC == m.IDNCC);
                    ListViewItem lvi = new ListViewItem(m.IDMA.ToString());
                    lvi.SubItems.Add(m.TenMonAn);
                    lvi.SubItems.Add(ncc?.HoVaTen ?? "Ẩn danh");
                    lvi.SubItems.Add(ncc?.QuyenHan ?? "Thành viên");
                    lvi.SubItems.Add(m.HinhAnh);
                    lvwMonAn.Items.Add(lvi);
                }
            }
        }

        private void HienThiChiTietTuListViewItem(ListViewItem item)
        {
            string tenMon = item.SubItems[1].Text;
            string nguoiDongGop = item.SubItems[2].Text;
            string quyenHan = item.SubItems[3].Text;
            string duongDanAnh = item.SubItems[4].Text;

            txtKetQuaMon.Text = tenMon;
            txtKetQuaNCC.Text = $"{nguoiDongGop} ({quyenHan})";

            HienThiHinhAnhMonAn(duongDanAnh, tenMon);
        }

        private void HienThiHinhAnhMonAn(string duongDanLuu, string tenMonAn)
        {
            if (picMonAn.Image != null)
            {
                Image oldImg = picMonAn.Image;
                picMonAn.Image = null;
                oldImg.Dispose();
            }

            string duongDanThucTe = LayDuongDanAnhThucTe(duongDanLuu);

            if (!string.IsNullOrEmpty(duongDanThucTe) && File.Exists(duongDanThucTe))
            {
                try
                {
                    // [ĐÃ SỬA] Đọc file vào bộ nhớ rồi sao chép sang Bitmap độc lập.
                    // Như vậy không bị khóa file, và đóng MemoryStream xong ảnh vẫn vẽ bình thường (tránh lỗi GDI+).
                    byte[] bytes = File.ReadAllBytes(duongDanThucTe);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    using (Image imgGoc = Image.FromStream(ms))
                    {
                        picMonAn.Image = new Bitmap(imgGoc);
                    }
                    return;
                }
                catch
                {
                    // Nếu file lỗi thì vẽ thẻ ảnh dự phòng bên dưới
                }
            }

            picMonAn.Image = VeTheHinhAnhMonAn(tenMonAn, duongDanLuu, Color.FromArgb(254, 215, 170));
        }

        private Bitmap VeTheHinhAnhMonAn(string tenMonAn, string tenFile, Color mauNen)
        {
            Bitmap bmp = new Bitmap(340, 220);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect, Color.FromArgb(255, 247, 237), mauNen, LinearGradientMode.ForwardDiagonal))
                {
                    g.FillRectangle(brush, rect);
                }

                using (Pen pen = new Pen(Color.FromArgb(234, 88, 12), 3))
                {
                    g.DrawRectangle(pen, 6, 6, bmp.Width - 12, bmp.Height - 12);
                }

                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                using (Font fIcon = new Font("Segoe UI Emoji", 34, FontStyle.Regular))
                using (Brush bIcon = new SolidBrush(Color.FromArgb(194, 65, 12)))
                {
                    g.DrawString("🍜", fIcon, bIcon, new RectangleF(0, 25, bmp.Width, 75), sf);
                }

                using (Font fTitle = new Font("Segoe UI", 14, FontStyle.Bold))
                using (Brush bTitle = new SolidBrush(Color.FromArgb(154, 52, 18)))
                {
                    g.DrawString(string.IsNullOrEmpty(tenMonAn) ? "Món ăn ngon" : tenMonAn,
                        fTitle, bTitle, new RectangleF(15, 105, bmp.Width - 30, 60), sf);
                }

                using (Font fSub = new Font("Segoe UI", 8.5F, FontStyle.Italic))
                using (Brush bSub = new SolidBrush(Color.FromArgb(120, 113, 108)))
                {
                    g.DrawString($"Ảnh: {(string.IsNullOrEmpty(tenFile) ? "Mặc định" : Path.GetFileName(tenFile))}",
                        fSub, bSub, new RectangleF(10, 175, bmp.Width - 20, 30), sf);
                }
            }
            return bmp;
        }
    }

    // ================= CÁC CLASS LƯU TRỮ & ĐỒNG BỘ DỮ LIỆU =================
    public class NguoiDungItem
    {
        public int IDNCC { get; set; }
        public string HoVaTen { get; set; } = string.Empty;
        public string QuyenHan { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{IDNCC} - {HoVaTen} ({QuyenHan})";
        }
    }

    public class MonAnRecord
    {
        public int IDMA { get; set; }
        public string TenMonAn { get; set; } = string.Empty;
        public string HinhAnh { get; set; } = string.Empty;
        public int IDNCC { get; set; }
    }

    public class DuLieuDongBoBai6
    {
        public List<NguoiDungItem> DanhSachNguoiDung { get; set; } = new List<NguoiDungItem>();
        public List<MonAnRecord> DanhSachMonAn { get; set; } = new List<MonAnRecord>();
    }
}