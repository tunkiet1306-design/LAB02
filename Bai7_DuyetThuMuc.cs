using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LAB02
{
    public partial class Bai7_DuyetThuMuc : Form
    {
        // ================= KIỂU DỮ LIỆU PHỤ =================

        // Thứ tự enum cũng là thứ tự hiển thị: Ổ đĩa -> Thư mục -> Tập tin
        private enum LoaiMuc { ODia = 0, ThuMuc = 1, TapTin = 2 }

        // Thông tin gắn vào Tag của mỗi dòng trong ListView
        private sealed class MucDuyet
        {
            public string DuongDan { get; set; } = string.Empty;
            public LoaiMuc Loai { get; set; }
            public long KichThuoc { get; set; }
            public DateTime NgaySua { get; set; }
        }

        // Bộ so sánh để sắp xếp khi bấm vào tiêu đề cột (thư mục luôn nằm trên tập tin)
        private sealed class BoSoSanhMuc : IComparer, IComparer<ListViewItem>
        {
            public int Cot { get; set; } = 0;
            public bool TangDan { get; set; } = true;

            public int Compare(object? x, object? y)
            {
                return Compare(x as ListViewItem, y as ListViewItem);
            }

            public int Compare(ListViewItem? a, ListViewItem? b)
            {
                if (a?.Tag is not MucDuyet ma || b?.Tag is not MucDuyet mb) return 0;

                // Khác loại thì giữ nguyên thứ tự Ổ đĩa < Thư mục < Tập tin, không phụ thuộc chiều sắp xếp
                if (ma.Loai != mb.Loai) return ma.Loai.CompareTo(mb.Loai);

                int kq = Cot switch
                {
                    1 => string.Compare(a.SubItems[1].Text, b.SubItems[1].Text, StringComparison.CurrentCultureIgnoreCase),
                    2 => ma.KichThuoc.CompareTo(mb.KichThuoc),
                    3 => ma.NgaySua.CompareTo(mb.NgaySua),
                    _ => string.Compare(a.Text, b.Text, StringComparison.CurrentCultureIgnoreCase)
                };

                // Bằng nhau thì so tiếp theo tên để thứ tự luôn ổn định
                if (kq == 0 && Cot != 0)
                    kq = string.Compare(a.Text, b.Text, StringComparison.CurrentCultureIgnoreCase);

                return TangDan ? kq : -kq;
            }
        }

        // ================= HẰNG SỐ & BIẾN DÙNG CHUNG =================

        private const int GIOI_HAN_DOC = 512 * 1024;          // Chỉ đọc tối đa 512 KB đầu của file văn bản
        private const long GIOI_HAN_ANH = 50L * 1024 * 1024;  // Ảnh lớn hơn 50 MB thì không xem trước

        private static readonly string[] TenCot = { "Tên", "Loại", "Kích thước", "Ngày sửa đổi" };

        private static readonly HashSet<string> DuoiAnh = new(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".ico", ".tif", ".tiff"
        };

        private static readonly HashSet<string> DuoiVanBan = new(StringComparer.OrdinalIgnoreCase)
        {
            ".txt", ".log", ".md", ".csv", ".tsv", ".json", ".xml", ".html", ".htm", ".css", ".js", ".ts",
            ".ini", ".cfg", ".config", ".yml", ".yaml", ".sql", ".bat", ".cmd", ".ps1", ".sh",
            ".cs", ".vb", ".cpp", ".c", ".h", ".hpp", ".java", ".py", ".php",
            ".sln", ".csproj", ".vbproj", ".resx", ".xaml", ".razor", ".gitignore"
        };

        private static readonly HashSet<string> DuoiNhiPhan = new(StringComparer.OrdinalIgnoreCase)
        {
            ".exe", ".dll", ".sys", ".msi", ".pdb", ".obj", ".lib", ".bin", ".dat", ".iso",
            ".zip", ".rar", ".7z", ".gz", ".tar", ".cab", ".pdf",
            ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx",
            ".mp3", ".mp4", ".mkv", ".avi", ".mov", ".wav", ".flac",
            ".webp", ".psd", ".ttf", ".otf", ".woff", ".woff2",
            ".db", ".mdf", ".ldf", ".bak", ".lnk"
        };

        // Chuỗi rỗng = màn hình "Máy tính" (danh sách các ổ đĩa)
        private string _thuMucHienTai = string.Empty;
        private readonly Stack<string> _lichSuLui = new();
        private readonly BoSoSanhMuc _boSoSanh = new();

        public Bai7_DuyetThuMuc()
        {
            InitializeComponent();
        }

        // ================= SỰ KIỆN FORM =================
        private void Bai7_DuyetThuMuc_Load(object sender, EventArgs e)
        {
            TaoBoIcon();
            CapNhatTieuDeCot();
            XoaXemTruoc();

            // Mở đầu hiển thị danh sách ổ đĩa của máy tính
            DiDen(string.Empty, ghiLichSu: false);
        }

        private void Bai7_DuyetThuMuc_FormClosed(object sender, FormClosedEventArgs e)
        {
            GiaiPhongAnhXemTruoc();
        }

        // ================= CÁC NÚT ĐIỀU HƯỚNG =================
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (_lichSuLui.Count == 0) return;

            string truoc = _lichSuLui.Pop();
            string dangO = _thuMucHienTai;
            DiDen(truoc, ghiLichSu: false, chonSan: dangO);
            CapNhatNut();
        }

        private void btnLenTren_Click(object sender, EventArgs e)
        {
            LenThuMucCha();
        }

        private void btnMayTinh_Click(object sender, EventArgs e)
        {
            DiDen(string.Empty);
        }

        private void btnDi_Click(object sender, EventArgs e)
        {
            DiDen(txtDuongDan.Text);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void chkHienAn_CheckedChanged(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void txtDuongDan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DiDen(txtDuongDan.Text);
            }
        }

        // ================= SỰ KIỆN LISTVIEW =================

        // Nhấp đúp: thư mục / ổ đĩa -> đi vào bên trong
        private void lvwThuMuc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem? item = lvwThuMuc.HitTest(e.Location).Item;
            if (item == null) return;

            item.Selected = true;
            MoMucDangChon();
        }

        // Bấm chọn: file -> hiển thị nội dung, thư mục / ổ đĩa -> hiển thị thông tin
        private void lvwThuMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwThuMuc.SelectedItems.Count == 0)
            {
                tsslDaChon.Text = string.Empty;
                return;
            }

            ListViewItem item = lvwThuMuc.SelectedItems[0];
            if (item.Tag is not MucDuyet muc) return;

            switch (muc.Loai)
            {
                case LoaiMuc.TapTin:
                    tsslDaChon.Text = $"Đã chọn: {item.Text} ({DinhDangDungLuong(muc.KichThuoc)})";
                    HienThiNoiDungFile(muc.DuongDan);
                    break;

                case LoaiMuc.ThuMuc:
                    tsslDaChon.Text = $"Đã chọn thư mục: {item.Text}";
                    HienThiThongTinThuMuc(muc.DuongDan);
                    break;

                default:
                    tsslDaChon.Text = $"Đã chọn ổ đĩa: {item.Text}";
                    HienThiThongTinODia(muc.DuongDan);
                    break;
            }
        }

        private void lvwThuMuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                MoMucDangChon();
            }
            else if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                LenThuMucCha();
            }
            else if (e.KeyCode == Keys.F5)
            {
                e.SuppressKeyPress = true;
                LamMoi();
            }
        }

        // Bấm vào tiêu đề cột để sắp xếp tăng / giảm
        private void lvwThuMuc_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _boSoSanh.Cot)
            {
                _boSoSanh.TangDan = !_boSoSanh.TangDan;
            }
            else
            {
                _boSoSanh.Cot = e.Column;
                _boSoSanh.TangDan = true;
            }

            lvwThuMuc.ListViewItemSorter = _boSoSanh;
            lvwThuMuc.Sort();
            lvwThuMuc.ListViewItemSorter = null;

            CapNhatTieuDeCot();

            if (lvwThuMuc.SelectedItems.Count > 0)
                lvwThuMuc.SelectedItems[0].EnsureVisible();
        }

        // ================= LÕI ĐIỀU HƯỚNG THƯ MỤC =================

        // Đi đến một đường dẫn. duongDanNhap rỗng = màn hình "Máy tính".
        // chonSan: đường dẫn của mục sẽ được chọn sẵn sau khi nạp xong (dùng khi Lên / Lùi / nhập đường dẫn file).
        private void DiDen(string duongDanNhap, bool ghiLichSu = true, string? chonSan = null)
        {
            string dich = duongDanNhap.Trim().Trim('"');
            string? mucCanChon = chonSan;

            if (dich.Length > 0)
            {
                // Người dùng gõ "D:" thì hiểu là gốc ổ D
                if (dich.Length == 2 && dich[1] == ':')
                    dich += Path.DirectorySeparatorChar;

                try
                {
                    dich = Path.GetFullPath(dich);
                }
                catch (Exception)
                {
                    MessageBox.Show("Đường dẫn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDuongDan.Text = _thuMucHienTai;
                    return;
                }

                if (File.Exists(dich))
                {
                    // Gõ đường dẫn một file: mở thư mục chứa file đó và chọn luôn file để xem nội dung
                    mucCanChon = dich;
                    dich = Path.GetDirectoryName(dich) ?? string.Empty;
                }
                else if (!Directory.Exists(dich))
                {
                    MessageBox.Show("Không tìm thấy đường dẫn:\n" + dich, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDuongDan.Text = _thuMucHienTai;
                    return;
                }

                // Bỏ dấu \ ở cuối (trừ gốc ổ đĩa như C:\)
                string goc = Path.GetPathRoot(dich) ?? string.Empty;
                if (dich.Length > goc.Length)
                    dich = dich.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            }

            // Nạp dữ liệu vào bộ nhớ trước, thành công rồi mới thay đổi giao diện (lỗi thì giữ nguyên thư mục cũ)
            List<ListViewItem>? danhSach;
            Cursor = Cursors.WaitCursor;
            try
            {
                danhSach = dich.Length == 0 ? LayDanhSachODia() : LayDanhSachThuMuc(dich);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (danhSach == null)
            {
                txtDuongDan.Text = _thuMucHienTai;
                return;
            }

            if (ghiLichSu && !string.Equals(_thuMucHienTai, dich, StringComparison.OrdinalIgnoreCase))
                _lichSuLui.Push(_thuMucHienTai);

            _thuMucHienTai = dich;
            txtDuongDan.Text = dich;

            HienThiDanhSach(danhSach);
            CapNhatNut();
            XoaXemTruoc();
            CapNhatTrangThai();

            if (mucCanChon != null)
                ChonItemTheoDuongDan(mucCanChon);

            lvwThuMuc.Focus();
        }

        private void MoMucDangChon()
        {
            if (lvwThuMuc.SelectedItems.Count == 0) return;
            if (lvwThuMuc.SelectedItems[0].Tag is not MucDuyet muc) return;

            // Tập tin: nội dung đã được hiển thị ngay khi bấm chọn nên không cần làm gì thêm
            if (muc.Loai == LoaiMuc.TapTin) return;

            DiDen(muc.DuongDan);
        }

        private void LenThuMucCha()
        {
            if (_thuMucHienTai.Length == 0) return;

            string vuaRoi = _thuMucHienTai;
            // Ở gốc ổ đĩa thì GetParent trả về null -> quay lại màn hình "Máy tính"
            string cha = Directory.GetParent(_thuMucHienTai)?.FullName ?? string.Empty;
            DiDen(cha, ghiLichSu: true, chonSan: vuaRoi);
        }

        private void LamMoi()
        {
            string? dangChon = null;
            if (lvwThuMuc.SelectedItems.Count > 0 && lvwThuMuc.SelectedItems[0].Tag is MucDuyet muc)
                dangChon = muc.DuongDan;

            DiDen(_thuMucHienTai, ghiLichSu: false, chonSan: dangChon);
        }

        private void CapNhatNut()
        {
            btnQuayLai.Enabled = _lichSuLui.Count > 0;
            btnLenTren.Enabled = _thuMucHienTai.Length > 0;
        }

        private void CapNhatTrangThai()
        {
            int soThuMuc = 0, soTapTin = 0, soODia = 0;
            foreach (ListViewItem item in lvwThuMuc.Items)
            {
                if (item.Tag is not MucDuyet muc) continue;
                if (muc.Loai == LoaiMuc.ODia) soODia++;
                else if (muc.Loai == LoaiMuc.ThuMuc) soThuMuc++;
                else soTapTin++;
            }

            tsslSoLuong.Text = _thuMucHienTai.Length == 0
                ? $"{soODia} ổ đĩa"
                : $"{soThuMuc} thư mục, {soTapTin} tập tin";
            tsslDaChon.Text = string.Empty;
        }

        private void CapNhatTieuDeCot()
        {
            for (int i = 0; i < lvwThuMuc.Columns.Count && i < TenCot.Length; i++)
            {
                string mui = i == _boSoSanh.Cot ? (_boSoSanh.TangDan ? " ▲" : " ▼") : string.Empty;
                lvwThuMuc.Columns[i].Text = TenCot[i] + mui;
            }
        }

        private void ChonItemTheoDuongDan(string duongDan)
        {
            foreach (ListViewItem item in lvwThuMuc.Items)
            {
                if (item.Tag is MucDuyet muc &&
                    string.Equals(muc.DuongDan, duongDan, StringComparison.OrdinalIgnoreCase))
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                    return;
                }
            }
        }

        private void HienThiDanhSach(List<ListViewItem> danhSach)
        {
            danhSach.Sort(_boSoSanh);

            lvwThuMuc.BeginUpdate();
            try
            {
                lvwThuMuc.Items.Clear();
                lvwThuMuc.Items.AddRange(danhSach.ToArray());
            }
            finally
            {
                lvwThuMuc.EndUpdate();
            }
        }

        // ================= ĐỌC DANH SÁCH Ổ ĐĨA / THƯ MỤC =================

        private List<ListViewItem> LayDanhSachODia()
        {
            var ketQua = new List<ListViewItem>();

            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                try
                {
                    if (!d.IsReady) continue;   // Bỏ qua ổ CD/USB chưa sẵn sàng

                    string nhan = string.IsNullOrWhiteSpace(d.VolumeLabel) ? "Ổ đĩa" : d.VolumeLabel;
                    string ten = $"{nhan} ({d.Name.TrimEnd('\\')})";

                    var muc = new MucDuyet
                    {
                        DuongDan = d.RootDirectory.FullName,
                        Loai = LoaiMuc.ODia,
                        KichThuoc = d.TotalSize,
                        NgaySua = DateTime.MinValue
                    };

                    var lvi = new ListViewItem(ten, "drive") { Tag = muc };
                    lvi.SubItems.Add(LayTenLoaiODia(d.DriveType));
                    lvi.SubItems.Add($"{DinhDangDungLuong(d.AvailableFreeSpace)} trống / {DinhDangDungLuong(d.TotalSize)}");
                    lvi.SubItems.Add(string.Empty);
                    ketQua.Add(lvi);
                }
                catch (Exception)
                {
                    // Ổ đĩa lỗi thì bỏ qua
                }
            }

            return ketQua;
        }

        // Trả về null nếu không đọc được thư mục (đã báo lỗi cho người dùng)
        private List<ListViewItem>? LayDanhSachThuMuc(string duongDan)
        {
            var ketQua = new List<ListViewItem>();

            var tuyChon = new EnumerationOptions
            {
                IgnoreInaccessible = false,      // Để bắt được lỗi "không có quyền" của chính thư mục đang mở
                RecurseSubdirectories = false,
                AttributesToSkip = chkHienAn.Checked
                    ? (FileAttributes)0
                    : (FileAttributes.Hidden | FileAttributes.System)
            };

            try
            {
                var di = new DirectoryInfo(duongDan);
                foreach (FileSystemInfo muc in di.EnumerateFileSystemInfos("*", tuyChon))
                {
                    try
                    {
                        if (muc is DirectoryInfo thuMuc)
                            ketQua.Add(TaoItemThuMuc(thuMuc));
                        else if (muc is FileInfo tapTin)
                            ketQua.Add(TaoItemTapTin(tapTin));
                    }
                    catch (Exception)
                    {
                        // Mục bị lỗi thì bỏ qua, không làm hỏng cả danh sách
                    }
                }
                return ketQua;
            }
            catch (UnauthorizedAccessException)
            {
                Loi("Bạn không có quyền truy cập thư mục này!");
            }
            catch (DirectoryNotFoundException)
            {
                Loi("Thư mục không còn tồn tại!");
            }
            catch (IOException ex)
            {
                Loi("Không thể đọc thư mục:\n" + ex.Message);
            }

            return null;
        }

        private ListViewItem TaoItemThuMuc(DirectoryInfo d)
        {
            var muc = new MucDuyet
            {
                DuongDan = d.FullName,
                Loai = LoaiMuc.ThuMuc,
                KichThuoc = -1,
                NgaySua = d.LastWriteTime
            };

            var lvi = new ListViewItem(d.Name, "folder") { Tag = muc };
            lvi.SubItems.Add("Thư mục");
            lvi.SubItems.Add(string.Empty);
            lvi.SubItems.Add(d.LastWriteTime.ToString("dd/MM/yyyy HH:mm"));
            return lvi;
        }

        private ListViewItem TaoItemTapTin(FileInfo f)
        {
            string duoi = f.Extension;
            var muc = new MucDuyet
            {
                DuongDan = f.FullName,
                Loai = LoaiMuc.TapTin,
                KichThuoc = f.Length,
                NgaySua = f.LastWriteTime
            };

            var lvi = new ListViewItem(f.Name, LayKhoaIcon(duoi)) { Tag = muc };
            lvi.SubItems.Add(duoi.Length > 1 ? duoi.Substring(1).ToUpperInvariant() + " File" : "Tập tin");
            lvi.SubItems.Add(DinhDangDungLuong(f.Length));
            lvi.SubItems.Add(f.LastWriteTime.ToString("dd/MM/yyyy HH:mm"));
            return lvi;
        }

        private static string LayKhoaIcon(string duoi)
        {
            if (DuoiAnh.Contains(duoi)) return "image";
            if (DuoiVanBan.Contains(duoi)) return "text";
            return "file";
        }

        private static string LayTenLoaiODia(DriveType loai)
        {
            return loai switch
            {
                DriveType.Fixed => "Ổ đĩa cục bộ",
                DriveType.Removable => "Ổ đĩa di động",
                DriveType.CDRom => "Ổ đĩa quang",
                DriveType.Network => "Ổ đĩa mạng",
                DriveType.Ram => "Ổ đĩa RAM",
                _ => "Ổ đĩa"
            };
        }

        private static string DinhDangDungLuong(long soByte)
        {
            if (soByte < 0) return string.Empty;

            string[] donVi = { "B", "KB", "MB", "GB", "TB" };
            double v = soByte;
            int i = 0;
            while (v >= 1024 && i < donVi.Length - 1)
            {
                v /= 1024;
                i++;
            }
            return i == 0 ? $"{soByte} B" : $"{v:0.##} {donVi[i]}";
        }

        // ================= HIỂN THỊ NỘI DUNG KHI BẤM CHỌN =================

        private void HienThiNoiDungFile(string duongDan)
        {
            FileInfo fi = new FileInfo(duongDan);
            if (!fi.Exists)
            {
                lblThongTinFile.Text = "File không còn tồn tại.";
                HienThiVanBan("File này đã bị xóa hoặc di chuyển.\r\nHãy nhấn 'Làm mới' để cập nhật lại danh sách.");
                return;
            }

            lblThongTinFile.Text = $"{fi.Name}   |   {DinhDangDungLuong(fi.Length)}   |   Sửa đổi: {fi.LastWriteTime:dd/MM/yyyy HH:mm}";
            string duoi = fi.Extension;

            try
            {
                // 1. File ảnh -> hiển thị hình
                if (DuoiAnh.Contains(duoi))
                {
                    HienThiAnh(fi);
                    return;
                }

                // 2. File nhị phân đã biết (exe, zip, pdf, docx...) -> chỉ hiện thông tin
                if (DuoiNhiPhan.Contains(duoi))
                {
                    HienThiVanBan(MoTaFileKhongXemDuoc(fi));
                    return;
                }

                if (fi.Length == 0)
                {
                    HienThiVanBan("(File rỗng - không có nội dung)");
                    return;
                }

                // 3. File văn bản -> đọc và hiển thị chữ
                byte[] buf = DocByteDauFile(fi.FullName, GIOI_HAN_DOC, out bool biCat);

                // Đuôi lạ: kiểm tra nội dung xem có phải văn bản không
                if (!DuoiVanBan.Contains(duoi) && LaNhiPhan(buf))
                {
                    HienThiVanBan(MoTaFileKhongXemDuoc(fi));
                    return;
                }

                string noiDung = GiaiMaVanBan(buf);
                if (biCat)
                    noiDung += "\r\n\r\n... [Đã cắt bớt: chỉ hiển thị 512 KB đầu tiên của file] ...";

                HienThiVanBan(noiDung);
            }
            catch (UnauthorizedAccessException)
            {
                HienThiVanBan("Bạn không có quyền đọc file này.");
            }
            catch (IOException ex)
            {
                HienThiVanBan("Không thể đọc file (có thể đang được chương trình khác sử dụng):\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                HienThiVanBan("Có lỗi khi đọc file:\r\n" + ex.Message);
            }
        }

        private void HienThiAnh(FileInfo fi)
        {
            if (fi.Length > GIOI_HAN_ANH)
            {
                HienThiVanBan("Ảnh quá lớn (trên 50 MB) nên không xem trước.\r\n\r\n" + MoTaFile(fi));
                return;
            }

            try
            {
                using var fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
                using var anhGoc = Image.FromStream(fs, false, false);

                // Sao chép sang Bitmap độc lập để không bị khóa file và không lỗi khi đóng stream
                var anh = new Bitmap(anhGoc);
                lblThongTinFile.Text += $"   |   {anhGoc.Width} x {anhGoc.Height} px";

                GiaiPhongAnhXemTruoc();
                picXemTruoc.Image = anh;
                txtNoiDung.Visible = false;
                picXemTruoc.Visible = true;
            }
            catch (Exception)
            {
                HienThiVanBan("Không thể mở file ảnh này (file lỗi hoặc định dạng không được hỗ trợ).\r\n\r\n" + MoTaFile(fi));
            }
        }

        private void HienThiThongTinThuMuc(string duongDan)
        {
            lblThongTinFile.Text = "Thư mục: " + duongDan;

            var sb = new StringBuilder();
            try
            {
                var di = new DirectoryInfo(duongDan);
                sb.AppendLine($"THƯ MỤC: {di.Name}");
                sb.AppendLine();
                sb.AppendLine($"Đường dẫn : {di.FullName}");
                sb.AppendLine($"Ngày tạo  : {di.CreationTime:dd/MM/yyyy HH:mm}");
                sb.AppendLine($"Sửa đổi   : {di.LastWriteTime:dd/MM/yyyy HH:mm}");

                try
                {
                    int soThuMuc = di.EnumerateDirectories().Count();
                    int soTapTin = di.EnumerateFiles().Count();
                    sb.AppendLine($"Bên trong : {soThuMuc} thư mục, {soTapTin} tập tin");
                }
                catch (UnauthorizedAccessException)
                {
                    sb.AppendLine("Bên trong : (không có quyền truy cập)");
                }
                catch (IOException)
                {
                    sb.AppendLine("Bên trong : (không đọc được)");
                }

                sb.AppendLine();
                sb.AppendLine("Nhấp đúp chuột (hoặc nhấn Enter) để mở thư mục này.");
            }
            catch (Exception ex)
            {
                sb.Clear();
                sb.AppendLine("Không đọc được thông tin thư mục:");
                sb.AppendLine(ex.Message);
            }

            HienThiVanBan(sb.ToString());
        }

        private void HienThiThongTinODia(string duongDan)
        {
            lblThongTinFile.Text = "Ổ đĩa: " + duongDan;

            var sb = new StringBuilder();
            try
            {
                var d = new DriveInfo(duongDan);
                sb.AppendLine($"Ổ ĐĨA {d.Name}");
                sb.AppendLine();
                sb.AppendLine($"Nhãn      : {(string.IsNullOrWhiteSpace(d.VolumeLabel) ? "(không có)" : d.VolumeLabel)}");
                sb.AppendLine($"Loại      : {LayTenLoaiODia(d.DriveType)}");
                sb.AppendLine($"Định dạng : {d.DriveFormat}");
                sb.AppendLine($"Dung lượng: {DinhDangDungLuong(d.TotalSize)}");
                sb.AppendLine($"Còn trống : {DinhDangDungLuong(d.AvailableFreeSpace)}");
                sb.AppendLine();
                sb.AppendLine("Nhấp đúp chuột (hoặc nhấn Enter) để mở ổ đĩa này.");
            }
            catch (Exception ex)
            {
                sb.Clear();
                sb.AppendLine("Không đọc được thông tin ổ đĩa:");
                sb.AppendLine(ex.Message);
            }

            HienThiVanBan(sb.ToString());
        }

        private void HienThiVanBan(string noiDung)
        {
            GiaiPhongAnhXemTruoc();
            picXemTruoc.Visible = false;
            txtNoiDung.Visible = true;
            txtNoiDung.Text = noiDung;
        }

        private void XoaXemTruoc()
        {
            HienThiVanBan(string.Empty);
            lblThongTinFile.Text = "Chưa chọn file nào. Bấm vào một file để xem nội dung.";
        }

        private void GiaiPhongAnhXemTruoc()
        {
            if (picXemTruoc.Image != null)
            {
                Image cu = picXemTruoc.Image;
                picXemTruoc.Image = null;
                cu.Dispose();
            }
        }

        private static string MoTaFile(FileInfo fi)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Tên       : {fi.Name}");
            sb.AppendLine($"Đường dẫn : {fi.FullName}");
            sb.AppendLine($"Kích thước: {DinhDangDungLuong(fi.Length)}");
            sb.AppendLine($"Ngày tạo  : {fi.CreationTime:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Sửa đổi   : {fi.LastWriteTime:dd/MM/yyyy HH:mm}");
            return sb.ToString();
        }

        private static string MoTaFileKhongXemDuoc(FileInfo fi)
        {
            return "KHÔNG THỂ HIỂN THỊ NỘI DUNG\r\n\r\n" +
                   "Đây là file nhị phân (hoặc định dạng không phải văn bản / hình ảnh)\r\n" +
                   "nên không thể xem dưới dạng chữ.\r\n\r\n" +
                   MoTaFile(fi);
        }

        // ================= ĐỌC & GIẢI MÃ NỘI DUNG FILE =================

        // Đọc tối đa 'toiDa' byte đầu của file (cho phép đọc cả file đang được chương trình khác mở)
        private static byte[] DocByteDauFile(string duongDan, int toiDa, out bool biCat)
        {
            using var fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);

            biCat = fs.Length > toiDa;
            int canDoc = (int)Math.Min(fs.Length, toiDa);
            byte[] buf = new byte[canDoc];

            int daDoc = 0;
            while (daDoc < canDoc)
            {
                int n = fs.Read(buf, daDoc, canDoc - daDoc);
                if (n <= 0) break;
                daDoc += n;
            }

            if (daDoc < canDoc) Array.Resize(ref buf, daDoc);
            return buf;
        }

        // Đoán xem dữ liệu có phải nhị phân không
        private static bool LaNhiPhan(byte[] buf)
        {
            if (buf.Length == 0) return false;

            // Có BOM (UTF-8 / UTF-16) thì chắc chắn là văn bản
            if (buf.Length >= 3 && buf[0] == 0xEF && buf[1] == 0xBB && buf[2] == 0xBF) return false;
            if (buf.Length >= 2 && ((buf[0] == 0xFF && buf[1] == 0xFE) || (buf[0] == 0xFE && buf[1] == 0xFF))) return false;

            int soMau = Math.Min(buf.Length, 8000);
            int kyTuLa = 0;
            for (int i = 0; i < soMau; i++)
            {
                byte b = buf[i];
                if (b == 0) return true;                                   // Byte 0 hầu như chỉ có trong file nhị phân
                if (b < 9 || (b > 13 && b < 32 && b != 27)) kyTuLa++;      // Ký tự điều khiển lạ
            }
            return kyTuLa > soMau * 0.05;
        }

        // Giải mã byte -> chuỗi (tự nhận UTF-8 / UTF-16 theo BOM, mặc định UTF-8) rồi chuẩn hóa xuống dòng cho TextBox
        private static string GiaiMaVanBan(byte[] buf)
        {
            using var ms = new MemoryStream(buf);
            using var sr = new StreamReader(ms, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
            string text = sr.ReadToEnd();

            // TextBox cần \r\n; file Unix chỉ có \n sẽ bị dính thành 1 dòng nếu không chuẩn hóa
            return text.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
        }

        private static void Loi(string noiDung)
        {
            MessageBox.Show(noiDung, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ================= VẼ BỘ ICON (không cần file ảnh ngoài) =================

        private void TaoBoIcon()
        {
            imgIcons.Images.Clear();

            ThemIcon("folder", g =>
            {
                using var vien = new Pen(Color.FromArgb(202, 138, 4));
                using var tab = new SolidBrush(Color.FromArgb(234, 179, 8));
                using var than = new SolidBrush(Color.FromArgb(250, 204, 21));
                g.FillRectangle(tab, 1, 3, 8, 4);
                g.FillRectangle(than, 1, 5, 18, 12);
                g.DrawRectangle(vien, 1, 5, 17, 11);
            });

            ThemIcon("file", g => VeTrangGiay(g));

            ThemIcon("text", g =>
            {
                VeTrangGiay(g);
                using var net = new Pen(Color.FromArgb(156, 163, 175));
                g.DrawLine(net, 7, 9, 14, 9);
                g.DrawLine(net, 7, 12, 14, 12);
                g.DrawLine(net, 7, 15, 14, 15);
            });

            ThemIcon("image", g =>
            {
                using var nen = new SolidBrush(Color.FromArgb(219, 234, 254));
                using var vien = new Pen(Color.FromArgb(59, 130, 246));
                using var matTroi = new SolidBrush(Color.FromArgb(250, 204, 21));
                using var nui = new SolidBrush(Color.FromArgb(34, 197, 94));
                g.FillRectangle(nen, 2, 3, 16, 14);
                g.FillEllipse(matTroi, 12, 5, 4, 4);
                g.FillPolygon(nui, new Point[] { new(3, 16), new(8, 9), new(12, 14), new(14, 12), new(17, 16) });
                g.DrawRectangle(vien, 2, 3, 16, 14);
            });

            ThemIcon("drive", g =>
            {
                using var than = new SolidBrush(Color.FromArgb(209, 213, 219));
                using var vien = new Pen(Color.FromArgb(75, 85, 99));
                using var den = new SolidBrush(Color.FromArgb(75, 85, 99));
                using var xanh = new SolidBrush(Color.FromArgb(34, 197, 94));
                g.FillRectangle(than, 1, 6, 18, 9);
                g.DrawRectangle(vien, 1, 6, 17, 8);
                g.FillRectangle(den, 3, 10, 8, 2);
                g.FillRectangle(xanh, 14, 10, 3, 2);
            });
        }

        private void ThemIcon(string khoa, Action<Graphics> ve)
        {
            using var bmp = new Bitmap(20, 20);
            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                ve(g);
            }
            imgIcons.Images.Add(khoa, bmp);
        }

        private static void VeTrangGiay(Graphics g)
        {
            using var nen = new SolidBrush(Color.White);
            using var vien = new Pen(Color.FromArgb(107, 114, 128));
            using var gap = new SolidBrush(Color.FromArgb(209, 213, 219));

            Point[] trang = { new(4, 1), new(13, 1), new(17, 5), new(17, 18), new(4, 18) };
            g.FillPolygon(nen, trang);
            g.DrawPolygon(vien, trang);
            g.FillPolygon(gap, new Point[] { new(13, 1), new(13, 5), new(17, 5) });
        }
    }
}