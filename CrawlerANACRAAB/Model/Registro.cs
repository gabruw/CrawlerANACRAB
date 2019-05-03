using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerANAC
{
    public class Registro
    {
        public string Indice { get; set; }

        public string Texto { get; set; }

        public List<string> Motivo = new List<string>();
    }
}
