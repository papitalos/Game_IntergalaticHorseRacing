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
    public static class Menu
    {
    
        public static bool estaRodando,primeiraVez = true,estaNoMenuInicial = true;
        public static void RodarMenu(Cavalo cavalo)
        {
            Console.Clear();
            Graficos.MenuPrincipal();

            estaRodando = true;
            while (estaRodando)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
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
                        }
                        else
                        {
                            Console.Clear();
                            Graficos.MenuJogar_Corridas(0, 1, cavalo);
                            estaNoMenuInicial = false;
                        }
                    break;
                    case ConsoleKey.Tab:
                        if (estaNoMenuInicial)
                        {
                            Console.Clear();
                            Graficos.MenuCarregar(1);
                            
                        }
                        else
                        {   
                            Console.Clear();
                            Graficos.MenuPrincipal();
                            estaNoMenuInicial=true;
                        }
                        
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
                
                    
                    

             
            }
           
        
        }
    }
}
