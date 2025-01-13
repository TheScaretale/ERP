namespace scanFiles
{
    partial class ReadFile
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
            btnChooseXML = new Button();
            textBox1 = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            btnReadXML = new Button();
            SuspendLayout();
            // 
            // btnChooseXML
            // 
            btnChooseXML.Location = new Point(12, 57);
            btnChooseXML.Name = "btnChooseXML";
            btnChooseXML.Size = new Size(110, 23);
            btnChooseXML.TabIndex = 0;
            btnChooseXML.Text = "Selecione o XML";
            btnChooseXML.UseVisualStyleBackColor = true;
            btnChooseXML.Click += btnChooseXML_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(145, 57);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(137, 23);
            textBox1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnReadXML
            // 
            btnReadXML.Location = new Point(145, 101);
            btnReadXML.Name = "btnReadXML";
            btnReadXML.Size = new Size(75, 23);
            btnReadXML.TabIndex = 2;
            btnReadXML.Text = "Ler arquivo";
            btnReadXML.UseVisualStyleBackColor = true;
            // 
            // ReadFile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 243);
            Controls.Add(btnReadXML);
            Controls.Add(textBox1);
            Controls.Add(btnChooseXML);
            Name = "ReadFile";
            Text = "ReadFile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChooseXML;
        private TextBox textBox1;
        private OpenFileDialog openFileDialog1;
        private Button btnReadXML;
    }
}