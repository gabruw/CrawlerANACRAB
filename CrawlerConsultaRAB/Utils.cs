using HtmlAgilityPack;
using System;

namespace CrawlerConsultaRAB
{
    public class Utils
    {
        /// <summary>
        /// Transforma a string Html em um HtmlDocument
        /// </summary>
        /// <param name="html">String Html</param>
        /// <returns>HtmlDocument</returns>
        public HtmlDocument ParseToHtmlDocument(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            return htmlDoc;
        }

        /// <summary>
        /// Controla qual URL será retornada apartir do tipo de consulta
        /// </summary>
        /// <param name="tipo">Código do tipo de consulta</param>
        /// <param name="chave">Código do a ser pesquisado</param>
        /// <returns>Uniform Resource Identifier</returns>
        public Uri SelectQueryType(int tipo, string chave)
        {
            Uri url = new Uri("https://www.anac.gov.br/servicos-on-line/consulta-rab");

            switch (tipo)
            {
                case 1:
                    url = new Uri(String.Format("https://sistemas.anac.gov.br/aeronaves/cons_rab_novo_resposta.asp?textMarca={0}&selectHabilitacao=&selectIcao=", chave));
                    break;
                case 2:
                    url = new Uri(String.Format("https://sistemas.anac.gov.br/aeronaves/cons_rab_print.asp?nf={0}", chave));
                    break;
                default:
                    throw new Exception("Tipo de consulta inválida!");
            }

            return url;
        }
    }
}