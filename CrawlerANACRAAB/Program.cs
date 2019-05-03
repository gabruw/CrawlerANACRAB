using CrawlerANACRAB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var htmlPDF = newNavigator.NavPDF(chave);

            foreach (var cap in capDados)
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

            Console.ReadKey();
        }
    }
}