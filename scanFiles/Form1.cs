using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
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
            CarregaValoresCNPJ();
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
                SalvarCNPJ(cnpj);
                if (Directory.Exists(sourcePath) && !string.IsNullOrWhiteSpace(destinationPath))
                {
                    int arquivosValidos = searchFiles.ArquivosValidos(sourcePath);
                    barraProgress.Minimum = 0;
                    barraProgress.Maximum = arquivosValidos;
                    barraProgress.Value = 0;

                    searchFiles.SearchFilesInFolder(sourcePath, destinationPath, cnpj, UpdateProgressBar);
                    if(barraProgress.Value == barraProgress.Maximum) 
                    { 
                        MessageBox.Show("Arquivos copiados com sucesso!");
                    }
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

        private void SalvarCNPJ(string cnpj)
        {
            var ValoresCnpj = Properties.Settings.Default.ValoresCnpj ?? new StringCollection();
            if (!ValoresCnpj.Contains(cnpj))
            {
                ValoresCnpj.Add(cnpj);
                Properties.Settings.Default.ValoresCnpj = ValoresCnpj;
                Properties.Settings.Default.Save();
                txtCNPJ.Items.Add(cnpj);
            }
        }

        private void CarregaValoresCNPJ()
        {
            var ValoresCnpj = Properties.Settings.Default.ValoresCnpj;
            if (ValoresCnpj != null)
            {
                txtCNPJ.Items.AddRange(ValoresCnpj.Cast<string>().ToArray());
            }

        }

        public void UpdateProgressBar(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateProgressBar), value);
            }
            else
            {
                barraProgress.Value = value;
            }
        }
    }
}
