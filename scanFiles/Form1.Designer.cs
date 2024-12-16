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
            label1 = new Label();
            pastaOri = new TextBox();
            pastaDest = new TextBox();
            txtCNPJ = new ComboBox();
            barraProgress = new ProgressBar();
            SuspendLayout();
            // 
            // btnSearchFiles
            // 
            btnSearchFiles.Location = new Point(26, 53);
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
            btnCopyFile.Location = new Point(303, 151);
            btnCopyFile.Name = "btnCopyFile";
            btnCopyFile.Size = new Size(131, 63);
            btnCopyFile.TabIndex = 1;
            btnCopyFile.Text = "Copiar Arquivos";
            btnCopyFile.UseVisualStyleBackColor = true;
            btnCopyFile.Click += btnCopyFile_Click;
            // 
            // btnDestPath
            // 
            btnDestPath.Location = new Point(28, 88);
            btnDestPath.Name = "btnDestPath";
            btnDestPath.Size = new Size(115, 23);
            btnDestPath.TabIndex = 2;
            btnDestPath.Text = "Pasta Destino";
            btnDestPath.UseVisualStyleBackColor = true;
            btnDestPath.Click += btnDestPath_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 15);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 7;
            label1.Text = "Digite o CNPJ:";
            // 
            // pastaOri
            // 
            pastaOri.Location = new Point(164, 53);
            pastaOri.Name = "pastaOri";
            pastaOri.ReadOnly = true;
            pastaOri.Size = new Size(270, 23);
            pastaOri.TabIndex = 8;
            // 
            // pastaDest
            // 
            pastaDest.Location = new Point(164, 88);
            pastaDest.Name = "pastaDest";
            pastaDest.ReadOnly = true;
            pastaDest.Size = new Size(270, 23);
            pastaDest.TabIndex = 9;
            // 
            // txtCNPJ
            // 
            txtCNPJ.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCNPJ.FormattingEnabled = true;
            txtCNPJ.Location = new Point(164, 12);
            txtCNPJ.Name = "txtCNPJ";
            txtCNPJ.Size = new Size(121, 23);
            txtCNPJ.TabIndex = 10;
            // 
            // barraProgress
            // 
            barraProgress.Location = new Point(43, 170);
            barraProgress.Name = "barraProgress";
            barraProgress.Size = new Size(242, 23);
            barraProgress.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 226);
            Controls.Add(barraProgress);
            Controls.Add(txtCNPJ);
            Controls.Add(pastaDest);
            Controls.Add(pastaOri);
            Controls.Add(label1);
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
        private Label label1;
        private TextBox pastaOri;
        private TextBox pastaDest;
        private ComboBox txtCNPJ;
        private ProgressBar barraProgress;
    }
}
