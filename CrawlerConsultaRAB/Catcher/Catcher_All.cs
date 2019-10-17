using CrawlerConsultaRAB.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CrawlerConsultaRAB.Catcher
{
    public class Catcher_All
    {
        private Utils _utils = new Utils();

        /// <summary>
        /// Captura as informações da página
        /// </summary>
        /// <param name="html">HtmlDocument a ser análisado</param>
        /// <returns>A lista de dados (Registro) capturados</returns>
        public List<Registro> GetData(HtmlDocument html)
        {
            List<Registro> listData = new List<Registro>();

            HtmlNodeCollection nodesData = html.DocumentNode.SelectNodes("//div[contains(@class, 'retorno-pesquisa')]/table[contains(@class, 'table')]/tbody/tr");
            if (nodesData == null)
            {
                throw new Exception("Erro ao capturar os nodes que contém os dados a serem capturados.");
            }

            foreach (HtmlNode node in nodesData)
            {
                Registro newRegistro = new Registro();

                HtmlDocument nodeHtmlDoc = _utils.ParseToHtmlDocument(node.InnerHtml);

                string indice = nodeHtmlDoc.DocumentNode.SelectSingleNode("th/text()").OuterHtml;

                string texto = string.Empty;
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

        /// <summary>
        /// Verifica se o registro foi encontrado
        /// </summary>
        /// <param name="htmlDoc">HtmlDocument a ser análisado</param>
        public void HasNotFoundInformation(HtmlDocument htmlDoc)
        {
            Match node = Regex.Match(htmlDoc.ParsedText, "Registro não encontrado!");
            if (node.Success)
            {
                throw new Exception("Matrícula não encontrada.");
            }
        }
    }
}
