using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    static public class Loja
    {
        static public int Gastos, carteiraConverted;
        static public void ComprarRemedios()
        {
            carteiraConverted = Int32.Parse(Player.Carteira);

            Gastos = 80;
            if(carteiraConverted >= Gastos)//se consegue comprar
            {
                BootJogo.adquirido = true;
                Inventario.nRemedios++;

                //adiciona espaços de acordo com numero de caracteres


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

                //adiciona espaços de acordo com numero de caracteres
                if (carteiraConverted - Gastos < 9999 && carteiraConverted - Gastos < 100000)
                {
                    Player.Carteira = (carteiraConverted - Gastos).ToString();
                }
                if (carteiraConverted - Gastos < 999 && carteiraConverted - Gastos < 10000)
                {
                    Player.Carteira = (carteiraConverted - Gastos).ToString();
                }
                if (carteiraConverted - Gastos < 99 && carteiraConverted - Gastos < 1000)
                {
                    Player.Carteira = (carteiraConverted - Gastos).ToString();
                }
                if (carteiraConverted - Gastos < 9 && carteiraConverted - Gastos < 100)
                {
                    Player.Carteira = (carteiraConverted - Gastos).ToString();
                }
                if (carteiraConverted - Gastos < 0 && carteiraConverted - Gastos < 10)
                {
                    Player.Carteira = (carteiraConverted - Gastos).ToString();
                }
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

                //adiciona espaços de acordo com numero de caracteres
                if (carteiraConverted - Gastos < 9999 && carteiraConverted - Gastos < 100000)
                {
                    Player.Carteira = (carteiraConverted - Gastos).ToString();
                }
                if (carteiraConverted - Gastos < 999 && carteiraConverted - Gastos < 10000)
                {
                    Player.Carteira = (carteiraConverted - Gastos).ToString();
                }
                if (carteiraConverted - Gastos < 99 && carteiraConverted - Gastos < 1000)
                {
                    Player.Carteira = (carteiraConverted - Gastos).ToString();
                }
                if (carteiraConverted - Gastos < 9 && carteiraConverted - Gastos < 100)
                {
                    Player.Carteira = (carteiraConverted - Gastos).ToString();
                }
                if (carteiraConverted - Gastos < 0 && carteiraConverted - Gastos < 10)
                {
                    Player.Carteira = (carteiraConverted - Gastos).ToString();
                }
            }
            else if (carteiraConverted < Gastos)//Caso nao tenha o dinheiro
            {
                BootJogo.adquirido = false;


            }
        }

    }
}
