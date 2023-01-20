using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    public static class GeradorDeCavalo
    {
        public static string[] nomeNV1 = new string[5] { "Ringo               ","Fúria               ", "Relampago           ", "Nobre               ", "Amendoin            " };
        public static string[] nomeNV2 = new string[5] { "Aquiles             ","Sherlock            ", "Mufasa              ", "Klaus               ", "Grinch              " };
        public static string[] nomeNV3 = new string[5] { "Vegeta              ","Eros                ", "Icarus              ", "Marco Polo          ", "Brutus              " };
        public static string[] nomeNV4 = new string[5] { "Pegasus             ","Poseidon            ", "Loki                ", "Kratos              ", "Atreus              " };
        public static string[] nomeNV5 = new string[5] { "Uranus              ","Andromeda           ", "Mr.Meeseks          ", "Pissmaster          ", "Mr.Poppybutthole    " };

        //PrimeiroCavalo
        static public void GerarPrimeiro(int SlotEscolhido)
        {
            Cavalo escolhido = null;
            switch (SlotEscolhido)
            {
                case 1:
                    Cavalo PD = new Cavalo(1,5,"Pangaré Desnutrido",Cavalo.raca.arabe,150,3,2, 150);
                    escolhido= PD;
                    break;
                case 2:
                    Cavalo MP = new Cavalo(1, 5, "Montaria Peluda", Cavalo.raca.shire, 600, 1, 2, 150);
                    escolhido= MP;
                    break;
                case 3:
                    Cavalo CB = new Cavalo(1, 5, "Corsel Burro", Cavalo.raca.parcheron, 450, 3, 1, 150);
                    escolhido= CB;
                    break;
            }

            Celeiro.AddCavalo(escolhido);

        }
        static public void GerarAleatorioLoja()
        {
            if (Player.RankAtual == "Madeira     ")
            {
                Cavalo id1 = new Cavalo(1, Randomize.randomizeAgeMadeira, nomeNV1[Randomize.randomizeName], Cavalo.raca.shire, Randomize.randomizeKgShire, Randomize.randomizeMadeira, Randomize.randomizeMadeira,Randomize.randomizeVMadeira);
                Cavalo id2 = new Cavalo(2, Randomize.randomizeAgeMadeira, nomeNV1[Randomize.randomizeName], Cavalo.raca.parcheron, Randomize.randomizeKgParcheron, Randomize.randomizeMadeira, Randomize.randomizeMadeira, Randomize.randomizeVMadeira);
                Cavalo id3 = new Cavalo(3, Randomize.randomizeAgeMadeira, nomeNV1[Randomize.randomizeName], Cavalo.raca.arabe, Randomize.randomizeKgArabe, Randomize.randomizeMadeira, Randomize.randomizeMadeira, Randomize.randomizeVMadeira);

                Loja.cavalosLoja.Add(id1);
                Loja.cavalosLoja.Add(id2);
                Loja.cavalosLoja.Add(id3);
            }
            
        }


    }
}
