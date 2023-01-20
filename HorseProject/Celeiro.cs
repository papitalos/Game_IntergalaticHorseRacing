using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    static public class Celeiro
    {
        static private List<Cavalo> cavalosCeleiro = new List<Cavalo>();
        // Adiciona cavalos ao celeiro
        static public void AddCavalo(Cavalo cavalo)
        {
            cavalosCeleiro.Add(cavalo);
        }
        // Remove cavalos do celeiro
        static public void RemoveCavalo(Cavalo cavalo)
        {
            cavalosCeleiro.Remove(cavalo);
        }
        static public void VenderCavalo(Cavalo cavalo)
        {
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
            int x = CapacidadeCeleiro();
            if (x == 1)
            {
                Console.WriteLine("Venda Cancelada, é necessário ter pelo menos 1 Cavalo no Celeiro");
            }
            else
            if (y <= 4)
            {
                ValorC = cavalo.valor;
                ValorS = (y * 100) + (v / 10) + p;
                ValorF = ValorC + ValorS;
                Player.Carteira = Player.Carteira + ValorF;
                RemoveCavalo(cavalo);
            }
            else
            if (y > 4 || y <= 7)
            {
                ValorC = cavalo.valor;
                ValorS = (y * 100) + (v / 10) + p;
                ValorF = ValorC + ValorS;
                Player.Carteira = Player.Carteira + ValorF;
                RemoveCavalo(cavalo);
            }
            else
            if (y > 7 || y <= 10)
            {
                ValorC = cavalo.valor;
                ValorS = (y * 100) + (v / 10) + p;
                ValorF = ValorC + ValorS;
                Player.Carteira = Player.Carteira + ValorF;
                RemoveCavalo(cavalo);
            }
            else
            if (y > 10 || y <= 13)
            {
                ValorC = cavalo.valor;
                ValorS = (y * 100) + (v / 10) + p;
                ValorF = ValorC + ValorS;
                Player.Carteira = Player.Carteira + ValorF;
                RemoveCavalo(cavalo);
            }
            else
            if (y > 13)
            {
                ValorC = cavalo.valor;
                ValorS = (y * 100) + (v / 10) + p;
                ValorF = ValorC + ValorS;
                Player.Carteira = Player.Carteira + ValorF;
                RemoveCavalo(cavalo);
            }
            else
                Console.WriteLine("Erro ao Vender Cavalo");
        }
        // Retrona a quantia de cavalos no celeiro
        static public int CapacidadeCeleiro()
        {
            int quantia;
            quantia = cavalosCeleiro.Count;
            return quantia;
        }
        // Mostra os cavalos
        static public Cavalo MostrarCavalo(int valor)
        {

            foreach (Cavalo cavalo in cavalosCeleiro)
            {
                if (valor == cavalo.id)
                {
                    return cavalo;
                }
            }
            return null;
        }

    }
}