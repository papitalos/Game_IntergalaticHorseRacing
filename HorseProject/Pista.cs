using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HorseProject
{
    class Pista
    {
        public bool estaAberto;
        public estadoHorario ciclo;
        public estadoPista estadoP;
        public int myDelay = 2000; //300.000ms = 5min

        //enum dos estados e dos horarios
        public enum estadoHorario
        {
            manha = 1,
            tarde,
            noite,
            madrugada
        }
        public enum estadoPista
        {
            neve = 1,
            chuva,
            nevoeiro,
            limpo
        }
        public void CicloDiario()
        {

            //mudar os periodos do dia
            for (estadoHorario ciclo = estadoHorario.manha; ciclo <= estadoHorario.madrugada; ciclo++)
            {

                //randomizar estado da pista
                Random rdm = new Random();
                int randomize = rdm.Next(1, 5);
                estadoPista estadoP = (estadoPista)randomize;




                //determinar se a pista esta aberta ou fechada dependendo do periodo do dia
                if (ciclo == estadoHorario.manha || ciclo == estadoHorario.tarde)
                {
                    estaAberto = true;
                }
                else
                {
                    estaAberto = false;
                }

                Thread.Sleep(myDelay);

                Console.WriteLine(ciclo);
                Console.WriteLine(estaAberto);
                Console.WriteLine(estadoP);

            }

        }




    }
}