using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank
{
    public class ExtratorURL
    {
        private readonly string _parametros;

        public string URL { get; }

        public ExtratorURL(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("A URL não pode ser nula ou vazia", nameof(url));
            }

            URL = url;
            _parametros = url.Substring(url.IndexOf('?') + 1);
        }

        public void MostraParametros()
        {
            //string url = "teste.com.br/teste?moedaOrigem=real&moedaDestino=dolar&valor=100";
            string moedaOrigem = "moedaOrigem";
            string moedaDestino = "moedaDestino";
            string valor = "valor";

            //string parametros = url.Substring(url.IndexOf('?') + 1);

            string[] valores = _parametros.Split('&');

            Console.WriteLine($"Parâmetros: {_parametros}");
            Console.WriteLine($"moedaOrigem: {valores[0].Substring(moedaOrigem.Length + 1)}");
            Console.WriteLine($"moedaDestino: {valores[1].Substring(moedaDestino.Length + 1)}");
            Console.WriteLine($"valor: {valores[2].Substring(valor.Length + 1)}");
            Console.WriteLine("Fim do programa!");
            Console.ReadKey();
        }

        public string GetValor(string parametro)
        {
            string valor = "";
            int indexParametro = _parametros.ToUpper().IndexOf(parametro.ToUpper());
            if(string.IsNullOrEmpty(parametro) || indexParametro == -1)
            {
                throw new ArgumentException(parametro);
            }
            else
            {
                parametro = parametro + "=";
                valor = _parametros.Substring(indexParametro + parametro.Length);
                int indexEComercial = valor.IndexOf('&');
                if(indexEComercial != -1)
                {
                    valor = valor.Remove(indexEComercial);
                }
            }

            return valor;

        }

        public override string ToString()
        {
            return "Essa é uma classe que extrai os query params de uma determinada URL";
        }
    }
}
