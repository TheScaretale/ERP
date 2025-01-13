using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Cms;

namespace scanFiles
{
    public partial class ReadFile : Form
    {
        public ReadFile()
        {
            InitializeComponent();
        }

        private void btnChooseXML_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    ProcessFile(selectedFilePath);
                }
            }
        }

        private void ProcessFile(string filePath)
        {
            GerarSQL gerarSQL = new GerarSQL();
            gerarSQL.GetFileData(filePath);
        }
    }

}
