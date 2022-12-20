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
    
        public static bool estaRodando,primeiraVez = true,estaNoMenuInicial = true, estaNoMenuLoading=false;
        public static int qntdSaves = 1;
        public static void RodarJogo(Cavalo cavalo)
        {   
            
            estaRodando = true;//o jogo passa a estar rodando
            Console.Clear();
            Graficos.MenuPrincipal(); //inicia o menu principal

            
            while (estaRodando) //enquanto o jogo estiver rodando
            {
                switch (Console.ReadKey().Key) //verifica a KEY clicada
                {
                    case ConsoleKey.Enter://se ENTER entra:
                        if (primeiraVez)
                        {
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
                        Graficos.MenuJogar_Corridas(0, 1, cavalo);//imprime menu corridas inicial (DEFAULT)
                            primeiraVez = false;//primeira vez passa a ser falso
                            estaNoMenuInicial = false;//não esta no menu inicial

                        }//se primeira vez na opção ENTER entra no menu de escolha de cavalo inicial
                        else
                        {
                            Console.Clear();
                            Graficos.MenuJogar_Corridas(0, 1, cavalo);//imprime o menu inicial de corridas na tela (DEFAULT)
                            estaNoMenuInicial = false;//nao esta mais no menu inicial

                            while(estaNoMenuInicial = false)
                            {
                                switch(Console.ReadKey().Key)
                                {
                                    case ConsoleKey.Enter://se ENTER
                                        break;
                                    case ConsoleKey.I://se I
                                        break;
                                    case ConsoleKey.L://se L
                                        break;

                                }//verifique a KEY clicada
                            }//enquanto nao estiver no menu incial
                        }//senao entra no menu de corridas
                        break;
                    case ConsoleKey.Tab://se TAB:
                        if (estaNoMenuInicial)
                        {

                            estaNoMenuLoading = true; //passa a estar no menu de Loading
                           
                            while (estaNoMenuLoading)
                            { 
                                Console.Clear();
                                Graficos.MenuCarregar(qntdSaves);//CARREGA COM A QNTD SAVE ANTERIOR

                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.A://se A
                                        if(qntdSaves < 4)//so adiciona se tiver menos que 4 saves
                                        {
                                            
                                            qntdSaves++;//adiciona mais um save
                                            Console.Clear();
                                            Graficos.MenuCarregar(qntdSaves);//imprime
                                        }//se quantidade de saves for menor que 4
                                        break;
                                    case ConsoleKey.D://se D
                                        if(qntdSaves > 1)//so apaga se tiver mais q 1 save
                                        {
                                            //LIMPA O D imprimido na tela ***
                                            Console.Clear();
                                            Graficos.MenuCarregar(qntdSaves);
                                            //LIMPA O D imprimido na tela ***


                                            Console.WriteLine("Qual slot deseja apagar? [NUM + ENTER]");//pergunta qual slot deve apagar
                                            int slot = Console.Read();//cria uma variavel do slot a apagar (equivalente a linha a apagar no arquivo de saves)    
                                            
                                            qntdSaves--;//diminui a quantidade de saves
                                            switch (slot)
                                            {
                                                case 1://apaga a linha 1 do arquivo
                                                    Console.Clear();
                                                    Graficos.MenuCarregar(qntdSaves);
                                                    break;
                                                case 2://apaga a linha 2 do arquivo
                                                    Console.Clear();
                                                    Graficos.MenuCarregar(qntdSaves);
                                                    break;
                                                case 3://apaga a linha 3 do arquivo
                                                    Console.Clear();
                                                    Graficos.MenuCarregar(qntdSaves);
                                                    break;
                                                case 4://apaga a linha 4 do arquivo
                                                    Console.Clear();
                                                    Graficos.MenuCarregar(qntdSaves);
                                                    break;
                                                default:
                                                    Console.WriteLine("Não é um SLOT existente");
                                                    break;
                                            }//verifica de acordo com o SLOT escolhido
                                            
                                        }//se quantidade de saves maior que 1
                                        break;



                                    case ConsoleKey.Enter://permite entrar no menu jogar a partir do meno de loading
                                        if (primeiraVez)
                                        {
                                            int escolhaCI = 1;
                                            bool escolhaFinal = false;
                                            Console.Clear();
                                            Graficos.MenuEscolhaInicial(escolhaCI);

                                            while (escolhaFinal == false)
                                            {
                                                switch (Console.ReadKey().Key)
                                                {
                                                    case ConsoleKey.LeftArrow:
                                                        if (escolhaCI == 1)
                                                        {
                                                            escolhaCI = 3;
                                                        }
                                                        else if (escolhaCI == 2 || escolhaCI == 3)
                                                        {
                                                            escolhaCI--;
                                                        }
                                                        Console.Clear();
                                                        Graficos.MenuEscolhaInicial(escolhaCI);
                                                        break;
                                                    case ConsoleKey.RightArrow:

                                                        if (escolhaCI == 3)
                                                        {
                                                            escolhaCI = 1;
                                                        }
                                                        else if (escolhaCI == 1 || escolhaCI == 2)
                                                        {
                                                            escolhaCI++;
                                                        }

                                                        Console.Clear();
                                                        Graficos.MenuEscolhaInicial(escolhaCI);
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        escolhaFinal = true;
                                                        break;
                                                    default:
                                                        Console.Clear();
                                                        Graficos.MenuEscolhaInicial(escolhaCI);
                                                        break;

                                                }

                                            }
                                            Console.Clear();
                                            Graficos.MenuJogar_Corridas(0, 1, cavalo);
                                            primeiraVez = false;
                                            estaNoMenuInicial = false;
                                            estaNoMenuLoading = false;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Graficos.MenuJogar_Corridas(0, 1, cavalo);
                                            estaNoMenuInicial = false;
                                            estaNoMenuLoading = false;
                                        }
                                        break;
                                    case ConsoleKey.Escape://permite sair caso esteja no menu de loading
                                        Environment.Exit(0);
                                        break;
                                }//verifica a KEY clicada
                            } //enquanto estiver no Menu de Loading //**** BUG na HORA DE APAGAR ****




                        }//entra no menu de LOADING se estiver no Menu Inicial
                        else
                        {   
                            Console.Clear();
                            Graficos.MenuPrincipal();
                            estaNoMenuInicial=true;//passa a estar no menu inicial
                        }//senao volta para o menu inicial

                        break;
                    case ConsoleKey.Escape://se ESC sai do jogo
                        Environment.Exit(0);
                        break;
                }
                
                    
                    

             
            }
           
        
        }
    }
}
