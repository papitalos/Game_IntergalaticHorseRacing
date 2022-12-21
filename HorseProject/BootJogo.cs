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

        public static bool estaRodando = false, primeiraVez = true;//jogo nao esta rodando
        public static menu menuAtual, subMenuAtual;
        
        public static int qntdSaves = 1;
        
        public enum menu
        {
            menuInicial = 1,
            menuLoading,
            subMenuCorridas,
            subMenuCeleiro,
            subMenuLoja,
            menuEscolhaInicial,
            menuJogos

        }
        public static void RodarJogo(Cavalo cavalo)
        {
            
            estaRodando = true;//o jogo passa a estar rodando
            Console.Clear();
            Graficos.MenuInicial(); //inicia o menu principal
            menuAtual = menu.menuInicial;//MENU ATUAL: menu inicial
            
            while (estaRodando) //enquanto o jogo estiver rodando
            {

                switch (Console.ReadKey().Key) //verifica a KEY clicada
                {
                    case ConsoleKey.Enter://se ENTER entra:
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
                            Console.Clear();
                            Graficos.MenuEscolhaInicial(slotEscolhido);
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

                            Console.Clear();
                            Graficos.MenuEscolhaInicial(slotEscolhido);
                            break;
                        case ConsoleKey.Enter://se ENTER
                            escolhaFinal = true;//usuario escolheu
                            break;
                        default:
                            Console.Clear();
                            Graficos.MenuEscolhaInicial(slotEscolhido);//se ERROR, volta pro slot escolhido anterior
                            break;

                    }//verifica a KEY cliquada

                }//enquanto usuario nao fez escolha final

                //depois do usuario ter feito a escolha final:
                Console.Clear();//limpa
                

            }//se primeira vez na opção ENTER entra no menu de escolha de cavalo inicial
                subMenuCeleiro(cavalo);
                menuAtual = menu.menuJogos;//MENU ATUAL: Menu Jogos 
                subMenuAtual = menu.subMenuCeleiro;//submenu: corridas (default)

                while (menuAtual == menu.menuJogos)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter://se ENTER
                            subMenuCorrida(1, cavalo);
                            break;
                        case ConsoleKey.I://se I
                            subMenuCeleiro(cavalo);
                            break; 
                        case ConsoleKey.L://se L
                            subMenuLoja(cavalo);
                            break;



                        //COMANDOS PADRÃO ****
                        case ConsoleKey.Tab://se TAB
                            Console.Clear();
                            Graficos.MenuInicial();//volta ao menu inicial
                            menuAtual = menu.menuInicial;//passa a estar no menu inicial
                            break;
                        case ConsoleKey.Escape://se ESC
                            Environment.Exit(0);//sai do programa
                            break;
                        //COMANDOS PADRÃO ****

                        default :
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
                }//enquanto nao estiver no menu incial, ou seja, estiver no menu de jogar

            
        }
        public static void menuLoading(Cavalo cavalo)
        {
            if (menuAtual == menu.menuInicial)
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
                            menuJogar(cavalo);
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }//verifica a KEY clicada
                } //enquanto estiver no Menu de Loading 

            }//entra no menu de LOADING se estiver no Menu Inicial
        }
        public static void subMenuCorrida(int posicaoVitoria, Cavalo cavalo)
        {
            Console.Clear();
            Graficos.SubMenuCorrida(0, posicaoVitoria, cavalo);
            subMenuAtual = menu.subMenuCorridas;
            int tipoCorrida = 0;
            while (subMenuAtual == menu.subMenuCorridas)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        tipoCorrida = 1;

                        break;
                    case ConsoleKey.D2:
                        tipoCorrida = 2;
                        break;
                    case ConsoleKey.D3:
                        tipoCorrida = 3;
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
                    //COMANDOS PADRÃO ****

                    case ConsoleKey.I:
                        subMenuCeleiro(cavalo);
                        break;
                    case ConsoleKey.L:
                        subMenuLoja(cavalo);
                        break;




                    default:
                        tipoCorrida = 0;
                        Console.Clear();
                        Graficos.SubMenuCorrida(tipoCorrida,posicaoVitoria, cavalo);
                        break;
                }
            }
        }
        public static void subMenuCeleiro(Cavalo cavalo)
        {
            Console.Clear();
            Graficos.SubMenuCeleiro();
            subMenuAtual = menu.subMenuCeleiro;
            while (subMenuAtual == menu.subMenuCeleiro)
            {
                switch (Console.ReadKey().Key)
                {




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
                    //COMANDOS PADRÃO ****

                    case ConsoleKey.Enter:
                        subMenuCorrida(0,cavalo);
                        break;
                    case ConsoleKey.L:
                        subMenuLoja(cavalo);
                        break;

                    default :
                        Console.Clear();
                        Graficos.SubMenuCeleiro();
                        break;

                }




            }
            
        }
        public static void subMenuLoja(Cavalo cavalo) {
            subMenuAtual = menu.subMenuLoja;
            while (subMenuAtual == menu.subMenuLoja)
            {
                switch (Console.ReadKey().Key)
                {


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
                    //COMANDOS PADRÃO ****

                    case ConsoleKey.Enter:
                        subMenuCorrida(0, cavalo);
                        break;
                    case ConsoleKey.I:
                        subMenuCeleiro(cavalo);
                        break;

                    default:
                        Console.Clear();
                        
                        break;
                }
            }
        }
    }
}
