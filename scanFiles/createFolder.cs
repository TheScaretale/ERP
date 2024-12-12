using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scanFiles
{
    internal class CreateFolder
    {
        public void CreateFolders(string[] files, string destinationPath, string noteType, string cnpj, DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString("D2");
            string noteTypeFolder = Path.Combine(destinationPath, noteType);
            string cnpjFolder = Path.Combine(noteTypeFolder, cnpj);
            string yearFolder = Path.Combine(cnpjFolder, year);
            string monthFolder = Path.Combine(yearFolder, $"{month}-{year.Substring(2, 2)}");

            Directory.CreateDirectory(monthFolder);

            foreach (string file in files)
            {
                string destFile = Path.Combine(monthFolder, Path.GetFileName(file));
                Directory.CreateDirectory(Path.GetDirectoryName(destFile)); // Ensure the directory exists
                File.Copy(file, destFile, true);
            }
        }
    }
}
