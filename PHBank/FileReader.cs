using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank
{
    public class FileReader : IDisposable
    {
        public string File { get; set; }

        public FileReader(string fullFileName)
        {
            File = fullFileName;
            //throw new FileNotFoundException();
            FileOpen(File);
        }

        private void FileOpen(string file)
        {
            Console.WriteLine($"Abrindo o arquivo: {file}");
        }

        public void ReadLine()
        {
            Console.WriteLine("Lendo uma linha ...");
            //throw new IOException();
            //throw new ArgumentException();
        }

        public void Dispose()
        {
            Console.WriteLine("Fechando o arquivo ...");
        }
    }
}
