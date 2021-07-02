using PHBank_RH.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Extensions
{
    public static class ExtensionClass
    {

        public static void TestExtensionsMethods(this Funcionario funcionario)
        {
            Console.WriteLine($"Esse é um método de Extensão chamado de uma instância de {nameof(Funcionario)} que tem o " +
                $"nome {funcionario.Nome}");
        }
    }
}
