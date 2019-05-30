using CrawlerANAC;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CrawlerANACRAAB
{
    public class Catcher
    {
        public List<Registro> listData = new List<Registro>();

        public List<Registro> GetData(HtmlDocument html)
        {
            FormUtils newForm = new FormUtils();

            var nodesData = html.DocumentNode.SelectNodes("//div[contains(@class, 'retorno-pesquisa')]/table[contains(@class, 'table')]/tbody/tr");
            if (nodesData == null)
            {
                throw new Exception("Erro ao capturar os node que contém os dados.");
            }

            foreach (var node in nodesData)
            {
                var newRegistro = new Registro();

                var nodeHtmlDoc = newForm.ParserHtmlDocument(node.InnerHtml);

                var indice = nodeHtmlDoc.DocumentNode.SelectSingleNode("th/text()").OuterHtml;

                var texto = string.Empty;
                if (indice.Contains("Motivo(s)"))
                {
                    var motivos = nodeHtmlDoc.DocumentNode.SelectNodes("td/br");
                    if (motivos != null)
                    {
                        foreach (var txt in motivos)
                        {
                            newRegistro.Motivo.Add(txt.InnerText);
                        }
                    }
                }
                else
                {
                    try
                    {
                        texto = nodeHtmlDoc.DocumentNode.SelectSingleNode("td/text()").OuterHtml;

                    }
                    catch
                    {
                        texto = string.Empty;
                    }

                    newRegistro.Texto = texto.Trim();
                }

                newRegistro.Indice = indice.Trim().Remove(indice.Trim().Length - 1);
                
                listData.Add(newRegistro);
            }

            return listData;
        }

        public void HasNotFoundInformation(HtmlDocument html)
        {
            var node = Regex.Match(html.ParsedText, "Registro não encontrado!");
            if (node.Success)
            {
                throw new Exception("Matrícula não encontrada.");
            }
        }
    }
}