using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HorseProject
{
    public static class BootJogo
    {
        
     
        public static bool adquirido;
        public static int horse1Position = 0;
        public static int horse2Position = 0;
        public static int horse3Position = 0;
        public static int horse4Position = 0;
        public static bool raceEnded = false;
        public static bool estaRodando = false, primeiraVez = true, rodarDia, resetarDia;//jogo nao esta rodandos
        public static bool escolhaFinal = false;//usuario ainda nao fez sua escolha final
        public static menu menuAtual, subMenuAtual;
        public static int slotEscolhido = 1; //começa no primeiro cavalo
        public static string filePath = @"C:\Users\italo\Source\Repos\papitalos\IntergalaticHorseRacing\Info.txt";
        
        public static int qntdSaves = 1, escolhaCorrida = 0, valorItem = 0;

        public enum menu
        {
            menuInicial = 1,
            menuLoading,
            menuSleep,
            subMenuCorridas,
            subMenuCeleiro,
            subMenuLoja,
            subMenuInventario,
            menuEscolhaInicial,
            menuJogos,
            subMenuStatusCompra,
            nenhum

        }
        public static void RodarJogo(Cavalo cavalo)
        {
            
            CicloDiario.Musica(1);
            estaRodando = true;//o jogo passa a estar rodando
            Console.Clear();
            Graficos.MenuInicial(); //inicia o menu principal
            menuAtual = menu.menuInicial;//MENU ATUAL: menu inicial
            rodarDia = false;
            while (estaRodando) //enquanto o jogo estiver rodando
            {



                switch (Console.ReadKey().Key) //verifica a KEY clicada
                {
                    case ConsoleKey.Enter://se ENTER entra:
                        Thread.Sleep(50);
                        menuAtual = menu.menuJogos;
                        subMenuAtual = menu.subMenuCeleiro;
                        menuJogar(cavalo);//ativa o menu jogar
                        break;
                    case ConsoleKey.Tab://se TAB:
                        Thread.Sleep(50);
                        menuLoading(cavalo);//ativa o menu de loading
                        break;
                    case ConsoleKey.Escape://se ESC sai do jogo
                        Thread.Sleep(50);
                        Environment.Exit(0);
                        break;
                }





            }


        }
        public static void menuJogar(Cavalo cavalo)
        {


            if (primeiraVez)
            {
                primeiraVez = false;//deixa de ser a primeira vez
                menuAtual = menu.menuEscolhaInicial;//MENU ATUAL: ESCOLHA INICIAL

               
            
                Console.Clear();
                Graficos.MenuEscolhaInicial(slotEscolhido);

                while (escolhaFinal == false)
                {
                    Console.Clear();
                    Graficos.MenuEscolhaInicial(slotEscolhido);
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow://se SETA ESQUERDA
                            if (slotEscolhido == 1)//se estiver no primeiro slot
                            {
                                slotEscolhido = 3;//vai pro 3º slot
                            }
                            else if (slotEscolhido == 2 || slotEscolhido == 3)//se estiver no 2 ou 3 slot
                            {
                                slotEscolhido--;//diminui menus um slot
                            }
                            
                            break;
                        case ConsoleKey.RightArrow://se SETA DIREITA

                            if (slotEscolhido == 3)//se estiver no terceiro slot
                            {
                                slotEscolhido = 1;//vai pro 1º slot
                            }
                            else if (slotEscolhido == 1 || slotEscolhido == 2)//se estiver no 1 ou 2 slot
                            {
                                slotEscolhido++;//adiciona mais um slot
                            }

                            
                            break;
                        case ConsoleKey.Enter://se ENTER
                            
                            escolhaFinal = true;//usuario escolheu
                            GeradorDeCavalo.GerarPrimeiro(slotEscolhido);
                            
                            CicloDiario.dia.Start();

                            Thread.Sleep(100);

                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            subMenuCeleiro(cavalo);
                            break;
                        default:
                            Console.Clear();
                            Graficos.MenuEscolhaInicial(slotEscolhido);//se ERROR, volta pro slot escolhido anterior
                            break;

                    }//verifica a KEY cliquada

                }//enquanto usuario nao fez escolha final

                //depois do usuario ter feito a escolha final:



            }//se primeira vez na opção ENTER entra no menu de escolha de cavalo inicial


            while (menuAtual == menu.menuJogos)
            {
                
                    if (subMenuAtual == menu.subMenuCeleiro)
                    {
                        Thread.Sleep(100);
                        Console.Clear();
                        subMenuCeleiro(cavalo);
                    }


                    if (menuAtual == menu.menuJogos)
                    {

                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.Enter://se ENTER
                                if (CicloDiario.i != 3) {if (CicloDiario.pistaAberta == true)
                                {
                                    Thread.Sleep(100);
                                    subMenuCorrida(1, cavalo);
                                }
                                if (CicloDiario.pistaAberta != true)
                                {

                                    Console.WriteLine("A Pista esta fechada nesse momento!");
                                    Thread.Sleep(700);
                                    Console.Clear();
                                    if(subMenuAtual == menu.subMenuCeleiro)
                                    {
                                        Thread.Sleep(100);
                                        subMenuCeleiro(cavalo);
                                    }
                                    if (subMenuAtual == menu.subMenuLoja)
                                    {
                                        Thread.Sleep(100);
                                        subMenuLoja(cavalo);
                                    }
                                    if (subMenuAtual == menu.subMenuInventario)
                                    {
                                        Thread.Sleep(100);
                                        subMenuInventario(cavalo);
                                    }

                                } }
                                else
                            {
                                menuAtual = menu.menuJogos;
                                subMenuAtual = menu.subMenuCeleiro;
                                Console.Clear();
                                Console.WriteLine("Dormindo...");
                                Thread.Sleep(2000);
                            }

                            break;
                            case ConsoleKey.I://se I
                                if (CicloDiario.i != 3) {
                                    Thread.Sleep(100);
                                subMenuCeleiro(cavalo); }
                                else
                            {
                                menuAtual = menu.menuJogos;
                                subMenuAtual = menu.subMenuCeleiro;
                                Console.Clear();
                                Console.WriteLine("Dormindo...");
                                Thread.Sleep(2000);
                            }
                            break;
                            case ConsoleKey.L://se L
                                if (CicloDiario.i != 3)
                                {
                                    Thread.Sleep(100);
                                subMenuLoja(cavalo);
                                }
                                else
                            {
                                menuAtual = menu.menuJogos;
                                subMenuAtual = menu.subMenuCeleiro;
                                Console.Clear();
                                Console.WriteLine("Dormindo...");
                                Thread.Sleep(2000);
                            }


                            break;
                            case ConsoleKey.E://Se E
                                if (CicloDiario.i != 3) { Thread.Sleep(100);
                                subMenuInventario(cavalo); }
                                else
                            {
                                menuAtual = menu.menuJogos;
                                subMenuAtual = menu.subMenuCeleiro;
                                Console.Clear();
                                Console.WriteLine("Dormindo...");
                                Thread.Sleep(2000);
                            }
                            break;

                        case ConsoleKey.Tab://se TAB
                            if (CicloDiario.i != 3)
                            {
                                Thread.Sleep(100);
                                Console.Clear();
                                Graficos.MenuInicial();//volta ao menu inicial
                                menuAtual = menu.menuInicial;//passa a estar no menu inicial
                                subMenuAtual = menu.nenhum;
                            }
                            else
                            {
                                menuAtual = menu.menuJogos;
                                subMenuAtual = menu.subMenuCeleiro;
                                Console.Clear();
                                Console.WriteLine("Dormindo...");
                                Thread.Sleep(2000);
                            }

                            break;
                        case ConsoleKey.Escape://se ESC sai do programa
                            if (CicloDiario.i != 3)
                            {
                                Thread.Sleep(100);
                                Environment.Exit(0);
                            }
                            else
                            {
                                menuAtual = menu.menuJogos;
                                subMenuAtual = menu.subMenuCeleiro;
                                Console.Clear();
                                Console.WriteLine("Dormindo...");
                                Thread.Sleep(2000);
                            }
                            break;

                        default:
                            if (CicloDiario.i != 3) {Thread.Sleep(100);
                                Console.Clear();
                                switch (menuAtual)
                                {
                                    case menu.subMenuCorridas:
                                        Graficos.SubMenuCorrida(0, 1, cavalo);
                                        break;
                                    case menu.subMenuCeleiro:

                                        Graficos.SubMenuCeleiro();
                                        break;
                                    case menu.subMenuLoja:

                                        break;
                                } }
                            else
                            {
                                menuAtual = menu.menuJogos;
                                subMenuAtual = menu.subMenuCeleiro;
                                Console.Clear();
                                Console.WriteLine("Dormindo...");
                                Thread.Sleep(2000);
                            }

                            break;

                        }//verifique a KEY clicada
              
                
                    }
              
                
                
            }//enquanto nao estiver no menu incial, ou seja, estiver no menu de jogar


        }
        public static void menuLoading(Cavalo cavalo)
        {
            
            menuAtual = menu.menuLoading; //passa a estar no menu de Loading
            Console.Clear();
            Graficos.MenuLoading(qntdSaves);//CARREGA COM A QNTD SAVE ANTERIOR

            while (menuAtual == menu.menuLoading)
            {
               
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.A://se A
                            if (qntdSaves < 4)//so adiciona se tiver menos que 4 saves
                            {

                                qntdSaves++;//adiciona mais um save
                                Thread.Sleep(100);
                                Console.Clear();
                                Graficos.MenuLoading(qntdSaves);//imprime
                            }//se quantidade de saves for menor que 4
                            break;
                        case ConsoleKey.D://se D
                            if (qntdSaves > 1)//so apaga se tiver mais q 1 save
                            {
                           
                                //LIMPA O D imprimido na tela ***
                                Console.Clear();
                                Graficos.MenuLoading(qntdSaves);
                                //LIMPA O D imprimido na tela ***


                                Console.WriteLine("Qual slot deseja apagar? [NUM + ENTER] [0 - cancelar]");//pergunta qual slot deve apagar
                                string slot = Console.ReadLine();//cria uma variavel do slot a apagar (equivalente a linha a apagar no arquivo de saves)    

                                if (slot == "1" || slot == "2" || slot == "3" || slot == "4")//se for 1, 2,3 ou 4
                                {
                                    qntdSaves--;//diminui a quantidade de saves
                                    Thread.Sleep(100);
                                    Console.Clear();
                                    Graficos.MenuLoading(qntdSaves);//imprime
                                }
                                else if (slot == "0")
                                {//se for 0 
                                    Thread.Sleep(100);
                                    Console.Clear();
                                    Graficos.MenuLoading(qntdSaves);//imprime sem alterar o valor

                                }
                                else//se for qualquer outra tecla
                                {
                                    Thread.Sleep(100);
                                    Console.Clear();
                                    Graficos.MenuLoading(qntdSaves);
                                    Console.WriteLine("Não existe esse SLOT!");//avisa que nao existe esse SLOT
                                    Thread.Sleep(1000);//espera 1 segundo
                                    Console.Clear();
                                    Graficos.MenuLoading(qntdSaves);//apaga o aviso
                                }



                            }//se quantidade de saves maior que 1
                            break;
                        default://se for qualquer outra KEY
                            Thread.Sleep(100);
                            Console.Clear();
                            Graficos.MenuLoading(qntdSaves);//limpa e imprime o que estava antes
                            break;
                        case ConsoleKey.Enter:
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            menuJogar(cavalo);
                            break;
                        case ConsoleKey.Escape:
                            Thread.Sleep(100);
                            Environment.Exit(0);
                            break;
                    }//verifica a KEY clicada
               
                
            } //enquanto estiver no Menu de Loading 


        }


        public static void subMenuCorrida(int posicaoVitoria, Cavalo cavalo)
        {
            CicloDiario.SaveGameData("Cavalo:\n\nNome: " + cavalo.nome + "\nID: " + cavalo.id + "\nIdade: " + cavalo.idade + "\nPeso: " + cavalo.Kg + "\nResistencia: " + cavalo.r + "\nVelocidade Máxima: " + cavalo.VMax + "\nAceleração: " + cavalo.a + "\nValor: " + cavalo.valor, filePath);
            Thread.Sleep(100);
            Console.Clear();
            Graficos.SubMenuCorrida(escolhaCorrida, posicaoVitoria, cavalo);
            CicloDiario.Musica(3);
            subMenuAtual = menu.subMenuCorridas;
            escolhaCorrida = 0;

            
            while (subMenuAtual == menu.subMenuCorridas)
            {
               
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        if (CicloDiario.i != 3) {CicloDiario.Musica(2);
                            while (!raceEnded)
        {
                    while (horse1Position < 100 && horse2Position < 100 && horse3Position < 100)
                    {
                        Console.Clear(); // Clear the screen

                        // Draw the horses
                        Console.SetCursorPosition(horse1Position, 0);
                        Console.Write("Horse 1");

                        Console.SetCursorPosition(horse2Position, 1);
                        Console.Write("Horse 2");

                        Console.SetCursorPosition(horse3Position, 2);
                        Console.Write("Horse 3");

                        // Update the positions of the horses
                        horse1Position += 1;
                        horse2Position += 2;
                        horse3Position += 3;
                        if (horse1Position >= 100)
                            Console.WriteLine("\nHorse 1 wins!");
                        else if (horse2Position >= 100)
                            Console.WriteLine("\nHorse 2 wins!");
                        else if (horse3Position >= 100)
                            Console.WriteLine("\nHorse 3 wins!");

                        System.Threading.Thread.Sleep(100);
                        raceEnded = true;
                    }
                }

                        escolhaCorrida = 1;
                        Thread.Sleep(100);
                        Console.Clear();
                        Graficos.SubMenuCorrida(escolhaCorrida, posicaoVitoria, cavalo);
                        Thread.Sleep(2000);
                        
                        escolhaCorrida = 0;}
                        
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                    case ConsoleKey.D2:
                        if (CicloDiario.i != 3) { CicloDiario.Musica(2);
                            while (!raceEnded)
        {
                    while (horse1Position < 100 && horse2Position < 100 && horse3Position < 100)
                    {
                        Console.Clear(); // Clear the screen

                        // Draw the horses
                        Console.SetCursorPosition(horse1Position, 0);
                        Console.Write("Horse 1");

                        Console.SetCursorPosition(horse2Position, 1);
                        Console.Write("Horse 2");

                        // Update the positions of the horses
                        horse1Position += 1;
                        horse2Position += 2;
                        horse3Position += 3;
                        if (horse1Position >= 100)
                            Console.WriteLine("\nHorse 1 wins!");
                        else if (horse2Position >= 100)
                            Console.WriteLine("\nHorse 2 wins!");

                        System.Threading.Thread.Sleep(100);
                        raceEnded = true;
                    }
                }
                        escolhaCorrida = 2;
                        Thread.Sleep(100);
                        Console.Clear();
                        Graficos.SubMenuCorrida(escolhaCorrida, posicaoVitoria, cavalo);
                            raceEnded = false;
                        Thread.Sleep(2000); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        escolhaCorrida = 0;
                        break;
                    case ConsoleKey.D3:
                            
                        if (CicloDiario.i != 3) {CicloDiario.Musica(2);
                            while (!raceEnded)
        {
                    while (horse1Position < 100 && horse2Position < 100 && horse3Position < 100)
                    {
                        Console.Clear(); // Clear the screen

                        // Draw the horses
                        Console.SetCursorPosition(horse1Position, 0);
                        Console.Write("Horse 1");

                        Console.SetCursorPosition(horse2Position, 1);
                        Console.Write("Horse 2");

                        Console.SetCursorPosition(horse3Position, 2);
                        Console.Write("Horse 3");

                        Console.SetCursorPosition(horse4Position, 3);
                        Console.Write("Horse 4");

                        // Update the positions of the horses
                        horse1Position += 1;
                        horse2Position += 2;
                        horse3Position += 3;
                        if (horse1Position >= 100)
                            Console.WriteLine("\nHorse 1 wins!");
                        else if (horse2Position >= 100)
                            Console.WriteLine("\nHorse 2 wins!");
                        else if (horse3Position >= 100)
                            Console.WriteLine("\nHorse 3 wins!");
                        else if (horse3Position >= 100)
                            Console.WriteLine("\nHorse 4 wins!");

                        System.Threading.Thread.Sleep(100);
                        raceEnded = true;
                    }
                }
                        escolhaCorrida = 3;
                        Thread.Sleep(100);
                        Console.Clear();
                        Graficos.SubMenuCorrida(escolhaCorrida, posicaoVitoria, cavalo);
                        Thread.Sleep(2000);
                        raceEnded = false;
                        escolhaCorrida = 0; }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;


                    //COMANDOS PADRÃO ****
                    case ConsoleKey.Tab://se TAB
                        if (CicloDiario.i != 3)
                        {
                            Thread.Sleep(100);
                            Console.Clear();
                            Graficos.MenuInicial();//volta ao menu inicial
                            menuAtual = menu.menuInicial;//passa a estar no menu inicial
                            subMenuAtual = menu.nenhum;
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }

                        break;
                    case ConsoleKey.Escape://se ESC sai do programa
                        if (CicloDiario.i != 3)
                        {
                            Thread.Sleep(100);
                            Environment.Exit(0);
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                   
                    case ConsoleKey.I:
                        if (CicloDiario.i != 3) {
                            subMenuCeleiro(cavalo); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                    case ConsoleKey.L:
                        if (CicloDiario.i != 3) {  subMenuLoja(cavalo);
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }


                        break;
                    case ConsoleKey.E:
                        if (CicloDiario.i != 3) { subMenuInventario(cavalo);
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                    //COMANDOS PADRÃO ****


                    default:
                        if (CicloDiario.i != 3) { escolhaCorrida = 0;
                        Thread.Sleep(100);
                        Console.Clear();
                        Graficos.SubMenuCorrida(escolhaCorrida, posicaoVitoria, cavalo); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                }
                
                
            }
        }
        public static void subMenuCeleiro(Cavalo cavalo)
        {
            Celeiro.Reorganizar();
            if (CicloDiario.currentAudio != 1)
            {
                CicloDiario.Musica(1);
            }

            Thread.Sleep(100);
            Console.Clear();
            Graficos.SubMenuCeleiro();

            while (subMenuAtual == menu.subMenuCeleiro)
            {
              
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Thread.Sleep(100);
                        Console.Clear();
                        cavalo.ToString();
                        Console.WriteLine(   "┌──────────────────────┐ ┌──────────────────────┐ \r\n" +
                                             "│ S - Staff            │ │ Tab - Voltar         │ \r\n" +
                                             "└──────────────────────┘ └──────────────────────┘ \r\n");
                        switch (Console.ReadKey().Key)
                        {

                            case ConsoleKey.S:
                                Thread.Sleep(100);
                                if (CicloDiario.diaAtual == "Terça-feira           ")
                                {
                                    cavalo.VMax = +1;
                                    Console.WriteLine("O seu cavalo recebeu +1 de Velocidade! "); 

                                }
                                if (CicloDiario.diaAtual == "Quarta-feira          ")
                                {
                                    Console.WriteLine("O estado do seu cavalo é: " + cavalo.estadoDoencaAtual);
                                }
                                if (CicloDiario.diaAtual == "Quinta-feira          ")
                                {
                                    cavalo.bonus = +1;
                                    Console.WriteLine("O seu cavalo recebeu +1 de Bônus! ");
                                }
                                break;
                            case ConsoleKey.Tab:
                                Thread.Sleep(100);
                                Console.Clear();
                                Graficos.SubMenuLoja(0);
                                break;
                        }
                        break;


                    //COMANDOS PADRÃO ****
                    
                    case ConsoleKey.Tab://se TAB
                        if (CicloDiario.i != 3)
                        {Thread.Sleep(100);
                        Console.Clear();
                        Graficos.MenuInicial();//volta ao menu inicial
                        menuAtual = menu.menuInicial;//passa a estar no menu inicial
                        subMenuAtual = menu.nenhum; }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                                
                        break;
                    case ConsoleKey.Escape://se ESC sai do programa
                        if (CicloDiario.i != 3)
                        {
                            Thread.Sleep(100);
                            Environment.Exit(0);
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                    //COMANDOS PADRÃO ****

                    case ConsoleKey.Enter:
                        if (CicloDiario.i != 3) {if (CicloDiario.pistaAberta == true)
                        {
                            subMenuCorrida(1, cavalo);
                        }
                        if (CicloDiario.pistaAberta != true)
                        {
                            Console.WriteLine("A Pista esta fechada nesse momento!");
                            Thread.Sleep(700);
                            Console.Clear();
                            if (subMenuAtual == menu.subMenuCeleiro)
                            {
                                subMenuCeleiro(cavalo);
                            }
                            if (subMenuAtual == menu.subMenuLoja)
                            {
                                subMenuLoja(cavalo);
                            }
                            if (subMenuAtual == menu.subMenuInventario)
                            {
                                subMenuInventario(cavalo);
                            }
                        } }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                    case ConsoleKey.L:
                        if (CicloDiario.i != 3) {
                            subMenuLoja(cavalo); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }


                        break;
                    case ConsoleKey.E:
                        if (CicloDiario.i != 3) { 
                            subMenuInventario(cavalo); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;

                    default:
                        if (CicloDiario.i != 3) {Thread.Sleep(100);
                        Console.Clear();
                        Graficos.SubMenuCeleiro(); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;

                }
                
                

            }

        }
        public static void subMenuLoja(Cavalo cavalo)
        {
            GeradorDeCavalo.GerarAleatorioLoja();
            if (CicloDiario.currentAudio != 1)
            {
                CicloDiario.Musica(1);
            }
            Thread.Sleep(100);
            Console.Clear();
            subMenuAtual = menu.subMenuLoja;
            Graficos.SubMenuLoja(0); //default

            while (subMenuAtual == menu.subMenuLoja)
            {
                
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.D1:
                        if (CicloDiario.i != 3)
                        {

                            //LIMPA O 1 DA TELA
                            Console.Clear();
                            cavalo.ToString();
                            Console.WriteLine("┌──────────────────────┐ ┌──────────────────────┐ \r\n" +
                                              "│ C - Comprar          │ │ Tab - Voltar         │ \r\n" +
                                              "└──────────────────────┘ └──────────────────────┘ \r\n");
                            //LIMPA O 1 DA TELA
                            switch (Console.ReadKey().Key)
                            {

                                case ConsoleKey.C:
                                    Loja.ComprarCavalo(cavalo, 1);
                                    if (Celeiro.CapacidadeCeleiro() < 4)
                                    {

                                        Thread.Sleep(100);
                                        Console.Clear();
                                        Graficos.SubMenuLoja(1);
                                        Thread.Sleep(1200);
                                        Console.Clear();
                                        Graficos.SubMenuLoja(0);
                                    }
                                    else
                                    {
                                        Console.WriteLine("SEM ESPAÇO NO CELEIRO!");
                                        Thread.Sleep(700);
                                        Console.Clear();
                                        Graficos.SubMenuLoja(0);
                                    }
                                    break;
                                case ConsoleKey.Tab:
                                    Thread.Sleep(100);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(0);
                                    break;
                            }

                          

                             }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                        case ConsoleKey.D2:
                        Loja.ComprarCavalo(cavalo, 2);
                        if (CicloDiario.i != 3)
                        {   //LIMPA O 2 DA TELA
                            Console.Clear();
                            cavalo.ToString();
                            Console.WriteLine("┌──────────────────────┐ ┌──────────────────────┐ \r\n" +
                                              "│ C - Comprar          │ │ Tab - Voltar         │ \r\n" +
                                              "└──────────────────────┘ └──────────────────────┘ \r\n");
                            //LIMPA O 2 DA TELA
                            switch (Console.ReadKey().Key)
                            {

                                case ConsoleKey.C:
                                    if (Celeiro.CapacidadeCeleiro() < 4)
                                    {
                                        Thread.Sleep(100);
                                        Console.Clear();
                                        Graficos.SubMenuLoja(2);
                                        Thread.Sleep(1200);
                                        Console.Clear();
                                        Graficos.SubMenuLoja(0);
                                    }
                                    else
                                    {
                                        menuAtual = menu.menuJogos;
                                        subMenuAtual = menu.subMenuCeleiro;
                                        Console.Clear();
                                        Console.WriteLine("Dormindo...");
                                        Thread.Sleep(2000);
                                    }
                                    break;
                                case ConsoleKey.Tab:
                                    Thread.Sleep(100);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(0);
                                    break;
                            }
                            
                        }
                       
                        break;
                        case ConsoleKey.D3:
                        if (CicloDiario.i != 3)
                        {   //LIMPA O 3 DA TELA
                            Console.Clear();
                            cavalo.ToString();
                            Console.WriteLine("┌──────────────────────┐ ┌──────────────────────┐ \r\n" +
                                              "│ C - Comprar          │ │ Tab - Voltar         │ \r\n" +
                                              "└──────────────────────┘ └──────────────────────┘ \r\n");
                            //LIMPA O 3 DA TELA

                            Loja.ComprarCavalo(cavalo, 3);
                            if (Celeiro.CapacidadeCeleiro() < 4)
                            {
                                Thread.Sleep(100);
                                Console.Clear();
                                Graficos.SubMenuLoja(3);
                                Thread.Sleep(1200);
                                Console.Clear();
                                Graficos.SubMenuLoja(0);
                            }
                            else
                            {
                                Console.WriteLine("SEM ESPAÇO NO CELEIRO!");
                                Thread.Sleep(1200);
                                Console.Clear();
                                Graficos.SubMenuLoja(0);
                            }
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                        case ConsoleKey.D4:
                        if (CicloDiario.i != 3)
                        {   //LIMPA O 4 DA TELA
                            Console.Clear();
                            Graficos.SubMenuLoja(0);
                            //LIMPA O 4 DA TELA
                            if (Inventario.nRemedios < Inventario.limite)
                            {
                                Loja.ComprarRemedios();
                                if (adquirido == true)
                                {
                                    Thread.Sleep(100);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(4);
                                    Thread.Sleep(700);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(0);
                                }
                                if (adquirido == false)
                                {
                                    Console.WriteLine("SEM DINHEIRO NA CARTEIRA!");
                                    Thread.Sleep(700);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(0);
                                }
                            }
                            else if (Inventario.nRemedios >= 0)
                            {
                                Console.WriteLine("SEM ESPAÇOS NO INVENTARIOS!");
                            }
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }

                        break;
                        case ConsoleKey.D5:
                        if (CicloDiario.i != 3)
                        {//LIMPA O 5 DA TELA
                            Console.Clear();
                            Graficos.SubMenuLoja(0);
                            //LIMPA O 5 DA TELA
                            if (Inventario.nAlimentos < Inventario.limite)
                            {
                                Loja.ComprarAlimentação();
                                if (adquirido == true)
                                {
                                    Thread.Sleep(100);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(5);
                                    Thread.Sleep(700);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(0);
                                }
                                else if (adquirido == false)
                                {
                                    Console.WriteLine("SEM DINHEIRO NA CARTEIRA!");
                                    Thread.Sleep(700);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(0);
                                }
                            }
                            else if (Inventario.nAlimentos >= 0)
                            {
                                Console.WriteLine("SEM ESPAÇOS NO INVENTARIOS!");
                            }
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                        case ConsoleKey.D6:
                        if (CicloDiario.i != 3) {//LIMPA O 6 DA TELA
                            Console.Clear();
                            Graficos.SubMenuLoja(0);
                            //LIMPA O 6 DA TELA
                            if (Inventario.nSelas < Inventario.limite)
                            {
                                Loja.ComprarSela();
                                if (adquirido == true)
                                {
                                    Thread.Sleep(100);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(6);
                                    Thread.Sleep(700);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(0);
                                }
                                if (adquirido == false)
                                {
                                    Console.WriteLine("SEM DINHEIRO NA CARTEIRA!");
                                    Thread.Sleep(700);
                                    Console.Clear();
                                    Graficos.SubMenuLoja(0);
                                }
                            }
                            else if (Inventario.nSelas >= 0)
                            {
                                Console.WriteLine("SEM ESPAÇOS NO INVENTARIOS!");
                            } }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }

                        break;

                    //COMANDOS PADRÃO ****
                    case ConsoleKey.Tab://se TAB
                        if (CicloDiario.i != 3)
                        {
                            Thread.Sleep(100);
                            Console.Clear();
                            Graficos.MenuInicial();//volta ao menu inicial
                            menuAtual = menu.menuInicial;//passa a estar no menu inicial
                            subMenuAtual = menu.nenhum;
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }

                        break;
                    case ConsoleKey.Escape://se ESC sai do programa
                        if (CicloDiario.i != 3)
                        {
                            Thread.Sleep(100);
                            Environment.Exit(0);
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                    //COMANDOS PADRÃO ****

                    case ConsoleKey.Enter:
                        if (CicloDiario.i != 3) { 
                            if (CicloDiario.pistaAberta == true)
                            {
                                subMenuCorrida(1, cavalo);
                            }
                            if (CicloDiario.pistaAberta != true)
                            {
                                Console.WriteLine("A Pista esta fechada nesse momento!");
                                Thread.Sleep(700);
                                Console.Clear();
                                if (subMenuAtual == menu.subMenuCeleiro)
                                {
                                    subMenuCeleiro(cavalo);
                                }
                                if (subMenuAtual == menu.subMenuLoja)
                                {
                                    subMenuLoja(cavalo);
                                }
                                if (subMenuAtual == menu.subMenuInventario)
                                {
                                    subMenuInventario(cavalo);
                                }
                            } }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                        case ConsoleKey.I:
                        if (CicloDiario.i != 3) { 
                            subMenuCeleiro(cavalo); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                        case ConsoleKey.E:
                        if (CicloDiario.i != 3) {
                            subMenuInventario(cavalo); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                        

                        default:
                        if (CicloDiario.i != 3) {Thread.Sleep(100);
                            Console.Clear();
                            Graficos.SubMenuLoja(0); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                    }
                

            }
        }
         public static void subMenuInventario(Cavalo cavalo)
        {
            if (CicloDiario.currentAudio != 1)
            {
                CicloDiario.Musica(1);
            }
            Thread.Sleep(100);
            Console.Clear();
            subMenuAtual = menu.subMenuInventario;
            Inventario.VerificarStatus();
            Graficos.SubMenuInventario();
            

            while (subMenuAtual == menu.subMenuInventario)
            {
                Inventario.VerificarStatus();

                
                    switch (Console.ReadKey().Key)
                    {



                    //COMANDOS PADRÃO ****
                    case ConsoleKey.Tab://se TAB
                        if (CicloDiario.i != 3)
                        {
                            Thread.Sleep(100);
                            Console.Clear();
                            Graficos.MenuInicial();//volta ao menu inicial
                            menuAtual = menu.menuInicial;//passa a estar no menu inicial
                            subMenuAtual = menu.nenhum;
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }

                        break;
                    case ConsoleKey.Escape://se ESC sai do programa
                        if (CicloDiario.i != 3)
                        {
                            Thread.Sleep(100);
                            Environment.Exit(0);
                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                    //COMANDOS PADRÃO ****

                    case ConsoleKey.Enter:
                        if (CicloDiario.i != 3) { if (CicloDiario.pistaAberta == true)
                            {
                                subMenuCorrida(1, cavalo);
                            }
                            if (CicloDiario.pistaAberta != true)
                            {
                                Console.WriteLine("A Pista esta fechada nesse momento!");
                                Thread.Sleep(700);
                                Console.Clear();
                                if (subMenuAtual == menu.subMenuCeleiro)
                                {
                                    subMenuCeleiro(cavalo);
                                }
                                if (subMenuAtual == menu.subMenuLoja)
                                {
                                    subMenuLoja(cavalo);
                                }
                                if (subMenuAtual == menu.subMenuInventario)
                                {
                                    subMenuInventario(cavalo);
                                }
                            } }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                        case ConsoleKey.I:
                        if (CicloDiario.i != 3)
                        {subMenuCeleiro(cavalo);

                        }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                        case ConsoleKey.L:
                        if (CicloDiario.i != 3) {
                            subMenuLoja(cavalo); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }

                        break;
                        //COMANDOS PADRÃO ****
                        default:
                        if (CicloDiario.i != 3) {Thread.Sleep(100);
                            Console.Clear();
                            Graficos.SubMenuLoja(0); }
                        else
                        {
                            menuAtual = menu.menuJogos;
                            subMenuAtual = menu.subMenuCeleiro;
                            Console.Clear();
                            Console.WriteLine("Dormindo...");
                            Thread.Sleep(2000);
                        }
                        break;
                    }

                


            }

        }

    

        public static void menuSleep()
        {
            menuAtual =  menu.menuSleep;
            Console.Clear();
            Graficos.MenuSleep();
            

        }
    }


        
}
