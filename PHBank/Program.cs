using System;
using PHBank_RH;
using System.Collections.Generic;
using PHBank_RH.Funcionarios;
using PHBank_RH.Sistemas;
using PHBank_RH.Externos;
using PHBank_GerenciamentoContas;
using System.IO;
using System.Text.RegularExpressions;
using PHBank.Extensions;
using PHBank_GerenciamentoContas.Comparer;
using PHBank_RH.Extensions;
using System.Linq;
using PHBank.Streams;

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
            //LogarSistemaInterno();
            //RealizarTransacoesContaCorrente();
            //TestarExceptions();
            //UsarRecursosExternosExplicito();
            //UsarRecursosExternosImplicito();
            //ListsAndGenericsAndExtensionsMethodsAndOtherThings
            //LearnLinqOrderBtWhereAndOthers

            var filePath = "C:\\Dev\\Alura\\PHBank\\Files\\contas2.txt";
            //var reader = new FileReader(filePath, FileMode.Open);
            //reader.ShowAllFile();
            //Console.WriteLine("=====================================");
            //reader.ShowAllFileComoContaCorrente();

            //var file = new FileManipulation(filePath, FileMode.Open);
            //file.GenereteCSV("teste.csv");
            var c = ContaCorrente.GerarContaCorrente();
            c.Titular = new Cliente();
            c.Titular.Nome = "Ronaldo Nazário";
            c.Depositar(1500);
            BinaryFile.WriteBinaryFile(c);
            BinaryFile.ReadBinaryFile();

            Console.ReadLine();
        }

        public static void LearnLinqOrderBtWhereAndOthers()
        {
            var lista = ContaCorrente.GerarListaContasCorrentes(5);
            lista.Add(new ContaCorrente(lista[3].Agencia, lista[3].NumeroConta - 1));
            lista.Add(new ContaCorrente(lista[3].Agencia, lista[3].NumeroConta - 2));
            lista.Add(null);
            lista.Add(new ContaCorrente(lista[3].Agencia - 1, lista[3].NumeroConta));
            Console.WriteLine("Lista Desordenada");
            ContaCorrente.PrintListContasCorrentes(lista.Where(c => c != null).ToList());

            Console.WriteLine("=======================================================");

            Console.WriteLine($"Lista Ordenada por {nameof(ContaCorrente.NumeroConta)}");
            lista = lista
                .Where(c => c != null)
                .OrderBy(c => c.NumeroConta)
                .ToList<ContaCorrente>();
            ContaCorrente.PrintListContasCorrentes(lista);

            Console.WriteLine("=======================================================");
            Console.WriteLine($"Lista Ordenada por {nameof(ContaCorrente.Agencia)}");
            lista = lista
                .Where(c => c != null)
                .OrderBy(c => c.Agencia)
                .ToList();
            ContaCorrente.PrintListContasCorrentes(lista);

            Console.WriteLine("=======================================================");
            Console.WriteLine($"Lista Ordenada por {nameof(ContaCorrente.Agencia)} e {nameof(ContaCorrente.NumeroConta)}");
            lista = lista
                .Where(c => c != null)
                .OrderBy(c => c.Agencia)
                .ThenBy(c => c.NumeroConta)
                .ToList();
            ContaCorrente.PrintListContasCorrentes(lista);
        }
        public static void ListsAndGenericsAndExtensionsMethodsAndOtherThings()
        {
            Lista<ContaCorrente> contas = new Lista<ContaCorrente>();

            contas.Adicionar(new ContaCorrente(123, 123456));
            contas.Adicionar(new ContaCorrente(123, 456789));
            var contaRemovida = new ContaCorrente(111, 111111);
            contas.Adicionar(contaRemovida);
            contas.Adicionar(new ContaCorrente(123, 456781));
            contas.Adicionar(new ContaCorrente(123, 123456));
            contas.Adicionar(new ContaCorrente(123, 456789));
            contas.Adicionar(new ContaCorrente(123, 456781));

            //contas.Listar();

            Console.WriteLine();

            contas.Remover(contaRemovida);
            //contas.Listar();

            Console.WriteLine("---");
            Console.WriteLine($"{contas[2].Agencia} | {contas[2].NumeroConta}");

            Console.WriteLine("---");

            Lista<ContaCorrente> novaLista = new Lista<ContaCorrente>();

            novaLista.Adicionar(
                ContaCorrente.GerarContaCorrente(),
                ContaCorrente.GerarContaCorrente(),
                ContaCorrente.GerarContaCorrente(),
                ContaCorrente.GerarContaCorrente(),
                ContaCorrente.GerarContaCorrente(),
                ContaCorrente.GerarContaCorrente()
                );

            List<ContaCorrente> listaContaCorrente = new List<ContaCorrente>();

            listaContaCorrente.Add(ContaCorrente.GerarContaCorrente());
            listaContaCorrente.Add(ContaCorrente.GerarContaCorrente());
            listaContaCorrente.Add(ContaCorrente.GerarContaCorrente());
            listaContaCorrente.Add(ContaCorrente.GerarContaCorrente());
            listaContaCorrente.Add(ContaCorrente.GerarContaCorrente());

            foreach (var item in listaContaCorrente)
            {
                Console.WriteLine($"Ag - {item.Agencia}| Conta - {item.NumeroConta}");
            }

            listaContaCorrente.Sort();
            Console.WriteLine("-------");
            Console.WriteLine("Ordenado por Conta");
            foreach (var item in listaContaCorrente)
            {
                Console.WriteLine($"Ag - {item.Agencia}| Conta - {item.NumeroConta}");
            }

            listaContaCorrente.Sort(new CompareByAgencia());
            Console.WriteLine("-------");
            Console.WriteLine("Ordenado por Agencia");
            foreach (var item in listaContaCorrente)
            {
                Console.WriteLine($"Ag - {item.Agencia}| Conta - {item.NumeroConta}");
            }

            listaContaCorrente.PrintList<ContaCorrente>();


            Lista<int> listaInt = new Lista<int>();

            listaInt.Adicionar(1, 2, 3, 4);
            listaInt.Adicionar(66);
            listaInt.Remover(3);

            for (int i = 0; i < listaInt.Tamanho; i++)
            {
                Console.WriteLine($"listaInt[{i}] = {listaInt[i]}");
            }

            List<int> lista = new List<int>();

            lista.AddManyItens<int>(4, 959, 269, 70);

            foreach (var item in lista)
                Console.WriteLine(item);

            List<string> names = new List<string>()
            {
               "Ronaldo"
            };

            names.AddManyItens<string>("Pedro", "Paulo", "Miguel", "Letícia", "Maria");
            names.Sort();
            names.PrintList();

            //Console.Clear();

            List<string> forLets = new List<string>();

            forLets.AddManyItens("Pedro", "S2", "Leticia");
            forLets.PrintList();

            //novaLista.Listar();
            Console.ReadLine();


            Console.Clear();
            var func = new Desenvolvedor("Pedro", "12345678", 2000.0);

            func.TestExtensionsMethods();
        }

        public static void TestesComArraysAndStringInterpolation()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(123, 123456),
                new ContaCorrente(123, 456789),
                new ContaCorrente(123, 456781)
            };

            for (int i = 0; i < contas.Length; i++)
            {
                Console.WriteLine($"Ag: {contas[i].Agencia} | Conta: {contas[i].NumeroConta}");
            }

            string teste = @$"
                Teste string interpolation {contas[0].Agencia}
                Teste string interpolation {contas[0].Agencia}
            ";

            Console.WriteLine();
            Console.WriteLine(teste);
        }
        public static void Curso6FuncoesStrings()
        {
            string pattern = "[0-9]{4,5}-?[0-9]{4}";
            pattern = "[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}";
            string text = "jdsfhksdjhfdsjkfkds 192168102-91 dsfjgndsjkndsjkdsfjknsjkfn";
            Match match = Regex.Match(text, pattern);
            Console.WriteLine(match.Success);
            Console.WriteLine(match.Value);


            ExtratorURL url = new ExtratorURL("teste.com.br/teste?moedaOrigem=real&moedaDestino=dolar&valor=100");
            url.MostraParametros();
            Console.WriteLine(url.GetValor("moedaorigem"));
            Console.WriteLine(url.GetValor("moedaDestino"));
            //Console.WriteLine(url.GetValor(""));
            //.WriteLine(url.GetValor(""));
            Console.ReadLine();
        }

        public static void UsarRecursosExternosImplicito()
        {
            using(FileReaderDecapred reader = new FileReaderDecapred("myFile.txt"))
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
            FileReaderDecapred reader = null;

            try
            {
                reader = new FileReaderDecapred("meuArquivo.txt");
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
