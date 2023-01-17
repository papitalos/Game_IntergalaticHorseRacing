using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    public static class Player
    {
        static private string[] ranks = new string[5] { "Madeira     ", "Prata       ", "Ouro        ", "Diamante    ", "Intergalatic" };
        static private string rankAtual = ranks[0];     
        static private int nRankeadas = 0;
        static private int nCorridasGanhas = 0, nCorridasPerdidas = 0;
        public static string Carteira = "10000";


 
        static public int NCorridasGanhas { get => nCorridasGanhas; set => nCorridasGanhas = value; }
        static public int NCorridasPerdidas { get => nCorridasPerdidas; set => nCorridasPerdidas = value; }
        static public int NRankeadas { get => nRankeadas; set => nRankeadas = value; }
        static public string RankAtual { get => rankAtual; set => rankAtual = value; }

        static private void SelecaoDeRank()
        {
            switch (nRankeadas)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    RankAtual = ranks[0];
                    break;
                case 4:
                case 5:
                case 6:
                    RankAtual = ranks[1];
                    break;
                case 7:
                case 8:
                case 9:
                    RankAtual = ranks[3];
                    break;
                case 10:
                case 11:
                case 12:
                    RankAtual = ranks[4];
                    break;
                case 13:
                case 14:
                case 15:
                    RankAtual = ranks[5];
                    break;
            }
        }
    }
}
