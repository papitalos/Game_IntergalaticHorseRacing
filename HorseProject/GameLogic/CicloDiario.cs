﻿using HorseProject;
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
using System.IO;


namespace HorseProject
{
    public static class CicloDiario
    {
        public static int currentAudio;
        public static Cavalo cavalo;
        public static int numVitoria = 1, escolhaCorrida = BootJogo.escolhaCorrida;
        public static bool pistaAberta = true,lojaAberta = true;
        public static string[] cicloRelogio = new string[4] { "Manhã    ", "Tarde    ", "Noite    ", "Madrugada" };
        public static string[] diasDaSemana = new string[7] { "Segunda-feira         ","Terça-feira           ","Quarta-feira          ","Quinta-feira          ","Sexta-feira           ","Sabado                ","Domingo               " };
        public static string horaDoDiaAtual, diaAtual;                                                                                                                                                                                                                                               
        public static int myDelay = 10000;
        public static int contadorDia = 1, diasSemComer = 0, i;
        public static Thread dia = new Thread(PassarTempo);//Criar uma nova thread para rodar o relogio do dia de maneira independente
        
        public static void Musica(int audio)
        {
            // Reproduz música em background sem bloquear o jogo
            TocarMusica(audio);
        }

        public static void TocarMusica(int audio)
        {
            string audioFile = "";
            
            // Seleciona o arquivo de áudio baseado no parâmetro
            switch (audio)
            {
                case 1:
                    audioFile = "Menu.wav";
                    break;
                case 2:
                    audioFile = "Som_de_trompetas.wav";
                    break;
                case 3:
                    audioFile = "Corrida.wav";
                    break;
                default:
                    Console.WriteLine("⚠️  Código de áudio inválido: " + audio);
                    return;
            }

            // Usa o sistema de áudio em background para não bloquear
            try
            {
                AudioManager.PlayAudioInBackground(audioFile);
                Console.WriteLine($"🎵 Reproduzindo em background: {audioFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️  Erro ao reproduzir áudio: {ex.Message}");
            }
            
            currentAudio = audio;
        }

        public static void SaveGameData(string gameData, string filePath)
        {
            using (StreamWriter file = new StreamWriter(File.Open(filePath, FileMode.Create)))
            {
                file.Write(gameData);
            }
            Console.WriteLine("Informações do jogo salvas com sucesso em: " + filePath);
        }

        /*
        public static string LoadGameData(string filePath, Cavalo cavalo)
        {
            string gameData = File.ReadAllText(filePath);
            Console.WriteLine("Informações do jogo carregadas com sucesso do arquivo: " + filePath);
            AtualiarVariaveis(gameData, cavalo);
            return gameData;
        }

        public static void AtualiarVariaveis(string gameData, Cavalo cavalo)
        {
            cavalo.nome = gameData.nome;
            cavalo.idade = gameData.idade;
            cavalo.id = gameData.id;
            cavalo.VMax = gameData.VMax;
            cavalo.valor = gameData.valor;
            cavalo.a = gameData.a;
            cavalo.r = gameData.r;

        }*/

        public static void ThreadTimerDiario()
        {

            while (BootJogo.estaRodando == true)
            {
              
                if (BootJogo.menuAtual == BootJogo.menu.menuEscolhaInicial || BootJogo.menuAtual == BootJogo.menu.menuInicial || BootJogo.menuAtual == BootJogo.menu.menuLoading)
                {
                    dia.Suspend();
                }
                else if(BootJogo.menuAtual == BootJogo.menu.menuSleep)
                {
                    dia.Abort();
                    i = 0;
                    dia.Start();
                }
                else
                {
                    dia.Resume();
                }
            }
            
           

        }
        //Método que altera o estado de Doença
        public static void CicloDoenca(Cavalo cavalo)
        {
            double diferenca;
            diferenca = cavalo.KgInicial - cavalo.Kg;

            if (diferenca >= 50)
            {
                Cavalo.contadorDoenca = Cavalo.contadorDoenca + 1;
            }

        }




        public static void PassarTempo()
        {

            while (BootJogo.estaRodando == true)
            {
                for (contadorDia = 0; contadorDia < 7; contadorDia++)
                {
                    lojaAberta = true;
                    pistaAberta = true;
                    diaAtual = diasDaSemana[contadorDia];

                    for (i = 0; i < 4; i++)
                    {

                        horaDoDiaAtual = cicloRelogio[i];


                        //randomizar estado da pista
                        int randomizeEstados = Randomize.rdm.Next(1, 4);
                        Pista.condicoesPistaAtual = Pista.possiveisEstados[randomizeEstados];




                        //determinar se a pista esta aberta ou fechada dependendo do periodo do dia
                        if (i == 0 || i == 1)
                        {
                            pistaAberta = true;
                            lojaAberta = true;
                        }
                        if (i == 2)
                        {
                            pistaAberta = false;
                            lojaAberta = true;
                        }
                        if (i == 3)
                        {
                            pistaAberta = false;
                            lojaAberta = false;
                        }



                        if (BootJogo.menuAtual == BootJogo.menu.menuJogos)
                        {
                            switch (BootJogo.subMenuAtual)
                            {
                                case BootJogo.menu.subMenuCeleiro:
                                    Console.Clear();
                                    Graficos.SubMenuCeleiro();
                                    break;
                                case BootJogo.menu.subMenuCorridas:
                                    Console.Clear();
                                    Graficos.SubMenuCorrida(escolhaCorrida, numVitoria, cavalo);
                                    break;
                                case BootJogo.menu.subMenuLoja:
                                    break;
                            }
                        }


                        if (i != 3)
                        {
                            Thread.Sleep(myDelay);
                        }
                        if (i == 3)
                        {
                            Thread.Sleep(2000);
                            BootJogo.menuSleep();

                        }
                        while (BootJogo.menuAtual == BootJogo.menu.menuSleep) ;
                        
                    }
                    Thread.Sleep(2000);


                }
                CicloDoenca(cavalo);

            }
            contadorDia = 0;
            diaAtual = diasDaSemana[0];
        }
    }
}






