using CrawlerANAC;
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
        public List<Registro> NavResultado(Uri url)
        {
            Connect newConnect = new Connect();
            Catcher newCatcher = new Catcher();

            newConnect.CheckStatus(url);
            var html = newConnect.RequestGET(url);

            newCatcher.HasNotFoundInformation(html);
            var capturas = newCatcher.GetData(html);

            return capturas;
        }
    }
}
