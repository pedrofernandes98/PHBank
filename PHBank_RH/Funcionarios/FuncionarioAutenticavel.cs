using PHBank_RH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
        public string Senha { get; set; }
        public FuncionarioAutenticavel(string nome, string cpf, string senha, double salario) : base(nome, cpf, salario)
        {
            Senha = senha;
        }
        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
        public string GetNome()
        {
            return Nome;
        }
        public bool isExterno()
        {
            return false;
        }
    }
}
