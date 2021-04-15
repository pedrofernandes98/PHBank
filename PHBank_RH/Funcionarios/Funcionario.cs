using System;

namespace PHBank_RH.Funcionarios
{
    public abstract class Funcionario
    {
        public static int QuantidadeFuncionario { get; private set; } 
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }

        public Funcionario(string nome, string cpf, double salario)
        {
            //Console.WriteLine("Criando um novo Funcionário");
            Nome = nome;
            CPF = cpf;
            Salario = salario;

            QuantidadeFuncionario++;

            //COLOCAR ESSES ATRIBUTOS READONLY NO CONSTRUTOR DA CLASSE?
        }

        public abstract double GetBonificacao();

        public abstract void AumentarSalario();

        
    }
}
