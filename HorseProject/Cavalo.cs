using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HorseProject
{
    public class Cavalo
    {
        public int id, idade, valor;
        public string nome;
        public bool podeParticipar = true, foiAlimentadoHoje = false;
        public estadoDaDoenca estadoAtual;
        public raca racaAtual;
        public double Kg,tA,tR,tD,tTotal,bonus,KgInicial;
        public double r = 0, VMax = 0, a = 0;
        public int contadorDoenca = 0;
        public static string[] estadodoenca = new string[5] { "Saudável ", "Ligeiramente Doente    ", "Pouco Doente    ", "Muito Doente    ", "Extremamente Doente" };

        public Cavalo(int id, int idade, string nome, raca racaAtual, double kg,double vMax, double a, int valor)
        {
            this.valor= valor;
            this.id = id;
            this.idade = idade;
            this.nome = nome;
            this.racaAtual = racaAtual;
            Kg = kg;
            VMax = vMax;
            this.a = a;
        }

        public enum estadoDaDoenca
        {
            poucoDoente = 1,
            medioDoente,
            muitoDoente,
            extremamenteDoente
        }
        public enum raca
        {
            shire = 1,
            parcheron,
            arabe,
            purosangueingles
        }


        //método que faz com que o cavalo vá perdendo peso a cada dia que passa
        public void Alímentacao()
        {
            foiAlimentadoHoje = true;
            if(foiAlimentadoHoje == true)
            {
                CicloDiario.diasSemComer = 0;
            }
            if(foiAlimentadoHoje == false && CicloDiario.lojaAberta == false)
            {
                CicloDiario.diasSemComer++;
                Kg = Kg-10;
            }
        }
        //define o bonus que o cavalo recebe
        public double Bonus()
        {
            switch(racaAtual){
                case raca.shire:
                    if (Pista.condicoesPistaAtual == "Neve    ")
                    {
                        bonus = 10;
                        r = r + (r * (bonus/100));//adiciona 10% de bonus

                    }
                    else if(Pista.condicoesPistaAtual == "Chuva   " || Pista.condicoesPistaAtual == "Nevoeiro")
                    {
                        bonus = 5;
                        r = r - (r * (bonus / 100));//tira 5% de bonus
                    }
                    break;
                case raca.parcheron:
                    if (Pista.condicoesPistaAtual == "Chuva   ")
                    {
                        bonus = 10;
                        r = r + (r * (bonus / 100));//adiciona 10% de bonus

                    }
                    else if (Pista.condicoesPistaAtual == "Neve    ")
                    {
                        bonus = 5;
                        r = r - (r * (bonus / 100));//tira 5% de bonus
                    }
                    else if (Pista.condicoesPistaAtual == "Nevoeiro")
                    {
                        bonus = 2;
                        r = r - (r * (bonus / 100));//tira 2% de bonus
                    }
                    break;
                case raca.arabe:
                    if (Pista.condicoesPistaAtual == "Nevoeiro")
                    {
                        bonus = 10;
                        r = r + (r * (bonus / 100));//adiciona 10% de bonus

                    }
                    else if (Pista.condicoesPistaAtual == "Chuva   " || Pista.condicoesPistaAtual == "Neve    ")
                    {
                        bonus = 5;
                        r = r - (r * (bonus / 100));//tira 5% de bonus
                    }
                    break;
                case raca.purosangueingles:
                    if (Pista.condicoesPistaAtual == "Limpo   ")
                    {
                        bonus = 10;
                        r = r + (r * (bonus / 100));//adiciona 10% de bonus
                    }
                    else if (Pista.condicoesPistaAtual == "Chuva   " || Pista.condicoesPistaAtual == "Neve    " || Pista.condicoesPistaAtual == "Nevoeiro")
                    {
                        bonus = 5;
                        r = r - (r * (bonus / 100));//tira 5% de bonus
                    }
                    break;
            
            }

            return bonus;
        }

   
        //faz a barra de status
        public string Barra(string parametro)
        {
            
            string Barra = "";
            switch (parametro)
            {
                case "VMax":
                    for (int i = 0; i != 15; i++)
                    {
                        if (i < VMax)
                        {
                            Barra = Barra + "■";
                        }
                        if (i >= VMax)
                        {
                            Barra = Barra + "¤";
                        }
                    }
                    break;
                case "a":
                    for (int i = 0; i != 15; i++)
                    {
                        if (i < a)
                        {
                            Barra = Barra + "■";
                        }
                        if (i >= a)
                        {
                            Barra = Barra + "¤";
                        }
                    }
                    break;
                case "r":
                    for (int i = 0; i != 15; i++)
                    {
                        if (i < r)
                        {
                            Barra = Barra + "■";
                        }
                        if (i >= r)
                        {
                            Barra = Barra + "¤";
                        }
                    }
                    break;
            }
            
            
            return Barra;
        }
 
        //galopa
        public void Galopar(Cavalo cavalo)
        {
            cavalo.tA = cavalo.VMax / cavalo.a; //tempo pra acelerar ate velocidade max
            cavalo.tR = 5 * cavalo.r; //define o tempo de resistencia derrubando 1 de resistencia a cada 5 segundos
            cavalo.tD = cavalo.tA - (cavalo.tA * 0.03); //define o tempo de desaceleração sendo esse 3% mais rapido que a aceleração

            cavalo.tTotal = cavalo.tA + cavalo.tR + cavalo.tD;

        }







        public override string ToString()
        {
            void PrintColoredText(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }
            Console.WriteLine(            "┌─────────────────────────┬──────────────────────────────────────────────────────────────────────────────────────┐\r\n" +
                                          "│ » " + CicloDiario.horaDoDiaAtual + " » " + Pista.condicoesPistaAtual + "  │                                         Status                                       │\r\n" +
                                          "│ » " + CicloDiario.diaAtual +"│                      » o jogo esta pausado enquanto nesse menu«                      │\r\n" +
                                          "│─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─ ─│──────────────────────────────────────────────────────────────────────────────────────│\r\n" +
                                          "│  Carteira »  " + Player.Carteira + " ß    │ [h] » help?                                                                   Id - "+id+" │\r\n" +
                                          "│─────────────────────────│                                                                                      │\r\n" +
                                          "│                         │ Raça: "+racaAtual+"                                       Bonûs » "+Pista.condicoesPistaAtual+" "+bonus+" %    │\r\n" +
                                          "│                         │ Idade: "+idade+"                                               Resistencia » "+Barra("r")+ " │\r\n" +
                                          "│                         │ Peso: "+Kg+"kg                                            Aceleração  » "+ Barra("a") + " │\r\n" +
                                          "│                         │ Nome: "+nome+"                               Velocidade  » "+ Barra("VMax") + " │\r\n" +
                                          "│                         │ Estado: "+estadoAtual+"                                                                            │\r\n" +
                                          "│                         │                                                                                      │\r\n" +
                                          "│                         │                                                                                      │\r\n" +
                                          "│─────────────────────────│──────────────────────────────────────────────────────────────────────────────────────|\r\n" +
                                          "│        Noticia:         │ " + Jornal.Noticiar()+" │\r\n" +
                                          "└─────────────────────────┴──────────────────────────────────────────────────────────────────────────────────────┘") ;

            return base.ToString();
        }






    }
}
