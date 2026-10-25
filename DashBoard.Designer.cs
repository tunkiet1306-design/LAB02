namespace LAB02
{
    partial class DashBoard
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
        private void InitializeComponent()
        {
            btnBai1 = new Button();
            btnBai2 = new Button();
            btnBai3 = new Button();
            btnBai4 = new Button();
            btnBai5 = new Button();
            btnBai6 = new Button();
            btnBai7 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnBai1
            // 
            btnBai1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBai1.Location = new Point(162, 124);
            btnBai1.Name = "btnBai1";
            btnBai1.Size = new Size(272, 55);
            btnBai1.TabIndex = 0;
            btnBai1.Text = "Bài 1 - Ghi và đọc File";
            btnBai1.UseVisualStyleBackColor = true;
            btnBai1.Click += btnBai1_Click;
            // 
            // btnBai2
            // 
            btnBai2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBai2.Location = new Point(491, 124);
            btnBai2.Name = "btnBai2";
            btnBai2.Size = new Size(293, 55);
            btnBai2.TabIndex = 0;
            btnBai2.Text = "Bài 2 - Đọc thông tin một file .txt";
            btnBai2.UseVisualStyleBackColor = true;
            btnBai2.Click += btnBai2_Click;
            // 
            // btnBai3
            // 
            btnBai3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBai3.Location = new Point(656, 237);
            btnBai3.Name = "btnBai3";
            btnBai3.Size = new Size(328, 55);
            btnBai3.TabIndex = 0;
            btnBai3.Text = "Bài 3 - Đọc Ghi File và Tính toán";
            btnBai3.UseVisualStyleBackColor = true;
            btnBai3.Click += btnBai3_Click;
            // 
            // btnBai4
            // 
            btnBai4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBai4.Location = new Point(656, 361);
            btnBai4.Name = "btnBai4";
            btnBai4.Size = new Size(328, 55);
            btnBai4.TabIndex = 0;
            btnBai4.Text = "Bài 4 Binary Formater";
            btnBai4.UseVisualStyleBackColor = true;
            btnBai4.Click += btnBai4_Click;
            // 
            // btnBai5
            // 
            btnBai5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBai5.Location = new Point(491, 450);
            btnBai5.Name = "btnBai5";
            btnBai5.Size = new Size(293, 55);
            btnBai5.TabIndex = 0;
            btnBai5.Text = "Bài 5 Quản Lý Phòng Vé";
            btnBai5.UseVisualStyleBackColor = true;
            btnBai5.Click += btnBai5_Click;
            // 
            // btnBai6
            // 
            btnBai6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBai6.Location = new Point(162, 450);
            btnBai6.Name = "btnBai6";
            btnBai6.Size = new Size(272, 55);
            btnBai6.TabIndex = 0;
            btnBai6.Text = "Bài 6 Hôm nay ăn gì";
            btnBai6.UseVisualStyleBackColor = true;
            btnBai6.Click += btnBai6_Click;
            // 
            // btnBai7
            // 
            btnBai7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBai7.Location = new Point(43, 283);
            btnBai7.Name = "btnBai7";
            btnBai7.Size = new Size(284, 55);
            btnBai7.TabIndex = 0;
            btnBai7.Text = "Bài 7 Duyệt thư mục";
            btnBai7.UseVisualStyleBackColor = true;
            btnBai7.Click += btnBai7_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(330, 45);
            label1.Name = "label1";
            label1.Size = new Size(280, 41);
            label1.TabIndex = 1;
            label1.Text = "LAB02 - 25520966 ";
            // 
            // DashBoard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 794);
            Controls.Add(label1);
            Controls.Add(btnBai7);
            Controls.Add(btnBai6);
            Controls.Add(btnBai5);
            Controls.Add(btnBai4);
            Controls.Add(btnBai3);
            Controls.Add(btnBai2);
            Controls.Add(btnBai1);
            Name = "DashBoard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBai1;
        private Button btnBai2;
        private Button btnBai3;
        private Button btnBai4;
        private Button btnBai5;
        private Button btnBai6;
        private Button btnBai7;
        private Label label1;
    }
}