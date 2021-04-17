using PHBank_RH.Funcionarios;
using PHBank_RH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Sistemas
{
    public class SistemaInterno
    {
        public bool Logar(IAutenticavel autenticavel, string senha)
        {
            if(autenticavel.Autenticar(senha))
            {
                Console.WriteLine($"Login feito com sucesso! \nBem-vindo ao Sitema Interno - {autenticavel.GetNome()}!");

                if (autenticavel.isExterno())
                {
                    Console.WriteLine("Olá parceiro, veja suas vantagens comerciais!");
                }
                else
                {
                    Console.WriteLine("Olá colaborador!");
                }

                return true;
            }

            Console.WriteLine("Senha inválida!");
            return false;
        }
    }
}
