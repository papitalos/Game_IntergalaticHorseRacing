using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    static class GeradorDeCavalo
    {
        static string[] nomeNV1 = new string[5] { "Ringo               ","Fúria               ", "Relampago           ", "Nobre               ", "Amendoin            " };
        static string[] nomeNV2 = new string[5] { "Aquiles             ","Sherlock            ", "Mufasa              ", "Klaus               ", "Grinch              " };
        static string[] nomeNV3 = new string[5] { "Vegeta              ","Eros                ", "Icarus              ", "Marco Polo          ", "Brutus              " };
        static string[] nomeNV4 = new string[5] { "Pegasus             ","Poseidon            ", "Loki                ", "Kratos              ", "Atreus              " };
        static string[] nomeNV5 = new string[5] { "Uranus              ","Andromeda           ", "Mr.Meeseks          ", "Pissmaster          ", "Mr.Poppybutthole    " };
        
        static Cavalo GerarCavalo() {
            
            return new Cavalo();
        }


    }
}
