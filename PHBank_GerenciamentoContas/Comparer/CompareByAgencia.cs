using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_GerenciamentoContas.Comparer
{
    public class CompareByAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            return x == y ? 0 : x.Agencia.CompareTo(y.Agencia);
        }
    }
}
