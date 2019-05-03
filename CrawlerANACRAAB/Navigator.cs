using CrawlerANAC;
using CrawlerANACRAB;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerANACRAAB
{
    public class Navigator
    {
        Consulta newConsulta = new Consulta();

        public List<Registro> NavPrincipal(string chave)
        {
            Connect newConnect = new Connect();
            Catcher newCatcher = new Catcher();
            FormUtils newForm = new FormUtils();

            var url = newForm.UrlBuilder(1, chave);

            newConnect.CheckStatus(url);
            var html = newConnect.RequestGET(url);

            newCatcher.HasNotFoundInformation(html);
            var capturas = newCatcher.GetData(html);

            newConsulta.ListRegistro.AddRange(capturas);

            return capturas;
        }

        public string NavPDF(string chave)
        {
            Connect newConnect = new Connect();
            FormUtils newForm = new FormUtils();

            var url = newForm.UrlBuilder(2, chave);

            var html = newConnect.RequestGET(url);

            var htmlPDF = html.ParsedText;

            newConsulta.HtmlPDF = htmlPDF;

            return htmlPDF;
        }
    }
}
