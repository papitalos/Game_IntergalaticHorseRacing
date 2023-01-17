using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    public class Randomize
    {
        public static Random rdm = new Random();

        public static int randomizeEstados = rdm.Next(1, 4);
        public static int randomizeMadeira = rdm.Next(1, 4);
        public static int randomizePrata = rdm.Next(4, 7);
        public static int randomizeOuro = rdm.Next(7, 10);
        public static int randomizeDiamante = rdm.Next(10, 13);
        public static int randomizeIntergalatic = rdm.Next(13, 16);
    }   
}
