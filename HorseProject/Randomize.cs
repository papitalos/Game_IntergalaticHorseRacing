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

       //ATRIBUTOS DE CADA RANK
        public static int randomizeMadeira = rdm.Next(1, 4);
        public static int randomizePrata = rdm.Next(4, 7);
        public static int randomizeOuro = rdm.Next(7, 10);
        public static int randomizeDiamante = rdm.Next(10, 13);
        public static int randomizeIntergalatic = rdm.Next(13, 16);

        //NOME E RAÇA
        public static int randomizeName = rdm.Next(0,5);
        public static int randomizeRace = rdm.Next(1,5);

        //IDADE POR CADA RANK
        public static int randomizeAgeMadeira = rdm.Next(4, 6);
        public static int randomizeAgePrata = rdm.Next(6, 8);
        public static int randomizeAgeOuro = rdm.Next(6, 10);
        public static int randomizeAgeDiamante = rdm.Next(8, 10);
        public static int randomizeAgeIntergalatic = 0;

        //PESO POR RAÇA
        public static int randomizeKgShire = rdm.Next(600, 1000);
        public static int randomizeKgParcheron = rdm.Next(450, 851);
        public static int randomizeKgArabe = rdm.Next(300, 501);
        public static int randomizeKgPuroSangueIngles = rdm.Next(300, 501);

        //VALOR DE CADA RANK
        public static int randomizeVMadeira = rdm.Next(800, 1000);
        public static int randomizeVPrata = rdm.Next(1001, 2500);
        public static int randomizeVOuro = rdm.Next(2501, 5000);
        public static int randomizeVDiamante = rdm.Next(5001, 8000);
        public static int randomizeVIntergalatic = rdm.Next(8001, 15000);


        
    }   
}
