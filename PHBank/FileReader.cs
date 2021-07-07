using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank
{
    public class FileReader
    {
        public string FilePath { get; set; }

        public FileMode AccessMode { get; set; }

        public readonly int BufferLenght = 1024;

        public FileReader(string fullFileName, FileMode accessMode)
        {
            FilePath = fullFileName;
            AccessMode = accessMode;
        }

        private FileStream FileOpen()
        {
            var stream = new FileStream(FilePath, AccessMode);
            Console.WriteLine($"Abrindo o arquivo: {FilePath}");
            return stream;
        }

        public void ShowAllFileWithBuffer()
        {
            try
            {
                using (var stream = FileOpen())
                {
                    var buffer = new byte[BufferLenght];
                    var contBytes = -1;

                    while(contBytes != 0)
                    {
                        contBytes = stream.Read(buffer, 0, BufferLenght);
                        DecodeAndShowBytes(buffer, contBytes);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void ShowAllFile()
        {
            try
            {
                using (var stream = FileOpen())
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void DecodeAndShowBytes(byte[] buffer, int contBytes)
        {
            //var bufferToPrint = new byte[buffer.Length - garbage];
            //Array.Copy(buffer, bufferToPrint, buffer.Length - garbage);
            var decoder = Encoding.UTF8;
            var text = decoder.GetString(buffer, 0, contBytes);
            //Console.WriteLine(buffer.pos);
            Console.Write(text);
            
        }

        public void ReadLine()
        {
            //Console.WriteLine("Lendo uma linha ...");
            //throw new IOException();
            //throw new ArgumentException();
        }
    }

    public class FileReaderDecapred : IDisposable
    {
        public string File { get; set; }

        public FileReaderDecapred(string fullFileName)
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
