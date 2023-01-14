using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //define os dados do cavalo inicial de acordo com a escolha do player
            
            Cavalo cavalo = new Cavalo("Pangaré Desnutrido ", Cavalo.raca.shire, 100, 2, 15, 4);
            //define os dados iniciais do jogador
        
            CicloDiario.ThreadTimerDiario();
            BootJogo.RodarJogo(cavalo);


            

            

        }
    }
}
