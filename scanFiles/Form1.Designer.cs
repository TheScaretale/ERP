namespace scanFiles
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSearchFiles = new Button();
            btnCopyFile = new Button();
            btnDestPath = new Button();
            cmbFileType = new ComboBox();
            pastaOri = new Label();
            pastaDest = new Label();
            txtCNPJ = new TextBox();
            SuspendLayout();
            // 
            // btnSearchFiles
            // 
            btnSearchFiles.Location = new Point(180, 311);
            btnSearchFiles.Name = "btnSearchFiles";
            btnSearchFiles.Size = new Size(117, 23);
            btnSearchFiles.TabIndex = 0;
            btnSearchFiles.Text = "Pasta origem";
            btnSearchFiles.UseVisualStyleBackColor = true;
            btnSearchFiles.Click += btnSearchFiles_Click;
            // 
            // btnCopyFile
            // 
            btnCopyFile.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnCopyFile.Location = new Point(277, 121);
            btnCopyFile.Name = "btnCopyFile";
            btnCopyFile.Size = new Size(191, 81);
            btnCopyFile.TabIndex = 1;
            btnCopyFile.Text = "Copiar Arquivos";
            btnCopyFile.UseVisualStyleBackColor = true;
            btnCopyFile.Click += btnCopyFile_Click;
            // 
            // btnDestPath
            // 
            btnDestPath.Location = new Point(474, 311);
            btnDestPath.Name = "btnDestPath";
            btnDestPath.Size = new Size(115, 23);
            btnDestPath.TabIndex = 2;
            btnDestPath.Text = "Pasta Destino";
            btnDestPath.UseVisualStyleBackColor = true;
            btnDestPath.Click += btnDestPath_Click;
            // 
            // cmbFileType
            // 
            cmbFileType.FormattingEnabled = true;
            cmbFileType.Items.AddRange(new object[] { "PDF", "XML", "HTML", "DOCX" });
            cmbFileType.Location = new Point(305, 208);
            cmbFileType.Name = "cmbFileType";
            cmbFileType.Size = new Size(121, 23);
            cmbFileType.TabIndex = 3;
            // 
            // pastaOri
            // 
            pastaOri.AutoSize = true;
            pastaOri.Location = new Point(143, 337);
            pastaOri.Name = "pastaOri";
            pastaOri.Size = new Size(0, 15);
            pastaOri.TabIndex = 4;
            // 
            // pastaDest
            // 
            pastaDest.AutoSize = true;
            pastaDest.Location = new Point(433, 337);
            pastaDest.Name = "pastaDest";
            pastaDest.Size = new Size(0, 15);
            pastaDest.TabIndex = 5;
            // 
            // txtCNPJ
            // 
            txtCNPJ.Location = new Point(313, 243);
            txtCNPJ.Name = "txtCNPJ";
            txtCNPJ.Size = new Size(100, 23);
            txtCNPJ.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtCNPJ);
            Controls.Add(pastaDest);
            Controls.Add(pastaOri);
            Controls.Add(cmbFileType);
            Controls.Add(btnDestPath);
            Controls.Add(btnCopyFile);
            Controls.Add(btnSearchFiles);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSearchFiles;
        private Button btnCopyFile;
        private Button btnDestPath;
        private ComboBox cmbFileType;
        private Label pastaOri;
        private Label pastaDest;
        public TextBox txtCNPJ;
    }
}
