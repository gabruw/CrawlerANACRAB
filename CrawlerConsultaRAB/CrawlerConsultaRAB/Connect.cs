using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CrawlerConsultaRAB
{
    public class Connect
    {
        Utils utils = new Utils();

        /// <summary>
        /// Captura o código fonte de uma página através de um GET
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HtmlDocument RequestGET(Uri url)
        {
            string html = string.Empty;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.AllowAutoRedirect = false;

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            html = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF7).ReadToEnd();

            HtmlDocument htmlDoc = utils.ParserHtmlDocument(html);

            return htmlDoc;
        }
    }
}
