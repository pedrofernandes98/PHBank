using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_GerenciamentoContas
{
    public class ContaCorrente
    {
        public static int TotalContas { get; private set; }
        public Cliente Titular { get; set; }
        public int NumeroConta { get;} //readOnly
        public int Agencia { get; }//readOnly
        public double Saldo { get; private set; }

        public bool Ativa { get; set; }
        public ContaCorrente(int agencia, int numeroConta, bool ativa = true)
        {
            validaAgenciaConta(agencia, numeroConta);
            Agencia = agencia;
            NumeroConta = numeroConta;
            Saldo = 0;
            Ativa = ativa;

            TotalContas++;
        }

        public ContaCorrente(Cliente titular, int agencia, int numeroConta, bool ativa = true)
        {
            validaAgenciaConta(agencia, numeroConta);
            Titular = titular;
            Agencia = agencia;
            NumeroConta = numeroConta;
            Saldo = 0;
            Ativa = ativa;

            TotalContas++;
        }

        public ContaCorrente(string nome, string cpf, int agencia, int numeroConta, string profissao = "", bool ativa = true)
        {
            validaAgenciaConta(agencia, numeroConta);
            Titular = new Cliente(nome, cpf, profissao);
            Agencia = agencia;
            NumeroConta = numeroConta;
            Saldo = 0;
            Ativa = ativa;

            TotalContas++;
        }

        private void validaAgenciaConta(int agencia, int numeroConta)
        {
            if (agencia <= 0)
                throw new ArgumentException("O número da agência não pode ser menor o igual a 0.", nameof(agencia));

            if (numeroConta <= 0)
                throw new ArgumentException("O número da conta não pode ser menor o igual a 0.", nameof(numeroConta));
        }

        public void Depositar(double valor)
        {
            
            if(valor > 0)
            {
                Saldo += valor;
                Console.WriteLine("Depósito realizado com sucesso!");
                return;
            }

            Console.WriteLine("Valor inválido para depósito");
        }

        public bool Sacar(double valor)
        {
            if(valor <= 0)
            {
                Console.WriteLine("Valor de saque inválido!");
                return false;
            }

            if(valor > Saldo)
            {
                Console.WriteLine($"Saldo insuficiente para o saque de R$ {valor}!\nSaldo Atual: R${Saldo}");
                return false;
            }

            Saldo -= valor;
            return true;
        }

        public void SacarException(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor de saque inválido!", nameof(valor));
            }

            if (valor > Saldo)
            {
                string mensagem = $"Saldo insuficiente para o saque de R$ {valor}!\nSaldo Atual: R${Saldo}";
                throw new SaldoInsuficienteException(mensagem, Saldo, valor);
            }

            Saldo -= valor;
        }

        public bool Transferir(ContaCorrente contaDestino, double valor)
        {
            if (this.Sacar(valor))
            {
                if(contaDestino != null)
                {
                    contaDestino.Depositar(valor);
                    return true;
                }
                else
                {
                    Console.WriteLine("Conta de destino inválida");
                }
                
            }
            return false;
        }

        public void TransferirException(ContaCorrente contaDestino, double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor de transferência inválido!", nameof(valor));
            }

            try
            {
                this.SacarException(valor);
            }
            catch(SaldoInsuficienteException ex)
            {
                throw new OperacaoFinanceiraException("Operação de transferência inválida devido a saldo insuficiênte para transferência", ex);
            }
            
            if(contaDestino != null)
            {
                contaDestino.Depositar(valor);
            }
            else
            {
                throw new NullReferenceException("A Conta Corrente da Conta de Destino deve ser preenchida");
            }
        }
    }
}
