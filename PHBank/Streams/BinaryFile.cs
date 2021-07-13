using PHBank_GerenciamentoContas;
using System.IO;
using System;


namespace PHBank.Streams
{
    public static class BinaryFile
    {
        public static void WriteBinaryFile(ContaCorrente conta, string path = "BinaryFile.txt")
        {
            if (conta != null)
            {
                using (var fs = new FileStream(path, FileMode.Create))
                using (var writer = new BinaryWriter(fs))
                {
                    writer.Write(conta.Agencia);
                    writer.Write(conta.NumeroConta);
                    writer.Write(conta.Titular.Nome);
                    writer.Write(conta.Saldo);
                }
            }
        }

        public static void ReadBinaryFile(string path = "BinaryFile.txt")
        {
            using(var fs = new FileStream(path, FileMode.Open))
            using(var reader = new BinaryReader(fs))
            {
                Console.WriteLine($"Ag: {reader.ReadInt32()} | Conta: {reader.ReadInt32()}\n" +
                    $"Titular: {reader.ReadString()} - Saldo R${reader.ReadDouble()}");
            }
        }
    }
}

