using CrawlerConsultaRAB.Model;
using System;

namespace CrawlerConsultaRAB
{
    public class Index
    {
        /*
         Chaves para teste:
         PRATA
         PTHGP
         PTFTP
         PTCPD
         PTKGB
         PTRTC
         PTTCC
         PTYEL
         PTJFP
         PTLSD
         PTFFG
        */

        public static void Main(string[] args)
        {
            Index index = new Index();
            index.Menu();
        }

        private void Menu()
        {
            ConsultaRAB();

            Console.WriteLine("<> Deseja efetuar uma nova consulta? [S/N]");
            string option = Console.ReadLine().ToUpper();

            Console.Clear();

            switch (option)
            {
                case "S":
                case "SIM":
                    Menu();
                    break;
                case "N":
                case "NAO":
                default:
                    Console.WriteLine("Obrigado por utilizar o programa.");
                    break;
            }
        }

        private void ConsultaRAB()
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
            Console.WriteLine("----------------------------------------------------------------------------------------");
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

            Console.WriteLine("\nLink do PDF:");
            Console.WriteLine(Consulta.HtmlPDF + "\n");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }
    }
}
