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
            double Valor = 0;
  
         
            Valor = Randomize.RandomizeValue(3);

            if (CarteiraConverted >= Valor)
            {
                BootJogo.adquirido = true;
                Player.Carteira = (carteiraConverted - Valor).ToString();
                foreach (Cavalo cavaloparaceleiro in cavalosLoja)
                {
                    if(idCavalo == cavaloparaceleiro.id)
                    {
                        Celeiro.AddCavalo(cavaloparaceleiro);
                    }
                }
                
            }
            else 
            {
                BootJogo.adquirido = false;
            }
                    
          
        }
    }
}
