using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank
{
    public static class ListExtensions
    {
        public static void AddExtends(this List<int> lista, params int[] itens)
        {
            foreach(var x in itens)
            {
                lista.Add(x);
            }
        }
    }
}
