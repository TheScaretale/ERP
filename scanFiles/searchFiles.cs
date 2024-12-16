using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace scanFiles
{
    internal class SearchFiles
    {
        private string[] files;
        private string destinationPath;

        public int ArquivosValidos(string sourcePath)
        {
            string padraoBusca = $"*.XML";
            files = Directory.GetFiles(sourcePath, padraoBusca, SearchOption.AllDirectories);
            XNamespace ns = "http://www.portalfiscal.inf.br/nfe";

            int countArquivosValidos = 0;
            foreach (string file in files) {
                XDocument doc = XDocument.Load(file);
                if (doc.Descendants(ns + "infNFe").Any())
                {
                    countArquivosValidos++;
                }
            }
            return countArquivosValidos;
        }

        public void SearchFilesInFolder(string sourcePath, string destinationPath, string cnpj, Action <int> updateProgressBar)
        {
            if (sourcePath == null) throw new ArgumentNullException(nameof(sourcePath));
            if (destinationPath == null) throw new ArgumentNullException(nameof(destinationPath));
            if (cnpj == null) throw new ArgumentNullException(nameof(cnpj));

            this.destinationPath = destinationPath; // Set the destination path

            string searchPattern = $"*.XML";
            files = Directory.GetFiles(sourcePath, searchPattern, SearchOption.AllDirectories);

            bool notaPropriaCreated = false;
            bool notaTerceirosCreated = false;
            int progress = 0;

            foreach (string file in files)
            {
                XDocument doc = XDocument.Load(file);
                XNamespace ns = "http://www.portalfiscal.inf.br/nfe"; // Define the namespace

                // Check if the file is a valid nFE document
                if (doc.Descendants(ns + "infNFe").Any())
                {
                    string? emitCnpj = doc.Descendants(ns + "emit").FirstOrDefault()?.Element(ns + "CNPJ")?.Value;
                    DateTime dhEmi = DateTime.Parse(doc.Descendants(ns + "ide").FirstOrDefault()?.Element(ns + "dhEmi")?.Value);

                    string noteType;
                    if (emitCnpj == cnpj)
                    {
                        noteType = "NF Propria";
                        if (!notaPropriaCreated)
                        {
                            Directory.CreateDirectory(Path.Combine(this.destinationPath, noteType));
                            notaPropriaCreated = true;
                        }
                    }
                    else
                    {
                        noteType = "NF Terceiros";
                        if (!notaTerceirosCreated)
                        {
                            Directory.CreateDirectory(Path.Combine(this.destinationPath, noteType));
                            notaTerceirosCreated = true;
                        }
                    }

                    string relativePath = Path.GetRelativePath(sourcePath, file);
                    string destFile = Path.Combine(this.destinationPath, relativePath);
                    Directory.CreateDirectory(Path.GetDirectoryName(destFile)); // Ensure the directory exists

                    // Create folders based on file names, note type, and CNPJ
                    CreateFolder createFolder = new CreateFolder();
                    createFolder.CreateFolders(new string[] { file }, this.destinationPath, noteType, emitCnpj, dhEmi);

                    progress++;
                    updateProgressBar(progress);
                }
                else
                {
                    Debug.WriteLine($"Skipping non-nFE file: {file}");
                }
            }
        }

        public string[] GetFiles()
        {
            return files;
        }

        public void CopyFiles()
        {
            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (fileName.Length >= 6)
                {
                    string year = "20" + fileName.Substring(2, 2);
                    string month = fileName.Substring(4, 2);
                    string yearFolder = Path.Combine(destinationPath, year);
                    string monthFolder = Path.Combine(yearFolder, $"{month}-{year.Substring(2, 2)}");

                    string destFile = Path.Combine(monthFolder, Path.GetFileName(file));
                    Directory.CreateDirectory(Path.GetDirectoryName(destFile)); // Ensure the directory exists
                    File.Copy(file, destFile, true);
                }
            }
        }
    }
}
