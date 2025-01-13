namespace scanFiles
{
    partial class Menu
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
            btnCopyFilesScreen = new Button();
            btnReadXML = new Button();
            SuspendLayout();
            // 
            // btnCopyFilesScreen
            // 
            btnCopyFilesScreen.Location = new Point(60, 81);
            btnCopyFilesScreen.Name = "btnCopyFilesScreen";
            btnCopyFilesScreen.Size = new Size(214, 23);
            btnCopyFilesScreen.TabIndex = 0;
            btnCopyFilesScreen.Text = "Copiar arquivos";
            btnCopyFilesScreen.UseVisualStyleBackColor = true;
            btnCopyFilesScreen.Click += btnCopyFilesScreen_Click;
            // 
            // btnReadXML
            // 
            btnReadXML.Location = new Point(60, 133);
            btnReadXML.Name = "btnReadXML";
            btnReadXML.Size = new Size(214, 23);
            btnReadXML.TabIndex = 1;
            btnReadXML.Text = "Ler XML";
            btnReadXML.UseVisualStyleBackColor = true;
            btnReadXML.Click += btnReadXML_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 244);
            Controls.Add(btnReadXML);
            Controls.Add(btnCopyFilesScreen);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCopyFilesScreen;
        private Button btnReadXML;
    }
}