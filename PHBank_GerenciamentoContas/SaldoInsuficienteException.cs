using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_GerenciamentoContas
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public double Saldo { get;}

        public double ValorSaque { get; }
        public SaldoInsuficienteException() { }
        public SaldoInsuficienteException(string message) : base(message) { }
        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this($"Saldo insuficiente para o saque de R$ {valorSaque}!\nSaldo Atual: R${saldo}")
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
        public SaldoInsuficienteException(string message, Exception innerException)
            :base(message, innerException) { }

    }
}
