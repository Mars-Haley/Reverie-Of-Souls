using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public class Cura : Efeito
    {
        public Cura(double modificador) : base (modificador)
        {
            Modificador = modificador;
        }
        public override void Aplicar(Personagem alvo)
        {
            alvo.Curar(Modificador);
        }
        



        
    }
}
