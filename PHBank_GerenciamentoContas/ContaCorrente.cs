using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_GerenciamentoContas
{
    /// <summary>
    /// Classe que define uma Conta Corrente do Banco PHBank.
    /// </summary>
    public class ContaCorrente
    {
        public static int TotalContas { get; private set; }
        public Cliente Titular { get; set; }
        public int NumeroConta { get;} //readOnly
        public int Agencia { get; }//readOnly
        public double Saldo { get; private set; }
        public bool Ativa { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ContaCorrente"/> com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia">Define o valor da propriedade <see cref="Agencia"/> que deve ser maior do que zero.</param>
        /// <param name="numeroConta">Define o valor da propriedade <see cref="NumeroConta"/> que deve ser maior do que zero.</param>
        /// <param name="ativa">Define o valor da propriedade <see cref="Ativa"/> que por padrão recebe true.</param>
        public ContaCorrente(int agencia, int numeroConta, bool ativa = true)
        {
            validaAgenciaConta(agencia, numeroConta);
            Agencia = agencia;
            NumeroConta = numeroConta;
            Saldo = 0;
            Ativa = ativa;

            TotalContas++;
        }
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ContaCorrente"/> com os argumentos utilizados.
        /// </summary>
        /// <param name="titular">Define o valor da propriedade <see cref="Titular"/>.</param> 
        /// <param name="agencia">Define o valor da propriedade <see cref="Agencia"/> que deve ser maior do que zero.</param>
        /// <param name="numeroConta">Define o valor da propriedade <see cref="NumeroConta"/> que deve ser maior do que zero.</param>
        /// <param name="ativa">Define o valor da propriedade <see cref="Ativa"/> que por padrão recebe true.</param>
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
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ContaCorrente"/> com os argumentos utilizados.
        /// </summary>
        /// <param name="nome">Define o valor da propriedade <see cref="Cliente.Nome"/> do <see cref="Titular"/>.</param>
        /// <param name="cpf">Define o valor da propriedade <see cref="Cliente.CPF"/> do <see cref="Titular"/>.</param>
        /// <param name="agencia">Define o valor da propriedade <see cref="Agencia"/>.</param>
        /// <param name="numeroConta">Define o valor da propriedade <see cref="NumeroConta"/>.</param>
        /// <param name="profissao">Define o valor da propriedade <see cref="Cliente.Profissao"/> do <see cref="Titular"/>.</param>
        /// <param name="ativa">Define o valor da propriedade <see cref="Ativa"/> que por padrão recebe true.</param>
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
        
        /// <summary>
        /// Método efetua o saque e atualiza o valor da propriedade <see cref="Saldo"/> da <see cref="ContaCorrente"/>
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um <paramref name="valor"/> é menor que zero.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando um <paramref name="valor"/> é menor que o valor do <see cref="Saldo">.</see>/></exception>
        /// <param name="valor">Valor a ser sacado, deve ser maior que zero e menor que o valor do <see cref="Saldo"/>.</param>
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

        public override bool Equals(object obj)
        {
            ContaCorrente outraContaCorrente = obj as ContaCorrente;

            return outraContaCorrente != null ?
                (Agencia == outraContaCorrente.Agencia && NumeroConta == outraContaCorrente.NumeroConta) :
                false;
        }
    }
}
