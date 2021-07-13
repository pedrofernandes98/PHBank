using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank.Streams
{
    public class FileManipulation
    {
        public string FilePath { get; set; }
        public FileMode AccessMode { get; set; }

        public readonly int BufferLenght = 1024;

        public FileManipulation(string fullFileName, FileMode accessMode)
        {
            FilePath = fullFileName;
            AccessMode = accessMode;
        }

        protected FileStream FileOpen()
        {
            var stream = new FileStream(FilePath, AccessMode);
            Console.WriteLine($"Abrindo o arquivo: {FilePath}");
            return stream;
        }

        public void GenereteCSV(string path)
        {
            try
            {
                using (var stream = FileOpen())
                using (var stream2 = new FileStream(path, FileMode.OpenOrCreate))
                using (var reader = new StreamReader(stream))
                using(var writer = new StreamWriter(stream2))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine().Split(' ');
                        var formatLine = $"{line[0]},{line[1]},{line[2]},{line[3]}";
                        writer.WriteLine(formatLine);
                        //writer.Flush() -> Despejar o buffer para o stream
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
