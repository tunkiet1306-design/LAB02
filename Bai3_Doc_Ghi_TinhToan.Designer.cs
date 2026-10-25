namespace LAB02
{
    partial class Bai3_Doc_Ghi_TinhToan
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
            rtbOutput = new RichTextBox();
            rtbInput = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            btnThucThi = new Button();
            btnRead = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(416, 79);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.ReadOnly = true;
            rtbOutput.Size = new Size(372, 282);
            rtbOutput.TabIndex = 0;
            rtbOutput.Text = "";
            // 
            // rtbInput
            // 
            rtbInput.Location = new Point(24, 80);
            rtbInput.Name = "rtbInput";
            rtbInput.ReadOnly = true;
            rtbInput.Size = new Size(361, 281);
            rtbInput.TabIndex = 0;
            rtbInput.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 52);
            label1.Name = "label1";
            label1.Size = new Size(61, 25);
            label1.TabIndex = 1;
            label1.Text = "INPUT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(416, 52);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 1;
            label2.Text = "OUTPUT";
            // 
            // btnThucThi
            // 
            btnThucThi.Location = new Point(416, 386);
            btnThucThi.Name = "btnThucThi";
            btnThucThi.Size = new Size(372, 52);
            btnThucThi.TabIndex = 2;
            btnThucThi.Text = "THỰC THI TÍNH TOÁN";
            btnThucThi.UseVisualStyleBackColor = true;
            btnThucThi.Click += btnThucThi_Click;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(24, 386);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(361, 52);
            btnRead.TabIndex = 3;
            btnRead.Text = "READ FROM FILE";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(211, 9);
            label3.Name = "label3";
            label3.Size = new Size(378, 25);
            label3.TabIndex = 1;
            label3.Text = "BÀI 3: TÍNH TOÁN BIỂU THỨC TRONG FILE";
            // 
            // Bai3_Doc_Ghi_TinhToan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRead);
            Controls.Add(btnThucThi);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(rtbInput);
            Controls.Add(rtbOutput);
            Name = "Bai3_Doc_Ghi_TinhToan";
            Text = "Bai3_Doc_Ghi_TinhToan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbOutput;
        private RichTextBox rtbInput;
        private Label label1;
        private Label label2;
        private Button btnThucThi;
        private Button btnRead;
        private Label label3;
    }
}