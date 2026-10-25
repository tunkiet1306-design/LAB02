namespace LAB02
{
    partial class Bai4_BinaryFormatter
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
            btnWrite = new Button();
            txtAddName = new TextBox();
            rtbHienThi = new RichTextBox();
            btnRead = new Button();
            txtAddID = new TextBox();
            txtAddPhone = new TextBox();
            txtAddCourse2 = new TextBox();
            txtAddCourse3 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtAddAverage = new TextBox();
            label7 = new Label();
            txtAddCourse1 = new TextBox();
            txtReadName = new TextBox();
            txtReadID = new TextBox();
            txtReadPhone = new TextBox();
            txtReadCourse1 = new TextBox();
            txtReadCourse2 = new TextBox();
            txtReadCourse3 = new TextBox();
            txtReadAverage = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label1 = new Label();
            label14 = new Label();
            btnAdd = new Button();
            btnBack = new Button();
            btnNext = new Button();
            lblPage = new Label();
            SuspendLayout();
            // 
            // btnWrite
            // 
            btnWrite.Location = new Point(0, 14);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(288, 48);
            btnWrite.TabIndex = 0;
            btnWrite.Text = "Write to a File";
            btnWrite.UseVisualStyleBackColor = true;
            btnWrite.Click += btnWrite_Click;
            // 
            // txtAddName
            // 
            txtAddName.Location = new Point(12, 79);
            txtAddName.Name = "txtAddName";
            txtAddName.Size = new Size(165, 31);
            txtAddName.TabIndex = 2;
            // 
            // rtbHienThi
            // 
            rtbHienThi.Location = new Point(329, 14);
            rtbHienThi.Name = "rtbHienThi";
            rtbHienThi.Size = new Size(500, 522);
            rtbHienThi.TabIndex = 4;
            rtbHienThi.Text = "";
            rtbHienThi.TextChanged += rtbHienThi_TextChanged;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(859, 12);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(315, 52);
            btnRead.TabIndex = 0;
            btnRead.Text = "Read a File";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // txtAddID
            // 
            txtAddID.Location = new Point(12, 134);
            txtAddID.Name = "txtAddID";
            txtAddID.Size = new Size(165, 31);
            txtAddID.TabIndex = 2;
            // 
            // txtAddPhone
            // 
            txtAddPhone.Location = new Point(12, 191);
            txtAddPhone.Name = "txtAddPhone";
            txtAddPhone.Size = new Size(165, 31);
            txtAddPhone.TabIndex = 2;
            // 
            // txtAddCourse2
            // 
            txtAddCourse2.Location = new Point(12, 303);
            txtAddCourse2.Name = "txtAddCourse2";
            txtAddCourse2.Size = new Size(165, 31);
            txtAddCourse2.TabIndex = 2;
            // 
            // txtAddCourse3
            // 
            txtAddCourse3.Location = new Point(12, 361);
            txtAddCourse3.Name = "txtAddCourse3";
            txtAddCourse3.Size = new Size(165, 31);
            txtAddCourse3.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(206, 85);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 3;
            label2.Text = "Name";
            label2.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(206, 140);
            label3.Name = "label3";
            label3.Size = new Size(31, 25);
            label3.TabIndex = 3;
            label3.Text = "ID";
            label3.Click += label1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(206, 257);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 3;
            label4.Text = "Course 1";
            label4.Click += label1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(203, 197);
            label5.Name = "label5";
            label5.Size = new Size(66, 25);
            label5.TabIndex = 3;
            label5.Text = "Phone";
            label5.Click += label1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(206, 309);
            label6.Name = "label6";
            label6.Size = new Size(85, 25);
            label6.TabIndex = 3;
            label6.Text = "Course 2";
            label6.Click += label1_Click;
            // 
            // txtAddAverage
            // 
            txtAddAverage.Location = new Point(12, 421);
            txtAddAverage.Name = "txtAddAverage";
            txtAddAverage.Size = new Size(165, 31);
            txtAddAverage.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(206, 367);
            label7.Name = "label7";
            label7.Size = new Size(85, 25);
            label7.TabIndex = 3;
            label7.Text = "Course 3";
            label7.Click += label1_Click;
            // 
            // txtAddCourse1
            // 
            txtAddCourse1.Location = new Point(12, 251);
            txtAddCourse1.Name = "txtAddCourse1";
            txtAddCourse1.Size = new Size(165, 31);
            txtAddCourse1.TabIndex = 2;
            // 
            // txtReadName
            // 
            txtReadName.Location = new Point(835, 84);
            txtReadName.Name = "txtReadName";
            txtReadName.Size = new Size(165, 31);
            txtReadName.TabIndex = 2;
            txtReadName.TextChanged += txtReadName_TextChanged;
            // 
            // txtReadID
            // 
            txtReadID.Location = new Point(835, 136);
            txtReadID.Name = "txtReadID";
            txtReadID.Size = new Size(165, 31);
            txtReadID.TabIndex = 2;
            // 
            // txtReadPhone
            // 
            txtReadPhone.Location = new Point(835, 196);
            txtReadPhone.Name = "txtReadPhone";
            txtReadPhone.Size = new Size(165, 31);
            txtReadPhone.TabIndex = 2;
            txtReadPhone.TextChanged += textBox10_TextChanged;
            // 
            // txtReadCourse1
            // 
            txtReadCourse1.Location = new Point(835, 253);
            txtReadCourse1.Name = "txtReadCourse1";
            txtReadCourse1.Size = new Size(165, 31);
            txtReadCourse1.TabIndex = 2;
            // 
            // txtReadCourse2
            // 
            txtReadCourse2.Location = new Point(835, 308);
            txtReadCourse2.Name = "txtReadCourse2";
            txtReadCourse2.Size = new Size(165, 31);
            txtReadCourse2.TabIndex = 2;
            // 
            // txtReadCourse3
            // 
            txtReadCourse3.Location = new Point(835, 366);
            txtReadCourse3.Name = "txtReadCourse3";
            txtReadCourse3.Size = new Size(165, 31);
            txtReadCourse3.TabIndex = 2;
            // 
            // txtReadAverage
            // 
            txtReadAverage.Location = new Point(835, 429);
            txtReadAverage.Name = "txtReadAverage";
            txtReadAverage.Size = new Size(165, 31);
            txtReadAverage.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(1057, 90);
            label8.Name = "label8";
            label8.Size = new Size(62, 25);
            label8.TabIndex = 3;
            label8.Text = "Name";
            label8.Click += label1_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(1059, 202);
            label9.Name = "label9";
            label9.Size = new Size(66, 25);
            label9.TabIndex = 3;
            label9.Text = "Phone";
            label9.Click += label1_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(1059, 314);
            label10.Name = "label10";
            label10.Size = new Size(85, 25);
            label10.TabIndex = 3;
            label10.Text = "Course 2";
            label10.Click += label1_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(1057, 372);
            label11.Name = "label11";
            label11.Size = new Size(85, 25);
            label11.TabIndex = 3;
            label11.Text = "Course 3";
            label11.Click += label1_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(1059, 432);
            label12.Name = "label12";
            label12.Size = new Size(83, 25);
            label12.TabIndex = 3;
            label12.Text = "Average";
            label12.Click += label1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.Location = new Point(1059, 259);
            label13.Name = "label13";
            label13.Size = new Size(85, 25);
            label13.TabIndex = 3;
            label13.Text = "Course 1";
            label13.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(1059, 142);
            label1.Name = "label1";
            label1.Size = new Size(31, 25);
            label1.TabIndex = 3;
            label1.Text = "ID";
            label1.Click += label1_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label14.Location = new Point(203, 427);
            label14.Name = "label14";
            label14.Size = new Size(83, 25);
            label14.TabIndex = 3;
            label14.Text = "Average";
            label14.Click += label1_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(114, 509);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(123, 34);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(859, 518);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(1090, 518);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(112, 34);
            btnNext.TabIndex = 7;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(1018, 523);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(22, 25);
            lblPage.TabIndex = 8;
            lblPage.Text = "1";
            lblPage.Click += lblPage_Click;
            // 
            // Bai4_BinaryFormatter
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 574);
            Controls.Add(lblPage);
            Controls.Add(btnNext);
            Controls.Add(btnBack);
            Controls.Add(rtbHienThi);
            Controls.Add(label13);
            Controls.Add(label5);
            Controls.Add(label12);
            Controls.Add(label14);
            Controls.Add(label7);
            Controls.Add(label11);
            Controls.Add(label6);
            Controls.Add(label10);
            Controls.Add(label4);
            Controls.Add(label9);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(txtReadAverage);
            Controls.Add(txtAddAverage);
            Controls.Add(txtReadCourse3);
            Controls.Add(txtAddCourse3);
            Controls.Add(txtReadCourse2);
            Controls.Add(txtAddCourse2);
            Controls.Add(txtReadCourse1);
            Controls.Add(txtAddCourse1);
            Controls.Add(txtReadPhone);
            Controls.Add(txtReadID);
            Controls.Add(txtAddPhone);
            Controls.Add(txtReadName);
            Controls.Add(txtAddID);
            Controls.Add(txtAddName);
            Controls.Add(btnAdd);
            Controls.Add(btnRead);
            Controls.Add(btnWrite);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "Bai4_BinaryFormatter";
            Text = "Bai4_BinaryFormatter";
            Load += Bai4_BinaryFormatter_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnWrite;
        private TextBox txtAddName;
        private RichTextBox rtbHienThi;
        private Button btnRead;
        private TextBox txtAddID;
        private TextBox txtAddPhone;
        private TextBox txtAddCourse2;
        private TextBox txtAddCourse3;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtAddAverage;
        private Label label7;
        private TextBox txtAddCourse1;
        private TextBox txtReadName;
        private TextBox txtReadID;
        private TextBox txtReadPhone;
        private TextBox txtReadCourse1;
        private TextBox txtReadCourse2;
        private TextBox txtReadCourse3;
        private TextBox txtReadAverage;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label1;
        private Label label14;
        private Button btnAdd;
        private Button btnBack;
        private Button btnNext;
        private Label lblPage;
    }
}