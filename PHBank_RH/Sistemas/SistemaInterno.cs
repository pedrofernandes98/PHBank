using PHBank_RH.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Sistemas
{
    public class SistemaInterno
    {
        public bool Logar(Autenticavel autenticavel, string senha)
        {
            if(autenticavel.Autenticar(senha))
            {
                Console.WriteLine($"Login feito com sucesso! \nBem-vindo ao Sitema Interno - {autenticavel.Nome}!");
                return true;
            }

            Console.WriteLine("Senha inválida!");
            return false;
        }
    }
}
