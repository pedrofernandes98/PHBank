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
        public int NumeroConta { get; set; }
        private int _agencia;
        public int Agencia
        {
            get
            {
                return _agencia;
            }
            set
            {
                if(value > 0)
                {
                    _agencia = value;
                }
            }
        }
        public double Saldo { get; private set; }


        public ContaCorrente(int agencia, int numeroConta)
        {
            Agencia = agencia;
            NumeroConta = numeroConta;
            Saldo = 0;

            TotalContas++;
        }

        public ContaCorrente(Cliente titular, int agencia, int numeroConta)
        {
            Titular = titular;
            Agencia = agencia;
            NumeroConta = numeroConta;
            Saldo = 0;

            TotalContas++;
        }

        public ContaCorrente(string nome, string cpf, int agencia, int numeroConta, string profissao = "")
        {
            Titular = new Cliente(nome, cpf, profissao);
            Agencia = agencia;
            NumeroConta = numeroConta;
            Saldo = 0;

            TotalContas++;
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
            if(valor > Saldo)
            {
                Console.WriteLine($"Saldo insuficiente!\nSaldo Atual: R${Saldo}");
                return false;
            }

            Saldo -= valor;
            return true;
        }

        public bool Transferir(ContaCorrente contaDestino, double valor)
        {
            if (this.Sacar(valor))
            {
                contaDestino.Depositar(valor);
                return true;
            }
            return false;
        }
    }
}
