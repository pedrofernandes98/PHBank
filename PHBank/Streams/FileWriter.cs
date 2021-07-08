using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank.Streams
{
    public class FileWriter : FileManipulation
    {
        public FileWriter(string fullFileName, FileMode accessMode) : base(fullFileName, accessMode) { }

        public void WriteWithBuffer(string text)
        {
            using (var stream = FileOpen())
            {
                var buffer = new byte[BufferLenght];
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(text);
                stream.Write(buffer, 0, bytes.Length);
            }
        }

        public void WriteFile(string text)
        {
            using (var stream = base.FileOpen())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(text);
            }
        }
    }

}