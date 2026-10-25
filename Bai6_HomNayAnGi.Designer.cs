namespace LAB02
{
    partial class Bai6_HomNayAnGi
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
            this.grpNguoiDung = new System.Windows.Forms.GroupBox();
            this.lblHoVaTen = new System.Windows.Forms.Label();
            this.txtHoVaTen = new System.Windows.Forms.TextBox();
            this.lblQuyenHan = new System.Windows.Forms.Label();
            this.cbbQuyenHan = new System.Windows.Forms.ComboBox();
            this.btnThemNguoiDung = new System.Windows.Forms.Button();

            this.grpMonAn = new System.Windows.Forms.GroupBox();
            this.lblTenMonAn = new System.Windows.Forms.Label();
            this.txtTenMonAn = new System.Windows.Forms.TextBox();
            this.lblNguoiDongGop = new System.Windows.Forms.Label();
            this.cbbNguoiDongGop = new System.Windows.Forms.ComboBox();
            this.lblHinhAnh = new System.Windows.Forms.Label();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.btnThemMonAn = new System.Windows.Forms.Button();
            this.btnTaoDuLieuMau = new System.Windows.Forms.Button();
            this.btnXoaMonAn = new System.Windows.Forms.Button();

            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.lvwMonAn = new System.Windows.Forms.ListView();
            this.colIDMA = new System.Windows.Forms.ColumnHeader();
            this.colTenMonAn = new System.Windows.Forms.ColumnHeader();
            this.colNguoiDongGop = new System.Windows.Forms.ColumnHeader();
            this.colQuyenHan = new System.Windows.Forms.ColumnHeader();
            this.colHinhAnh = new System.Windows.Forms.ColumnHeader();

            this.grpKetQua = new System.Windows.Forms.GroupBox();
            this.btnNgauNhien = new System.Windows.Forms.Button();
            this.lblKetQuaMon = new System.Windows.Forms.Label();
            this.txtKetQuaMon = new System.Windows.Forms.TextBox();
            this.lblKetQuaNCC = new System.Windows.Forms.Label();
            this.txtKetQuaNCC = new System.Windows.Forms.TextBox();
            this.lblAnhMinhHoa = new System.Windows.Forms.Label();
            this.picMonAn = new System.Windows.Forms.PictureBox();

            this.grpNguoiDung.SuspendLayout();
            this.grpMonAn.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            this.grpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMonAn)).BeginInit();
            this.SuspendLayout();

            // 
            // ================= GROUPBOX 1: BẢNG NGUOIDUNG (IDNCC, HoVaTen, QuyenHan) =================
            // 
            this.grpNguoiDung.Controls.Add(this.lblHoVaTen);
            this.grpNguoiDung.Controls.Add(this.txtHoVaTen);
            this.grpNguoiDung.Controls.Add(this.lblQuyenHan);
            this.grpNguoiDung.Controls.Add(this.cbbQuyenHan);
            this.grpNguoiDung.Controls.Add(this.btnThemNguoiDung);
            this.grpNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpNguoiDung.Location = new System.Drawing.Point(12, 12);
            this.grpNguoiDung.Name = "grpNguoiDung";
            this.grpNguoiDung.Size = new System.Drawing.Size(380, 165);
            this.grpNguoiDung.TabIndex = 0;
            this.grpNguoiDung.TabStop = false;
            this.grpNguoiDung.Text = "1. Thêm Người Đóng Góp (Bảng NguoiDung)";

            // lblHoVaTen
            this.lblHoVaTen.AutoSize = true;
            this.lblHoVaTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblHoVaTen.Location = new System.Drawing.Point(14, 28);
            this.lblHoVaTen.Name = "lblHoVaTen";
            this.lblHoVaTen.Size = new System.Drawing.Size(140, 15);
            this.lblHoVaTen.Text = "Họ và tên người đóng góp:";

            // txtHoVaTen
            this.txtHoVaTen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.txtHoVaTen.Location = new System.Drawing.Point(16, 47);
            this.txtHoVaTen.Name = "txtHoVaTen";
            this.txtHoVaTen.Size = new System.Drawing.Size(346, 24);
            this.txtHoVaTen.TabIndex = 0;

            // lblQuyenHan
            this.lblQuyenHan.AutoSize = true;
            this.lblQuyenHan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblQuyenHan.Location = new System.Drawing.Point(14, 80);
            this.lblQuyenHan.Name = "lblQuyenHan";
            this.lblQuyenHan.Size = new System.Drawing.Size(70, 15);
            this.lblQuyenHan.Text = "Quyền hạn:";

            // cbbQuyenHan
            this.cbbQuyenHan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbQuyenHan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.cbbQuyenHan.FormattingEnabled = true;
            this.cbbQuyenHan.Location = new System.Drawing.Point(16, 99);
            this.cbbQuyenHan.Name = "cbbQuyenHan";
            this.cbbQuyenHan.Size = new System.Drawing.Size(175, 25);
            this.cbbQuyenHan.TabIndex = 1;

            // btnThemNguoiDung
            this.btnThemNguoiDung.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnThemNguoiDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemNguoiDung.ForeColor = System.Drawing.Color.White;
            this.btnThemNguoiDung.Location = new System.Drawing.Point(202, 95);
            this.btnThemNguoiDung.Name = "btnThemNguoiDung";
            this.btnThemNguoiDung.Size = new System.Drawing.Size(160, 32);
            this.btnThemNguoiDung.TabIndex = 2;
            this.btnThemNguoiDung.Text = "Thêm Người Dùng";
            this.btnThemNguoiDung.UseVisualStyleBackColor = false;
            this.btnThemNguoiDung.Click += new System.EventHandler(this.btnThemNguoiDung_Click);

            // 
            // ================= GROUPBOX 2: BẢNG MONAN (IDMA, TenMonAn, HinhAnh, IDNCC) =================
            // 
            this.grpMonAn.Controls.Add(this.lblTenMonAn);
            this.grpMonAn.Controls.Add(this.txtTenMonAn);
            this.grpMonAn.Controls.Add(this.lblNguoiDongGop);
            this.grpMonAn.Controls.Add(this.cbbNguoiDongGop);
            this.grpMonAn.Controls.Add(this.lblHinhAnh);
            this.grpMonAn.Controls.Add(this.txtHinhAnh);
            this.grpMonAn.Controls.Add(this.btnChonAnh);
            this.grpMonAn.Controls.Add(this.btnThemMonAn);
            this.grpMonAn.Controls.Add(this.btnTaoDuLieuMau);
            this.grpMonAn.Controls.Add(this.btnXoaMonAn);
            this.grpMonAn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpMonAn.Location = new System.Drawing.Point(404, 12);
            this.grpMonAn.Name = "grpMonAn";
            this.grpMonAn.Size = new System.Drawing.Size(540, 165);
            this.grpMonAn.TabIndex = 1;
            this.grpMonAn.TabStop = false;
            this.grpMonAn.Text = "2. Thêm Món Ăn Vào CSDL (Bảng MonAn)";

            // lblTenMonAn
            this.lblTenMonAn.AutoSize = true;
            this.lblTenMonAn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblTenMonAn.Location = new System.Drawing.Point(14, 28);
            this.lblTenMonAn.Name = "lblTenMonAn";
            this.lblTenMonAn.Size = new System.Drawing.Size(75, 15);
            this.lblTenMonAn.Text = "Tên món ăn:";

            // txtTenMonAn
            this.txtTenMonAn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.txtTenMonAn.Location = new System.Drawing.Point(16, 47);
            this.txtTenMonAn.Name = "txtTenMonAn";
            this.txtTenMonAn.Size = new System.Drawing.Size(250, 24);
            this.txtTenMonAn.TabIndex = 0;

            // lblNguoiDongGop
            this.lblNguoiDongGop.AutoSize = true;
            this.lblNguoiDongGop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblNguoiDongGop.Location = new System.Drawing.Point(280, 28);
            this.lblNguoiDongGop.Name = "lblNguoiDongGop";
            this.lblNguoiDongGop.Size = new System.Drawing.Size(155, 15);
            this.lblNguoiDongGop.Text = "Người đóng góp (IDNCC):";

            // cbbNguoiDongGop
            this.cbbNguoiDongGop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNguoiDongGop.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.cbbNguoiDongGop.FormattingEnabled = true;
            this.cbbNguoiDongGop.Location = new System.Drawing.Point(282, 47);
            this.cbbNguoiDongGop.Name = "cbbNguoiDongGop";
            this.cbbNguoiDongGop.Size = new System.Drawing.Size(242, 25);
            this.cbbNguoiDongGop.TabIndex = 1;

            // lblHinhAnh
            this.lblHinhAnh.AutoSize = true;
            this.lblHinhAnh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblHinhAnh.Location = new System.Drawing.Point(14, 78);
            this.lblHinhAnh.Name = "lblHinhAnh";
            this.lblHinhAnh.Size = new System.Drawing.Size(130, 15);
            this.lblHinhAnh.Text = "Hình ảnh món ăn (File):";

            // txtHinhAnh
            this.txtHinhAnh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.txtHinhAnh.Location = new System.Drawing.Point(16, 97);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Size = new System.Drawing.Size(395, 23);
            this.txtHinhAnh.TabIndex = 2;

            // btnChonAnh
            this.btnChonAnh.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnChonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Location = new System.Drawing.Point(418, 95);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(106, 26);
            this.btnChonAnh.TabIndex = 3;
            this.btnChonAnh.Text = "Chọn ảnh...";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            // btnThemMonAn
            this.btnThemMonAn.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnThemMonAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMonAn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemMonAn.ForeColor = System.Drawing.Color.White;
            this.btnThemMonAn.Location = new System.Drawing.Point(16, 126);
            this.btnThemMonAn.Name = "btnThemMonAn";
            this.btnThemMonAn.Size = new System.Drawing.Size(165, 30);
            this.btnThemMonAn.TabIndex = 4;
            this.btnThemMonAn.Text = "Thêm Món Ăn";
            this.btnThemMonAn.UseVisualStyleBackColor = false;
            this.btnThemMonAn.Click += new System.EventHandler(this.btnThemMonAn_Click);

            // btnTaoDuLieuMau
            this.btnTaoDuLieuMau.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btnTaoDuLieuMau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoDuLieuMau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTaoDuLieuMau.ForeColor = System.Drawing.Color.White;
            this.btnTaoDuLieuMau.Location = new System.Drawing.Point(190, 126);
            this.btnTaoDuLieuMau.Name = "btnTaoDuLieuMau";
            this.btnTaoDuLieuMau.Size = new System.Drawing.Size(175, 30);
            this.btnTaoDuLieuMau.TabIndex = 5;
            this.btnTaoDuLieuMau.Text = "Nạp / Tạo Dữ Liệu Mẫu";
            this.btnTaoDuLieuMau.UseVisualStyleBackColor = false;
            this.btnTaoDuLieuMau.Click += new System.EventHandler(this.btnTaoDuLieuMau_Click);

            // btnXoaMonAn
            this.btnXoaMonAn.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnXoaMonAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMonAn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaMonAn.ForeColor = System.Drawing.Color.White;
            this.btnXoaMonAn.Location = new System.Drawing.Point(374, 126);
            this.btnXoaMonAn.Name = "btnXoaMonAn";
            this.btnXoaMonAn.Size = new System.Drawing.Size(150, 30);
            this.btnXoaMonAn.TabIndex = 6;
            this.btnXoaMonAn.Text = "Xóa Món Đã Chọn";
            this.btnXoaMonAn.UseVisualStyleBackColor = false;
            this.btnXoaMonAn.Click += new System.EventHandler(this.btnXoaMonAn_Click);

            // 
            // ================= GROUPBOX 3: DANH SÁCH MÓN ĂN TRONG CSDL (LISTVIEW) =================
            // 
            this.grpDanhSach.Controls.Add(this.lvwMonAn);
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDanhSach.Location = new System.Drawing.Point(12, 185);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(550, 440);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "3. Danh Sách Món Ăn Đọc Từ SQL Server (ListView)";

            // lvwMonAn
            this.lvwMonAn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colIDMA,
                this.colTenMonAn,
                this.colNguoiDongGop,
                this.colQuyenHan,
                this.colHinhAnh});
            this.lvwMonAn.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lvwMonAn.FullRowSelect = true;
            this.lvwMonAn.GridLines = true;
            this.lvwMonAn.HideSelection = false;
            this.lvwMonAn.Location = new System.Drawing.Point(14, 28);
            this.lvwMonAn.MultiSelect = false;
            this.lvwMonAn.Name = "lvwMonAn";
            this.lvwMonAn.Size = new System.Drawing.Size(522, 396);
            this.lvwMonAn.TabIndex = 0;
            this.lvwMonAn.UseCompatibleStateImageBehavior = false;
            this.lvwMonAn.View = System.Windows.Forms.View.Details;
            this.lvwMonAn.SelectedIndexChanged += new System.EventHandler(this.lvwMonAn_SelectedIndexChanged);

            // Định dạng độ rộng các cột của ListView
            this.colIDMA.Text = "IDMA";
            this.colIDMA.Width = 55;
            this.colTenMonAn.Text = "Tên Món Ăn";
            this.colTenMonAn.Width = 155;
            this.colNguoiDongGop.Text = "Người Đóng Góp";
            this.colNguoiDongGop.Width = 135;
            this.colQuyenHan.Text = "Quyền Hạn";
            this.colQuyenHan.Width = 85;
            this.colHinhAnh.Text = "Hình Ảnh";
            this.colHinhAnh.Width = 120;

            // 
            // ================= GROUPBOX 4: KẾT QUẢ CHỌN NGẪU NHIÊN & HÌNH ẢNH =================
            // 
            this.grpKetQua.Controls.Add(this.btnNgauNhien);
            this.grpKetQua.Controls.Add(this.lblKetQuaMon);
            this.grpKetQua.Controls.Add(this.txtKetQuaMon);
            this.grpKetQua.Controls.Add(this.lblKetQuaNCC);
            this.grpKetQua.Controls.Add(this.txtKetQuaNCC);
            this.grpKetQua.Controls.Add(this.lblAnhMinhHoa);
            this.grpKetQua.Controls.Add(this.picMonAn);
            this.grpKetQua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpKetQua.Location = new System.Drawing.Point(574, 185);
            this.grpKetQua.Name = "grpKetQua";
            this.grpKetQua.Size = new System.Drawing.Size(370, 440);
            this.grpKetQua.TabIndex = 3;
            this.grpKetQua.TabStop = false;
            this.grpKetQua.Text = "4. Kết Quả: Hôm Nay Ăn Gì?";

            // btnNgauNhien
            this.btnNgauNhien.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnNgauNhien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNgauNhien.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNgauNhien.ForeColor = System.Drawing.Color.White;
            this.btnNgauNhien.Location = new System.Drawing.Point(16, 28);
            this.btnNgauNhien.Name = "btnNgauNhien";
            this.btnNgauNhien.Size = new System.Drawing.Size(338, 42);
            this.btnNgauNhien.TabIndex = 0;
            this.btnNgauNhien.Text = "🎲 HÔM NAY ĂN GÌ? (NGẪU NHIÊN)";
            this.btnNgauNhien.UseVisualStyleBackColor = false;
            this.btnNgauNhien.Click += new System.EventHandler(this.btnNgauNhien_Click);

            // lblKetQuaMon
            this.lblKetQuaMon.AutoSize = true;
            this.lblKetQuaMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblKetQuaMon.Location = new System.Drawing.Point(14, 80);
            this.lblKetQuaMon.Name = "lblKetQuaMon";
            this.lblKetQuaMon.Size = new System.Drawing.Size(130, 15);
            this.lblKetQuaMon.Text = "Món ăn được chọn:";

            // txtKetQuaMon
            this.txtKetQuaMon.BackColor = System.Drawing.Color.FromArgb(254, 243, 199);
            this.txtKetQuaMon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtKetQuaMon.ForeColor = System.Drawing.Color.FromArgb(180, 83, 9);
            this.txtKetQuaMon.Location = new System.Drawing.Point(16, 98);
            this.txtKetQuaMon.Name = "txtKetQuaMon";
            this.txtKetQuaMon.ReadOnly = true;
            this.txtKetQuaMon.Size = new System.Drawing.Size(338, 27);
            this.txtKetQuaMon.TabIndex = 1;
            this.txtKetQuaMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblKetQuaNCC
            this.lblKetQuaNCC.AutoSize = true;
            this.lblKetQuaNCC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblKetQuaNCC.Location = new System.Drawing.Point(14, 132);
            this.lblKetQuaNCC.Name = "lblKetQuaNCC";
            this.lblKetQuaNCC.Size = new System.Drawing.Size(165, 15);
            this.lblKetQuaNCC.Text = "Người đóng góp món ăn:";

            // txtKetQuaNCC
            this.txtKetQuaNCC.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtKetQuaNCC.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtKetQuaNCC.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtKetQuaNCC.Location = new System.Drawing.Point(16, 150);
            this.txtKetQuaNCC.Name = "txtKetQuaNCC";
            this.txtKetQuaNCC.ReadOnly = true;
            this.txtKetQuaNCC.Size = new System.Drawing.Size(338, 24);
            this.txtKetQuaNCC.TabIndex = 2;
            this.txtKetQuaNCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblAnhMinhHoa
            this.lblAnhMinhHoa.AutoSize = true;
            this.lblAnhMinhHoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblAnhMinhHoa.Location = new System.Drawing.Point(14, 182);
            this.lblAnhMinhHoa.Name = "lblAnhMinhHoa";
            this.lblAnhMinhHoa.Size = new System.Drawing.Size(125, 15);
            this.lblAnhMinhHoa.Text = "Hình ảnh của món ăn:";

            // picMonAn
            this.picMonAn.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.picMonAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMonAn.Location = new System.Drawing.Point(16, 202);
            this.picMonAn.Name = "picMonAn";
            this.picMonAn.Size = new System.Drawing.Size(338, 222);
            this.picMonAn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMonAn.TabIndex = 3;
            this.picMonAn.TabStop = false;

            // 
            // ================= CẤU HÌNH FORM CHÍNH (Bai6_HomNayAnGi) =================
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(958, 638);
            this.Controls.Add(this.grpKetQua);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpMonAn);
            this.Controls.Add(this.grpNguoiDung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bai6_HomNayAnGi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 06 - Hôm nay ăn gì? (Phiên bản 2 - Kết nối SQL Server)";
            this.Load += new System.EventHandler(this.Bai6_HomNayAnGi_Load);
            this.grpNguoiDung.ResumeLayout(false);
            this.grpNguoiDung.PerformLayout();
            this.grpMonAn.ResumeLayout(false);
            this.grpMonAn.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            this.grpKetQua.ResumeLayout(false);
            this.grpKetQua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMonAn)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpNguoiDung;
        private System.Windows.Forms.Label lblHoVaTen;
        private System.Windows.Forms.TextBox txtHoVaTen;
        private System.Windows.Forms.Label lblQuyenHan;
        private System.Windows.Forms.ComboBox cbbQuyenHan;
        private System.Windows.Forms.Button btnThemNguoiDung;

        private System.Windows.Forms.GroupBox grpMonAn;
        private System.Windows.Forms.Label lblTenMonAn;
        private System.Windows.Forms.TextBox txtTenMonAn;
        private System.Windows.Forms.Label lblNguoiDongGop;
        private System.Windows.Forms.ComboBox cbbNguoiDongGop;
        private System.Windows.Forms.Label lblHinhAnh;
        private System.Windows.Forms.TextBox txtHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnThemMonAn;
        private System.Windows.Forms.Button btnTaoDuLieuMau;
        private System.Windows.Forms.Button btnXoaMonAn;

        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.ListView lvwMonAn;
        private System.Windows.Forms.ColumnHeader colIDMA;
        private System.Windows.Forms.ColumnHeader colTenMonAn;
        private System.Windows.Forms.ColumnHeader colNguoiDongGop;
        private System.Windows.Forms.ColumnHeader colQuyenHan;
        private System.Windows.Forms.ColumnHeader colHinhAnh;

        private System.Windows.Forms.GroupBox grpKetQua;
        private System.Windows.Forms.Button btnNgauNhien;
        private System.Windows.Forms.Label lblKetQuaMon;
        private System.Windows.Forms.TextBox txtKetQuaMon;
        private System.Windows.Forms.Label lblKetQuaNCC;
        private System.Windows.Forms.TextBox txtKetQuaNCC;
        private System.Windows.Forms.Label lblAnhMinhHoa;
        private System.Windows.Forms.PictureBox picMonAn;
    }
}