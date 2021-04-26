using PHBank_RH.Helpers;
using PHBank_RH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Externos
{
    public class ParceiroComercial : IAutenticavel
    {
        public string Nome { get; set; }
        public string Senha { get; set; }

        public ParceiroComercial(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }
        public bool Autenticar(string senha)
        {
            return AutenticarHelper.CompararSenhas(Senha, senha);
        }

        public string GetNome()
        {
            return Nome;
        }

        public bool isExterno()
        {
            return true;
        }
    }
}
