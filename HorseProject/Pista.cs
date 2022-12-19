using HorseProject;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HorseProject
{
    public class Pista
    {
        public bool estaAberto;
        public estadoHorario ciclo;
        public estadoPista estadoP;
        public int myDelay = 2000;
      

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
        public void ThreadTimerDiario()
        {
            //Criar uma nova thread para rodar o relogio do dia de maneira independente
            Thread dia = new Thread(CicloDiario);
            dia.Start();
            
            

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
            }
            
        }


    }
}




