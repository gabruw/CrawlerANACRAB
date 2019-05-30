using System.Collections.Generic;

namespace CrawlerANAC
{
    public class Registro
    {
        public string Indice { get; set; }

        public string Texto { get; set; }

        public List<string> Motivo = new List<string>();
    }
}