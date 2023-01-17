using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseProject
{
    class Celeiro
    {
        private List<Cavalo> cavalosCeleiro;

        public Celeiro()
        {
            cavalosCeleiro = new List<Cavalo>();
        }

        public void AddCavalo(Cavalo cavalo)
        {
            cavalosCeleiro.Add(cavalo);
        } 
        public void RemoveCavalo(Cavalo cavalo)
        {
            cavalosCeleiro.Remove(cavalo);
        }
        public int CapacidadeCeleiro()
        {
            int quantia;
            quantia = cavalosCeleiro.Count;
            return quantia;
        }
       
        public Cavalo MostrarCavalo(int valor)
        {

            foreach  (Cavalo cavalo in cavalosCeleiro)
            {
                if (valor == cavalo.id)
                {
                    return cavalo;
                }
            }
            return null;
        }
        
    }
}
