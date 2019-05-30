using CrawlerANACRAB;
using System;

namespace CrawlerANACRAAB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Navigator newNavigator = new Navigator();

            Console.WriteLine("Digite uma chave:");
            var chave = Console.ReadLine().ToUpper();

            Console.Clear();

            var capDados = newNavigator.NavPrincipal(chave);
            newNavigator.NavPDF(chave);

            Consulta newConsulta = newNavigator.newConsulta;

            foreach (var cap in newConsulta.ListRegistro)
            {
                Console.WriteLine(cap.Indice);

                if (cap.Indice.Contains("Motiv") && cap.Motivo.Count > 0)
                {
                    foreach(var mot in cap.Motivo)
                    {
                        Console.WriteLine(mot);
                    }
                }
                else
                {
                    Console.WriteLine(cap.Texto + "\n");
                }
            }

            Console.WriteLine(newConsulta.HtmlPDF + "\n");

            Console.ReadKey();
        }
    }
}