using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank.Extensions
{
    public static class ListExtensions
    {
        public static void AddManyItens<T>(this List<T> listToAdd, params T[] itensToAdd)
        {
            foreach (var item in itensToAdd)
                listToAdd.Add(item);
        }

        public static void PrintList<T>(this List<T> listToPrint)
        {
            foreach (var item in listToPrint)
                Console.WriteLine($"{item}");
        }
    }
}
