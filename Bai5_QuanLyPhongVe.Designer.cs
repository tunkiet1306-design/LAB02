namespace LAB02
{
    partial class Bai5_QuanLyPhongVe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.lblTenPhimMoi = new System.Windows.Forms.Label();
            this.txtTenPhimMoi = new System.Windows.Forms.TextBox();
            this.lblGiaVeMoi = new System.Windows.Forms.Label();
            this.txtGiaVeMoi = new System.Windows.Forms.TextBox();
            this.lblPhongChieuMoi = new System.Windows.Forms.Label();
            this.txtPhongChieuMoi = new System.Windows.Forms.TextBox();
            this.btnGhiInput = new System.Windows.Forms.Button();
            this.btnDocInput = new System.Windows.Forms.Button();
            this.lblNoiDungInput = new System.Windows.Forms.Label();
            this.rtbInput5 = new System.Windows.Forms.RichTextBox();

            this.grpDatVe = new System.Windows.Forms.GroupBox();
            this.lblHoTenKhach = new System.Windows.Forms.Label();
            this.txtHoTenKhach = new System.Windows.Forms.TextBox();
            this.lblChonPhim = new System.Windows.Forms.Label();
            this.cbbChonPhim = new System.Windows.Forms.ComboBox();
            this.lblChonPhong = new System.Windows.Forms.Label();
            this.cbbChonPhongChieu = new System.Windows.Forms.ComboBox();
            this.lblChonGhe = new System.Windows.Forms.Label();
            this.clbChoNgoi = new System.Windows.Forms.CheckedListBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblBienLai = new System.Windows.Forms.Label();
            this.rtbBienLai = new System.Windows.Forms.RichTextBox();

            this.grpThongKe = new System.Windows.Forms.GroupBox();
            this.btnXuatThongKe = new System.Windows.Forms.Button();
            this.lblTienTrinh = new System.Windows.Forms.Label();
            this.prgTienTrinh = new System.Windows.Forms.ProgressBar();
            this.lblKetQuaThongKe = new System.Windows.Forms.Label();
            this.rtbThongKe = new System.Windows.Forms.RichTextBox();

            this.grpInput.SuspendLayout();
            this.grpDatVe.SuspendLayout();
            this.grpThongKe.SuspendLayout();
            this.SuspendLayout();

            // 
            // ================= GROUPBOX 1: QUẢN LÝ FILE PHIM (input5.txt) =================
            // 
            this.grpInput.Controls.Add(this.lblTenPhimMoi);
            this.grpInput.Controls.Add(this.txtTenPhimMoi);
            this.grpInput.Controls.Add(this.lblGiaVeMoi);
            this.grpInput.Controls.Add(this.txtGiaVeMoi);
            this.grpInput.Controls.Add(this.lblPhongChieuMoi);
            this.grpInput.Controls.Add(this.txtPhongChieuMoi);
            this.grpInput.Controls.Add(this.btnGhiInput);
            this.grpInput.Controls.Add(this.btnDocInput);
            this.grpInput.Controls.Add(this.lblNoiDungInput);
            this.grpInput.Controls.Add(this.rtbInput5);
            this.grpInput.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(370, 410);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "1. Quản lý dữ liệu phim (input5.txt)";

            // lblTenPhimMoi
            this.lblTenPhimMoi.AutoSize = true;
            this.lblTenPhimMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblTenPhimMoi.Location = new System.Drawing.Point(14, 28);
            this.lblTenPhimMoi.Name = "lblTenPhimMoi";
            this.lblTenPhimMoi.Size = new System.Drawing.Size(180, 15);
            this.lblTenPhimMoi.Text = "Tên phim (VD: Đào, phở và piano):";

            // txtTenPhimMoi
            this.txtTenPhimMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.txtTenPhimMoi.Location = new System.Drawing.Point(16, 46);
            this.txtTenPhimMoi.Name = "txtTenPhimMoi";
            this.txtTenPhimMoi.Size = new System.Drawing.Size(336, 24);
            this.txtTenPhimMoi.TabIndex = 0;

            // lblGiaVeMoi
            this.lblGiaVeMoi.AutoSize = true;
            this.lblGiaVeMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblGiaVeMoi.Location = new System.Drawing.Point(14, 76);
            this.lblGiaVeMoi.Name = "lblGiaVeMoi";
            this.lblGiaVeMoi.Size = new System.Drawing.Size(165, 15);
            this.lblGiaVeMoi.Text = "Giá vé chuẩn VNĐ (VD: 45000):";

            // txtGiaVeMoi
            this.txtGiaVeMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.txtGiaVeMoi.Location = new System.Drawing.Point(16, 94);
            this.txtGiaVeMoi.Name = "txtGiaVeMoi";
            this.txtGiaVeMoi.Size = new System.Drawing.Size(336, 24);
            this.txtGiaVeMoi.TabIndex = 1;

            // lblPhongChieuMoi
            this.lblPhongChieuMoi.AutoSize = true;
            this.lblPhongChieuMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblPhongChieuMoi.Location = new System.Drawing.Point(14, 124);
            this.lblPhongChieuMoi.Name = "lblPhongChieuMoi";
            this.lblPhongChieuMoi.Size = new System.Drawing.Size(255, 15);
            this.lblPhongChieuMoi.Text = "Phòng chiếu (cách nhau dấu phẩy, VD: 1, 2, 3):";

            // txtPhongChieuMoi
            this.txtPhongChieuMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.txtPhongChieuMoi.Location = new System.Drawing.Point(16, 142);
            this.txtPhongChieuMoi.Name = "txtPhongChieuMoi";
            this.txtPhongChieuMoi.Size = new System.Drawing.Size(336, 24);
            this.txtPhongChieuMoi.TabIndex = 2;

            // btnGhiInput
            this.btnGhiInput.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnGhiInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGhiInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGhiInput.ForeColor = System.Drawing.Color.White;
            this.btnGhiInput.Location = new System.Drawing.Point(16, 174);
            this.btnGhiInput.Name = "btnGhiInput";
            this.btnGhiInput.Size = new System.Drawing.Size(164, 34);
            this.btnGhiInput.TabIndex = 3;
            this.btnGhiInput.Text = "Thêm && Ghi input5.txt";
            this.btnGhiInput.UseVisualStyleBackColor = false;
            this.btnGhiInput.Click += new System.EventHandler(this.btnGhiInput_Click);

            // btnDocInput
            this.btnDocInput.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnDocInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDocInput.ForeColor = System.Drawing.Color.White;
            this.btnDocInput.Location = new System.Drawing.Point(188, 174);
            this.btnDocInput.Name = "btnDocInput";
            this.btnDocInput.Size = new System.Drawing.Size(164, 34);
            this.btnDocInput.TabIndex = 4;
            this.btnDocInput.Text = "Đọc từ input5.txt";
            this.btnDocInput.UseVisualStyleBackColor = false;
            this.btnDocInput.Click += new System.EventHandler(this.btnDocInput_Click);

            // lblNoiDungInput
            this.lblNoiDungInput.AutoSize = true;
            this.lblNoiDungInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblNoiDungInput.Location = new System.Drawing.Point(14, 216);
            this.lblNoiDungInput.Name = "lblNoiDungInput";
            this.lblNoiDungInput.Size = new System.Drawing.Size(145, 15);
            this.lblNoiDungInput.Text = "Nội dung file input5.txt:";

            // rtbInput5
            this.rtbInput5.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.rtbInput5.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular);
            this.rtbInput5.Location = new System.Drawing.Point(16, 235);
            this.rtbInput5.Name = "rtbInput5";
            this.rtbInput5.ReadOnly = true;
            this.rtbInput5.Size = new System.Drawing.Size(336, 160);
            this.rtbInput5.TabIndex = 5;
            this.rtbInput5.Text = "";

            // 
            // ================= GROUPBOX 2: ĐẶT VÉ XEM PHIM (KHÁCH HÀNG) =================
            // 
            this.grpDatVe.Controls.Add(this.lblHoTenKhach);
            this.grpDatVe.Controls.Add(this.txtHoTenKhach);
            this.grpDatVe.Controls.Add(this.lblChonPhim);
            this.grpDatVe.Controls.Add(this.cbbChonPhim);
            this.grpDatVe.Controls.Add(this.lblChonPhong);
            this.grpDatVe.Controls.Add(this.cbbChonPhongChieu);
            this.grpDatVe.Controls.Add(this.lblChonGhe);
            this.grpDatVe.Controls.Add(this.clbChoNgoi);
            this.grpDatVe.Controls.Add(this.btnThanhToan);
            this.grpDatVe.Controls.Add(this.lblBienLai);
            this.grpDatVe.Controls.Add(this.rtbBienLai);
            this.grpDatVe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDatVe.Location = new System.Drawing.Point(394, 12);
            this.grpDatVe.Name = "grpDatVe";
            this.grpDatVe.Size = new System.Drawing.Size(490, 410);
            this.grpDatVe.TabIndex = 1;
            this.grpDatVe.TabStop = false;
            this.grpDatVe.Text = "2. Đặt vé xem phim (Khách hàng)";

            // lblHoTenKhach
            this.lblHoTenKhach.AutoSize = true;
            this.lblHoTenKhach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblHoTenKhach.Location = new System.Drawing.Point(16, 28);
            this.lblHoTenKhach.Name = "lblHoTenKhach";
            this.lblHoTenKhach.Size = new System.Drawing.Size(115, 15);
            this.lblHoTenKhach.Text = "Họ và tên khách hàng:";

            // txtHoTenKhach
            this.txtHoTenKhach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.txtHoTenKhach.Location = new System.Drawing.Point(18, 46);
            this.txtHoTenKhach.Name = "txtHoTenKhach";
            this.txtHoTenKhach.Size = new System.Drawing.Size(454, 24);
            this.txtHoTenKhach.TabIndex = 0;

            // lblChonPhim
            this.lblChonPhim.AutoSize = true;
            this.lblChonPhim.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblChonPhim.Location = new System.Drawing.Point(16, 76);
            this.lblChonPhim.Name = "lblChonPhim";
            this.lblChonPhim.Size = new System.Drawing.Size(68, 15);
            this.lblChonPhim.Text = "Chọn phim:";

            // cbbChonPhim
            this.cbbChonPhim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChonPhim.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.cbbChonPhim.FormattingEnabled = true;
            this.cbbChonPhim.Location = new System.Drawing.Point(18, 94);
            this.cbbChonPhim.Name = "cbbChonPhim";
            this.cbbChonPhim.Size = new System.Drawing.Size(270, 25);
            this.cbbChonPhim.TabIndex = 1;
            this.cbbChonPhim.SelectedIndexChanged += new System.EventHandler(this.cbbChonPhim_SelectedIndexChanged);

            // lblChonPhong
            this.lblChonPhong.AutoSize = true;
            this.lblChonPhong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblChonPhong.Location = new System.Drawing.Point(302, 76);
            this.lblChonPhong.Name = "lblChonPhong";
            this.lblChonPhong.Size = new System.Drawing.Size(105, 15);
            this.lblChonPhong.Text = "Chọn phòng chiếu:";

            // cbbChonPhongChieu
            this.cbbChonPhongChieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChonPhongChieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.cbbChonPhongChieu.FormattingEnabled = true;
            this.cbbChonPhongChieu.Location = new System.Drawing.Point(304, 94);
            this.cbbChonPhongChieu.Name = "cbbChonPhongChieu";
            this.cbbChonPhongChieu.Size = new System.Drawing.Size(168, 25);
            this.cbbChonPhongChieu.TabIndex = 2;

            // lblChonGhe
            this.lblChonGhe.AutoSize = true;
            this.lblChonGhe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblChonGhe.Location = new System.Drawing.Point(16, 126);
            this.lblChonGhe.Name = "lblChonGhe";
            this.lblChonGhe.Size = new System.Drawing.Size(360, 15);
            this.lblChonGhe.Text = "Chọn ghế (Vớt: A1,A5,C1,C5 | Thường: A2-A4,B1,B5,C2-C4 | VIP: B2-B4):";

            // clbChoNgoi
            this.clbChoNgoi.CheckOnClick = true;
            this.clbChoNgoi.ColumnWidth = 85;
            this.clbChoNgoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.clbChoNgoi.FormattingEnabled = true;
            this.clbChoNgoi.Location = new System.Drawing.Point(18, 145);
            this.clbChoNgoi.MultiColumn = true;
            this.clbChoNgoi.Name = "clbChoNgoi";
            this.clbChoNgoi.Size = new System.Drawing.Size(454, 76);
            this.clbChoNgoi.TabIndex = 3;

            // btnThanhToan
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(18, 228);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(454, 36);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "ĐẶT VÉ && THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            // lblBienLai
            this.lblBienLai.AutoSize = true;
            this.lblBienLai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblBienLai.Location = new System.Drawing.Point(16, 270);
            this.lblBienLai.Name = "lblBienLai";
            this.lblBienLai.Size = new System.Drawing.Size(115, 15);
            this.lblBienLai.Text = "Biên lai thanh toán:";

            // rtbBienLai
            this.rtbBienLai.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.rtbBienLai.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular);
            this.rtbBienLai.Location = new System.Drawing.Point(18, 289);
            this.rtbBienLai.Name = "rtbBienLai";
            this.rtbBienLai.ReadOnly = true;
            this.rtbBienLai.Size = new System.Drawing.Size(454, 106);
            this.rtbBienLai.TabIndex = 5;
            this.rtbBienLai.Text = "";

            // 
            // ================= GROUPBOX 3: THỐNG KÊ & XUẤT FILE (output5.txt) =================
            // 
            this.grpThongKe.Controls.Add(this.btnXuatThongKe);
            this.grpThongKe.Controls.Add(this.lblTienTrinh);
            this.grpThongKe.Controls.Add(this.prgTienTrinh);
            this.grpThongKe.Controls.Add(this.lblKetQuaThongKe);
            this.grpThongKe.Controls.Add(this.rtbThongKe);
            this.grpThongKe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpThongKe.Location = new System.Drawing.Point(12, 428);
            this.grpThongKe.Name = "grpThongKe";
            this.grpThongKe.Size = new System.Drawing.Size(872, 235);
            this.grpThongKe.TabIndex = 2;
            this.grpThongKe.TabStop = false;
            this.grpThongKe.Text = "3. Thống kê phòng vé & Xuất file (output5.txt)";

            // btnXuatThongKe
            this.btnXuatThongKe.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnXuatThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatThongKe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXuatThongKe.ForeColor = System.Drawing.Color.White;
            this.btnXuatThongKe.Location = new System.Drawing.Point(16, 26);
            this.btnXuatThongKe.Name = "btnXuatThongKe";
            this.btnXuatThongKe.Size = new System.Drawing.Size(240, 34);
            this.btnXuatThongKe.TabIndex = 0;
            this.btnXuatThongKe.Text = "Xuất Thống Kê (output5.txt)";
            this.btnXuatThongKe.UseVisualStyleBackColor = false;
            this.btnXuatThongKe.Click += new System.EventHandler(this.btnXuatThongKe_Click);

            // lblTienTrinh
            this.lblTienTrinh.AutoSize = true;
            this.lblTienTrinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblTienTrinh.Location = new System.Drawing.Point(272, 35);
            this.lblTienTrinh.Name = "lblTienTrinh";
            this.lblTienTrinh.Size = new System.Drawing.Size(115, 15);
            this.lblTienTrinh.Text = "Tiến trình xuất file:";

            // prgTienTrinh
            this.prgTienTrinh.Location = new System.Drawing.Point(395, 30);
            this.prgTienTrinh.Name = "prgTienTrinh";
            this.prgTienTrinh.Size = new System.Drawing.Size(459, 26);
            this.prgTienTrinh.TabIndex = 1;

            // lblKetQuaThongKe
            this.lblKetQuaThongKe.AutoSize = true;
            this.lblKetQuaThongKe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblKetQuaThongKe.Location = new System.Drawing.Point(14, 66);
            this.lblKetQuaThongKe.Name = "lblKetQuaThongKe";
            this.lblKetQuaThongKe.Size = new System.Drawing.Size(340, 15);
            this.lblKetQuaThongKe.Text = "Bảng thống kê doanh thu (Xếp hạng từ cao xuống thấp):";

            // rtbThongKe
            this.rtbThongKe.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.rtbThongKe.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular);
            this.rtbThongKe.Location = new System.Drawing.Point(16, 85);
            this.rtbThongKe.Name = "rtbThongKe";
            this.rtbThongKe.ReadOnly = true;
            this.rtbThongKe.Size = new System.Drawing.Size(838, 136);
            this.rtbThongKe.TabIndex = 2;
            this.rtbThongKe.Text = "";

            // 
            // ================= CẤU HÌNH FORM CHÍNH (Form5) =================
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 675);
            this.Controls.Add(this.grpThongKe);
            this.Controls.Add(this.grpDatVe);
            this.Controls.Add(this.grpInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 05 - Quản lý phòng vé (Phiên bản 2)";
            this.Load += new System.EventHandler(this.Bai5_QuanLyPhongVe_Load);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpDatVe.ResumeLayout(false);
            this.grpDatVe.PerformLayout();
            this.grpThongKe.ResumeLayout(false);
            this.grpThongKe.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Khai báo biến cho các Control trên giao diện
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblTenPhimMoi;
        private System.Windows.Forms.TextBox txtTenPhimMoi;
        private System.Windows.Forms.Label lblGiaVeMoi;
        private System.Windows.Forms.TextBox txtGiaVeMoi;
        private System.Windows.Forms.Label lblPhongChieuMoi;
        private System.Windows.Forms.TextBox txtPhongChieuMoi;
        private System.Windows.Forms.Button btnGhiInput;
        private System.Windows.Forms.Button btnDocInput;
        private System.Windows.Forms.Label lblNoiDungInput;
        private System.Windows.Forms.RichTextBox rtbInput5;

        private System.Windows.Forms.GroupBox grpDatVe;
        private System.Windows.Forms.Label lblHoTenKhach;
        private System.Windows.Forms.TextBox txtHoTenKhach;
        private System.Windows.Forms.Label lblChonPhim;
        private System.Windows.Forms.ComboBox cbbChonPhim;
        private System.Windows.Forms.Label lblChonPhong;
        private System.Windows.Forms.ComboBox cbbChonPhongChieu;
        private System.Windows.Forms.Label lblChonGhe;
        private System.Windows.Forms.CheckedListBox clbChoNgoi;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblBienLai;
        private System.Windows.Forms.RichTextBox rtbBienLai;

        private System.Windows.Forms.GroupBox grpThongKe;
        private System.Windows.Forms.Button btnXuatThongKe;
        private System.Windows.Forms.Label lblTienTrinh;
        private System.Windows.Forms.ProgressBar prgTienTrinh;
        private System.Windows.Forms.Label lblKetQuaThongKe;
        private System.Windows.Forms.RichTextBox rtbThongKe;
    }
}