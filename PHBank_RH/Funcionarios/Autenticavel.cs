using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Funcionarios
{
    public abstract class Autenticavel : Funcionario
    {
        public string Senha { get; set; }
        public Autenticavel(string nome, string cpf, string senha, double salario) : base(nome, cpf, salario) 
        {
            Senha = senha;
        }
        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
    }
}
