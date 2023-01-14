using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    public static class Inventario
    {
        public static int nRemedios = 0, nAlimentos = 0, nSelas = 0;
        public static int limite = 1;
        public static string[] status = new string[2] {"[Adquirido ]", "[Em Falta  ]" } ;
        public static string statusRemedio,statusAlimentos,statusSelas;
                                                         
        public static void VerificarStatus()
        {
            if(nRemedios == limite)
            {
                statusRemedio = status[0];
            }
            else if(nRemedios < limite)
            {
                statusRemedio = status[1];
            }


            if (nAlimentos == limite)
            {
                statusAlimentos = status[0];
            }
            else if (nAlimentos < limite)
            {


                statusAlimentos = status[1];
            }
            if (nSelas == limite)
            {
                statusSelas = status[0];
            }
            else if (nSelas < limite)
            {
                statusSelas = status[1];
            }

        }


    }
}
