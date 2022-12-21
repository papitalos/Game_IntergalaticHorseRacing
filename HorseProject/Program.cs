using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Cavalo cavalo = new Cavalo("Pangaré Desnutrido ", Cavalo.raca.shire, 100, 2, 15, 4);
            BootJogo.RodarJogo(cavalo);
            CicloDiario.ThreadTimerDiario();



            
;
        }
    }
}
