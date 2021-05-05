using Humanizer;
using System;

namespace ConsoleAppOutOfScope
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dataAniversario = new DateTime(2022, 04, 30);
            DateTime dataAtual = DateTime.Now;

            TimeSpan diferenca = dataAniversario - dataAtual;

            Console.WriteLine("Tempo para o meu proximo aniversário: " + TimeSpanHumanizeExtensions.Humanize(diferenca, 6));

            Console.ReadLine();
        }
    }
}
