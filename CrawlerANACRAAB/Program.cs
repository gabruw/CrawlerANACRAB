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
            FormUtils newForm = new FormUtils();
            Navigator newNavigator = new Navigator();

            Console.WriteLine("Digite uma chave:");
            var chave = Console.ReadLine().ToUpper();

            Console.Clear();

            var url = newForm.UrlBuilder(chave);
            var capturas = newNavigator.NavResultado(url);

            foreach(var cap in capturas)
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