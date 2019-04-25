using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace CrawlerANACRAAB
{
    public class Connect
    {
        public void CheckStatus(Uri url)
        {
            var networkStatus = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (networkStatus != true)
            {
                throw new Exception("Erro ao conectar, verifique sua rede.");
            }

            var verifyStatusRequest = (HttpWebRequest)WebRequest.Create(url);
            verifyStatusRequest.AllowAutoRedirect = false;
            verifyStatusRequest.Method = "HEAD";

            using (var response = verifyStatusRequest.GetResponse() as HttpWebResponse)
            {
                var siteStatus = response.StatusCode;
                response.Close();

                if (siteStatus != HttpStatusCode.OK)
                {
                    throw new Exception("O serviço está indisponível no momento.");
                }
            }
        }

        public HtmlDocument RequestGET(Uri url)
        {
            var html = string.Empty;
            FormUtils parseData = new FormUtils();

            var webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "GET";
            webRequest.AllowAutoRedirect = false;

            var webResponse = (HttpWebResponse)webRequest.GetResponse();

            html = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF7).ReadToEnd();

            var htmlDoc = parseData.ParserHtmlDocument(html);

            return htmlDoc;
        }
    }
}