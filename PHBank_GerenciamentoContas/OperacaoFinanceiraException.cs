using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_GerenciamentoContas
{
    public class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException() { }

        public OperacaoFinanceiraException(string message)
            :base(message)
        {

        }

        public OperacaoFinanceiraException(string message, Exception innerException)
            :base(message, innerException)
        {

        }
    }
}
