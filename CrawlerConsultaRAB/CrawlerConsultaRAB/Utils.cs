using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerConsultaRAB
{
    public class Utils
    {
        /// <summary>
        /// Transforma a string Html em um HtmlDocument
        /// </summary>
        /// <param name="html">String Html</param>
        /// <returns>HtmlDocument</returns>
        public HtmlDocument ParserHtmlDocument(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            return htmlDoc;
        }
    }
}
