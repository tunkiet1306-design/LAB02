namespace LAB02
{
    partial class Bai2_DocThongTin1File
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtFileName = new TextBox();
            txtSize = new TextBox();
            txtURL = new TextBox();
            txtWordsCount = new TextBox();
            txtCharacterCount = new TextBox();
            txtLineCount = new TextBox();
            btnRead = new Button();
            btnExit = new Button();
            rtbContent = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 87);
            label1.Name = "label1";
            label1.Size = new Size(96, 25);
            label1.TabIndex = 0;
            label1.Text = "File Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 135);
            label2.Name = "label2";
            label2.Size = new Size(46, 25);
            label2.TabIndex = 1;
            label2.Text = "Size";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 184);
            label3.Name = "label3";
            label3.Size = new Size(46, 25);
            label3.TabIndex = 1;
            label3.Text = "URL";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(12, 232);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 1;
            label4.Text = "Line Count";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 286);
            label5.Name = "label5";
            label5.Size = new Size(123, 25);
            label5.TabIndex = 1;
            label5.Text = "Words Count";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(12, 340);
            label6.Name = "label6";
            label6.Size = new Size(150, 25);
            label6.TabIndex = 1;
            label6.Text = "Character Count";
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(162, 84);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(224, 31);
            txtFileName.TabIndex = 2;
            // 
            // txtSize
            // 
            txtSize.Location = new Point(162, 132);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(224, 31);
            txtSize.TabIndex = 2;
            // 
            // txtURL
            // 
            txtURL.Location = new Point(162, 181);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(224, 31);
            txtURL.TabIndex = 2;
            // 
            // txtWordsCount
            // 
            txtWordsCount.Location = new Point(162, 283);
            txtWordsCount.Name = "txtWordsCount";
            txtWordsCount.Size = new Size(224, 31);
            txtWordsCount.TabIndex = 2;
            // 
            // txtCharacterCount
            // 
            txtCharacterCount.Location = new Point(162, 337);
            txtCharacterCount.Name = "txtCharacterCount";
            txtCharacterCount.Size = new Size(224, 31);
            txtCharacterCount.TabIndex = 2;
            // 
            // txtLineCount
            // 
            txtLineCount.Location = new Point(162, 229);
            txtLineCount.Name = "txtLineCount";
            txtLineCount.Size = new Size(224, 31);
            txtLineCount.TabIndex = 2;
            // 
            // btnRead
            // 
            btnRead.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRead.Location = new Point(12, 12);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(374, 48);
            btnRead.TabIndex = 3;
            btnRead.Text = "Read From File";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExit.Location = new Point(12, 383);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(377, 46);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(395, 12);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(393, 417);
            rtbContent.TabIndex = 5;
            rtbContent.Text = "";
            // 
            // Bai2_DocThongTin1File
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbContent);
            Controls.Add(btnExit);
            Controls.Add(btnRead);
            Controls.Add(txtLineCount);
            Controls.Add(txtCharacterCount);
            Controls.Add(txtWordsCount);
            Controls.Add(txtURL);
            Controls.Add(txtSize);
            Controls.Add(txtFileName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Bai2_DocThongTin1File";
            Text = "Bai2_DocThongTin1File";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtFileName;
        private TextBox txtSize;
        private TextBox txtURL;
        private TextBox txtWordsCount;
        private TextBox txtCharacterCount;
        private TextBox txtLineCount;
        private Button btnRead;
        private Button btnExit;
        private RichTextBox rtbContent;
    }
}