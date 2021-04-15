using System;

namespace PHBank_RH.Funcionarios
{
    public abstract class Funcionario
    {
        private readonly double PERC_BONIFICAO_BASE = 0.1;
        private readonly double PERC_AUMENTAR_SALARIO_BASE = 1.1;

        public static int QuantidadeFuncionario { get; private set; } 
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }

        public Funcionario(string nome, string cpf, double salario)
        {
            Console.WriteLine("Criando um novo Funcionário");
            Nome = nome;
            CPF = cpf;
            Salario = salario;

            QuantidadeFuncionario++;

            //COLOCAR ESSES ATRIBUTOS READONLY NO CONSTRUTOR DA CLASSE?
        }

        public virtual double GetBonificacao()
        {
            return Salario * PERC_BONIFICAO_BASE;
        }

        public virtual void AumentarSalario()
        {
            Salario *= PERC_AUMENTAR_SALARIO_BASE;
        }

        
    }
}
