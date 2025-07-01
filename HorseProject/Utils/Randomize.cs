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
        public static int RandomizeAtributos(int lim)
        {
            int randomN = 0;

            for (int i = 0; i <= lim; i++)
            {
                int randomizeMadeira = rdm.Next(1, 4);
                int randomizePrata = rdm.Next(4, 7);
                int randomizeOuro = rdm.Next(7, 10);
                int randomizeDiamante = rdm.Next(10, 13);
                int randomizeIntergalatic = rdm.Next(13, 16);
                if (Player.RankAtual == "Madeira     ")
                {
                    randomN = randomizeMadeira;
                }
                if (Player.RankAtual == "Prata       ")
                {
                    randomN = randomizePrata;
                }
                if (Player.RankAtual == "Ouro        ")
                {
                    randomN = randomizeOuro;
                }
                if (Player.RankAtual == "Diamante    ")
                {
                    randomN = randomizeDiamante;
                }
                if (Player.RankAtual == "Intergalatic")
                {
                    randomN = randomizeIntergalatic;
                }

                return randomN;
            }
            return 0;
        }
        //NOME
        public static int RandomizeName(int lim)
        {
  

            for (int i = 0; i <= lim; i++)
            {
                int randomizeName = rdm.Next(0, 5);

                return randomizeName;

            }
            return 0;
        }

        //IDADE POR CADA RANK
        public static int RandomizeAge(int lim)
        {
            int randomN = 0;
            
            for (int i = 0; i <= lim; i++)
            {
                    int randomizeAgeMadeira = rdm.Next(4, 6);
                    int randomizeAgePrata = rdm.Next(6, 8);
                    int randomizeAgeOuro = rdm.Next(6, 10);
                    int randomizeAgeDiamante = rdm.Next(8, 10);
                    int randomizeAgeIntergalatic = 0;
                    
                if (Player.RankAtual == "Madeira     ")
                {
                    randomN = randomizeAgeMadeira;
                }
                if (Player.RankAtual == "Prata       ")
                {
                    randomN = randomizeAgePrata;
                }
                if (Player.RankAtual == "Ouro        ")
                {
                    randomN = randomizeAgeOuro;
                }
                if (Player.RankAtual == "Diamante    ")
                {
                    randomN = randomizeAgeDiamante;
                }
                if (Player.RankAtual == "Intergalatic")
                {
                    randomN = randomizeAgeIntergalatic;
                }

                return randomN;

            }
            return 0;
        }   
        

        //PESO POR RAÇA
        public static int randomizeKgShire = rdm.Next(600, 1000);
        public static int randomizeKgParcheron = rdm.Next(450, 851);
        public static int randomizeKgArabe = rdm.Next(300, 501);
        public static int randomizeKgPuroSangueIngles = rdm.Next(300, 501);

        //VALOR DE CADA RANK
        public static int RandomizeValue(int lim)
        {
            int randomN = 0;

            for (int i = 0; i <= lim; i++)
            {
                int randomizeVMadeira = rdm.Next(800, 1000);
                int randomizeVPrata = rdm.Next(1001, 2500);
                int randomizeVOuro = rdm.Next(2501, 5000);
                int randomizeVDiamante = rdm.Next(5001, 8000);
                int randomizeVIntergalatic = rdm.Next(8001, 15000);

                if (Player.RankAtual == "Madeira     ")
                {
                    randomN = randomizeVMadeira;
                }
                if (Player.RankAtual == "Prata       ")
                {
                    randomN = randomizeVPrata;
                }
                if (Player.RankAtual == "Ouro        ")
                {
                    randomN = randomizeVOuro;
                }
                if (Player.RankAtual == "Diamante    ")
                {
                    randomN = randomizeVDiamante;
                }
                if (Player.RankAtual == "Intergalatic")
                {
                    randomN = randomizeVIntergalatic;
                }

                return randomN;

            }
            return 0;
        }
        


        
    }   
}
