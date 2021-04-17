using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Interfaces
{
    public interface IAutenticavel
    {
        public bool Autenticar(string senha);
        public string GetNome();
        bool isExterno();
    }
}
