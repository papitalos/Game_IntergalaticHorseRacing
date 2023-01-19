using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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

    }
}
