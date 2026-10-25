#nullable disable
using System.Drawing;
using System.Windows.Forms;

namespace LAB02
{
    partial class Bai7_DuyetThuMuc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlTop = new Panel();
            btnQuayLai = new Button();
            btnLenTren = new Button();
            btnMayTinh = new Button();
            txtDuongDan = new TextBox();
            btnDi = new Button();
            chkHienAn = new CheckBox();
            btnLamMoi = new Button();
            splitMain = new SplitContainer();
            lvwThuMuc = new ListView();
            colTen = new ColumnHeader();
            colLoai = new ColumnHeader();
            colKichThuoc = new ColumnHeader();
            colNgaySua = new ColumnHeader();
            imgIcons = new ImageList(components);
            txtNoiDung = new TextBox();
            picXemTruoc = new PictureBox();
            lblThongTinFile = new Label();
            lblTieuDeNoiDung = new Label();
            statusStrip = new StatusStrip();
            tsslSoLuong = new ToolStripStatusLabel();
            tsslDaChon = new ToolStripStatusLabel();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picXemTruoc).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(243, 244, 246);
            pnlTop.Controls.Add(btnQuayLai);
            pnlTop.Controls.Add(btnLenTren);
            pnlTop.Controls.Add(btnMayTinh);
            pnlTop.Controls.Add(txtDuongDan);
            pnlTop.Controls.Add(btnDi);
            pnlTop.Controls.Add(chkHienAn);
            pnlTop.Controls.Add(btnLamMoi);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(4, 5, 4, 5);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1571, 87);
            pnlTop.TabIndex = 0;
            // 
            // btnQuayLai
            // 
            btnQuayLai.BackColor = Color.White;
            btnQuayLai.Cursor = Cursors.Hand;
            btnQuayLai.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnQuayLai.FlatStyle = FlatStyle.Flat;
            btnQuayLai.Location = new Point(14, 17);
            btnQuayLai.Margin = new Padding(4, 5, 4, 5);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(103, 53);
            btnQuayLai.TabIndex = 0;
            btnQuayLai.Text = "← Lùi";
            btnQuayLai.UseVisualStyleBackColor = false;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // btnLenTren
            // 
            btnLenTren.BackColor = Color.White;
            btnLenTren.Cursor = Cursors.Hand;
            btnLenTren.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnLenTren.FlatStyle = FlatStyle.Flat;
            btnLenTren.Location = new Point(126, 17);
            btnLenTren.Margin = new Padding(4, 5, 4, 5);
            btnLenTren.Name = "btnLenTren";
            btnLenTren.Size = new Size(103, 53);
            btnLenTren.TabIndex = 1;
            btnLenTren.Text = "↑ Lên";
            btnLenTren.UseVisualStyleBackColor = false;
            btnLenTren.Click += btnLenTren_Click;
            // 
            // btnMayTinh
            // 
            btnMayTinh.BackColor = Color.White;
            btnMayTinh.Cursor = Cursors.Hand;
            btnMayTinh.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnMayTinh.FlatStyle = FlatStyle.Flat;
            btnMayTinh.Location = new Point(237, 17);
            btnMayTinh.Margin = new Padding(4, 5, 4, 5);
            btnMayTinh.Name = "btnMayTinh";
            btnMayTinh.Size = new Size(137, 53);
            btnMayTinh.TabIndex = 2;
            btnMayTinh.Text = "Máy tính";
            btnMayTinh.UseVisualStyleBackColor = false;
            btnMayTinh.Click += btnMayTinh_Click;
            // 
            // txtDuongDan
            // 
            txtDuongDan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDuongDan.BorderStyle = BorderStyle.FixedSingle;
            txtDuongDan.Font = new Font("Segoe UI", 10F);
            txtDuongDan.Location = new Point(382, 28);
            txtDuongDan.Margin = new Padding(4, 5, 4, 5);
            txtDuongDan.Name = "txtDuongDan";
            txtDuongDan.PlaceholderText = "Máy tính  (nhập đường dẫn rồi nhấn Enter...)";
            txtDuongDan.Size = new Size(742, 34);
            txtDuongDan.TabIndex = 3;
            txtDuongDan.KeyDown += txtDuongDan_KeyDown;
            // 
            // btnDi
            // 
            btnDi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDi.BackColor = Color.FromArgb(37, 99, 235);
            btnDi.Cursor = Cursors.Hand;
            btnDi.FlatAppearance.BorderSize = 0;
            btnDi.FlatStyle = FlatStyle.Flat;
            btnDi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDi.ForeColor = Color.White;
            btnDi.Location = new Point(1143, 17);
            btnDi.Margin = new Padding(4, 5, 4, 5);
            btnDi.Name = "btnDi";
            btnDi.Size = new Size(86, 53);
            btnDi.TabIndex = 4;
            btnDi.Text = "Đi";
            btnDi.UseVisualStyleBackColor = false;
            btnDi.Click += btnDi_Click;
            // 
            // chkHienAn
            // 
            chkHienAn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkHienAn.AutoSize = true;
            chkHienAn.Cursor = Cursors.Hand;
            chkHienAn.Location = new Point(1285, 28);
            chkHienAn.Margin = new Padding(4, 5, 4, 5);
            chkHienAn.Name = "chkHienAn";
            chkHienAn.Size = new Size(126, 29);
            chkHienAn.TabIndex = 5;
            chkHienAn.Text = "Hiện file ẩn";
            chkHienAn.UseVisualStyleBackColor = true;
            chkHienAn.CheckedChanged += chkHienAn_CheckedChanged;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.White;
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Location = new Point(1437, 17);
            btnLamMoi.Margin = new Padding(4, 5, 4, 5);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 53);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // splitMain
            // 
            splitMain.Dock = DockStyle.Fill;
            splitMain.Location = new Point(0, 87);
            splitMain.Margin = new Padding(4, 5, 4, 5);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(lvwThuMuc);
            splitMain.Panel1MinSize = 300;
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(txtNoiDung);
            splitMain.Panel2.Controls.Add(picXemTruoc);
            splitMain.Panel2.Controls.Add(lblThongTinFile);
            splitMain.Panel2.Controls.Add(lblTieuDeNoiDung);
            splitMain.Panel2MinSize = 250;
            splitMain.Size = new Size(1571, 964);
            splitMain.SplitterDistance = 914;
            splitMain.SplitterWidth = 6;
            splitMain.TabIndex = 1;
            // 
            // lvwThuMuc
            // 
            lvwThuMuc.BorderStyle = BorderStyle.None;
            lvwThuMuc.Columns.AddRange(new ColumnHeader[] { colTen, colLoai, colKichThuoc, colNgaySua });
            lvwThuMuc.Dock = DockStyle.Fill;
            lvwThuMuc.FullRowSelect = true;
            lvwThuMuc.Location = new Point(0, 0);
            lvwThuMuc.Margin = new Padding(4, 5, 4, 5);
            lvwThuMuc.MultiSelect = false;
            lvwThuMuc.Name = "lvwThuMuc";
            lvwThuMuc.Size = new Size(914, 964);
            lvwThuMuc.SmallImageList = imgIcons;
            lvwThuMuc.TabIndex = 0;
            lvwThuMuc.UseCompatibleStateImageBehavior = false;
            lvwThuMuc.View = View.Details;
            lvwThuMuc.ColumnClick += lvwThuMuc_ColumnClick;
            lvwThuMuc.SelectedIndexChanged += lvwThuMuc_SelectedIndexChanged;
            lvwThuMuc.KeyDown += lvwThuMuc_KeyDown;
            lvwThuMuc.MouseDoubleClick += lvwThuMuc_MouseDoubleClick;
            // 
            // colTen
            // 
            colTen.Text = "Tên";
            colTen.Width = 250;
            // 
            // colLoai
            // 
            colLoai.Text = "Loại";
            colLoai.Width = 100;
            // 
            // colKichThuoc
            // 
            colKichThuoc.Text = "Kích thước";
            colKichThuoc.Width = 150;
            // 
            // colNgaySua
            // 
            colNgaySua.Text = "Ngày sửa đổi";
            colNgaySua.Width = 120;
            // 
            // imgIcons
            // 
            imgIcons.ColorDepth = ColorDepth.Depth32Bit;
            imgIcons.ImageSize = new Size(20, 20);
            imgIcons.TransparentColor = Color.Transparent;
            // 
            // txtNoiDung
            // 
            txtNoiDung.BackColor = Color.White;
            txtNoiDung.BorderStyle = BorderStyle.None;
            txtNoiDung.Dock = DockStyle.Fill;
            txtNoiDung.Font = new Font("Consolas", 10F);
            txtNoiDung.Location = new Point(0, 97);
            txtNoiDung.Margin = new Padding(4, 5, 4, 5);
            txtNoiDung.Multiline = true;
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.ReadOnly = true;
            txtNoiDung.ScrollBars = ScrollBars.Both;
            txtNoiDung.Size = new Size(651, 867);
            txtNoiDung.TabIndex = 0;
            txtNoiDung.WordWrap = false;
            // 
            // picXemTruoc
            // 
            picXemTruoc.BackColor = Color.White;
            picXemTruoc.Dock = DockStyle.Fill;
            picXemTruoc.Location = new Point(0, 97);
            picXemTruoc.Margin = new Padding(4, 5, 4, 5);
            picXemTruoc.Name = "picXemTruoc";
            picXemTruoc.Size = new Size(651, 867);
            picXemTruoc.SizeMode = PictureBoxSizeMode.Zoom;
            picXemTruoc.TabIndex = 1;
            picXemTruoc.TabStop = false;
            picXemTruoc.Visible = false;
            // 
            // lblThongTinFile
            // 
            lblThongTinFile.AutoEllipsis = true;
            lblThongTinFile.BackColor = Color.FromArgb(239, 246, 255);
            lblThongTinFile.Dock = DockStyle.Top;
            lblThongTinFile.ForeColor = Color.FromArgb(30, 64, 175);
            lblThongTinFile.Location = new Point(0, 50);
            lblThongTinFile.Margin = new Padding(4, 0, 4, 0);
            lblThongTinFile.Name = "lblThongTinFile";
            lblThongTinFile.Padding = new Padding(11, 0, 0, 0);
            lblThongTinFile.Size = new Size(651, 47);
            lblThongTinFile.TabIndex = 2;
            lblThongTinFile.Text = "Chưa chọn file nào.";
            lblThongTinFile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTieuDeNoiDung
            // 
            lblTieuDeNoiDung.BackColor = Color.FromArgb(30, 64, 175);
            lblTieuDeNoiDung.Dock = DockStyle.Top;
            lblTieuDeNoiDung.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblTieuDeNoiDung.ForeColor = Color.White;
            lblTieuDeNoiDung.Location = new Point(0, 0);
            lblTieuDeNoiDung.Margin = new Padding(4, 0, 4, 0);
            lblTieuDeNoiDung.Name = "lblTieuDeNoiDung";
            lblTieuDeNoiDung.Padding = new Padding(11, 0, 0, 0);
            lblTieuDeNoiDung.Size = new Size(651, 50);
            lblTieuDeNoiDung.TabIndex = 3;
            lblTieuDeNoiDung.Text = "NỘI DUNG FILE ĐANG CHỌN";
            lblTieuDeNoiDung.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { tsslSoLuong, tsslDaChon });
            statusStrip.Location = new Point(0, 1051);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 20, 0);
            statusStrip.Size = new Size(1571, 32);
            statusStrip.TabIndex = 2;
            // 
            // tsslSoLuong
            // 
            tsslSoLuong.Name = "tsslSoLuong";
            tsslSoLuong.Size = new Size(91, 25);
            tsslSoLuong.Text = "Đang tải...";
            // 
            // tsslDaChon
            // 
            tsslDaChon.Name = "tsslDaChon";
            tsslDaChon.Size = new Size(1459, 25);
            tsslDaChon.Spring = true;
            tsslDaChon.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Bai7_DuyetThuMuc
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1571, 1083);
            Controls.Add(splitMain);
            Controls.Add(statusStrip);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1133, 713);
            Name = "Bai7_DuyetThuMuc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 07 - Duyệt thư mục";
            FormClosed += Bai7_DuyetThuMuc_FormClosed;
            Load += Bai7_DuyetThuMuc_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picXemTruoc).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlTop;
        private Button btnQuayLai;
        private Button btnLenTren;
        private Button btnMayTinh;
        private TextBox txtDuongDan;
        private Button btnDi;
        private CheckBox chkHienAn;
        private Button btnLamMoi;
        private SplitContainer splitMain;
        private ListView lvwThuMuc;
        private ColumnHeader colTen;
        private ColumnHeader colLoai;
        private ColumnHeader colKichThuoc;
        private ColumnHeader colNgaySua;
        private ImageList imgIcons;
        private TextBox txtNoiDung;
        private PictureBox picXemTruoc;
        private Label lblThongTinFile;
        private Label lblTieuDeNoiDung;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel tsslSoLuong;
        private ToolStripStatusLabel tsslDaChon;
    }
}