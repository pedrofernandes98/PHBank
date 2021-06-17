using PHBank_GerenciamentoContas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank
{
    public class Lista<T>
    {
        private T[] _lista;

        private int _ProximoIndice;

        public int Tamanho { get { return _ProximoIndice; } }

        public Lista(int length = 5)
        {
            _lista = new T[length];
            _ProximoIndice = 0;
        }

        public void Adicionar(T item)
        {
            VerificaTamanho(_ProximoIndice + 1);
            _lista[_ProximoIndice] = item;
            _ProximoIndice++;
        }
        
        public void Adicionar(params T[] lista)
        {
            foreach(var item in lista)
                this.Adicionar(item);
        }

        public void Remover(T item)
        {
            int indiceElementoRemovido = -1;

            for(int i = 0; i < _lista.Length; i++)
            {
                if (_lista[i].Equals(item))
                {
                    indiceElementoRemovido = i; 
                    break;
                }
                    
            }

            for(int i = indiceElementoRemovido; i < _ProximoIndice - 1; i++)
            {
                _lista[i] = _lista[i + 1];
            }

            _ProximoIndice--;
            //_lista[_ProximoIndice] = null;
        }

        public void VerificaTamanho(int tamanhoNecessario)
        {
            if(_lista.Length < tamanhoNecessario)
            {
                int novoTamanho = tamanhoNecessario > (_lista.Length * 2) ? tamanhoNecessario : _lista.Length * 2;

                T[] novoArray = new T[novoTamanho];
                Array.Copy(_lista, novoArray, _lista.Length);
                _lista = novoArray;
            }
        }

        //public void Listar()
        //{
        //    for (int i = 0; i < _lista.Length - 1; i++)
        //    {
        //        if(_lista[i] != null)
        //            Console.WriteLine($"{i + 1} - Ag: {_lista[i].Agencia} | Conta: {_lista[i].NumeroConta}");
        //    }
        //}

        private T GetItemByIndice(int indice)
        {
            if (indice < 0 || indice > Tamanho)
                throw new ArgumentOutOfRangeException(nameof(indice));

            return _lista[indice];
        }

        public T this[int indice]
        {
            get
            {
                return GetItemByIndice(indice);
            }
        }

        


    }
}
