using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public abstract class Efeito : IEfeito
    {
        public double Modificador{get;set;}
        public abstract void Aplicar(Personagem alvo);
        public Efeito(double modificador)
        {
            Modificador = modificador;
        }
    }
}
