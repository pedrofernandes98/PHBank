using PHBank_GerenciamentoContas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank
{
    class ListaContaCorrente
    {
        private ContaCorrente[] _listaContaCorrente;

        private int _ProximoIndice;

        public int Tamanho { get { return _ProximoIndice; } }

        public ListaContaCorrente(int length = 5)
        {
            _listaContaCorrente = new ContaCorrente[length];
            _ProximoIndice = 0;
        }

        public void Adicionar(ContaCorrente contaCorrente)
        {
            VerificaTamanho(_ProximoIndice + 1);
            _listaContaCorrente[_ProximoIndice] = contaCorrente;
            _ProximoIndice++;
        }
        
        public void Adicionar(params ContaCorrente[] contasCorrentes)
        {
            foreach(ContaCorrente conta in contasCorrentes)
                this.Adicionar(conta);
        }

        public void Remover(ContaCorrente contaCorrente)
        {
            int indiceElementoRemovido = -1;

            for(int i = 0; i < _listaContaCorrente.Length; i++)
            {
                if (_listaContaCorrente[i].Equals(contaCorrente))
                {
                    indiceElementoRemovido = i; 
                    break;
                }
                    
            }

            for(int i = indiceElementoRemovido; i < _ProximoIndice - 1; i++)
            {
                _listaContaCorrente[i] = _listaContaCorrente[i + 1];
            }

            _ProximoIndice--;
            _listaContaCorrente[_ProximoIndice] = null;
        }

        public void VerificaTamanho(int tamanhoNecessario)
        {
            if(_listaContaCorrente.Length < tamanhoNecessario)
            {
                int novoTamanho = tamanhoNecessario > (_listaContaCorrente.Length * 2) ? tamanhoNecessario : _listaContaCorrente.Length * 2;

                ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];
                Array.Copy(_listaContaCorrente, novoArray, _listaContaCorrente.Length);
                _listaContaCorrente = novoArray;
            }
        }

        public void Listar()
        {
            for (int i = 0; i < _listaContaCorrente.Length - 1; i++)
            {
                if(_listaContaCorrente[i] != null)
                    Console.WriteLine($"{i + 1} - Ag: {_listaContaCorrente[i].Agencia} | Conta: {_listaContaCorrente[i].NumeroConta}");
            }
        }

        private ContaCorrente GetContaCorrenteByIndice(int indice)
        {
            if (indice < 0 || indice > Tamanho)
                throw new ArgumentOutOfRangeException(nameof(indice));

            return _listaContaCorrente[indice];
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return GetContaCorrenteByIndice(indice);
            }
        }

        


    }
}
