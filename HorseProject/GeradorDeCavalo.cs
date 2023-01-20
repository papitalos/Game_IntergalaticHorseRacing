using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                Cavalo id1 = new Cavalo(1, Randomize.RandomizeAge(3), nomeNV1[Randomize.RandomizeName(3)], Cavalo.raca.arabe, Randomize.randomizeKgArabe, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));
                Cavalo id2 = new Cavalo(2, Randomize.RandomizeAge(3), nomeNV1[Randomize.RandomizeName(3)], Cavalo.raca.arabe, Randomize.randomizeKgArabe, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));
                Cavalo id3 = new Cavalo(3, Randomize.RandomizeAge(3), nomeNV1[Randomize.RandomizeName(3)], Cavalo.raca.arabe, Randomize.randomizeKgArabe, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));

                Loja.cavalosLoja.Add(id1);
                Loja.cavalosLoja.Add(id2);
                Loja.cavalosLoja.Add(id3);
            }
            else if (Player.RankAtual == "Prata       ")
            {
                Cavalo id1 = new Cavalo(1, Randomize.RandomizeAge(3), nomeNV2[Randomize.RandomizeName(3)], Cavalo.raca.shire, Randomize.randomizeKgShire, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));
                Cavalo id2 = new Cavalo(2, Randomize.RandomizeAge(3), nomeNV2[Randomize.RandomizeName(3)], Cavalo.raca.parcheron, Randomize.randomizeKgParcheron, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));
                Cavalo id3 = new Cavalo(3, Randomize.RandomizeAge(3), nomeNV2[Randomize.RandomizeName(3)], Cavalo.raca.arabe, Randomize.randomizeKgArabe, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));

                Loja.cavalosLoja.Add(id1);
                Loja.cavalosLoja.Add(id2);
                Loja.cavalosLoja.Add(id3);

            }
            else if (Player.RankAtual == "Ouro        ")
            {
                Cavalo id1 = new Cavalo(1, Randomize.RandomizeAge(3), nomeNV3[Randomize.RandomizeName(3)], Cavalo.raca.shire, Randomize.randomizeKgShire, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));
                Cavalo id2 = new Cavalo(2, Randomize.RandomizeAge(3), nomeNV3[Randomize.RandomizeName(3)], Cavalo.raca.parcheron, Randomize.randomizeKgParcheron, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));
                Cavalo id3 = new Cavalo(3, Randomize.RandomizeAge(3), nomeNV3[Randomize.RandomizeName(3)], Cavalo.raca.parcheron, Randomize.randomizeKgParcheron, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));

                Loja.cavalosLoja.Add(id1);
                Loja.cavalosLoja.Add(id2);
                Loja.cavalosLoja.Add(id3);

            }
            else if (Player.RankAtual == "Diamante    ")
            {
                Cavalo id1 = new Cavalo(1, Randomize.RandomizeAge(3), nomeNV4[Randomize.RandomizeName(3)], Cavalo.raca.shire, Randomize.randomizeKgShire, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));
                Cavalo id2 = new Cavalo(2, Randomize.RandomizeAge(3), nomeNV4[Randomize.RandomizeName(3)], Cavalo.raca.parcheron, Randomize.randomizeKgParcheron, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));
                Cavalo id3 = new Cavalo(3, Randomize.RandomizeAge(3), nomeNV4[Randomize.RandomizeName(3)], Cavalo.raca.purosangueingles, Randomize.randomizeKgPuroSangueIngles, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));

                Loja.cavalosLoja.Add(id1);
                Loja.cavalosLoja.Add(id2);
                Loja.cavalosLoja.Add(id3);

            }
            else if (Player.RankAtual == "Intergalatic")
            {
                Cavalo id1 = new Cavalo(1, Randomize.RandomizeAge(3), nomeNV5[Randomize.RandomizeName(3)], Cavalo.raca.purosangueingles, Randomize.randomizeKgPuroSangueIngles, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));
                Cavalo id2 = new Cavalo(2, Randomize.RandomizeAge(3), nomeNV5[Randomize.RandomizeName(3)], Cavalo.raca.purosangueingles, Randomize.randomizeKgPuroSangueIngles, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));
                Cavalo id3 = new Cavalo(3, Randomize.RandomizeAge(3), nomeNV5[Randomize.RandomizeName(3)], Cavalo.raca.purosangueingles, Randomize.randomizeKgPuroSangueIngles, Randomize.RandomizeAtributos(15), Randomize.RandomizeAtributos(15), Randomize.RandomizeValue(3));

                Loja.cavalosLoja.Add(id1);
                Loja.cavalosLoja.Add(id2);
                Loja.cavalosLoja.Add(id3);

            }


        }

        
    }
}
