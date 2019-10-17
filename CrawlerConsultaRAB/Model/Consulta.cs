using System.Collections.Generic;

namespace CrawlerConsultaRAB.Model
{
    public class Consulta
    {
        public List<Registro> ListRegistro = new List<Registro>();

        public string HtmlPDF { get; set; }
    }
}