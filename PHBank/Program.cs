using System;
using PHBank_RH;
using System.Collections.Generic;
using PHBank_RH.Funcionarios;
using PHBank_RH.Sistemas;
using PHBank_RH.Externos;

namespace PHBank
{
    class Program
    {
        private enum TiposFuncionarios 
        { 
            Auxiliar, Designer, Diretor, GerenteConta
        }       
        static void Main(string[] args)
        {
            //CadastrarFuncionarios();
            LogarSistemaInterno();
            Console.ReadKey();
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
    }
}
