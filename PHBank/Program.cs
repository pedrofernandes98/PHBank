﻿using System;
using PHBank_RH;
using System.Collections.Generic;
using PHBank_RH.Funcionarios;
using PHBank_RH.Sistemas;
using PHBank_RH.Externos;
using PHBank_GerenciamentoContas;
using System.IO;

namespace PHBank
{
    public class Program
    {
        private enum TiposFuncionarios 
        { 
            Auxiliar, Designer, Diretor, GerenteConta
        }       
        static void Main(string[] args)
        {
            //CadastrarFuncionarios();
            LogarSistemaInterno();
            //RealizarTransacoesContaCorrente();
            //TestarExceptions();
            //UsarRecursosExternosExplicito();
            //UsarRecursosExternosImplicito();
            

            Console.WriteLine("Fim do programa!");
            Console.ReadKey();
        }

        public static void UsarRecursosExternosImplicito()
        {
            using(FileReader reader = new FileReader("myFile.txt"))
            {
                try
                {
                    reader.ReadLine();
                    reader.ReadLine();
                    reader.ReadLine();
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Capturando um IOException");
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        public static void UsarRecursosExternosExplicito()
        {
            FileReader reader = null;

            try
            {
                reader = new FileReader("meuArquivo.txt");
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
            }
            catch (IOException ex)
            {
                Console.WriteLine("Capturando um IOException");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if(reader != null)
                {
                    reader.Dispose();
                }
            }
        }

        public static void LogarSistemaInterno()
        {
            Diretor diretor = new Diretor("Cláudia", "147.159.621-58", "123456", 5000);
            GerenteConta gerenteConta = new GerenteConta("Ronaldo", "248.157.248-17", "22314");
            //Designer designer = new Designer("Wellingto", "123.456.147-12");

            ParceiroComercial parceiroComercial = new ParceiroComercial("Rivaldo", "123456");

            SistemaInterno sistemaInterno = new SistemaInterno();
            sistemaInterno.Logar(diretor, "123456");
            sistemaInterno.Logar(gerenteConta, "25");
            sistemaInterno.Logar(parceiroComercial, "123456");
            //sistemaInterno.Logar(designer, "545450");
        }

        public static void InserirFuncionario(Funcionario funcionario)
        {
            //implementar
        }

        public static void CadastrarFuncionarios()
        {
            GerenciadorBonificacao gerenciaBonificacoes = new GerenciadorBonificacao();
            List<Funcionario> listaFuncionarios = new List<Funcionario>();

            Diretor diretor = new Diretor("Cláudia", "147.159.621-58","123456", 5000);
            gerenciaBonificacoes.RegistrarBonificacao(diretor);
            listaFuncionarios.Add(diretor);

            GerenteConta gerenteConta = new GerenteConta("Ronaldo", "248.157.248-17", "123456");
            gerenciaBonificacoes.RegistrarBonificacao(gerenteConta);
            listaFuncionarios.Add(gerenteConta);

            Designer designer = new Designer("Wellingto", "123.456.147-12");
            gerenciaBonificacoes.RegistrarBonificacao(designer);
            listaFuncionarios.Add(designer);

            Auxiliar auxiliar = new Auxiliar("Alexandre", "159.124.157-00");
            gerenciaBonificacoes.RegistrarBonificacao(auxiliar);
            listaFuncionarios.Add(auxiliar);

            Auxiliar dev = new Auxiliar("Maria", "513.322.428-12");
            gerenciaBonificacoes.RegistrarBonificacao(dev);
            listaFuncionarios.Add(dev);

            ListaFuncionarios(listaFuncionarios, gerenciaBonificacoes);
        }

        public static void ListaFuncionarios(List<Funcionario> listaFuncionarios, GerenciadorBonificacao gerenciador)
        {
            Console.WriteLine();
            Console.WriteLine("Lista de Funcionário da PHBank LTDA");
            foreach (Funcionario x in listaFuncionarios)
            {
                Console.WriteLine();
                Console.WriteLine($"Nome: {x.Nome}");
                Console.WriteLine($"CPF: {x.CPF}");
                Console.WriteLine($"Salário: R${x.Salario}");
                Console.WriteLine($"Bonificação: R$ {x.GetBonificacao()}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total de Funcionários : {Funcionario.QuantidadeFuncionario}");
            Console.WriteLine($"Total de Bonificação: R$ {gerenciador.TotalBonificacao}");

            Console.ReadKey();

        }
    
        public static void RealizarTransacoesContaCorrente()
        {
            ContaCorrente contaCorrente = new ContaCorrente("Mirella Alana Andreia Carvalho", "696.269.200-50", 1234, 123456, "Cabelereira");
            contaCorrente.Depositar(1000.00);

            Console.WriteLine($"{contaCorrente.Titular.Nome} - R${contaCorrente.Saldo}");

            ContaCorrente contaCorrente2 = new ContaCorrente("Lúcia Sophie Rita Oliveira", "115.218.455-57", 1234, 123457, "Médica");
            contaCorrente2.Depositar(1000.00);
            Console.WriteLine($"{contaCorrente2.Titular.Nome} - R${contaCorrente2.Saldo}");

            if (contaCorrente2.Transferir(contaCorrente, 200.50)) 
            {
                Console.WriteLine("Tranferência realizada!");
            }
            Console.WriteLine($"{contaCorrente.Titular.Nome} - R${contaCorrente.Saldo}");
            Console.WriteLine($"{contaCorrente2.Titular.Nome} - R${contaCorrente2.Saldo}");

        }

        public static void TestarExceptions()
        {
            //try
            //{
            //    ContaCorrente conta = new ContaCorrente(0, 0);
            //}
            //catch(ArgumentException ex)
            //{
            //    Console.WriteLine($"Mensagem de erro: {ex.Message}");
            //    Console.WriteLine($"Nome do Parâmetro que gerou a Exception: {ex.ParamName}");
            //    Console.WriteLine("Stack Trace:");
            //    Console.WriteLine(ex.StackTrace);
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            //try
            //{
            //    ContaCorrente conta = new ContaCorrente(123, 0);
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine($"Mensagem de erro: {ex.Message}");
            //    Console.WriteLine($"Nome do Parâmetro que gerou a Exception: {ex.ParamName}");
            //    Console.WriteLine("Stack Trace:");
            //    Console.WriteLine(ex.StackTrace);
            //}

            //try
            //{
            //    ContaCorrente contaCorreta = new ContaCorrente(1212, 146565);
            //    contaCorreta.Depositar(1000);
            //    contaCorreta.SacarException(2000);
            //}
            //catch(SaldoInsuficienteException ex)
            //{
            //    Console.WriteLine("Saldo: "+ ex.Saldo + " Valor Saque: " + ex.ValorSaque);
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);
            //}

            try
            {
                ContaCorrente contaCorreta = new ContaCorrente(1212, 146565);
                contaCorreta.Depositar(1000);
                ContaCorrente contaCorreta2 = new ContaCorrente(1212, 146563);
                contaCorreta2.Depositar(1000);
                contaCorreta2.TransferirException(contaCorreta,400000);
            }
            catch (OperacaoFinanceiraException ex)
            {
                //Console.WriteLine(ex.Saldo + ex.ValorSaque);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                Console.WriteLine("\n-------------InnerException---------------\n");
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Mensagem de erro: {ex.Message}");
                Console.WriteLine($"Nome do Parâmetro que gerou a Exception: {ex.ParamName}");
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
