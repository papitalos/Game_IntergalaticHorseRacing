using HorseProject;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace HorseProject
{
    public static class CicloDiario
    {
        public static Cavalo cavalo;
        public static int numVitoria = 1, escolhaCorrida = BootJogo.escolhaCorrida;
        public static bool pistaAberta;
        public static string[] cicloRelogio = new string[4] { "Manhã    ", "Tarde    ", "Noite    ", "Madrugada" };
        public static string[] possiveisEstados = new string[4] { "Neve    ", "Chuva   ", "Nevoeiro", "Limpo   " };
        public static string condicoesPista, horaDoDia;
        public static int myDelay = 5000;


        public static void ThreadTimerDiario()
        {
            //Criar uma nova thread para rodar o relogio do dia de maneira independente
            Thread dia = new Thread(PassarTempo);
            dia.Start();



        }

        public static void PassarTempo()
        {

            //mudar os periodos do dia
            for (int i = 0; i < 4; i++)
            {
                horaDoDia = cicloRelogio[i];


                //randomizar estado da pista
                Random rdm = new Random();
                int randomize = rdm.Next(1, 4);
                condicoesPista = possiveisEstados[randomize];




                //determinar se a pista esta aberta ou fechada dependendo do periodo do dia
                if (i == 0 || i == 1)
                {
                    pistaAberta = true;
                }
                else
                {
                    pistaAberta = false;
                }



                if(BootJogo.menuAtual == BootJogo.menu.menuJogos)
                {
                    switch (BootJogo.subMenuAtual)
                    {
                        case BootJogo.menu.subMenuCeleiro:
                            Console.Clear();
                            Graficos.SubMenuCeleiro();
                            break;
                        case BootJogo.menu.subMenuCorridas:
                            Console.Clear();
                            Graficos.SubMenuCorrida(escolhaCorrida,numVitoria, cavalo);
                            break;
                        case BootJogo.menu.subMenuLoja:
                            break;
                    }
                }

                Thread.Sleep(myDelay);
            }


        }
    }
}






