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
        }
    }
}
