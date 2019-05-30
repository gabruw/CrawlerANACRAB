using CrawlerANAC;
using CrawlerANACRAB;
using System.Collections.Generic;

namespace CrawlerANACRAAB
{
    public class Navigator
    {
        public Consulta newConsulta = new Consulta();

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

        public void NavPDF(string chave)
        {
            Connect newConnect = new Connect();
            FormUtils newForm = new FormUtils();

            var url = newForm.UrlBuilder(2, chave).ToString();

            newConsulta.HtmlPDF = url;
        }
    }
}