using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    class Player
    {
        private string[] ranks = new string[5] { "Madeira", "Prata", "Ouro", "Diamante", "Intergalatic" };
        private string rankAtual;
        private int nRankeadas;
        private int nCorridasGanhas, nCorridasPerdidas;
        private int Carteira;

        public Player(string rankAtual, int nRankeadas, int nCorridasGanhas, int nCorridasPerdidas, int carteira)
        {
            this.rankAtual = rankAtual;
            this.nRankeadas = nRankeadas;
            this.nCorridasGanhas = nCorridasGanhas;
            this.nCorridasPerdidas = nCorridasPerdidas;
            Carteira = carteira;
        }

        public int NCorridasGanhas { get => nCorridasGanhas; set => nCorridasGanhas = value; }
        public int NCorridasPerdidas { get => nCorridasPerdidas; set => nCorridasPerdidas = value; }
        public int Carteira1 { get => Carteira; set => Carteira = value; }
        public int NRankeadas { get => nRankeadas; set => nRankeadas = value; }
        public string RankAtual { get => rankAtual; set => rankAtual = value; }

        private void SelecaoDeRank()
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
