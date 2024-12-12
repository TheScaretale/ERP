using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace scanFiles
{
    public partial class Form1 : Form
    {

        public string sourcePath;
        public string destinationPath;
        public string cnpj;

        

        public Form1()
        {
            InitializeComponent();
        }

        SearchFiles searchFiles = new();

        public void btnSearchFiles_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    sourcePath = folderDialog.SelectedPath;
                    MessageBox.Show("Pasta mãe escolhida: " + sourcePath);
                    pastaOri.Text = sourcePath;
                }
            }
        }

        private void btnCopyFile_Click(object sender, EventArgs e)
        {
            cnpj = txtCNPJ.Text;
            if (cnpj != "")
            {
                if (Directory.Exists(sourcePath) && !string.IsNullOrWhiteSpace(destinationPath))
                {
                    searchFiles.SearchFilesInFolder(sourcePath, destinationPath, cnpj);
                    //searchFiles.CopyFiles();
                    MessageBox.Show("Arquivos copiados com sucesso!");
                }
                else
                {
                    MessageBox.Show("Por favor escolha os caminhos.");
                }
            }
            else
            {
                MessageBox.Show("Insira o CNPJ");
            }
        }

        public void btnDestPath_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    destinationPath = folderDialog.SelectedPath;
                    MessageBox.Show("Pasta destino escolhida: " + destinationPath);
                    pastaDest.Text = destinationPath;
                }
            }
        }

        
    }
}
