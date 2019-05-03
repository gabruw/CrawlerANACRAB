using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerANACRAAB
{
    public class FormUtils
    {
        public HtmlDocument ParserHtmlDocument(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            return htmlDoc;
        }

        public Uri UrlBuilder(int tipo, string chave)
        {
            Uri Url = new Uri("https://sistemas.anac.gov.br/aeronaves");

            switch (tipo)
            {
                case 1:
                    Url = new Uri(String.Format("https://sistemas.anac.gov.br/aeronaves/cons_rab_novo_resposta.asp?textMarca={0}&selectHabilitacao=&selectIcao=", chave));
                    break;
                case 2:
                    Url = new Uri(String.Format("https://sistemas.anac.gov.br/aeronaves/cons_rab_print.asp?nf={0}", chave));
                    break;
            }
            
            return Url;
        }
    }
}