using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    static public class Loja
    {
        static public int Gastos, carteiraConverted;
        static public List<Cavalo> cavalosLoja =  new List<Cavalo>();

       
        static public string MostrarCavalo(int id)
        {
            string nome = "";
            foreach (Cavalo cavaloatual in cavalosLoja)
            {
                if(id == cavaloatual.id)
                {
                    nome = cavaloatual.nome; break;
                }
            }

            return nome;
        }

        static public void ComprarRemedios()
        {
            carteiraConverted = Int32.Parse(Player.Carteira);
            
            Gastos = 80;
            if(carteiraConverted >= Gastos)//se consegue comprar
            {
                BootJogo.adquirido = true;
                Inventario.nRemedios++;

              Player.Carteira = (carteiraConverted - Gastos).ToString();


            }
            else if(carteiraConverted < Gastos)//Caso nao tenha o dinheiro
            {   
                BootJogo.adquirido = false;
               
                
            }
            
            
        }
        static public void ComprarAlimentação()
        {
            carteiraConverted = Int32.Parse(Player.Carteira);
            Gastos = 80;
            if (carteiraConverted >= Gastos)//se consegue comprar
            {
                BootJogo.adquirido = true;
                Inventario.nAlimentos++;

                Player.Carteira = (carteiraConverted - Gastos).ToString();
               
            }
            else if (carteiraConverted < Gastos)//Caso nao tenha o dinheiro
            {
                BootJogo.adquirido = false;


            }


        }
        static public void ComprarSela()
        {
            carteiraConverted = Int32.Parse(Player.Carteira);
            Gastos = 500;
            if (carteiraConverted >= Gastos)//se consegue comprar
            {
                BootJogo.adquirido = true;
                Inventario.nSelas++;

                Player.Carteira = (carteiraConverted - Gastos).ToString();

            }
            else if (carteiraConverted < Gastos)//Caso nao tenha o dinheiro
            {
                BootJogo.adquirido = false;
            }
        }


        static public void ComprarCavalo(Cavalo cavalo, int idCavalo)
        {
            //Carteira Converted
            int CarteiraConverted = Int32.Parse(Player.Carteira);
            //Valor do Cavalo
            double ValorC;
            //Resitência do Cavalo
            double y = cavalo.r;
            //Velocidade Máxima do Cavalo
            double v = cavalo.VMax;
            //Peso do Cavalo
            double p = cavalo.Kg;
            //Valor dos Stats
            double ValorS;
            //Valor Final
            double ValorF;
            if (y <= 3)
            {
                ValorC = cavalo.valor;
                ValorS = (y * 100) + (v * 10) + p;
                ValorF = ValorC + ValorS;

                if (CarteiraConverted >= ValorF)
                {
                    BootJogo.adquirido = true;
                    Player.Carteira = (carteiraConverted - ValorF).ToString();
                    Celeiro.AddCavalo(cavalo);
                }
                else 
                {
                    BootJogo.adquirido = false;
                }
                    
            }
            if (y > 3 && y <= 6)
            {
                ValorC = cavalo.valor;
                ValorS = (y * 100) + (v / 10) + p;
                ValorF = ValorC + ValorS;
                if (CarteiraConverted >= ValorF)
                {
                    BootJogo.adquirido = true;
                    Player.Carteira = (carteiraConverted - ValorF).ToString();
                    Celeiro.AddCavalo(cavalo);
                }
                else
                {
                    BootJogo.adquirido = false;
                }

            }
            if (y > 6 && y <= 9)
            {
                ValorC = cavalo.valor;
                ValorS = (y * 100) + (v / 10) + p;
                ValorF = ValorC + ValorS;
                if (CarteiraConverted >= ValorF)
                {
                    BootJogo.adquirido = true;
                    Player.Carteira = (carteiraConverted - ValorF).ToString();
                    Celeiro.AddCavalo(cavalo);
                }
                else
                {
                    BootJogo.adquirido = false;
                }

            }
            if (y > 9 && y <= 12)
            {
                ValorC = cavalo.valor;
                ValorS = (y * 100) + (v / 10) + p;
                ValorF = ValorC + ValorS;
                if (CarteiraConverted >= ValorF)
                {
                    BootJogo.adquirido = true;
                    Player.Carteira = (carteiraConverted - ValorF).ToString();
                    Celeiro.AddCavalo(cavalo);
                }
                else
                {
                    BootJogo.adquirido = false;
                }

            }
            if (y > 12)
            {
                ValorC = cavalo.valor;
                ValorS = (y * 100) + (v / 10) + p;
                ValorF = ValorC + ValorS;
                if (CarteiraConverted >= ValorF)
                {
                    BootJogo.adquirido = true;
                    Player.Carteira = (carteiraConverted - ValorF).ToString();
                    Celeiro.AddCavalo(cavalo);
                }
                else
                {
                    BootJogo.adquirido = false;
                }

            }
        }
    }
}
