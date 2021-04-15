using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Funcionarios
{
    public class Designer : Funcionario
    {
        private readonly double PERC_BONIFICAO_DESIGNER = 0.17;
        private readonly double PERC_AUMENTO_DESIGNER = 1.11;
        public Designer(string nome, string cpf, double salario = 3000) : base(nome, cpf, salario)
        { }

        public override double GetBonificacao()
        {
            return Salario * PERC_BONIFICAO_DESIGNER;
        }

        public override void AumentarSalario()
        {
            Salario *= PERC_AUMENTO_DESIGNER;
        }
    }
}
