using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Funcionarios
{
    public class Desenvolvedor : Funcionario
    {
        private readonly double PERC_BONIFICACAO_DESENVOLVEDOR = 0.1;
        private readonly double PERC_AUMENTAR_SALARIO_DESENVOLVEDOR = 1.15;

        public Desenvolvedor(string nome, string cpf, double salario = 3000) : base(nome, cpf, salario)
        { }

        public override void AumentarSalario()
        {
            Salario *= PERC_AUMENTAR_SALARIO_DESENVOLVEDOR;
        }

        public override double GetBonificacao()
        {
            return Salario * PERC_BONIFICACAO_DESENVOLVEDOR;
        }
    }
}
