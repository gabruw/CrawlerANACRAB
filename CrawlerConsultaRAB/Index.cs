using CrawlerConsultaRAB.Model;
using System;

namespace CrawlerConsultaRAB
{
    public class Index
    {
        public static void Main(string[] args)
        {
            Navigator Navigator = new Navigator();

            Console.WriteLine("Digite uma chave:");
            string chave = Console.ReadLine().ToUpper();

            Console.Clear();

            Console.WriteLine("Efetuando pesquisas...");

            Navigator.NavToQueryPage(chave);
            Navigator.NavToPDFPage(chave);

            Console.Clear();

            Consulta Consulta = Navigator._consulta;

            // Mostra as capturas na tela
            foreach (Registro captura in Consulta.ListRegistro)
            {
                Console.WriteLine(captura.Indice);

                if (captura.Indice.Contains("Motiv") && captura.Motivo.Count > 0)
                {
                    foreach (string motivo in captura.Motivo)
                    {
                        Console.WriteLine(motivo);
                    }
                }
                else
                {
                    Console.WriteLine(captura.Texto + "\n");
                }
            }

            Console.WriteLine(Consulta.HtmlPDF + "\n");

            Console.ReadKey();
        }
    }
}
