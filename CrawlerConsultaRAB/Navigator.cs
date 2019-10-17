using CrawlerConsultaRAB.Catcher;
using CrawlerConsultaRAB.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace CrawlerConsultaRAB
{
    public class Navigator
    {
        // Globais privadas
        private Utils _utils = new Utils();
        private Connect _connect = new Connect();
        private Catcher_All _catcher = new Catcher_All();

        // Globais publicas
        public Consulta _consulta = new Consulta();

        /// <summary>
        /// Navega para a página de Captura dos dados
        /// </summary>
        /// <param name="chave">Código do a ser pesquisado</param>
        public void NavToQueryPage(string chave)
        {
            Uri url = _utils.SelectQueryType(1, chave);

            _connect.CheckStatus(url);
            HtmlDocument html = _connect.RequestGET(url);

            _catcher.HasNotFoundInformation(html);
            List<Registro> capturas = _catcher.GetData(html);

            _consulta.ListRegistro.AddRange(capturas);
        }

        /// <summary>
        /// Navega para a página que possuí o arquivo de PDF
        /// </summary>
        /// <param name="chave">Código do a ser pesquisado</param>
        public void NavToPDFPage(string chave)
        {
            Uri url = _utils.SelectQueryType(2, chave);

            _consulta.HtmlPDF = url.ToString();
        }
    }
}
