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

        public Uri UrlBuilder(string chave)
        {
            Uri Url = new Uri(String.Format("https://sistemas.anac.gov.br/aeronaves/cons_rab_novo_resposta.asp?textMarca={0}&selectHabilitacao=&selectIcao=", chave));

            return Url;
        }
    }
}