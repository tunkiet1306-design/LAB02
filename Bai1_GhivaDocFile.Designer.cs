namespace LAB02
{
    partial class Bai1_GhivaDocFile
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
            btnDocFile = new Button();
            btnGhiFile = new Button();
            rtbDocFile = new RichTextBox();
            SuspendLayout();
            // 
            // btnDocFile
            // 
            btnDocFile.Location = new Point(67, 48);
            btnDocFile.Name = "btnDocFile";
            btnDocFile.Size = new Size(172, 77);
            btnDocFile.TabIndex = 0;
            btnDocFile.Text = "Đọc File";
            btnDocFile.UseVisualStyleBackColor = true;
            btnDocFile.Click += btnDocFile_Click;
            // 
            // btnGhiFile
            // 
            btnGhiFile.Location = new Point(67, 301);
            btnGhiFile.Name = "btnGhiFile";
            btnGhiFile.Size = new Size(172, 74);
            btnGhiFile.TabIndex = 0;
            btnGhiFile.Text = "Ghi File";
            btnGhiFile.UseVisualStyleBackColor = true;
            btnGhiFile.Click += btnGhiFile_Click;
            // 
            // rtbDocFile
            // 
            rtbDocFile.Location = new Point(336, 48);
            rtbDocFile.Name = "rtbDocFile";
            rtbDocFile.Size = new Size(473, 338);
            rtbDocFile.TabIndex = 1;
            rtbDocFile.Text = "";
            // 
            // Bai1_GhivaDocFile
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 450);
            Controls.Add(rtbDocFile);
            Controls.Add(btnGhiFile);
            Controls.Add(btnDocFile);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "Bai1_GhivaDocFile";
            Text = "Bai1_GhivaDocFile";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDocFile;
        private Button btnGhiFile;
        private RichTextBox rtbDocFile;
    }
}