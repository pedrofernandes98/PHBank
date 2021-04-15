using System;

namespace PHBank_RH.Funcionarios
{
    public class Diretor : Funcionario
    {
        private readonly double PERC_BONIFICACAO_DIRETOR = 0.5;
        private readonly double PERC_AUMENTAR_SALARIO_DIRETOR = 1.15;

        public Diretor(string nome, string cpf, double salario = 5000) : base(nome, cpf, salario) 
        { }

        public override double GetBonificacao()
        {
            return Salario * PERC_BONIFICACAO_DIRETOR;
        }

        public override void AumentarSalario()
        {
            Salario *= PERC_AUMENTAR_SALARIO_DIRETOR;
        }
    }
}
