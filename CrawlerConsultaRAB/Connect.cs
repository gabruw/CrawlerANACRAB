using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.NetworkInformation;

namespace CrawlerConsultaRAB
{
    public class Connect
    {
        private Utils _utils = new Utils();

        /// <summary>
        /// Verifica se a página se encontra disponível para acesso
        /// </summary>
        /// <param name="url">Uniform Resource Identifier</param>
        public void CheckStatus(Uri url)
        {
            bool networkStatus = NetworkInterface.GetIsNetworkAvailable();
            if (networkStatus != true)
            {
                throw new Exception("Erro ao conectar: Verifique sua rede.");
            }

            HttpWebRequest verifyStatusRequest = (HttpWebRequest)WebRequest.Create(url);
            verifyStatusRequest.Method = "HEAD";
            verifyStatusRequest.AllowAutoRedirect = false;

            HttpWebResponse response = verifyStatusRequest.GetResponse() as HttpWebResponse;
            HttpStatusCode siteStatus = response.StatusCode;
            response.Close();

            if (siteStatus != HttpStatusCode.OK)
            {
                throw new Exception("Erro ao conectar: O serviço está indisponível no momento.");
            }
        }

        /// <summary>
        /// Captura o código fonte de uma página através de um GET
        /// </summary>
        /// <param name="url">Uniform Resource Identifier</param>
        /// <returns>HtmlDocument</returns>
        public HtmlDocument RequestGET(Uri url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.AllowAutoRedirect = false;

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            string html = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF7).ReadToEnd();
            HtmlDocument htmlDoc = _utils.ParseToHtmlDocument(html);

            return htmlDoc;
        }
    }
}