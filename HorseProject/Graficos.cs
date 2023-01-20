using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{

    static public class Graficos
    {
        static public string[] data = new string[4] { "00/00/00", "00/00/00", "00/00/00", "00/00/00" }, hora = new string[4] { "00:00", "00:00", "00:00", "00:00" };


        static public void MenuInicial()
        {
            void PrintColoredText(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }


            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                              "│           Menu          │            *clique na tecla para ação*            │\r\n" +
                              "│─────────────────────────│───────────────────────────────────────────────────│\r\n" +
                              "│                         │                                                   │\r\n" +
                              "│                         │                                                   │\r\n" +
                              "│-» "); PrintColoredText("JOGAR", ConsoleColor.Green); Console.Write("[ENTER]          │                                                   │\r\n" +
                              "│                         │                        ~~%%%%%%%% _,_,            │\r\n" +
                              "│-» "); PrintColoredText("CARREGAR", ConsoleColor.Yellow); Console.Write("[TAB]         │                       ~~%%%%%%%%% -|/./           │\r\n" +
                              "│                         │                     ~~%%%%%%% -'   /  `.          │\r\n" +
                              "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                   ~~%%%%%%%% '  .     ,__;        │\r\n" +
                              "│                         │                 ~~%%%%%%%% '   :      .|O|        │\r\n" +
                              "│                         │               ~~%%%%%%%% '    :          `.       │\r\n" +
                              "│                         │             ~~%%%%%%%% '       `. _,        '     │\r\n" +
                              "│                         │           ~~%%%%%%%% '          .'`-._        `.  │\r\n" +
                              "│                         │         ~~%%%%%%%%% '           :     `-.     (,; │\r\n" +
                              "│                         │       ~~%%%%%%%% '             :         `._||_.' │\r\n" +
                              "│                         │     ~~%% jgs %% '              :                  │\r\n" +
                              "│                         │    ~~%%%%%%%% '                :                  │\r\n" +
                              "│                         │                                                   │\r\n" +
                              "│                         │                                                   │\r\n" +
                              "│                         │             INTERGALATIC HORSE RACING             │\r\n" +
                              "│                         │                                                   │\r\n" +
                              "└─────────────────────────┴───────────────────────────────────────────────────┘");
        }
        static public void MenuLoading(int qntdSaves)
        {
            void PrintColoredText(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }

            switch (qntdSaves)
            {
                case 1:
                    Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                      "│           Menu          │                 SEUS SAVES (Max.4)                │\r\n" +
                                      "│─────────────────────────│───────────────────────────────────────────────────│\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                  ┌──────────────────────────┐     │\r\n" +
                                      "│-» "); PrintColoredText("JOGAR", ConsoleColor.Green); Console.Write("[ENTER]          │     SLOT[1]  »»  │ " + data[0] + "           " + hora[0] + " │     │\r\n" +
                                      "│                         │                  └──────────────────────────┘     │\r\n" +
                                      "│-» "); PrintColoredText("CARREGAR", ConsoleColor.Yellow); Console.Write("[TAB]         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │     NOVO SLOT [A]                                 │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "└─────────────────────────┴───────────────────────────────────────────────────┘");
                    break;
                case 2:
                    Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                      "│           Menu          │                 SEUS SAVES (Max.4)                │\r\n" +
                                      "│─────────────────────────│───────────────────────────────────────────────────│\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                  ┌──────────────────────────┐     │\r\n" +
                                      "│-» "); PrintColoredText("JOGAR", ConsoleColor.Green); Console.Write("[ENTER]          │     SLOT[1]  »»  │ " + data[0] + "           " + hora[0] + " │     │\r\n" +
                                      "│                         │                  └──────────────────────────┘     │\r\n" +
                                      "│-» "); PrintColoredText("CARREGAR", ConsoleColor.Yellow); Console.Write("[TAB]         │                                                   │\r\n" +
                                      "│                         │                  ┌──────────────────────────┐     │\r\n" +
                                      "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │     SLOT[2]  »»  │ " + data[1] + "           " + hora[1] + " │     │\r\n" +
                                      "│                         │                  └──────────────────────────┘     │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │     NOVO SLOT [A]             APAGAR SLOT [D]     │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "└─────────────────────────┴───────────────────────────────────────────────────┘");
                    break;
                case 3:
                    Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                      "│           Menu          │                 SEUS SAVES (Max.4)                │\r\n" +
                                      "│─────────────────────────│───────────────────────────────────────────────────│\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                  ┌──────────────────────────┐     │\r\n" +
                                      "│-» "); PrintColoredText("JOGAR", ConsoleColor.Green); Console.Write("[ENTER]          │     SLOT[1]  »»  │ " + data[0] + "           " + hora[0] + " │     │\r\n" +
                                      "│                         │                  └──────────────────────────┘     │\r\n" +
                                      "│-» "); PrintColoredText("CARREGAR", ConsoleColor.Yellow); Console.Write("[TAB]         │                                                   │\r\n" +
                                      "│                         │                  ┌──────────────────────────┐     │\r\n" +
                                      "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │     SLOT[2]  »»  │ " + data[1] + "           " + hora[1] + " │     │\r\n" +
                                      "│                         │                  └──────────────────────────┘     │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                  ┌──────────────────────────┐     │\r\n" +
                                      "│                         │     SLOT[3]  »»  │ " + data[2] + "           " + hora[2] + " │     │\r\n" +
                                      "│                         │                  └──────────────────────────┘     │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │     NOVO SLOT [A]             APAGAR SLOT [D]     │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "└─────────────────────────┴───────────────────────────────────────────────────┘");
                    break;
                case 4:
                    Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                      "│           Menu          │                 SEUS SAVES (Max.4)                │\r\n" +
                                      "│─────────────────────────│───────────────────────────────────────────────────│\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                  ┌──────────────────────────┐     │\r\n" +
                                      "│-» "); PrintColoredText("JOGAR", ConsoleColor.Green); Console.Write("[ENTER]          │     SLOT[1]  »»  │ " + data[0] + "           " + hora[0] + " │     │\r\n" +
                                      "│                         │                  └──────────────────────────┘     │\r\n" +
                                      "│-» "); PrintColoredText("CARREGAR", ConsoleColor.Yellow); Console.Write("[TAB]         │                                                   │\r\n" +
                                      "│                         │                  ┌──────────────────────────┐     │\r\n" +
                                      "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │     SLOT[2]  »»  │ " + data[1] + "           " + hora[1] + " │     │\r\n" +
                                      "│                         │                  └──────────────────────────┘     │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                  ┌──────────────────────────┐     │\r\n" +
                                      "│                         │     SLOT[3]  »»  │ " + data[2] + "           " + hora[2] + " │     │\r\n" +
                                      "│                         │                  └──────────────────────────┘     │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                  ┌──────────────────────────┐     │\r\n" +
                                      "│                         │     SLOT[4]  »»  │ " + data[3] + "           " + hora[3] + " │     │\r\n" +
                                      "│                         │                  └──────────────────────────┘     │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │     APAGAR SLOT [D]                               │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "└─────────────────────────┴───────────────────────────────────────────────────┘");
                    break;
                default:
                    Console.WriteLine("ERRO NA QUANTIDADE DE SAVES");
                    break;
            }

        }
        static public void MenuEscolhaInicial(int escolha)
        {
            void PrintColoredText(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }
            switch (escolha)
            {

                case 1:
                    Console.Write("┌──────────────────────────────────────────────────────────────────────────────┐\r\n" +
                                      "│                         "); PrintColoredText("ESCOLHA SEU CAVALO INICIAL", ConsoleColor.Red); Console.WriteLine("                           │\r\n" +
                                      "│──────────────────────────────────────────────────────────────────────────────│\r\n" +
                                      "│            *Seu cavalo inicial é um Noob Imortal, literalmente*              │\r\n" +
                                      "│                                                                              │\r\n" +
                                      "│            ▼                                                                 │\r\n" +
                                      "│  ┌────────────────────┐    ┌────────────────────┐    ┌────────────────────┐  │\r\n" +
                                      "│  | Pangaré Desnutrido |    |  Montaria Peluda   |    |    Corsel Burro    |  │\r\n" +
                                      "│  |────────────────────|    |────────────────────|    |────────────────────|  │\r\n" +
                                      "│  |                    |    |                    |    |                    |  │\r\n" +
                                      "│  |   raça: ÁRABE      |    |   raça: ÁRABE      |    |   raça: ÁRABE      |  │\r\n" +
                                      "│  |   idade: 5 anos    |    |   idade: 5 anos    |    |   idade: 5 anos    |  │\r\n" +
                                      "│  |   peso: 150kg      |    |   peso: 150kg      |    |   peso: 150kg      |  │\r\n" +
                                      "│  |                    |    |                    |    |                    |  │\r\n" +
                                      "│  |   Resistencia      |    |   Resistencia      |    |   Resistencia      |  │\r\n" +
                                      "│  |   ■¤¤¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■■¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■¤¤¤¤¤¤¤¤¤¤¤¤  |  │\r\n" +
                                      "│  |   Aceleração       |    |   Aceleração       |    |   Aceleração       |  │\r\n" +
                                      "│  |   ■■■¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■¤¤¤¤¤¤¤¤¤¤¤¤¤¤  |  │\r\n" +
                                      "│  |   Velocidade       |    |   Velocidade       |    |   Velocidade       |  │\r\n" +
                                      "│  |   ■■■■¤¤¤¤¤¤¤¤¤¤¤  |    |   ■¤¤¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■■¤¤¤¤¤¤¤¤¤¤¤  |  │\r\n" +
                                      "│  |                    |    |                    |    |                    |  │\r\n" +
                                      "│  └────────────────────┘    └────────────────────┘    └────────────────────┘  │\r\n" +
                                      "│            ▲                                                                 │\r\n" +
                                      "└──────────────────────────────────────────────────────────────────────────────┘");
                    break;
                case 2:
                    Console.Write("┌──────────────────────────────────────────────────────────────────────────────┐\r\n" +
                                      "│                         "); PrintColoredText("ESCOLHA SEU CAVALO INICIAL", ConsoleColor.Red); Console.WriteLine("                           │\r\n" +
                                      "│──────────────────────────────────────────────────────────────────────────────│\r\n" +
                                      "│            *Seu cavalo inicial é um Noob Imortal, literalmente*              │\r\n" +
                                      "│                                                                              │\r\n" +
                                      "│                                       ▼                                      │\r\n" +
                                      "│  ┌────────────────────┐    ┌────────────────────┐    ┌────────────────────┐  │\r\n" +
                                      "│  | Pangaré Desnutrido |    |  Montaria Peluda   |    |    Corsel Burro    |  │\r\n" +
                                      "│  |────────────────────|    |────────────────────|    |────────────────────|  │\r\n" +
                                      "│  |                    |    |                    |    |                    |  │\r\n" +
                                      "│  |   raça: ÁRABE      |    |   raça: ÁRABE      |    |   raça: ÁRABE      |  │\r\n" +
                                      "│  |   idade: 5 anos    |    |   idade: 5 anos    |    |   idade: 5 anos    |  │\r\n" +
                                      "│  |   peso: 150kg      |    |   peso: 150kg      |    |   peso: 150kg      |  │\r\n" +
                                      "│  |                    |    |                    |    |                    |  │\r\n" +
                                      "│  |   Resistencia      |    |   Resistencia      |    |   Resistencia      |  │\r\n" +
                                      "│  |   ■¤¤¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■■¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■¤¤¤¤¤¤¤¤¤¤¤¤  |  │\r\n" +
                                      "│  |   Aceleração       |    |   Aceleração       |    |   Aceleração       |  │\r\n" +
                                      "│  |   ■■■¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■¤¤¤¤¤¤¤¤¤¤¤¤¤¤  |  │\r\n" +
                                      "│  |   Velocidade       |    |   Velocidade       |    |   Velocidade       |  │\r\n" +
                                      "│  |   ■■■■¤¤¤¤¤¤¤¤¤¤¤  |    |   ■¤¤¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■■¤¤¤¤¤¤¤¤¤¤¤  |  │\r\n" +
                                      "│  |                    |    |                    |    |                    |  │\r\n" +
                                      "│  └────────────────────┘    └────────────────────┘    └────────────────────┘  │\r\n" +
                                      "│                                       ▲                                      │\r\n" +
                                      "└──────────────────────────────────────────────────────────────────────────────┘");
                    break;
                case 3:
                    Console.Write("┌──────────────────────────────────────────────────────────────────────────────┐\r\n" +
                                      "│                         "); PrintColoredText("ESCOLHA SEU CAVALO INICIAL", ConsoleColor.Red); Console.WriteLine("                           │\r\n" +
                                      "│──────────────────────────────────────────────────────────────────────────────│\r\n" +
                                      "│            *Seu cavalo inicial é um Noob Imortal, literalmente*              │\r\n" +
                                      "│                                                                              │\r\n" +
                                      "│                                                                ▼             │\r\n" +
                                      "│  ┌────────────────────┐    ┌────────────────────┐    ┌────────────────────┐  │\r\n" +
                                      "│  | Pangaré Desnutrido |    |  Montaria Peluda   |    |    Corsel Burro    |  │\r\n" +
                                      "│  |────────────────────|    |────────────────────|    |────────────────────|  │\r\n" +
                                      "│  |                    |    |                    |    |                    |  │\r\n" +
                                      "│  |   raça: ÁRABE      |    |   raça: ÁRABE      |    |   raça: ÁRABE      |  │\r\n" +
                                      "│  |   idade: 5 anos    |    |   idade: 5 anos    |    |   idade: 5 anos    |  │\r\n" +
                                      "│  |   peso: 150kg      |    |   peso: 150kg      |    |   peso: 150kg      |  │\r\n" +
                                      "│  |                    |    |                    |    |                    |  │\r\n" +
                                      "│  |   Resistencia      |    |   Resistencia      |    |   Resistencia      |  │\r\n" +
                                      "│  |   ■¤¤¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■■¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■¤¤¤¤¤¤¤¤¤¤¤¤  |  │\r\n" +
                                      "│  |   Aceleração       |    |   Aceleração       |    |   Aceleração       |  │\r\n" +
                                      "│  |   ■■■¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■¤¤¤¤¤¤¤¤¤¤¤¤¤¤  |  │\r\n" +
                                      "│  |   Velocidade       |    |   Velocidade       |    |   Velocidade       |  │\r\n" +
                                      "│  |   ■■■■¤¤¤¤¤¤¤¤¤¤¤  |    |   ■¤¤¤¤¤¤¤¤¤¤¤¤¤¤  |    |   ■■■■¤¤¤¤¤¤¤¤¤¤¤  |  │\r\n" +
                                      "│  |                    |    |                    |    |                    |  │\r\n" +
                                      "│  └────────────────────┘    └────────────────────┘    └────────────────────┘  │\r\n" +
                                      "│                                                                ▲             │\r\n" +
                                      "└──────────────────────────────────────────────────────────────────────────────┘");
                    break;
                default:
                    Console.WriteLine("ERRO NA SELEÇÃO DO CAVALO INICIAL");
                    break;
            }

        }
        static public void SubMenuCorrida(int escolha, int posicaoVitoria, Cavalo cavalo)
        {
            void PrintColoredText(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }
            if (CicloDiario.diaAtual != "Domingo               ")
            {
                switch (escolha)
                {
                    case 1:
                        if (posicaoVitoria == 1)
                        {
                            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                              "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │      CORRIDAS (Equipe seu cavalo no celeiro)      │\r\n" +
                                              "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                              "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                              "│  Carteira »  " + Player.Carteira + " ß    │ [h] » help?                                       │\r\n" +
                                              "│─────────────────────────│                        1º                         │\r\n" +
                                              "│                         │              ┌────────────────────┐               │\r\n" +
                                              "│                         │              │ " + cavalo.nome + "│               │\r\n" +
                                              "│                         │              └────────────────────┘               │\r\n" +
                                              "│                         │           2º                                      │\r\n" +
                                              "│-» CORRIDAS[ENTER]       │ ┌────────────────────┐              3º            │\r\n" +
                                              "│                         │ │                    │     ┌────────────────────┐ │\r\n" +
                                              "│-» CELEIRO[I]            │ └────────────────────┘     │                    │ │\r\n" +
                                              "│                         │                            └────────────────────┘ │\r\n" +
                                              "│-» LOJA[L]               │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» INVENTARIO[E]         │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│─────────────────────────│                                                   │\r\n" +
                                              "│                         │         _____|---»   VITORIA   «---|_____         │\r\n" +
                                              "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        }
                        else if (posicaoVitoria == 2)
                        {
                            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                              "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │      CORRIDAS (Equipe seu cavalo no celeiro)      │\r\n" +
                                              "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                             "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                             "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                             "│─────────────────────────│                        1º                         │\r\n" +
                                             "│                         │              ┌────────────────────┐               │\r\n" +
                                             "│                         │              │                    │               │\r\n" +
                                             "│                         │              └────────────────────┘               │\r\n" +
                                             "│                         │           2º                                      │\r\n" +
                                             "│-» CORRIDAS[ENTER]       │ ┌────────────────────┐              3º            │\r\n" +
                                             "│                         │ │ " + cavalo.nome + "│     ┌────────────────────┐ │\r\n" +
                                             "│-» CELEIRO[I]            │ └────────────────────┘     │                    │ │\r\n" +
                                             "│                         │                            └────────────────────┘ │\r\n" +
                                             "│-» LOJA[L]               │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│-» INVENTARIO[E]         │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│─────────────────────────│                                                   │\r\n" +
                                             "│                         │         _____|---»   VITORIA   «---|_____         │\r\n" +
                                             "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        }
                        else if (posicaoVitoria == 3)
                        {
                            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                              "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │      CORRIDAS (Equipe seu cavalo no celeiro)      │\r\n" +
                                              "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                             "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                             "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                             "│─────────────────────────│                        1º                         │\r\n" +
                                             "│                         │              ┌────────────────────┐               │\r\n" +
                                             "│                         │              │                    │               │\r\n" +
                                             "│                         │              └────────────────────┘               │\r\n" +
                                             "│                         │           2º                                      │\r\n" +
                                             "│-» CORRIDAS[ENTER]       │ ┌────────────────────┐              3º            │\r\n" +
                                             "│                         │ │                    │     ┌────────────────────┐ │\r\n" +
                                             "│-» CELEIRO[I]            │ └────────────────────┘     │ " + cavalo.nome + "│ │\r\n" +
                                             "│                         │                            └────────────────────┘ │\r\n" +
                                             "│-» LOJA[L]               │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│-» INVENTARIO[E]         │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│─────────────────────────│                                                   │\r\n" +
                                             "│                         │         _____|---»   VITORIA   «---|_____         │\r\n" +
                                             "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        }
                        else if (posicaoVitoria == 4)
                        {
                            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                              "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │      CORRIDAS (Equipe seu cavalo no celeiro)      │\r\n" +
                                              "│ » " + CicloDiario.diaAtual + "│                                                  │\r\n" +
                                             "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                             "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                             "│─────────────────────────│                        1º                         │\r\n" +
                                             "│                         │              ┌────────────────────┐               │\r\n" +
                                             "│                         │              │                    │               │\r\n" +
                                             "│                         │              └────────────────────┘               │\r\n" +
                                             "│                         │           2º                                      │\r\n" +
                                             "│-» CORRIDAS[ENTER]       │ ┌────────────────────┐              3º            │\r\n" +
                                             "│                         │ │                    │     ┌────────────────────┐ │\r\n" +
                                             "│-» CELEIRO[I]            │ └────────────────────┘     │                    │ │\r\n" +
                                             "│                         │                            └────────────────────┘ │\r\n" +
                                             "│-» LOJA[L]               │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│-» INVENTARIO[E]         │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│─────────────────────────│                                                   │\r\n" +
                                             "│                         │         _____|---»   DERROTA   «---|_____         │\r\n" +
                                             "│-» "); PrintColoredText("Voltar", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        }
                        break;
                    case 2:
                        if (posicaoVitoria == 1)
                        {
                            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                              "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │      CORRIDAS (Equipe seu cavalo no celeiro)      │\r\n" +
                                              "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                              "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                              "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                              "│─────────────────────────│                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» CORRIDAS[ENTER]       │ ┌────────────────────┐     ┌────────────────────┐ │\r\n" +
                                              "│                         │ │ " + cavalo.nome + "│  x  │                    │ │\r\n" +
                                              "│-» CELEIRO[I]            │ └────────────────────┘     └────────────────────┘ │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» LOJA[L]               │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» INVENTARIO[E]         │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│─────────────────────────│                                                   │\r\n" +
                                              "│                         │         _____|---»   VITORIA   «---|_____         │\r\n" +
                                              "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        }
                        else if (posicaoVitoria == 2)
                        {
                            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                              "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │      CORRIDAS (Equipe seu cavalo no celeiro)      │\r\n" +
                                              "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                              "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                              "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                              "│─────────────────────────│                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» CORRIDAS[ENTER]       │ ┌────────────────────┐     ┌────────────────────┐ │\r\n" +
                                              "│                         │ │                    │  x  │ " + cavalo.nome + "│ │\r\n" +
                                              "│-» CELEIRO[I]            │ └────────────────────┘     └────────────────────┘ │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» LOJA[L]               │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» INVENTARIO[E]         │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│─────────────────────────│                                                   │\r\n" +
                                              "│                         │         _____|---»   DERROTA   «---|_____         │\r\n" +
                                              "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        }
                        break;
                    default:
                        Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                      "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │       CORRIDAS (Equipe seu cavalo no celeiro)     │\r\n" +
                                      "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                      "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                      "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                      "│─────────────────────────│                                                   │\r\n" +
                                      "│                         │ Casual » Recompensas para 1º, 2º e 3º lugar       │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│                         │ Resistencia » 1x1 com recompensas para o vencedor │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│-» CORRIDAS[ENTER]       │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│-» CELEIRO[I]            │                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│-» LOJA[L]               │                    Esta Pronto?                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│-» INVENTARIO[E]         │                ESCOLHA SUA CORRIDA                │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│─────────────────────────│                                                   │\r\n" +
                                      "│                         │                                                   │\r\n" +
                                      "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │              [1]                    [2]           │\r\n" +
                                      "│                         │         ┌───────────┐          ┌───────────┐      │\r\n" +
                                      "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │         │  CASUAL   │          │RESISTENCIA│      │\r\n" +
                                      "│                         │         └───────────┘          └───────────┘      │\r\n" +
                                      "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        break;
                }
            }
            else
            {
                switch (escolha)
                {
                    case 1:
                        if (posicaoVitoria == 1)
                        {
                            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                              "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │      CORRIDAS (Equipe seu cavalo no celeiro)      │\r\n" +
                                              "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                              "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                              "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                              "│─────────────────────────│                        1º                         │\r\n" +
                                              "│                         │              ┌────────────────────┐               │\r\n" +
                                              "│                         │              │ " + cavalo.nome + "│               │\r\n" +
                                              "│                         │              └────────────────────┘               │\r\n" +
                                              "│                         │           2º                                      │\r\n" +
                                              "│-» CORRIDAS[ENTER]       │ ┌────────────────────┐              3º            │\r\n" +
                                              "│                         │ │                    │     ┌────────────────────┐ │\r\n" +
                                              "│-» CELEIRO[I]            │ └────────────────────┘     │                    │ │\r\n" +
                                              "│                         │                            └────────────────────┘ │\r\n" +
                                              "│-» LOJA[L]               │                                                   │\r\n" +
                                              "│                         │                      00/03  ⇡                     │\r\n" +
                                              "│-» INVENTARIO[E]         │            Corridas para subir o rank             │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│─────────────────────────│                                                   │\r\n" +
                                              "│                         │         _____|---»   VITORIA   «---|_____         │\r\n" +
                                              "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │             Rank Atual:" + "              │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        }
                        else if (posicaoVitoria == 2)
                        {
                            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                              "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │      CORRIDAS (Equipe seu cavalo no celeiro)      │\r\n" +
                                              "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                              "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                              "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                              "│─────────────────────────│                        1º                         │\r\n" +
                                              "│                         │              ┌────────────────────┐               │\r\n" +
                                              "│                         │              │                    │               │\r\n" +
                                              "│                         │              └────────────────────┘               │\r\n" +
                                              "│                         │           2º                                      │\r\n" +
                                              "│-» CORRIDAS[ENTER]       │ ┌────────────────────┐              3º            │\r\n" +
                                              "│                         │ │ " + cavalo.nome + "│     ┌────────────────────┐ │\r\n" +
                                              "│-» CELEIRO[I]            │ └────────────────────┘     │                    │ │\r\n" +
                                              "│                         │                            └────────────────────┘ │\r\n" +
                                              "│-» LOJA[L]               │                                                   │\r\n" +
                                              "│                         │                      00/03  ⇡                     │\r\n" +
                                              "│-» INVENTARIO[E]         │            Corridas para subir o rank             │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│─────────────────────────│                                                   │\r\n" +
                                              "│                         │         _____|---»   VITORIA   «---|_____         │\r\n" +
                                              "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "└─────────────────────────┴───────────────────────────────────────────────────┘");

                        }
                        else if (posicaoVitoria == 3)
                        {
                            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                              "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │      CORRIDAS (Equipe seu cavalo no celeiro)      │\r\n" +
                                              "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                              "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                              "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                              "│─────────────────────────│                        1º                         │\r\n" +
                                              "│                         │              ┌────────────────────┐               │\r\n" +
                                              "│                         │              │                    │               │\r\n" +
                                              "│                         │              └────────────────────┘               │\r\n" +
                                              "│                         │           2º                                      │\r\n" +
                                              "│-» CORRIDAS[ENTER]       │ ┌────────────────────┐              3º            │\r\n" +
                                              "│                         │ │                    │     ┌────────────────────┐ │\r\n" +
                                              "│-» CELEIRO[I]            │ └────────────────────┘     │ " + cavalo.nome + "│ │\r\n" +
                                              "│                         │                            └────────────────────┘ │\r\n" +
                                              "│-» LOJA[L]               │                                                   │\r\n" +
                                              "│                         │                      00/03  ⇡                     │\r\n" +
                                              "│-» INVENTARIO[E]         │            Corridas para subir o rank             │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│─────────────────────────│                                                   │\r\n" +
                                              "│                         │         _____|---»   VITORIA   «---|_____         │\r\n" +
                                              "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                                                   │\r\n" +
                                              "│                         │                                                   │\r\n" +
                                              "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        }
                        else if (posicaoVitoria == 4)
                        {
                            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                              "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │      CORRIDAS (Equipe seu cavalo no celeiro)      │\r\n" +
                                              "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                             "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                             "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                             "│─────────────────────────│                        1º                         │\r\n" +
                                             "│                         │              ┌────────────────────┐               │\r\n" +
                                             "│                         │              │                    │               │\r\n" +
                                             "│                         │              └────────────────────┘               │\r\n" +
                                             "│                         │           2º                                      │\r\n" +
                                             "│-» CORRIDAS[ENTER]       │ ┌────────────────────┐              3º            │\r\n" +
                                             "│                         │ │                    │     ┌────────────────────┐ │\r\n" +
                                             "│-» CELEIRO[I]            │ └────────────────────┘     │                    │ │\r\n" +
                                             "│                         │                            └────────────────────┘ │\r\n" +
                                             "│-» LOJA[L]               │                                                   │\r\n" +
                                             "│                         │                       00/03  ⇣                    │\r\n" +
                                             "│-» INVENTARIO[E]         │             Corridas para subir o rank            │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│─────────────────────────│                                                   │\r\n" +
                                             "│                         │         _____|---»   DERROTA   «---|_____         │\r\n" +
                                             "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                                                   │\r\n" +
                                             "│                         │                                                   │\r\n" +
                                             "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        }
                        break;
                    default:

                        Console.Write(    "┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                          "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │       CORRIDAS (Equipe seu cavalo no celeiro)     │\r\n" +
                                          "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                          "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                          "│  Carteira »  10.000 ß   │ [h] » help?                                       │\r\n" +
                                          "│─────────────────────────│                                                   │\r\n" +
                                          "│                         │ Ranked » Suba de ligas ao ficar no top 3 e ganhe  │\r\n" +
                                          "│                         │          recompensas                              │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» CORRIDAS[ENTER]       │                                                   │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» CELEIRO[I]            │                                                   │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» LOJA[L]               │                    Esta Pronto?                   │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» INVENTARIO[E]         │                ESCOLHA SUA CORRIDA                │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│─────────────────────────│                                                   │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                        [1]                        │\r\n" +
                                          "│                         │                   ┌───────────┐                   │\r\n" +
                                          "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                   │  RANKED   │                   │\r\n" +
                                          "│                         │                   └───────────┘                   │\r\n" +
                                          "└─────────────────────────┴───────────────────────────────────────────────────┘");
                        break;
                }
            
            }
            
               

        }
        static public void SubMenuCeleiro()
        {
            void PrintColoredText(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }
            Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                          "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │                   CELEIRO (Max.4)                 │\r\n" +
                                          "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                          "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                          "│  Carteira »  " + Player.Carteira + " ß    │ [h] » help?                                       │\r\n" +
                                          "│─────────────────────────│                                                   │\r\n" +
                                          "│                         │        » Selecione o cavalo que deseja ver «      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│                         │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [1] │  Pangare Desnutrido  │                      │\r\n" +
                                          "│-» CORRIDAS[ENTER]       │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» CELEIRO[I]            │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [2] │  Puro Sangue Inglês  │                      │\r\n" +
                                          "│-» LOJA[L]               │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» INVENTARIO[E]         │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [3] │  Pedro Pereira       │                      │\r\n" +
                                          "│─────────────────────────│     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [4] │  Silveira            │                      │\r\n" +
                                          "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "└─────────────────────────┴───────────────────────────────────────────────────┘");
        }



        static public void SubMenuLoja(int escolha)
        {
            void PrintColoredText(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }

            switch (escolha)
            {
                case 4:
                    Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                          "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │                        Loja                       │\r\n" +
                                          "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                          "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                          "│  Carteira »  " + Player.Carteira + " ß    │ [h] » help?                                       │\r\n" +
                                          "│─────────────────────────│                                                   │\r\n" +
                                          "│                         │      » Selecione o cavalo que deseja comprar «    │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│                         │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [1] │       Luzitano       │                      │\r\n" +
                                          "│-» CORRIDAS[ENTER]       │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» CELEIRO[I]            │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [2] │   Quarto de Milha    │                      │\r\n" +
                                          "│-» LOJA[L]               │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» INVENTARIO[E]         │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [3] │      Percheron       │                      │\r\n" +
                                          "│─────────────────────────│     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                          "│                         │ [4] Comprar remedios ß80  [ADQUIRIDO]             │\r\n" +
                                          "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │ [5] Comprar alimentação ß250                      │\r\n" +
                                          "│                         │ [6] Comprar sela                                  │\r\n" +
                                          "└─────────────────────────┴───────────────────────────────────────────────────┘");
                    break;
                case 5:
                    Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                            "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │                        Loja                       │\r\n" +
                            "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                            "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                            "│  Carteira »  " + Player.Carteira + " ß    │ [h] » help?                                       │\r\n" +
                            "│─────────────────────────│                                                   │\r\n" +
                            "│                         │      » Selecione o cavalo que deseja comprar «    │\r\n" +
                            "│                         │                                                   │\r\n" +
                            "│                         │     ┌──────────────────────┐                      │\r\n" +
                            "│                         │ [1] │       Luzitano       │                      │\r\n" +
                            "│-» CORRIDAS[ENTER]       │     └──────────────────────┘                      │\r\n" +
                            "│                         │                                                   │\r\n" +
                            "│-» CELEIRO[I]            │     ┌──────────────────────┐                      │\r\n" +
                            "│                         │ [2] │   Quarto de Milha    │                      │\r\n" +
                            "│-» LOJA[L]               │     └──────────────────────┘                      │\r\n" +
                            "│                         │                                                   │\r\n" +
                            "│-» INVENTARIO[E]         │     ┌──────────────────────┐                      │\r\n" +
                            "│                         │ [3] │      Percheron       │                      │\r\n" +
                            "│─────────────────────────│     └──────────────────────┘                      │\r\n" +
                            "│                         │                                                   │\r\n" +
                            "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                            "│                         │ [4] Comprar remedios ß80                          │\r\n" +
                            "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │ [5] Comprar alimentação ß250 [ADQUIRIDO]          │\r\n" +
                            "│                         │ [6] Comprar sela ß500                             │\r\n" +
                            "└─────────────────────────┴───────────────────────────────────────────────────┘");
                    break;
                case 6:
                    Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                          "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │                        Loja                       │\r\n" +
                                          "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                          "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                          "│  Carteira »  " + Player.Carteira + " ß    │ [h] » help?                                       │\r\n" +
                                          "│─────────────────────────│                                                   │\r\n" +
                                          "│                         │      » Selecione o cavalo que deseja comprar «    │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│                         │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [1] │       Luzitano       │                      │\r\n" +
                                          "│-» CORRIDAS[ENTER]       │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» CELEIRO[I]            │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [2] │   Quarto de Milha    │                      │\r\n" +
                                          "│-» LOJA[L]               │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» INVENTARIO[E]         │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [3] │      Percheron       │                      │\r\n" +
                                          "│─────────────────────────│     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                          "│                         │ [4] Comprar remedios ß80                          │\r\n" +
                                          "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │ [5] Comprar alimentação ß250                      │\r\n" +
                                          "│                         │ [6] Comprar sela ß500 [ADQUIRIDO]                 │\r\n" +
                                          "└─────────────────────────┴───────────────────────────────────────────────────┘");
                    break;
                default:
                    Console.Write("┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                          "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │                        Loja                       │\r\n" +
                                          "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                          "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                          "│  Carteira »  " + Player.Carteira + " ß    │ [h] » help?                                       │\r\n" +
                                          "│─────────────────────────│                                                   │\r\n" +
                                          "│                         │      » Selecione o cavalo que deseja comprar «    │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│                         │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [1] │       Luzitano       │                      │\r\n" +
                                          "│-» CORRIDAS[ENTER]       │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» CELEIRO[I]            │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [2] │   Quarto de Milha    │                      │\r\n" +
                                          "│-» LOJA[L]               │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» INVENTARIO[E]         │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [3] │      Percheron       │                      │\r\n" +
                                          "│─────────────────────────│     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                          "│                         │ [4] Comprar remedios ß80                          │\r\n" +
                                          "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │ [5] Comprar alimentação ß250                      │\r\n" +
                                          "│                         │ [6] Comprar sela ß500                             │\r\n" +
                                          "└─────────────────────────┴───────────────────────────────────────────────────┘");
                    break;
            }

        }

        static public void SubMenuInventario()
        {
            void PrintColoredText(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }
            Console.Write(                "┌─────────────────────────┬───────────────────────────────────────────────────┐\r\n" +
                                          "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │                    Inventario                     │\r\n" +
                                          "│ » " + CicloDiario.diaAtual + "│                                                   │\r\n" +
                                          "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│───────────────────────────────────────────────────│\r\n" +
                                          "│  Carteira »  " + Player.Carteira + " ß    │ [h] » help?                                       │\r\n" +
                                          "│─────────────────────────│                                                   │\r\n" +
                                          "│                         │      » Itens armazenados «                        │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│                         │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [1] │ Remedios             │  »  " + Inventario.statusRemedio+"     │\r\n" +
                                          "│-» CORRIDAS[ENTER]       │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» CELEIRO[I]            │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [2] │ Alimentos            │  »  " + Inventario.statusAlimentos+"     │\r\n" +
                                          "│-» LOJA[L]               │     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» INVENTARIO[E]         │     ┌──────────────────────┐                      │\r\n" +
                                          "│                         │ [3] │ Selas                |  »  "+Inventario.statusSelas+"     │\r\n" +
                                          "│─────────────────────────│     └──────────────────────┘                      │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» "); PrintColoredText("VOLTAR", ConsoleColor.Yellow); Console.Write("[TAB]           │                                                   │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "│-» "); PrintColoredText("SAIR", ConsoleColor.Red); Console.WriteLine("[ESC]             │                                                   │\r\n" +
                                          "│                         │                                                   │\r\n" +
                                          "└─────────────────────────┴───────────────────────────────────────────────────┘");
        }


        static public void MenuSleep()
        {
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────┐\r\n" +
                              "│                                                                            │\r\n" +
                              "│                 ESTA NA HORA DE DORMIR, A LOJA ESTA FECHADA!               │\r\n" +
                              "│                     OS CAVALOS CANSADOS E VOCÊ EXAUSTO.                    │\r\n" +
                              "│                                                                            │\r\n" +
                              "│                          [QUALQUER BOTAO] DORMIR                           │\r\n" +
                              "└────────────────────────────────────────────────────────────────────────────┘");
        }

    }
}
