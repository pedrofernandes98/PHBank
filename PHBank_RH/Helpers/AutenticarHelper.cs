using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHBank_RH.Helpers
{
    internal static class AutenticarHelper
    {
        public static bool CompararSenhas(string senhaCorreta, string tentativa)
        {
            return senhaCorreta == tentativa;
        }
    }
}
