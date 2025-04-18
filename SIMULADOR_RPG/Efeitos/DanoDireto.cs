using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_RPG
{
    public class DanoDireto : Efeito
    {
        public double Modificador{get;}
        public DanoDireto(double modificador)
        {
            Modificador = modificador;
        }
        public override void Aplicar(Personagem alvo)
        {
            alvo.ReceberDano(Modificador);
        }
    }
}