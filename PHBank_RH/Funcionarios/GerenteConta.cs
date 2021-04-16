using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Funcionarios
{
    public class GerenteConta : Autenticavel
    {
        private readonly double PERC_BONIFICAO_GERENTE_CONTA = 0.25;
        private readonly double PERC_AUMENTO_GERENTE_CONTA = 1.05;
        public GerenteConta(string nome, string cpf, string senha, double salario = 4000) : base(nome, cpf, senha, salario)
        { }

        public override double GetBonificacao()
        {
            return Salario * PERC_BONIFICAO_GERENTE_CONTA;
        }

        public override void AumentarSalario()
        {
            Salario *= PERC_AUMENTO_GERENTE_CONTA;
        }
    }
}
