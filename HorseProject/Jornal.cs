using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    public static class Jornal
    {
        public static string Noticiar()
        {
            string retorno = "";
            if (CicloDiario.diaAtual == "Segunda-feira         ")
            {
                retorno = "Dizem que essas noticias parecem com as do CookieCliker, mas as nossas sao melhores!";
            }
            if (CicloDiario.diaAtual == "Terça-feira           ")
            {
                retorno = "Hoje chegou o famoso treinador Jonathan! ligue para HorseNews para contrata-lo!     ";
            }
            if (CicloDiario.diaAtual == "Quarta-feira          ")
            {
                retorno = "A veterinaria Amanda esta na cidade! ligue para HorseNews para marcar uma consulta! ";
            }
            if (CicloDiario.diaAtual == "Quinta-feira          ")
            {
                retorno = "O cuidador Jorge chegou! ligue para HorseNews para dar aquela lavada no seu cavalo! ";
            }
            if (CicloDiario.diaAtual == "Sexta-feira           ")
            {
                retorno = "A boatos de que uma corrida rankeada se aproxima! Fique atento nos proximos dias.   ";
            }
            if (CicloDiario.diaAtual == "Sabado                ")
            {
                retorno = "Nada demais por hoje! Pelo visto a pista esta tendo algumas corridas.               ";
            }
            if (CicloDiario.diaAtual == "Domingo               ")
            {
                retorno = "O GRANDE DIA CHEGOU! Hoje as corridas Rankeadas estão disponiveis!                  ";
            }
            
         
            


            return retorno;
        }
        
    }
}
