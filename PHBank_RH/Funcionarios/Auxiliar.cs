using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Funcionarios
{
    public class Auxiliar : Funcionario
    {
        private readonly double PERC_BONIFICAO_AUXILIAR = 0.2;
        private readonly double PERC_AUMENTO_AUXILIAR = 1.1;
        public Auxiliar(string nome, string cpf, double salario = 2000) : base(nome, cpf, salario)
        { }

        public override double GetBonificacao()
        {
            return Salario * PERC_BONIFICAO_AUXILIAR;
        }

        public override void AumentarSalario()
        {
            Salario *= PERC_AUMENTO_AUXILIAR;
        }
    }
}
