using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HorseProject
{
    public static class BootJogo
    {
        
        // Declara a lista de itens do inventário
        public static List<string> inventario = new List<string>();
        public static bool adquirido;

        public static bool estaRodando = false, primeiraVez = true;//jogo nao esta rodando
        public static menu menuAtual, subMenuAtual;

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

            while (estaRodando) //enquanto o jogo estiver rodando
            {



                switch (Console.ReadKey().Key) //verifica a KEY clicada
                {
                    case ConsoleKey.Enter://se ENTER entra:
                        menuAtual = menu.menuJogos;
                        subMenuAtual = menu.subMenuCeleiro;
                        menuJogar(cavalo);//ativa o menu jogar
                        break;
                    case ConsoleKey.Tab://se TAB:
                        menuLoading(cavalo);//ativa o menu de loading
                        break;
                    case ConsoleKey.Escape://se ESC sai do jogo
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

                int slotEscolhido = 1; //começa no primeiro cavalo
                bool escolhaFinal = false;//usuario ainda nao fez sua escolha final
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
                if (CicloDiario.lojaAberta != true)
                {
                    menuSleep(cavalo);
                }
                if (subMenuAtual == menu.subMenuCeleiro)
                {
                    Console.Clear();
                    subMenuCeleiro(cavalo);
                }


                if (menuAtual == menu.menuJogos)
                {

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter://se ENTER
                            if (CicloDiario.pistaAberta == true)
                            {
                                subMenuCorrida(1, cavalo);
                            }
                            if (CicloDiario.pistaAberta != true)
                            {
                                Console.WriteLine("A Pista esta fechada nesse momento!");
                                Thread.Sleep(700);
                                Console.Clear();
                                if(subMenuAtual == menu.subMenuCeleiro)
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

                            }
                            
                            break;
                        case ConsoleKey.I://se I
                            subMenuCeleiro(cavalo);
                            break;
                        case ConsoleKey.L://se L
                            subMenuLoja(cavalo);

                            break;
                        case ConsoleKey.E://Se E
                            subMenuInventario(cavalo);
                            break;

                        //COMANDOS PADRÃO ****
                        case ConsoleKey.Tab://se TAB
                            Console.Clear();
                            Graficos.MenuInicial();//volta ao menu inicial
                            menuAtual = menu.menuInicial;//passa a estar no menu inicial
                            subMenuAtual = menu.nenhum;
                            break;
                        case ConsoleKey.Escape://se ESC
                            Environment.Exit(0);//sai do programa
                            break;
                        //COMANDOS PADRÃO ****

                        default:
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
                                Console.Clear();
                                Graficos.MenuLoading(qntdSaves);//imprime
                            }
                            else if (slot == "0")
                            {//se for 0 
                                Console.Clear();
                                Graficos.MenuLoading(qntdSaves);//imprime sem alterar o valor

                            }
                            else//se for qualquer outra tecla
                            {
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
                        Console.Clear();
                        Graficos.MenuLoading(qntdSaves);//limpa e imprime o que estava antes
                        break;
                    case ConsoleKey.Enter:
                        menuAtual = menu.menuJogos;
                        subMenuAtual = menu.subMenuCeleiro;
                        menuJogar(cavalo);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }//verifica a KEY clicada
            } //enquanto estiver no Menu de Loading 


        }
        public static void subMenuCorrida(int posicaoVitoria, Cavalo cavalo)
        {
            Console.Clear();
            Graficos.SubMenuCorrida(escolhaCorrida, posicaoVitoria, cavalo);
            CicloDiario.Musica(3);
            subMenuAtual = menu.subMenuCorridas;
            escolhaCorrida = 0;
            while (subMenuAtual == menu.subMenuCorridas)
            {
                if (CicloDiario.lojaAberta != true)
                {
                    menuSleep(cavalo);
                }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        CicloDiario.Musica(2);
                        escolhaCorrida = 1;
                        Console.Clear();
                        Graficos.SubMenuCorrida(escolhaCorrida, posicaoVitoria, cavalo);
                        Thread.Sleep(2000);
                        escolhaCorrida = 0;
                        break;
                    case ConsoleKey.D2:
                        CicloDiario.Musica(2);
                        escolhaCorrida = 2;
                        Console.Clear();
                        Graficos.SubMenuCorrida(escolhaCorrida, posicaoVitoria, cavalo);
                        Thread.Sleep(2000);
                        escolhaCorrida = 0;
                        break;
                    case ConsoleKey.D3:
                        CicloDiario.Musica(2);
                        escolhaCorrida = 3;
                        Console.Clear();
                        Graficos.SubMenuCorrida(escolhaCorrida, posicaoVitoria, cavalo);
                        Thread.Sleep(2000);
                        escolhaCorrida = 0;
                        break;


                    //COMANDOS PADRÃO ****
                    case ConsoleKey.Tab://se TAB
                        Console.Clear();
                        Graficos.MenuInicial();//volta ao menu inicial
                        menuAtual = menu.menuInicial;//passa a estar no menu inicial
                        subMenuAtual = menu.menuInicial;
                        break;
                    case ConsoleKey.Escape://se ESC
                        Environment.Exit(0);//sai do programa
                        break;
                    case ConsoleKey.I:
                        subMenuCeleiro(cavalo);
                        break;
                    case ConsoleKey.L:
                        subMenuLoja(cavalo);


                        break;
                    case ConsoleKey.E:
                        subMenuInventario(cavalo);
                        break;
                    //COMANDOS PADRÃO ****

                   
                    default:
                        escolhaCorrida = 0;
                        Console.Clear();
                        Graficos.SubMenuCorrida(escolhaCorrida, posicaoVitoria, cavalo);
                        break;
                }
            }
        }
        public static void subMenuCeleiro(Cavalo cavalo)
        {
            if (CicloDiario.currentAudio != 1)
            {
                CicloDiario.Musica(1);
            }
            Console.Clear();
            Graficos.SubMenuCeleiro();

            while (subMenuAtual == menu.subMenuCeleiro)
            {
                if (CicloDiario.lojaAberta == false)
                {
                    menuSleep(cavalo);
                }
                switch (Console.ReadKey().Key)
                {




                    //COMANDOS PADRÃO ****
                    case ConsoleKey.Tab://se TAB
                        Console.Clear();
                        Graficos.MenuInicial();//volta ao menu inicial
                        menuAtual = menu.menuInicial;//passa a estar no menu inicial
                        subMenuAtual = menu.nenhum;
                        break;
                    case ConsoleKey.Escape://se ESC
                        Environment.Exit(0);//sai do programa
                        break;
                    //COMANDOS PADRÃO ****

                    case ConsoleKey.Enter:
                            if (CicloDiario.pistaAberta == true)
                            {
                                subMenuCorrida(1, cavalo);
                            }
                            if(CicloDiario.pistaAberta != true)
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
                            }
                            break;
                    case ConsoleKey.L:
                     
                         subMenuLoja(cavalo);
                     
                       
                        break;
                    case ConsoleKey.E:
                        subMenuInventario(cavalo);
                        break;

                    default:
                        Console.Clear();
                        Graficos.SubMenuCeleiro();
                        break;

                }




            }

        }

        public static void subMenuLoja(Cavalo cavalo)
        {
            if (CicloDiario.currentAudio != 1)
            {
                CicloDiario.Musica(1);
            }
            Console.Clear();
            subMenuAtual = menu.subMenuLoja;
            Graficos.SubMenuLoja(0); //default

            while (subMenuAtual == menu.subMenuLoja)
            {
                if (CicloDiario.lojaAberta != true)
                {
                    menuSleep(cavalo);
                }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Graficos.SubMenuLoja(0);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Graficos.SubMenuLoja(0);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Graficos.SubMenuLoja(0);
                        break;
                    case ConsoleKey.D4:

                        //LIMPA O 4 DA TELA
                        Console.Clear();
                        Graficos.SubMenuLoja(0);
                        //LIMPA O 4 DA TELA
                        if(Inventario.nRemedios < Inventario.limite)
                        {
                            Loja.ComprarRemedios();
                            if (adquirido == true)
                            {
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
                        else if(Inventario.nRemedios >= 0)
                        {
                            Console.WriteLine("SEM ESPAÇOS NO INVENTARIOS!");
                        }
                        
                        
                        

                        break;
                    case ConsoleKey.D5:

                        //LIMPA O 5 DA TELA
                        Console.Clear();
                        Graficos.SubMenuLoja(0);
                        //LIMPA O 5 DA TELA
                        if (Inventario.nAlimentos < Inventario.limite)
                        {
                            Loja.ComprarAlimentação();
                            if (adquirido == true)
                            {
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

                        break;
                    case ConsoleKey.D6:

                        //LIMPA O 6 DA TELA
                        Console.Clear();
                        Graficos.SubMenuLoja(0);
                        //LIMPA O 6 DA TELA
                        if (Inventario.nSelas < Inventario.limite)
                        {
                            Loja.ComprarSela();
                            if (adquirido == true)
                            {
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
                        }

                        break;

                    //COMANDOS PADRÃO ****
                    case ConsoleKey.Tab://se TAB
                        Console.Clear();
                        Graficos.MenuInicial();//volta ao menu inicial
                        menuAtual = menu.menuInicial;//passa a estar no menu inicial
                        subMenuAtual = menu.nenhum;
                        break;
                    case ConsoleKey.Escape://se ESC
                        Environment.Exit(0);//sai do programa
                        break;

                    case ConsoleKey.Enter:
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
                        }
                        break;
                    case ConsoleKey.I:
                        subMenuCeleiro(cavalo);
                        break;
                    case ConsoleKey.E:
                        subMenuInventario(cavalo);
                        break;
                    //COMANDOS PADRÃO ****

                    default:
                        Console.Clear();
                        Graficos.SubMenuLoja(0);
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
            Console.Clear();
            subMenuAtual = menu.subMenuInventario;
            Inventario.VerificarStatus();
            Graficos.SubMenuInventario();
            

            while (subMenuAtual == menu.subMenuInventario)
            {
                if (CicloDiario.lojaAberta != true)
                {
                    menuSleep(cavalo);
                }
                Inventario.VerificarStatus();
                switch (Console.ReadKey().Key)
                {




                    //COMANDOS PADRÃO ****
                    case ConsoleKey.Tab://se TAB
                        Console.Clear();
                        Graficos.MenuInicial();//volta ao menu inicial
                        menuAtual = menu.menuInicial;//passa a estar no menu inicial
                        subMenuAtual = menu.nenhum;
                        break;
                    case ConsoleKey.Escape://se ESC
                        Environment.Exit(0);//sai do programa
                        break;

                    case ConsoleKey.Enter:
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
                        }
                        break;
                    case ConsoleKey.I:
                        subMenuCeleiro(cavalo);
                        break;
                    case ConsoleKey.L:
                        subMenuLoja(cavalo);

                        break;
                    //COMANDOS PADRÃO ****
                    default:
                        Console.Clear();
                        Graficos.SubMenuLoja(0);
                        break;
                }


            }

        }

    

        public static void menuSleep(Cavalo cavalo)
        {
            menuAtual =  menu.menuSleep;
            Console.Clear();
            Graficos.MenuSleep();
            while (menuAtual == menu.menuSleep)
            {
                switch(Console.ReadKey().Key) {

                    case ConsoleKey.Enter:
                        menuAtual = menu.menuJogos;
                        subMenuAtual = menu.subMenuCeleiro;
                        CicloDiario.lojaAberta= true;
                        CicloDiario.pistaAberta = true;
                        Console.Clear();
                        Console.WriteLine("Dormindo...");
                        
                        Thread.Sleep(2000);

                        menuJogar(cavalo);
                       break;
                    default:
                        Console.Clear();
                        Graficos.MenuSleep();
                        break;
                }

            }
            

        }
    }


        
}
