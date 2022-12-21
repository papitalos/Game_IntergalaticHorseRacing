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
        public static bool pistaAberta;
        public static string[] cicloRelogio = new string[4] {"manhã    ", "tarde    ","noite    ", "madrugada"};
        public static string[] possiveisEstados = new string[4] { "neve    ", "chuva   ", "nevoeiro", "limpo   " };
        public static string condicoesPista, horaDoDia;
        public static int myDelay = 3000;

      
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


                Console.WriteLine("PASSOU!");

                Thread.Sleep(myDelay);
            }
         
            
        }

        /*public static void AtualizarGraficos(int posiçaoVitoria, Cavalo cavalo)
        {
            Console.Clear();
            BootJogo.menu menuAtual, subMenuAtual;
            menuAtual = BootJogo.menuAtual;
            subMenuAtual = BootJogo.subMenuAtual;
            if(menuAtual == BootJogo.menu.menuJogos && subMenuAtual == BootJogo.menu.subMenuCeleiro)
            {
                Graficos.SubMenuCeleiro();
            }
            else if (menuAtual == BootJogo.menu.menuJogos && subMenuAtual == BootJogo.menu.subMenuCorridas)
            {
                Graficos.SubMenuCorrida(0, posiçaoVitoria, cavalo);
            }
            else if (menuAtual == BootJogo.menu.menuJogos && subMenuAtual == BootJogo.menu.subMenuLoja)
            {
                
            }
        }*/

    }
}




