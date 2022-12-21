using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    public class Cavalo
    {
        public string nome;
        public bool podeParticipar = true;
        public estadoDaDoenca doente;
        public raca racas;
        public int idade;
        public double resistencia, velocidadeMax, aceleracao, peso;

        public enum estadoDaDoenca
        {
            poucoDoente = 1,
            medioDoente,
            muitoDoente,
            extremamenteDoente
        }
        public enum raca
        {
            shire = 1,
            parcheron,
            arabe,
            purosangueingles
        }




        public double CalculoResistencia(raca racaAtual)
        {
            string condicoesDaPista = CicloDiario.condicoesPista;//pega o estado atual da pista
            double u = 0.1;
            switch (condicoesDaPista)
            {
                case "neve    ":
                    u = 0.3;
                    break;
                case "chuva   ":
                    u = 0.3;
                    break;
                case "nevoeiro":
                    u = 0.3;
                    break;
                case "limpo   ":
                    u = 0.3;
                    break;
            }

            double fC = (peso * aceleracao); //força do cavalo
            double fA = ((u/ 4)) * (fC);//calcular a força de atrito usando o coeficiente de atrito da condiçao da pista
            resistencia = fA - fC;
            //ver estado de doença
            if (doente == estadoDaDoenca.poucoDoente)
            {
                resistencia = resistencia - (0.05 * resistencia);//tirar 5% da resistencia
            }
            else if (doente == estadoDaDoenca.medioDoente)
            {
                resistencia = resistencia - (0.20 * resistencia);//tirar 20% da resistencia
            }
            else if (doente == estadoDaDoenca.muitoDoente)
            {
                resistencia = resistencia - (0.60 * resistencia);//tirar 60% da resistencia
            }
            else if (doente == estadoDaDoenca.extremamenteDoente)
            {
                podeParticipar = false;//nao pode mais participar
            }
            switch (racaAtual)
            {
                case raca.shire:
                    if (condicoesDaPista == "neve    ")
                    {
                        resistencia = resistencia + (0.10 * resistencia);//adicionar 10% a mais de resistencia na neve
                    }
                    break;
                case raca.parcheron:
                    if (condicoesDaPista == "chuva   ")
                    {
                        resistencia = resistencia + (0.10 * resistencia);//adicionar 10% a mais de resistencia na chuva
                    }
                    break;
                case raca.arabe:
                    if (condicoesDaPista == "nevoeiro")
                    {
                        resistencia = resistencia + (0.10 * resistencia);//adicionar 10% a mais de resistencia no nevoeiro
                    }
                    break;
                case raca.purosangueingles:
                    if (condicoesDaPista == "limpo   ")
                    {
                        resistencia = resistencia + (0.10 * resistencia);//adicionar 10% a mais de resistencia no sol (em condições perfeitas)
                    }
                    break;
            }

            return resistencia;
        }

        //Cavalo inicial - Pangaré desnutrido
        public Cavalo()
        {
            this.podeParticipar = true;
            this.racas = raca.shire;
            this.idade = 3;
            this.velocidadeMax = 20.1;//m/s
            this.aceleracao = 1;//m/s^2
            this.peso = 900;

        }


        //cavalo geral
        public Cavalo(string nome, raca racas, int velocidadeMax, int aceleracao, int peso, int idade)
        {
            this.nome = nome;
            this.podeParticipar = podeParticipar;
            this.racas = racas;
            this.idade = idade;
            this.velocidadeMax = velocidadeMax;
            this.aceleracao = aceleracao;
            this.peso = peso;

        }



 




    }
}
